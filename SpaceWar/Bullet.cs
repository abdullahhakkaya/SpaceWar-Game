using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceWar
{
    internal class Bullet
    {
        public int Speed;
        public int Damage;
        public int Direction;
        public PictureBox bulletBox;
        public Spaceship player;
        private bool IsActive;
        public int MoveY;
        public Bullet(Spaceship player)
        {
            this.player = player;
            this.bulletBox = new PictureBox();
            bulletBox.SizeMode = PictureBoxSizeMode.StretchImage;
            bulletBox.Size = new Size(30, 15);
            bulletBox.BackColor = Color.Black;
        }
        public void SetIsActive(bool active) { this.IsActive = active; }
        public bool GetIsActive() { return this.IsActive; }
        //Merminin hareketi
        public void Move()
        {
            if (Direction == 1)
            {
                if (bulletBox.Left < player.game.GameForm.ClientSize.Width && GetIsActive())
                {
                    bulletBox.Location = new Point(bulletBox.Location.X + Speed, bulletBox.Location.Y);
                }
                else
                {
                    if (bulletBox.Parent != null) bulletBox.Parent.Controls.Remove(bulletBox);
                    player.bullets.Remove(this);
                    if(bulletBox != null)
                    {
                        bulletBox.Dispose();
                    }
                }
            }
            else if(Direction == -1)
            {
                double PlayerY = player.player.Location.Y;
                double PlayerX = player.player.Location.X;
                if (bulletBox.Left > 0 && GetIsActive())
                {
                    if(PlayerX - bulletBox.Location.X == 0)
                    {
                        bulletBox.Location = new Point(bulletBox.Location.X - Speed, bulletBox.Location.Y- MoveY);
                    }
                    else if(PlayerX - bulletBox.Location.X > -110)
                    {
                        bulletBox.Location = new Point(bulletBox.Location.X - Speed, bulletBox.Location.Y - MoveY);
                    }
                    else if(PlayerX - bulletBox.Location.X != 0)
                    {
                        double TempMoveY = (PlayerY - bulletBox.Location.Y) / ((PlayerX - bulletBox.Location.X) / Convert.ToDouble(Speed));
                        MoveY = Convert.ToInt32(Math.Round(TempMoveY));
                        bulletBox.Location = new Point(bulletBox.Location.X - Speed, bulletBox.Location.Y - MoveY);
                    }
                }
                else
                {
                    if(bulletBox.Parent!= null) bulletBox.Parent.Controls.Remove(bulletBox);
                    player.bullets.Remove(this);
                }
            }
            
        }
        //Mermi bir hedefe çarptığında hasarı uygular ve yok edilir
        public int OnHit()
        {
            SetIsActive(false);
            return Damage;
        }
    }
}
