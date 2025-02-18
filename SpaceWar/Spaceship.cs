using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceWar
{
    internal class Spaceship
    {
        private int Health = 100;
        private int Damage = 25;
        private int Speed = 10;
        public PictureBox player = new PictureBox();
        public List<Bullet> bullets = new List<Bullet>();
        public Game game;
        public Spaceship(Game game)
        {
            this.game = game;
            player.Image = Properties.Resources.SpaceshipRight;
            player.Size = new Size(70, 70);
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.Location = new Point(10, 300);
            player.BackColor = Color.Black;
            game.GameForm.Controls.Add(player);
        }

        
        public void SetHealth(int health) 
        {
            if (Health + health > 100)
            {
                this.Health = 100;
            }
            else this.Health = health;
        }
        public int GetHealth() {return this.Health;}
        public void SetDamage(int damage) {this.Damage = damage;}
        public int GetDamage() {return this.Damage;}
        public void SetSpeed(int speed) {this.Speed = speed;}
        public int GetSpeed() {return this.Speed;}

        //Aracın hareketi burdan sağlanır
        public void Move(bool right, bool left, bool up, bool down) //yön bilgisi 
        {
            if (left && player.Location.X > Speed)
            {
                player.Location = new Point(player.Location.X - Speed, player.Location.Y);
            }
            if (right && player.Location.X < 1200 - player.Width - Speed)
            {
                player.Location = new Point(player.Location.X + Speed, player.Location.Y);
            }
            if (up && player.Location.Y > Speed)
            {
                player.Location = new Point(player.Location.X, player.Location.Y - Speed);
            }
            if (down && player.Location.Y < 700 - player.Height - Speed - 30)
            {
                player.Location = new Point(player.Location.X, player.Location.Y + Speed);
            }
        }

        //Bir mermi nesnesi oluşturur ve ateşlenen mermiler(bullets) listesine ekler
        public void Shoot(Form form)
        {
            Bullet bullet = new Bullet(this);
            if(Damage == 25) bullet.bulletBox.Image = Properties.Resources.SpaceShipDefaultBullet;
            if(Damage > 25) bullet.bulletBox.Image = Properties.Resources.PowerUpBullet;
            bullet.bulletBox.Location = new Point(player.Location.X + 70, player.Location.Y + 30);
            bullet.Speed = 20;
            bullet.Damage = Damage;
            bullet.Direction = 1;
            bullet.SetIsActive(true);
            bullets.Add(bullet);
            form.Controls.Add(bullet.bulletBox);
        }

        //Aracın aldığı hasarı işler ve can seviyesini günceller.
        public void TakeDamage(int amount)
        {
            if (Health - amount < 0) Health = 0;
            else Health -= amount;
            if(Health <= 0)
            {
                game.IsGameOver = true;
            }
        }
    }
}
