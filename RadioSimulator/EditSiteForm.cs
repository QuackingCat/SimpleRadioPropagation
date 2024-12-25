using GMap.NET.WindowsForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioSimulator
{
	internal partial class EditSiteForm : Form
	{
		private Form1 parent;
		private Site site;
		private SignalPolygon polygon;

		public EditSiteForm(Form1 parent, Site site)
		{
			InitializeComponent();
			TopMost = true;

			this.parent = parent;
			this.site = site;

			site.editflag = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (namebox.Text != site.name) site.name = namebox.Text;
			if (Math.Abs((double)heightbox.Value - site.height) > 0.001) site.height = (double)heightbox.Value;
			if ((Math.Abs((double)latbox.Value - site.location.Lat) > 0.000000001) ||
				(Math.Abs((double)lngbox.Value - site.location.Lng) > 0.000000001))
			{
				site.location = new GMap.NET.PointLatLng((double)latbox.Value, (double)lngbox.Value);
			}

			site.signalParams = new SignalParams()
			{
				freq = (double)numericUpDown2.Value * 1000000,
				tdBm = (double)numericUpDown1.Value,
				rbad = -100,
				rgood = -50,
				rgain = 0,
				tgain = 0,
				sensitivity = -100,
				tloc = site.location,
				telev = site.height
			};

			parent.sitesToJson();

			polygon = (SignalPolygon)parent.polys.Polygons.Where(poly => poly.Name == comboBox1.Text).FirstOrDefault();
			polygon?.GenerateTilesAsync(Mode.signal, site.signalParams);

			if (polygon == null && comboBox1.Text != "None")
			{
				List<string> data = new List<string>((IList<string>)comboBox1.DataSource);
				data.Remove(comboBox1.Text);
				comboBox1.DataSource = data;
				comboBox1.SelectedIndex = 0;
			}
		}

		private void EditSiteForm_Load(object sender, EventArgs e)
		{
			namebox.Text = site.name;
			heightbox.Value = (decimal)site.height;
			latbox.Value = (decimal)site.location.Lat;
			lngbox.Value = (decimal)site.location.Lng;

			var items = new List<string>();
			items.Add("None");

			foreach (var poly in parent.polys.Polygons)
			{
				items.Add(poly.Name);
			}

			comboBox1.DataSource = items;

			if (site.signalParams != null)
			{
				decimal tdBm = (decimal)site.signalParams.Value.tdBm;
				tdBm = tdBm < numericUpDown1.Minimum ? numericUpDown1.Minimum : tdBm;
				tdBm = tdBm > numericUpDown1.Maximum ? numericUpDown1.Maximum : tdBm;
				numericUpDown1.Value = tdBm;

				decimal freq = (decimal)(site.signalParams.Value.freq / 1000000);
				freq = freq < numericUpDown2.Minimum ? numericUpDown2.Minimum : freq;
				freq = freq > numericUpDown2.Maximum ? numericUpDown2.Maximum : freq;
				numericUpDown2.Value = freq;
			}
		}

		private void EditSiteForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			site.editflag = false;
		}

		private void comboBox1_DropDown(object sender, EventArgs e)
		{
			var items = new List<string>();
			items.Add("None");

			foreach (var poly in parent.polys.Polygons)
			{
				items.Add(poly.Name);
			}

			comboBox1.DataSource = items;
		}
	}
}
