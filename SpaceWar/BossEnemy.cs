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
    internal class BossEnemy : Enemy
    {
        //PictureBox BasicEnemyImg = new PictureBox();
        //Game game;
        public BossEnemy(Game game)
        {
            this.game = game;
            SetHealth(100);
            SetSpeed(2);
            SetDamage(20);
            Point = 50;
            EnemyImg = new PictureBox
            {
                Image = Properties.Resources.BossEnemy,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(75, 75),
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

        public override void Shoot()
        {
            Bullet bullet = new Bullet(game.player);
            bullet.SetIsActive(true);
            bullet.bulletBox.Image = Properties.Resources.EnemyBullet;
            bullet.bulletBox.Size = new Size(40, 20);
            bullet.bulletBox.Location = new Point(EnemyImg.Location.X - 40, EnemyImg.Location.Y + 27);
            bullet.Speed = 8;
            bullet.Damage = GetDamage();
            bullet.Direction = -1;
            game.player.bullets.Add(bullet);
            game.GameForm.Controls.Add(bullet.bulletBox);
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
    }
}
