using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RadioSimulator
{
	internal class Site
	{
		static internal GMapOverlay defaultoverlay = null;

		[JsonIgnore]
		internal bool editflag;

		[JsonInclude]
		internal string name
		{
			set
			{
				marker.Caption = value;
			}
			get => marker.Caption;
		}

		[JsonInclude]
		internal double height;

		[JsonInclude]
		private double lat;
		[JsonInclude]
		private double lng;

		[JsonInclude]
		internal SignalParams? signalParams;

		internal PointLatLng location
		{
			set {
				lat = value.Lat; lng = value.Lng;
				marker.Position = value;
			}
			get => marker.Position;
		}

		private GMapMarkerWithLabel marker;

		internal Site(string name, double height, PointLatLng location, GMapOverlay overlay = null) {
			this.marker = new GMapMarkerWithLabel(location, name, Properties.Resources.site_icon);
			this.marker.Tag = this;
			this.name = name;
			this.height = height;
			this.location = location;
			editflag = false;
			if (overlay != null) overlay.Markers.Add(this.marker);
			else defaultoverlay.Markers.Add(this.marker);
		}

		[JsonConstructor]
		private Site(string name, double height, double lat, double lng, SignalParams? signalParams) : this(name, height, new PointLatLng(lat, lng), null)
		{
			this.signalParams = signalParams;
		}

		internal void delete()
		{
			marker.Overlay.Markers.Remove(marker);
			marker.Dispose();
		}
	}
}
