using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceWar
{

    internal class Skor
    {
        public int ElapsedTime = 0;
        public PictureBox skorImg = new PictureBox();
        public Skor(int skor, Point point)
        {
            if (skor == 0 || skor == null) return;
            skorImg.Location = point;
            skorImg.Size = new Size(30, 18);
            skorImg.SizeMode = PictureBoxSizeMode.StretchImage;
            skorImg.BackColor = Color.Transparent;
            skorImg.SendToBack();
            if (skor == 10) skorImg.Image = Properties.Resources.Point10;
            if (skor == 20) skorImg.Image = Properties.Resources.Point20;
            if (skor == 30) skorImg.Image = Properties.Resources.Point30;
            if (skor == 50) skorImg.Image = Properties.Resources.Point50;
        }
        public void DeletePointPic()
        {
            skorImg.Parent.Controls.Remove(skorImg);
            skorImg.Dispose();
        }
    }
}
