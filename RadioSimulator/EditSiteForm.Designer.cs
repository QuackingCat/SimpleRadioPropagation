namespace RadioSimulator
{
	partial class EditSiteForm
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
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			lngbox = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			latbox = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			heightbox = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			namebox = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			label8 = new System.Windows.Forms.Label();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)lngbox).BeginInit();
			((System.ComponentModel.ISupportInitialize)latbox).BeginInit();
			((System.ComponentModel.ISupportInitialize)heightbox).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.Location = new System.Drawing.Point(0, 0);
			splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(lngbox);
			splitContainer1.Panel1.Controls.Add(label5);
			splitContainer1.Panel1.Controls.Add(latbox);
			splitContainer1.Panel1.Controls.Add(label4);
			splitContainer1.Panel1.Controls.Add(label3);
			splitContainer1.Panel1.Controls.Add(button2);
			splitContainer1.Panel1.Controls.Add(button1);
			splitContainer1.Panel1.Controls.Add(heightbox);
			splitContainer1.Panel1.Controls.Add(label2);
			splitContainer1.Panel1.Controls.Add(namebox);
			splitContainer1.Panel1.Controls.Add(label1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(numericUpDown2);
			splitContainer1.Panel2.Controls.Add(label8);
			splitContainer1.Panel2.Controls.Add(comboBox1);
			splitContainer1.Panel2.Controls.Add(label6);
			splitContainer1.Panel2.Controls.Add(label7);
			splitContainer1.Panel2.Controls.Add(numericUpDown1);
			splitContainer1.Size = new System.Drawing.Size(933, 519);
			splitContainer1.SplitterDistance = 247;
			splitContainer1.SplitterWidth = 5;
			splitContainer1.TabIndex = 0;
			// 
			// lngbox
			// 
			lngbox.DecimalPlaces = 8;
			lngbox.Location = new System.Drawing.Point(55, 165);
			lngbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			lngbox.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
			lngbox.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
			lngbox.Name = "lngbox";
			lngbox.Size = new System.Drawing.Size(104, 23);
			lngbox.TabIndex = 10;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(22, 165);
			label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(27, 15);
			label5.TabIndex = 9;
			label5.Text = "Lng";
			// 
			// latbox
			// 
			latbox.DecimalPlaces = 8;
			latbox.Location = new System.Drawing.Point(55, 135);
			latbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			latbox.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
			latbox.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
			latbox.Name = "latbox";
			latbox.Size = new System.Drawing.Size(104, 23);
			latbox.TabIndex = 8;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(22, 137);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(23, 15);
			label4.TabIndex = 7;
			label4.Text = "Lat";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(19, 117);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(53, 15);
			label3.TabIndex = 6;
			label3.Text = "Location";
			// 
			// button2
			// 
			button2.BackColor = System.Drawing.SystemColors.ButtonFace;
			button2.Location = new System.Drawing.Point(156, 479);
			button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(88, 27);
			button2.TabIndex = 5;
			button2.Text = "Save";
			button2.UseVisualStyleBackColor = false;
			button2.Click += button2_Click;
			// 
			// button1
			// 
			button1.Location = new System.Drawing.Point(14, 479);
			button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(88, 27);
			button1.TabIndex = 4;
			button1.Text = "Cancel";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// heightbox
			// 
			heightbox.DecimalPlaces = 2;
			heightbox.Location = new System.Drawing.Point(19, 87);
			heightbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			heightbox.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
			heightbox.Name = "heightbox";
			heightbox.Size = new System.Drawing.Size(140, 23);
			heightbox.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(15, 67);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(90, 15);
			label2.TabIndex = 2;
			label2.Text = "Height (Meters)";
			// 
			// namebox
			// 
			namebox.Location = new System.Drawing.Point(19, 35);
			namebox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			namebox.Name = "namebox";
			namebox.Size = new System.Drawing.Size(139, 23);
			namebox.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(15, 15);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(39, 15);
			label1.TabIndex = 0;
			label1.Text = "Name";
			// 
			// numericUpDown2
			// 
			numericUpDown2.DecimalPlaces = 3;
			numericUpDown2.Increment = new decimal(new int[] { 25, 0, 0, 196608 });
			numericUpDown2.Location = new System.Drawing.Point(4, 137);
			numericUpDown2.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
			numericUpDown2.Minimum = new decimal(new int[] { 30, 0, 0, 0 });
			numericUpDown2.Name = "numericUpDown2";
			numericUpDown2.Size = new System.Drawing.Size(120, 23);
			numericUpDown2.TabIndex = 14;
			numericUpDown2.Value = new decimal(new int[] { 30, 0, 0, 0 });
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(4, 118);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(98, 15);
			label8.TabIndex = 13;
			label8.Text = "Frequency (MHz)";
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(4, 35);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(197, 23);
			comboBox1.TabIndex = 11;
			comboBox1.DropDown += comboBox1_DropDown;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(4, 15);
			label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(74, 15);
			label6.TabIndex = 12;
			label6.Text = "Test Polygon";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(4, 67);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(81, 15);
			label7.TabIndex = 1;
			label7.Text = "Output (dBm)";
			// 
			// numericUpDown1
			// 
			numericUpDown1.DecimalPlaces = 2;
			numericUpDown1.Location = new System.Drawing.Point(4, 87);
			numericUpDown1.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
			numericUpDown1.Minimum = new decimal(new int[] { 30, 0, 0, int.MinValue });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(120, 23);
			numericUpDown1.TabIndex = 0;
			// 
			// EditSiteForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(933, 519);
			Controls.Add(splitContainer1);
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Name = "EditSiteForm";
			Text = "Edit Site";
			FormClosing += EditSiteForm_FormClosing;
			Load += EditSiteForm_Load;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)lngbox).EndInit();
			((System.ComponentModel.ISupportInitialize)latbox).EndInit();
			((System.ComponentModel.ISupportInitialize)heightbox).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox namebox;
		private System.Windows.Forms.NumericUpDown heightbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown latbox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown lngbox;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label8;
	}
}