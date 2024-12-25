using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using System.Drawing.Drawing2D;

namespace RadioSimulator
{
	public class GMapMarkerWithLabel : GMarkerGoogle
	{
		private int font;
		public string Caption;

		public GMapMarkerWithLabel(PointLatLng p, string caption, GMarkerGoogleType type, int font = 14)
			: base(p, type)
		{
			this.font = font;
			Caption = caption;
		}

		public GMapMarkerWithLabel(PointLatLng p, string caption, Bitmap type, int font = 14)
			: base(p, type)
		{
			this.font = font;
			Caption = caption;
		}

		public override void OnRender(Graphics g)
		{
			base.OnRender(g);
			GraphicsPath path = new GraphicsPath();
			var point = new PointF(this.LocalPosition.X + Size.Width / 2 - g.MeasureString(Caption, new Font(FontFamily.GenericSansSerif, font)).Width / 2, this.LocalPosition.Y + Size.Height);
			path.AddString(Caption, FontFamily.GenericSansSerif, (int)FontStyle.Bold, g.DpiX * font / 72, point, null);
			g.DrawPath(new Pen(Color.Lime, 3), path);
			g.FillPath(Brushes.Black, path);
		}
	}
}
