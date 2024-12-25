using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RadioSimulator
{
	static internal class HGT
	{
		static internal readonly string TilesPath = @"C:\Users\PC1\Downloads\maps\tiles\";//"./tiles/";
		private static readonly Dictionary<ulong, byte[]> CachedFiles = [];

		static internal void LoadFiles(double bot, double top, double left, double right)
		{
			for (var i = (uint)bot; i <= (uint)top; i++)
			{
				for (var j = (uint)left; j <= (uint)right; j++)
				{
					ulong tilepos = i * 32ul + j;
					if (CachedFiles.TryGetValue(tilepos, out byte[] buff) == false)
					{
						string tilename = LatLngToTileName(i, j);
						string filepath = TilesPath + tilename + ".hgt";

						if (!File.Exists(filepath))
						{
							CachedFiles.Add(tilepos, null);
							continue;
						}

						var file = new BinaryReader(File.OpenRead(filepath));

						buff = file.ReadBytes((int)file.BaseStream.Length);

						CachedFiles.Add(tilepos, buff);

						file.Close();
					}
					else if (buff == null)
					{
						string tilename = LatLngToTileName(i, j);
						string filepath = TilesPath + tilename + ".hgt";

						if (!File.Exists(filepath))
						{
							continue;
						}

						CachedFiles.Remove(tilepos);

						var file = new BinaryReader(File.OpenRead(filepath));

						buff = file.ReadBytes((int)file.BaseStream.Length);

						CachedFiles.Add(tilepos, buff);

						file.Close();
					}
				}
			}
		}

		static internal string LatLngToTileName(PointLatLng point) => LatLngToTileName(point.Lat, point.Lng);
		static internal string LatLngToTileName(double lat, double lng)
		{
			string strlat = Math.Abs(lat < 0 ? (int)Math.Floor(lat) : (int)lat).ToString().PadLeft(2, '0');
			string strlng = Math.Abs(lng < 0 ? (int)Math.Floor(lng) : (int)lng).ToString().PadLeft(3, '0');

			return (0 < lat ? 'N' : 'S') + strlat
				 + (0 < lng ? 'E' : 'W') + strlng;
		}

		static internal int? GetElevation(PointLatLng point)
		{
			ulong tilepos = (ulong)(int)point.Lat * 32ul + (ulong)(int)point.Lng;

			if (CachedFiles.TryGetValue(tilepos, out byte[] buff) == false)
			{
				//string tilename = LatLngToTileName(point);
				//MessageBox.Show("Can't find the buffer for " + tilename);
				return null;
			}

			if (buff == null) return null;

			long n = (long)((point.Lat - (int)Math.Floor(point.Lat)) * 3600);
			long e = (long)((point.Lng - (int)Math.Floor(point.Lng)) * 3600);

			long pos = ((3600 - n) * 3601 + e) * 2;
			short val = (short)(buff[pos] << 8 | buff[pos + 1]);

			return val != -32768 ? val : null;
		}

		static internal bool IsLineOfSight(double start_rltvelev, PointLatLng start, PointLatLng end, out double distance3d)
		{
			distance3d = Get3DDist(start_rltvelev, start, end, out double? startelev, out double? endelev) ?? -1;

			if (distance3d == -1) return false;

			startelev += start_rltvelev;

			double distance2d = Math.Sqrt(Math.Pow(end.Lng - start.Lng, 2) + Math.Pow(end.Lat - start.Lat, 2));
			var (sin, cos) = Math.SinCos(Math.Atan2(end.Lat - start.Lat, end.Lng - start.Lng));
			double heightdiff = endelev.Value - startelev.Value;

			List<double> h = [];
			for (int i = 1; i / 3600.0 < distance2d; i++)
			{
				PointLatLng pos = new(start.Lat + sin * i / 3600, start.Lng + cos * i / 3600);
				double? elev = GetElevation(pos);
				if (elev == null) continue;
				h.Add(elev.Value);

				if (heightdiff / distance2d < (elev - startelev) / (i / 3600.0))
				{
					return false;
				}
			}

			return true;
		}

		static internal double? Get3DDist(double start_rltvelev, PointLatLng start, PointLatLng end, out double? startelev, out double? endelev)
		{
			startelev = GetElevation(start) + start_rltvelev;
			endelev = GetElevation(end);

			if (startelev == null || endelev == null) return null;

			double mapdist = 1000*GMapProviders.GoogleHybridMap.Projection.GetDistance(start, end);
			return Math.Sqrt(mapdist * mapdist + Math.Pow(Math.Abs(startelev.Value - endelev.Value), 2));
		}

		static internal void ClearCach()
		{
			lock (CachedFiles) CachedFiles.Clear();
			GC.Collect();
		}
	}
}
