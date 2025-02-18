using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceWar
{
    internal class PowerUp
    {
        private Game game;
        private Random random = new Random();
        public PictureBox PowerUpImg;
        public int TakenTime = 0;
        public int SelectPowerUp;
        public bool IsTaken = false;
        public PowerUp(Game game)
        {
            SelectPowerUp = random.Next(0, 3);
            this.game = game;
            PowerUpImg = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Properties.Resources.PowerUpDefoult,
                Size = new Size(40, 40),
                BackColor = Color.Transparent,
                Location = new Point(random.Next(100,700), random.Next(50,600))
            };
            PowerUpImg.SendToBack();
            game.GameForm.Controls.Add(PowerUpImg);
            game.powerups.Add(this);
        }

        public void TakePowerUp()
        {
            IsTaken = true;
            PowerUpImg.Size = new Size(70, 52);
            if (SelectPowerUp == 0) //+25 Health
            {
                PowerUpImg.Image = Properties.Resources.PowerUpHealth;
                game.player.SetHealth(game.player.GetHealth() + 25);
            }
            if(SelectPowerUp == 1) //2x Damage
            {
                PowerUpImg.Image = Properties.Resources.PowerUpDamage;
                game.player.SetDamage(game.player.GetDamage() * 2);
            }
            if(SelectPowerUp == 2) //+2 Speed
            {
                PowerUpImg.Image= Properties.Resources.PowerUpSpeed;
                game.player.SetSpeed(game.player.GetSpeed() + 2);
            }  
        }
        
        public void UndoPowerUp()
        {
            if (SelectPowerUp == 1)
            {
                game.player.SetDamage(game.player.GetDamage() / 2);
            }
            if(SelectPowerUp == 2)
            {
                game.player.SetSpeed(game.player.GetSpeed() - 2);
            }
            Destroy();
        }

        public void RemoveImg()
        {
            if(PowerUpImg.Parent != null) PowerUpImg.Parent.Controls.Remove(PowerUpImg);
        }

        public void Destroy()
        {
            game.powerups.Remove(this);
            if(PowerUpImg != null)
            {
                PowerUpImg.Dispose();
            }
        }
    }
}
