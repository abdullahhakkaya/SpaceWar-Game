using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace SpaceWar
{
    internal class Asteroid
    {
        private int RandSize;
        private int RandImgIndex;
        private int RandLocationX, RandLocationY;
        private int RandSpawnUpOrDown, RandSpawnX;
        public int Damage;
        private int Speed = 2, MoveCounter, MoveY, MoveX;
        //public int 
        Random random = new Random();
        Game game;
        public PictureBox AsteroidImg;
        
        public Asteroid(Game game)
        {
            this.game = game;
            SetRandomProperties();
            AsteroidImg = new PictureBox
            {
                Size = new Size(RandSize, RandSize),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Image = SelectPicture(RandImgIndex)
            };
            if(RandSpawnUpOrDown == 0)
            {
                AsteroidImg.Location = new Point(RandSpawnX, -RandSize);
            }
            else if(RandSpawnUpOrDown == 1)
            {
                AsteroidImg.Location = new Point(RandSpawnX, 700);
            }
            game.GameForm.Controls.Add(AsteroidImg);
            game.asteroids.Add(this);
            FindMovement();
        }

        private void SetRandomProperties()
        {
            RandSize = random.Next(30, 100);
            RandImgIndex = random.Next(1, 3);
            RandSpawnUpOrDown = random.Next(0,1);
            RandSpawnX = random.Next(300,900);
            RandLocationX = random.Next(100, 1100);
            RandLocationY = random.Next(50, 600);
            Damage = RandSize;
        }
        private Image SelectPicture(int index)
        {
            if (index == 1) return Properties.Resources.Asteroid1;
            else if(index == 2) return Properties.Resources.Asteroid2;
            else return Properties.Resources.Asteroid3;
        }
        public void FindMovement()
        {
            double MoveNumX = (RandLocationX - RandSpawnX)/Speed;
            MoveCounter = Convert.ToInt32(Math.Abs(Math.Round(MoveNumX)));
            if (MoveCounter == 0) MoveCounter = 1;
            if (RandSpawnUpOrDown == 0)
            {
                double TempMoveY = (RandLocationY + RandSize)/MoveCounter;
                MoveY = Convert.ToInt32(Math.Round(TempMoveY));
            }
            else if (RandSpawnUpOrDown == 1)
            {
                double TempMoveY = (RandLocationY - 700)/ MoveCounter;
                MoveY = Convert.ToInt32(Math.Round(TempMoveY));
            }
            if (RandLocationX - RandSpawnX < 0) MoveX = -Speed;
            if (RandLocationX - RandSpawnX > 0) MoveX = Speed;
            if (RandLocationX - RandSpawnX == 0) MoveX = 0;
        }

        public void Move()
        {
            if(MoveCounter == 0) return;
            else
            {
                MoveCounter--;
                AsteroidImg.Location = new Point(AsteroidImg.Location.X + MoveX, AsteroidImg.Location.Y + MoveY);
            }
        }
        public void Destroy()
        {
            game.asteroids.Remove(this);
            if(AsteroidImg.Parent != null) AsteroidImg.Parent.Controls.Remove(AsteroidImg);
            if(AsteroidImg != null) AsteroidImg.Dispose();
        }
    }
}
