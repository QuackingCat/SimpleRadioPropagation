namespace RadioSimulator
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
			menuEditTempMark = new System.Windows.Forms.ContextMenuStrip(components);
			menu_position = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			createPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			menuEditSiteMark = new System.Windows.Forms.ContextMenuStrip(components);
			copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			menuEditPoly = new System.Windows.Forms.ContextMenuStrip(components);
			copyPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			menuEditTempMark.SuspendLayout();
			menuEditSiteMark.SuspendLayout();
			menuEditPoly.SuspendLayout();
			SuspendLayout();
			// 
			// gMapControl1
			// 
			gMapControl1.BackColor = System.Drawing.Color.Black;
			gMapControl1.Bearing = 0F;
			gMapControl1.CanDragMap = true;
			gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			gMapControl1.EmptyTileColor = System.Drawing.Color.Black;
			gMapControl1.GrayScaleMode = false;
			gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			gMapControl1.LevelsKeepInMemory = 5;
			gMapControl1.Location = new System.Drawing.Point(0, 0);
			gMapControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			gMapControl1.MarkersEnabled = true;
			gMapControl1.MaxZoom = 2;
			gMapControl1.MinZoom = 2;
			gMapControl1.MouseWheelZoomEnabled = true;
			gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			gMapControl1.Name = "gMapControl1";
			gMapControl1.NegativeMode = false;
			gMapControl1.PolygonsEnabled = true;
			gMapControl1.RetryLoadTile = 0;
			gMapControl1.RoutesEnabled = true;
			gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
			gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(33, 65, 105, 225);
			gMapControl1.ShowTileGridLines = false;
			gMapControl1.Size = new System.Drawing.Size(933, 519);
			gMapControl1.TabIndex = 0;
			gMapControl1.Zoom = 0D;
			gMapControl1.Load += gMapControl1_Load;
			// 
			// menuEditTempMark
			// 
			menuEditTempMark.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menu_position, toolStripMenuItem2, createPolygonToolStripMenuItem });
			menuEditTempMark.Name = "contextMenuStrip1";
			menuEditTempMark.ShowImageMargin = false;
			menuEditTempMark.Size = new System.Drawing.Size(131, 70);
			menuEditTempMark.Opening += menuEditTempMark_Opening;
			// 
			// menu_position
			// 
			menu_position.Name = "menu_position";
			menu_position.Size = new System.Drawing.Size(130, 22);
			menu_position.Text = "copy position";
			// 
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(130, 22);
			toolStripMenuItem2.Text = "Create Site";
			// 
			// createPolygonToolStripMenuItem
			// 
			createPolygonToolStripMenuItem.Name = "createPolygonToolStripMenuItem";
			createPolygonToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			createPolygonToolStripMenuItem.Text = "Create Polygon";
			// 
			// menuEditSiteMark
			// 
			menuEditSiteMark.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { copyToolStripMenuItem, moveToolStripMenuItem, deleteToolStripMenuItem });
			menuEditSiteMark.Name = "menuEditSiteMark";
			menuEditSiteMark.ShowImageMargin = false;
			menuEditSiteMark.Size = new System.Drawing.Size(122, 70);
			menuEditSiteMark.Opening += menuEditSiteMark_Opening;
			// 
			// copyToolStripMenuItem
			// 
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			copyToolStripMenuItem.Text = "copy position";
			// 
			// moveToolStripMenuItem
			// 
			moveToolStripMenuItem.Name = "moveToolStripMenuItem";
			moveToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			moveToolStripMenuItem.Text = "Edit Site";
			// 
			// deleteToolStripMenuItem
			// 
			deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			deleteToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			deleteToolStripMenuItem.Text = "Delete";
			// 
			// menuEditPoly
			// 
			menuEditPoly.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { copyPositionToolStripMenuItem, deleteToolStripMenuItem2 });
			menuEditPoly.Name = "menuEditPoly";
			menuEditPoly.ShowImageMargin = false;
			menuEditPoly.Size = new System.Drawing.Size(122, 48);
			menuEditPoly.Opening += menuEditPoly_Opening;
			// 
			// copyPositionToolStripMenuItem
			// 
			copyPositionToolStripMenuItem.Name = "copyPositionToolStripMenuItem";
			copyPositionToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			copyPositionToolStripMenuItem.Text = "copy position";
			// 
			// deleteToolStripMenuItem2
			// 
			deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
			deleteToolStripMenuItem2.Size = new System.Drawing.Size(121, 22);
			deleteToolStripMenuItem2.Text = "Delete";
			// 
			// Form1
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(933, 519);
			Controls.Add(gMapControl1);
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			menuEditTempMark.ResumeLayout(false);
			menuEditSiteMark.ResumeLayout(false);
			menuEditPoly.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip menuEditTempMark;
		private System.Windows.Forms.ToolStripMenuItem menu_position;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ContextMenuStrip menuEditSiteMark;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		internal GMap.NET.WindowsForms.GMapControl gMapControl1;
		private System.Windows.Forms.ToolStripMenuItem createPolygonToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip menuEditPoly;
		private System.Windows.Forms.ToolStripMenuItem copyPositionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
	}
}

