using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceWar
{
    //Oyuncuya doğrusal bir yolla saldırır. Başlangıç noktasından başlayarak sadece yatay hareket eder. (Düşük hasar)
    internal class StrongEnemy : Enemy
    {
        public int ElapsedTime = 0;
        public int TimerInvertal = 2000;
        public int MoveX, MoveY;
        public StrongEnemy(Game game)
        {
            this.game = game;
            SetHealth(75);
            SetSpeed(2);
            SetDamage(15);
            Point = 30;
            EnemyImg = new PictureBox
            {
                Image = Properties.Resources.StrongEnemy,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(60, 60),
                Location = new Point(spawnX, spawnY),
                BackColor = Color.Black
            };
            game.GameForm.Controls.Add(EnemyImg);
            FindDistance(2000);
        }
        public override void Attack()
        {
            game.player.TakeDamage(GetDamage());
            Destroy();
        }

        public override void Move()
        {
            if (Distance == 0) return;
            EnemyImg.Location = new Point(EnemyImg.Location.X + MoveX, EnemyImg.Location.Y + MoveY);
        }
        public void FindDistance(int invertal)
        {
            ElapsedTime += invertal;
            if (ElapsedTime >= TimerInvertal)
            {
                Distance = FindShortestPath();
                ElapsedTime = 0;
                double TempMoveX = (TargetX - EnemyImg.Location.X) / Distance * GetSpeed();
                double TempMoveY = (TargetY - EnemyImg.Location.Y) / Distance * GetSpeed();
                MoveX = Convert.ToInt32(Math.Round(TempMoveX));
                MoveY = Convert.ToInt32(Math.Round(TempMoveY));
            }
        }
        public override void Shoot() { }
    }
}
