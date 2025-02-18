namespace SpaceWar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HealthBar = new System.Windows.Forms.ProgressBar();
            this.HealthIcon = new System.Windows.Forms.PictureBox();
            this.SkorLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShowControlsPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthIcon)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowControlsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(371, 271);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(457, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PlayButton);
            // 
            // HealthBar
            // 
            this.HealthBar.ForeColor = System.Drawing.Color.Red;
            this.HealthBar.Location = new System.Drawing.Point(42, 2);
            this.HealthBar.Name = "HealthBar";
            this.HealthBar.Size = new System.Drawing.Size(174, 25);
            this.HealthBar.Step = 5;
            this.HealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.HealthBar.TabIndex = 1;
            this.HealthBar.Value = 100;
            this.HealthBar.Visible = false;
            // 
            // HealthIcon
            // 
            this.HealthIcon.BackColor = System.Drawing.Color.Transparent;
            this.HealthIcon.BackgroundImage = global::SpaceWar.Properties.Resources.HearthImg;
            this.HealthIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HealthIcon.Location = new System.Drawing.Point(11, 2);
            this.HealthIcon.Name = "HealthIcon";
            this.HealthIcon.Size = new System.Drawing.Size(25, 25);
            this.HealthIcon.TabIndex = 2;
            this.HealthIcon.TabStop = false;
            this.HealthIcon.Visible = false;
            // 
            // SkorLabel
            // 
            this.SkorLabel.AutoSize = true;
            this.SkorLabel.BackColor = System.Drawing.Color.Transparent;
            this.SkorLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(23)))), ((int)(((byte)(235)))));
            this.SkorLabel.Location = new System.Drawing.Point(3, -2);
            this.SkorLabel.Name = "SkorLabel";
            this.SkorLabel.Size = new System.Drawing.Size(72, 25);
            this.SkorLabel.TabIndex = 3;
            this.SkorLabel.Text = "Skor ";
            this.SkorLabel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SkorLabel);
            this.panel1.Location = new System.Drawing.Point(907, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 25);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // ShowControlsPictureBox
            // 
            this.ShowControlsPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ShowControlsPictureBox.Image = global::SpaceWar.Properties.Resources.ControlsButton;
            this.ShowControlsPictureBox.Location = new System.Drawing.Point(441, 512);
            this.ShowControlsPictureBox.Name = "ShowControlsPictureBox";
            this.ShowControlsPictureBox.Size = new System.Drawing.Size(300, 85);
            this.ShowControlsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowControlsPictureBox.TabIndex = 7;
            this.ShowControlsPictureBox.TabStop = false;
            this.ShowControlsPictureBox.Click += new System.EventHandler(this.ShowControlsPictureBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::SpaceWar.Properties.Resources.LoginBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.ShowControlsPictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HealthIcon);
            this.Controls.Add(this.HealthBar);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Form1";
            this.Text = "SpaceWar";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShowControlsPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ProgressBar HealthBar;
        public System.Windows.Forms.PictureBox HealthIcon;
        public System.Windows.Forms.Label SkorLabel;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ShowControlsPictureBox;
    }
}

