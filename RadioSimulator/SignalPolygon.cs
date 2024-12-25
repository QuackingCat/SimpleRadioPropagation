using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioSimulator
{
	internal struct Tile
	{
		internal int x;
		internal int y;
		internal int? value;

		internal Tile(int x, int y, int? value)
		{
			this.x = x;
			this.y = y;
			this.value = value;
		}
	};

	internal struct SignalParams
	{
		internal double freq;
		internal PointLatLng tloc;
		internal double telev;
		internal double tdBm;
		internal double tgain;
		internal double rgain;
		internal double sensitivity;
		internal double rgood;
		internal double rbad;
	}

	enum Mode
	{
		elev,
		signal
	}

	public class SignalPolygon : GMapPolygon
	{
		static public PointLatLng RenderOffset;

		private Bitmap internal_graph = null;
		private Bitmap graph
		{
			set
			{
				internal_graph = value;
			}
			get
			{
				return internal_graph;
			}
		}

		private PointLatLng polyrect_topleft;
		private PointLatLng polyrect_botright;

		public SignalPolygon(List<PointLatLng> points, string name)
		: base(points, name)
		{
		}

		static private double Map(double val, double in_min, double in_max, double out_min, double out_max)
			=> (val - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;

		internal Task GenerateTilesAsync(Mode mode, SignalParams? signalparams = null)
		{
			var task = new Task(() => { GenerateTiles(mode, signalparams); Overlay.Control.Refresh(); });
			task.Start();
			return task;
		}
		internal void GenerateTiles(Mode mode, SignalParams? signalparams = null)
		{
			if (Points.Count < 3) return;

			double left, right, top, bottom;

			left = right = Points[0].Lng;
			top = bottom = Points[0].Lat;

			foreach (var point in Points)
			{
				top = Math.Max(top, point.Lat);
				bottom = Math.Min(bottom, point.Lat);
				right = Math.Max(right, point.Lng);
				left = Math.Min(left, point.Lng);
			}

			HGT.LoadFiles(bottom, top, left, right);

			this.polyrect_topleft = new PointLatLng(top, left);
			this.polyrect_botright = new PointLatLng(bottom, right);

			int leftindex = (int)((left - (int)left) * 3600);
			int rightindex = (int)((right - (int)left) * 3600);
			int topindex = (int)((top - (int)bottom) * 3600);
			int botindex = (int)((bottom - (int)bottom) * 3600);

			int tiles_cols = rightindex - leftindex;
			int tiles_rows = topindex - botindex;

			Bitmap tempgraph;
			try
			{
				tempgraph = new(tiles_cols == 0 ? 1 : tiles_cols, tiles_rows == 0 ? 1 : tiles_rows);
			}
			catch (Exception err)
			{
				MessageBox.Show("Error while creating new polygon bitmap:\n" + err.Message);
				throw new Exception("While creating new polygon bitmap", err);
			}

			Graphics g = Graphics.FromImage(tempgraph);
			g.Clear(Color.Transparent);

			Parallel.For(botindex, topindex + 1, y =>
			{
				for (int x = leftindex; x <= rightindex; x++)
				{
					double lng = (int)left + x / 3600.0;
					double lat = (int)bottom + y / 3600.0;
					PointLatLng curtile = new(lat, lng);

					int? min_value = null;
					int? max_value = null;

					if (base.IsInside(new PointLatLng(lat, lng)))
					{
						Brush brush = Brushes.Transparent;
						int? value;

						switch (mode)
						{
							case Mode.elev:
								value = HGT.GetElevation(curtile);
								if (value != null)
								{
									max_value = max_value == null ? value : Math.Max((int)value, (int)max_value);
									min_value = min_value == null ? value : Math.Min((int)value, (int)min_value);
								}

								if (value == null)
								{
									brush = Brushes.Transparent;
								}
								else
								{
									int rltv = (int)Map((double)value, (double)min_value, (double)max_value, (double)0, (double)255);
									brush = new SolidBrush(Color.FromArgb(200, rltv, rltv, rltv));
								}
								break;
							case Mode.signal:
								if (signalparams == null) break;

								Color color;

								if (HGT.IsLineOfSight(signalparams.Value.telev, signalparams.Value.tloc, curtile, out double dist))
								{
									double fspl = 20 * (Math.Log10(dist) + Math.Log10(signalparams.Value.freq)) - 147.55;
									double rdBm = signalparams.Value.tdBm-30 + signalparams.Value.tgain + signalparams.Value.rgain - fspl;

									rdBm = (rdBm < signalparams.Value.rbad || rdBm <= signalparams.Value.sensitivity ? signalparams.Value.rbad : rdBm);
									rdBm = (rdBm > signalparams.Value.rgood ? signalparams.Value.rgood : rdBm);

									int rltv = (int)Map(rdBm, signalparams.Value.rbad, signalparams.Value.rgood, 0, 255);
									color = Color.FromArgb(120, 255 - rltv, rltv, 0);
								}
								else
								{
									color = Color.FromArgb(120, Color.DarkSlateBlue);
								}

								brush = new SolidBrush(color);

								break;
						}

						lock (g) g.FillRectangle(brush, new RectangleF(x - leftindex, topindex - y, 1, 1));
					}
				}
			});

			g.Dispose();

			graph = tempgraph;
		}

		public override void OnRender(Graphics gscreen)
		{
			Bitmap graph = this.graph;

			if (graph == null || LocalPoints.Count < 3)
			{
				base.OnRender(gscreen);
				return;
			}

			Fill = Brushes.Transparent;

			Rectangle scrnrect = new(Point.Empty, Overlay.Control.Size);

			GPoint gp_topleft = Overlay.Control.FromLatLngToLocal(polyrect_topleft);
			GPoint gp_botright = Overlay.Control.FromLatLngToLocal(polyrect_botright);

			Rectangle polyrect = new((int)gp_topleft.X, (int)(gp_topleft.Y), (int)(gp_botright.X - gp_topleft.X), (int)(gp_botright.Y - gp_topleft.Y));

			if (!scrnrect.Contains(polyrect) && !scrnrect.IntersectsWith(polyrect))
			{
				base.OnRender(gscreen);
				return;
			}

			GPoint gp = Overlay.Control.FromLatLngToLocal(RenderOffset);

			gscreen.DrawImage(graph, new Rectangle(
					(int)(gp_topleft.X - gp.X),
					(int)(gp_topleft.Y - gp.Y),
					(int)(gp_botright.X - gp_topleft.X),
					(int)(gp_botright.Y - gp_topleft.Y)
				));

			base.OnRender(gscreen);
		}

		public override void Dispose()
		{
			GC.SuppressFinalize(this);
			graph?.Dispose();
			graph = null;
			base.Dispose();
			GC.Collect();
		}
	}
}
