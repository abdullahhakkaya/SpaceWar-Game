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
    internal class BasicEnemy : Enemy
    {
        //PictureBox BasicEnemyImg = new PictureBox();
        //Game game;
        public BasicEnemy(Game game)
        {
            this.game = game;
            SetHealth(50);
            SetSpeed(3);
            SetDamage(10);
            Point = 10;
            EnemyImg = new PictureBox
            {
                Image = Properties.Resources.BasicEnemy,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(50, 50),
                Location = new Point(spawnX, spawnY),
                BackColor = Color.Black
            };
            game.GameForm.Controls.Add(EnemyImg);
        }
        public override void Attack()
        {
            game.player.TakeDamage(GetDamage());
            Destroy();
        }

        public override void Move()
        {
            EnemyImg.Location = new Point(EnemyImg.Location.X - GetSpeed(), EnemyImg.Location.Y);
            if (EnemyImg.Left < 0)
            {
                game.GameForm.Controls.Remove(EnemyImg);
                game.enemies.Remove(this);
                EnemyImg.Dispose();
            }
        }
        public override void Shoot() { }
    }
}
