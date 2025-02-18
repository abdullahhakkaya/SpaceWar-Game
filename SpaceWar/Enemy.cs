using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceWar
{
    abstract class Enemy
    {
        private int Health;
        private int Speed;
        private int Damage;
        public double Distance;
        public int TargetX, TargetY;
        public int Point;
        private static Random randomSpawn = new Random();
        public int spawnX = 1200;//randomSpawn.Next(1000, 1100);
        public int spawnY = randomSpawn.Next(0, 600);
        public PictureBox EnemyImg;
        public Game game;

        
        public void SetHealth(int health) { this.Health = health; }
        public void SetSpeed(int speed) { this.Speed = speed; }
        public void SetDamage(int damage) { this.Damage = damage; }
        public int GetHealth() { return this.Health; }
        public int GetSpeed() { return this.Speed; }
        public int GetDamage() { return this.Damage; }

        //Düşmanın belirli bir hareket algoritmasına göre ekranda ilerlemesini sağlar
        public abstract void Move();
        //Düşmanın oyuncuya saldırmasını sağlar (soyut metot).
        public abstract void Attack();
        public abstract void Shoot();

        //Düşmanın aldığı hasarı işler, can seviyesi sıfıra ulaşırsa Destroy() çağrılır.
        public void TakeDamage(int amount)
        {
            Health -= amount;
            if(Health <= 0) Destroy();
        }

        //Düşman yok edilir ve oyun skoruna katkı yapar.
        public void Destroy()
        {
            if(EnemyImg.Parent != null) EnemyImg.Parent.Controls.Remove(EnemyImg);
            game.enemies.Remove(this);
            if(Point != 0) game.skorManager.AddPointAndPicture(this);
            if(EnemyImg != null )
            {
                EnemyImg.Dispose();
            }
        }

        public double FindShortestPath()
        {
            var playerLocation = game.player.player.Location;
            TargetX = playerLocation.X;
            TargetY = playerLocation.Y;
            return (Math.Sqrt(Math.Pow(EnemyImg.Location.X - playerLocation.X, 2) + Math.Pow(EnemyImg.Location.Y - playerLocation.Y, 2)));
        }
    }
}
