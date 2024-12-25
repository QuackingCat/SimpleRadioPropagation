using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioSimulator
{
	public partial class Form1 : Form
	{
		private GMapOverlay tempmarkers = null;
		private GMapOverlay sitemarkers = null;
		private GMapOverlay temppolys = null;
		internal GMapOverlay polys;

		private List<Site> sites = null;

		private PointLatLng lastpoint;
		internal GMapMarker lastmark;
		internal GMapPolygon lastpoly;

		private List<PointLatLng> newpoly = null;

		public Form1()
		{
			InitializeComponent();

			tempmarkers = new GMapOverlay("Temp Markers");
			sitemarkers = new GMapOverlay("Sites");

			temppolys = new GMapOverlay("Temp Polygons");
			polys = new GMapOverlay("Polygons");

			RadioSimulator.Site.defaultoverlay = sitemarkers;

			lastpoint = new PointLatLng(0, 0);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			gMapControl1.MapProvider = GMapProviders.GoogleHybridMap;
			gMapControl1.Position = new PointLatLng(31.4661537150243, 35.035400390625); // Set initial position
			gMapControl1.MinZoom = 1;
			gMapControl1.MaxZoom = 20;
			gMapControl1.Zoom = 8;
			gMapControl1.ShowCenter = false;
			gMapControl1.MouseWheelZoomEnabled = true;
			gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
			gMapControl1.OnMapZoomChanged += delegate
			{
				SignalPolygon.RenderOffset = gMapControl1.Position;
			};
			gMapControl1.DragButton = MouseButtons.Left;
			gMapControl1.MouseClick += GMapControl1_MouseClick;
			gMapControl1.Overlays.Add(temppolys);
			gMapControl1.Overlays.Add(polys);
			gMapControl1.Overlays.Add(tempmarkers);
			gMapControl1.Overlays.Add(sitemarkers);
			gMapControl1.MouseMove += OnMouseMove;

			sitesFromJson();

			menuEditTempMark.Items[0].Click += copyloc;
			menuEditTempMark.Items[1].Click += delegate
			{
				tempmarkers.Clear();
				sites.Add(new Site("", 0, lastpoint));
				sitesToJson();
			}; // create a new site marker
			menuEditTempMark.Items[2].Click += delegate
			{
				if (newpoly != null) return;
				newpoly = [lastmark.Position];

				double lat = gMapControl1.FromLocalToLatLng(MousePosition.X, MousePosition.Y).Lat;
				double lng = gMapControl1.FromLocalToLatLng(MousePosition.X, MousePosition.Y).Lng;

				GMapPolygon poly = new GMapPolygon([lastmark.Position, new PointLatLng(lat, lng)], "temp");
				temppolys.Polygons.Add(poly);
			}; // create a new polygon

			menuEditSiteMark.Items[0].Click += copyloc;
			menuEditSiteMark.Items[1].Click += delegate
			{
				EditSiteForm editSiteForm = new(this, (Site)lastmark.Tag);
				editSiteForm.Show();
			}; // edit site
			menuEditSiteMark.Items[2].Click += delegate
			{
				Site site = (Site)lastmark.Tag;
				site.delete();
				sites.Remove(site);
				sitesToJson();
			}; // delete site

			menuEditPoly.Items[0].Click += copyloc;
			menuEditPoly.Items[1].Click += delegate
			{
				polys.Polygons.Remove(lastpoly);
				lastpoly.Dispose();
				lastpoly = null;
			}; // delete poly


			SignalPolygon.RenderOffset = gMapControl1.Position;

		}


		protected void OnMouseMove(object _, MouseEventArgs e)
		{
			if (newpoly == null) return;

			double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
			double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

			GMapPolygon poly = temppolys.Polygons[^1];
			temppolys.Polygons.Remove(poly);
			temppolys.Polygons.Add(new GMapPolygon([poly.Points[0], new PointLatLng(lat, lng)], "temp"));
			poly.Dispose();
		}

		private GMapMarker CheckMarkerOver()
		{
			foreach (GMapOverlay overlay in gMapControl1.Overlays)
			{
				foreach (GMapMarker mark in overlay.Markers)
				{
					if (mark.IsVisible && mark.IsMouseOver) return mark;
				}
			}

			return null;
		}
		private GMapPolygon CheckPolyOver()
		{
			foreach (GMapOverlay overlay in gMapControl1.Overlays.Reverse())
			{
				foreach (GMapPolygon poly in overlay.Polygons.Reverse())
				{
					if (poly.IsVisible && poly.IsMouseOver) return poly;
				}
			}

			return null;
		}

		private void GMapControl1_MouseClick(object sender, MouseEventArgs e)
		{
			double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
			double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

			GMapMarker mark = null;
			GMapPolygon polygon = null;
			if (gMapControl1.IsMouseOverMarker) mark = CheckMarkerOver();
			if (gMapControl1.IsMouseOverPolygon) polygon = CheckPolyOver();

			if (mark != null)
			{
				lastpoint.Lat = mark.Position.Lat;
				lastpoint.Lng = mark.Position.Lng;
			}
			else
			{
				lastpoint.Lat = lat;
				lastpoint.Lng = lng;
			}

			switch (e.Button)
			{
				case MouseButtons.Right:
					if (mark == null || !mark.IsVisible) // no mark was clicked
					{
						if (newpoly != null) return;

						if (polygon != null)
						{
							menuEditPoly.Show(MousePosition.X, MousePosition.Y);
							lastpoly = polygon;
							break;
						}

						tempmarkers.Clear();
						tempmarkers.Markers.Add(lastmark = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue_dot));
						menuEditTempMark.Show(MousePosition.X, MousePosition.Y);
					}
					else if (mark.Overlay == sitemarkers) // clicked a site mark
					{
						lastmark = mark;
						menuEditSiteMark.Show(MousePosition.X, MousePosition.Y);
					}
					else if (mark.Overlay == tempmarkers) // clicked a temp mark
					{
						menuEditTempMark.Show(MousePosition.X, MousePosition.Y);
					}
					break;
				case MouseButtons.Left:
					if (newpoly == null) return;

					if (mark == null || mark.Position != newpoly[0])
					{
						var point = new PointLatLng(lat, lng);
						GMapPolygon poly = temppolys.Polygons[^1];

						temppolys.Polygons.Remove(poly);
						temppolys.Polygons.Add(new GMapPolygon([poly.Points[0], point], "temp"));
						poly.Dispose();
						temppolys.Polygons.Add(new GMapPolygon([point, point], "temp"));
						newpoly.Add(point);
					}
					else
					{
						if (2 < newpoly.Count)
						{
							SignalPolygon poly = new SignalPolygon(newpoly, Guid.NewGuid().ToString());
							poly.IsHitTestVisible = true;
							MessageBox.Show("Created new polygon named \"" + poly.Name + "\"");
							poly.GenerateTilesAsync(Mode.elev);
							polys.Polygons.Add(poly);
						}

						newpoly = null;
						foreach (var poly in temppolys.Polygons)
						{
							poly.Dispose();
						}
						temppolys.Clear();
					}
					break;
			}
		}



		private void gMapControl1_Load(object sender, EventArgs e)
		{

		}

		private void copyloc(object sender, EventArgs e)
		{
			Clipboard.SetData(DataFormats.StringFormat, lastpoint.Lat + ", " + lastpoint.Lng);
		}

		private void menuEditTempMark_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			menuEditTempMark.Items[0].Text = lastpoint.Lat.ToString("F7") + ", " + lastpoint.Lng.ToString("F7");
		}

		private void menuEditSiteMark_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			menuEditSiteMark.Items[0].Text = lastpoint.Lat.ToString("F7") + ", " + lastpoint.Lng.ToString("F7");
			menuEditSiteMark.Items[1].Enabled = !((Site)lastmark.Tag).editflag;
			menuEditSiteMark.Items[2].Enabled = !((Site)lastmark.Tag).editflag;
		}

		private void menuEditPoly_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			menuEditPoly.Items[0].Text = lastpoint.Lat.ToString("F7") + ", " + lastpoint.Lng.ToString("F7");
		}

		static private readonly string jsonname = "sites.json";

		internal void sitesToJson()
		{
			if (!File.Exists(jsonname))
			{
				File.Create(jsonname).Close();
			}

			File.WriteAllText(jsonname, JsonSerializer.Serialize(sites));
		}

		internal void sitesFromJson()
		{
			if (sites != null)
			{
				foreach (var site in sites)
				{
					site.delete();
				}
				sites.Clear();
			}

			if (!File.Exists(jsonname))
			{
				FileStream f = File.Create(jsonname);
				f.Write([(byte)'[', (byte)']'], 0, 2);
				f.Close();
			}

			string json = File.ReadAllText(jsonname);

			try
			{
				sites = JsonSerializer.Deserialize<List<Site>>(json.Length < 2 ? @"[]" : json);
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error accurd while parsing 'sites.json'. \n\n" + ex.Message);
				sites = [];
			}
		}


	}
}
