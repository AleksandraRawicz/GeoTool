namespace GeoTool
{
    partial class RosePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RosePanel));
            this.graphArea = new System.Windows.Forms.PictureBox();
            this.FilterPanelBtn = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.SetLegendCBox = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.ChangeColourBtn = new System.Windows.Forms.Button();
            this.CustomizePanelBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.BidirectRadioBtn = new System.Windows.Forms.RadioButton();
            this.DirectRadioBtn = new System.Windows.Forms.RadioButton();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.graphArea)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphArea
            // 
            this.graphArea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("graphArea.BackgroundImage")));
            this.graphArea.Location = new System.Drawing.Point(30, 30);
            this.graphArea.Name = "graphArea";
            this.graphArea.Size = new System.Drawing.Size(401, 401);
            this.graphArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.graphArea.TabIndex = 0;
            this.graphArea.TabStop = false;
            // 
            // FilterPanelBtn
            // 
            this.FilterPanelBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.FilterPanelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterPanelBtn.FlatAppearance.BorderSize = 0;
            this.FilterPanelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilterPanelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FilterPanelBtn.ForeColor = System.Drawing.Color.White;
            this.FilterPanelBtn.Location = new System.Drawing.Point(0, 0);
            this.FilterPanelBtn.Name = "FilterPanelBtn";
            this.FilterPanelBtn.Size = new System.Drawing.Size(313, 40);
            this.FilterPanelBtn.TabIndex = 4;
            this.FilterPanelBtn.Text = "Data filters";
            this.FilterPanelBtn.UseVisualStyleBackColor = false;
            this.FilterPanelBtn.Click += new System.EventHandler(this.FilterPanelBtn_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(0, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.CustomizePanelBtn);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.FilterPanelBtn);
            this.panel2.Controls.Add(this.buttonExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(607, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 600);
            this.panel2.TabIndex = 17;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.SetLegendCBox);
            this.panel6.Controls.Add(this.trackBar1);
            this.panel6.Controls.Add(this.ChangeColourBtn);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 334);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(313, 168);
            this.panel6.TabIndex = 28;
            // 
            // SetLegendCBox
            // 
            this.SetLegendCBox.FormattingEnabled = true;
            this.SetLegendCBox.Location = new System.Drawing.Point(81, 67);
            this.SetLegendCBox.Name = "SetLegendCBox";
            this.SetLegendCBox.Size = new System.Drawing.Size(142, 24);
            this.SetLegendCBox.TabIndex = 19;
            this.SetLegendCBox.Text = "Set legend";
            this.SetLegendCBox.SelectedIndexChanged += new System.EventHandler(this.SetLegendCBox_SelectedIndexChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(102, 106);
            this.trackBar1.Maximum = 600;
            this.trackBar1.Minimum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 56);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 200;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // ChangeColourBtn
            // 
            this.ChangeColourBtn.BackColor = System.Drawing.Color.Green;
            this.ChangeColourBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeColourBtn.ForeColor = System.Drawing.Color.White;
            this.ChangeColourBtn.Location = new System.Drawing.Point(81, 17);
            this.ChangeColourBtn.Name = "ChangeColourBtn";
            this.ChangeColourBtn.Size = new System.Drawing.Size(142, 33);
            this.ChangeColourBtn.TabIndex = 18;
            this.ChangeColourBtn.Text = "Choose colour";
            this.ChangeColourBtn.UseVisualStyleBackColor = false;
            this.ChangeColourBtn.Click += new System.EventHandler(this.ChangeColourBtn_Click);
            // 
            // CustomizePanelBtn
            // 
            this.CustomizePanelBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.CustomizePanelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CustomizePanelBtn.FlatAppearance.BorderSize = 0;
            this.CustomizePanelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomizePanelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CustomizePanelBtn.ForeColor = System.Drawing.Color.White;
            this.CustomizePanelBtn.Location = new System.Drawing.Point(0, 294);
            this.CustomizePanelBtn.Name = "CustomizePanelBtn";
            this.CustomizePanelBtn.Size = new System.Drawing.Size(313, 40);
            this.CustomizePanelBtn.TabIndex = 27;
            this.CustomizePanelBtn.Text = "Customize";
            this.CustomizePanelBtn.UseVisualStyleBackColor = false;
            this.CustomizePanelBtn.Click += new System.EventHandler(this.CustomizePanelBtn_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBox3);
            this.panel5.Controls.Add(this.BidirectRadioBtn);
            this.panel5.Controls.Add(this.DirectRadioBtn);
            this.panel5.Controls.Add(this.FilterBtn);
            this.panel5.Controls.Add(this.comboBox2);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.comboBox1);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(313, 254);
            this.panel5.TabIndex = 26;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.comboBox3.Location = new System.Drawing.Point(81, 162);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(142, 24);
            this.comboBox3.TabIndex = 28;
            // 
            // BidirectRadioBtn
            // 
            this.BidirectRadioBtn.AutoSize = true;
            this.BidirectRadioBtn.Location = new System.Drawing.Point(48, 126);
            this.BidirectRadioBtn.Name = "BidirectRadioBtn";
            this.BidirectRadioBtn.Size = new System.Drawing.Size(105, 21);
            this.BidirectRadioBtn.TabIndex = 27;
            this.BidirectRadioBtn.TabStop = true;
            this.BidirectRadioBtn.Text = "bidirectional";
            this.BidirectRadioBtn.UseVisualStyleBackColor = true;
            // 
            // DirectRadioBtn
            // 
            this.DirectRadioBtn.AutoSize = true;
            this.DirectRadioBtn.Location = new System.Drawing.Point(159, 126);
            this.DirectRadioBtn.Name = "DirectRadioBtn";
            this.DirectRadioBtn.Size = new System.Drawing.Size(94, 21);
            this.DirectRadioBtn.TabIndex = 26;
            this.DirectRadioBtn.TabStop = true;
            this.DirectRadioBtn.Text = "directional";
            this.DirectRadioBtn.UseVisualStyleBackColor = true;
            // 
            // FilterBtn
            // 
            this.FilterBtn.BackColor = System.Drawing.Color.Green;
            this.FilterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilterBtn.ForeColor = System.Drawing.Color.White;
            this.FilterBtn.Location = new System.Drawing.Point(81, 201);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(142, 33);
            this.FilterBtn.TabIndex = 25;
            this.FilterBtn.Text = "Set";
            this.FilterBtn.UseVisualStyleBackColor = false;
            this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(121, 86);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(165, 24);
            this.comboBox2.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 34);
            this.label2.TabIndex = 21;
            this.label2.Text = "structure \r\ntype";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(121, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(165, 24);
            this.comboBox1.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "age";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.graphArea);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(607, 600);
            this.panel3.TabIndex = 18;
            // 
            // WykresRozetowy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 600);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WykresRozetowy";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.graphArea)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox graphArea;
        private System.Windows.Forms.Button FilterPanelBtn;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ChangeColourBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button CustomizePanelBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.RadioButton BidirectRadioBtn;
        private System.Windows.Forms.RadioButton DirectRadioBtn;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox SetLegendCBox;
    }
}