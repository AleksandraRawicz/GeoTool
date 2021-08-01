namespace GeoTool
{
    partial class ContourGraphPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContourGraphPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.FilterPanelBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.legendArea = new System.Windows.Forms.PictureBox();
            this.GraphArea = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.legendArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphArea)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.FilterPanelBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(617, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 483);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.FilterBtn);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Controls.Add(this.comboBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(284, 147);
            this.panel4.TabIndex = 36;
            // 
            // FilterBtn
            // 
            this.FilterBtn.BackColor = System.Drawing.Color.Green;
            this.FilterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilterBtn.ForeColor = System.Drawing.Color.White;
            this.FilterBtn.Location = new System.Drawing.Point(47, 85);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(198, 34);
            this.FilterBtn.TabIndex = 26;
            this.FilterBtn.Text = "Set";
            this.FilterBtn.UseVisualStyleBackColor = false;
            this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(47, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(47, 45);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(198, 24);
            this.comboBox2.TabIndex = 1;
            // 
            // FilterPanelBtn
            // 
            this.FilterPanelBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.FilterPanelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterPanelBtn.FlatAppearance.BorderSize = 0;
            this.FilterPanelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilterPanelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FilterPanelBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FilterPanelBtn.Location = new System.Drawing.Point(0, 0);
            this.FilterPanelBtn.Name = "FilterPanelBtn";
            this.FilterPanelBtn.Size = new System.Drawing.Size(284, 30);
            this.FilterPanelBtn.TabIndex = 32;
            this.FilterPanelBtn.Text = "Choose data - use filters";
            this.FilterPanelBtn.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.legendArea);
            this.panel2.Controls.Add(this.GraphArea);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 483);
            this.panel2.TabIndex = 1;
            // 
            // legendArea
            // 
            this.legendArea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("legendArea.BackgroundImage")));
            this.legendArea.Cursor = System.Windows.Forms.Cursors.Cross;
            this.legendArea.Location = new System.Drawing.Point(407, 0);
            this.legendArea.Name = "legendArea";
            this.legendArea.Size = new System.Drawing.Size(67, 401);
            this.legendArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.legendArea.TabIndex = 7;
            this.legendArea.TabStop = false;
            // 
            // GraphArea
            // 
            this.GraphArea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GraphArea.BackgroundImage")));
            this.GraphArea.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GraphArea.Location = new System.Drawing.Point(0, 0);
            this.GraphArea.Name = "GraphArea";
            this.GraphArea.Size = new System.Drawing.Size(401, 401);
            this.GraphArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.GraphArea.TabIndex = 6;
            this.GraphArea.TabStop = false;
            // 
            // ContourGraphPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(901, 483);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContourGraphPanel";
            this.Text = "ContourGraphPanel";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.legendArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button FilterPanelBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox legendArea;
        private System.Windows.Forms.PictureBox GraphArea;
    }
}