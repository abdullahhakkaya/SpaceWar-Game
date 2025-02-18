using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceWar
{
    public partial class Form1 : Form
    {
        public PrivateFontCollection font;
        public Font SkorFont;
        public PictureBox ControlsPictureBox;
        private string fontPath;
        private Game game;
        private bool IsShooting = false;
        
        public Form1()
        {
            InitializeComponent();
            game = new Game(this);
            game.SkorLabel = this.SkorLabel;
            game.FormTimer = this.timer1;
            AddFont();
            SkorLabel.Font = SkorFont;
        }
        
        private void AddFont()
        {
            font = new PrivateFontCollection();
            fontPath = Path.Combine(Application.StartupPath, "RussoOne-Regular.ttf");
            if (File.Exists(fontPath))
            {
                font.AddFontFile(fontPath);
                SkorFont = new Font(font.Families[0], 16, FontStyle.Regular);
                game.EndGameFont = new Font(font.Families[0], 26, FontStyle.Regular);
                game.HighScoreFont = new Font(font.Families[0], 40, FontStyle.Regular);
                SkorLabel.Font = SkorFont;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                game.up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                game.down = true;
            }
            if(e.KeyCode == Keys.Left)
            {
                game.left = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                game.right = true;
            }
            if(e.KeyCode == Keys.Space && !IsShooting &&!game.IsGameOver)
            {
                IsShooting = true;
                game.player.Shoot(this);
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                game.up = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                game.down = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                game.left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                game.right = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                IsShooting = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            game.CheckCollisions();
            game.UpdateGame();
            this.HealthBar.Value = game.player.GetHealth();
        }

        private void PlayButton(object sender, EventArgs e)
        {
            pictureBox1.Parent.Controls.Remove(pictureBox1);
            ShowControlsPictureBox.Parent.Controls.Remove(ShowControlsPictureBox);
            this.BackgroundImage = null;
            this.BackColor = Color.Black;
            this.HealthBar.Visible = true;
            this.HealthIcon.Visible = true;
            this.SkorLabel.Visible = true;
            this.panel1.Visible = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            game.StartGame();
            timer1.Start();
            timer1.Interval = 16;
        }

        public int ControlButtonCounter = 0;
        private void ShowControlsPictureBox_Click(object sender, EventArgs e)
        {
            ControlButtonCounter++;
            if (ControlButtonCounter % 2 != 0)
            {
                this.pictureBox1.Visible = false;
                ControlsPictureBox = new PictureBox
                {
                    Size = new Size(450, 500),
                    Image = Properties.Resources.ControlsImg2,
                    BackColor = Color.White,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(366, 5)
                };
                this.Controls.Add(ControlsPictureBox);
                return;
            }
            else if(ControlsPictureBox.Parent != null)
            {
                ControlsPictureBox.Parent.Controls.Remove(ControlsPictureBox);
                if(ControlsPictureBox != null) ControlsPictureBox.Dispose();
            }
            this.pictureBox1.Visible = true;
        }
    }
}
