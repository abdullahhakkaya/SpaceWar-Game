using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceWar
{
    internal class SkorManager
    {
        public int TotalSkor = 0;
        public Timer timer;
        private List<Skor> skorList;
        private string ScoreFile = Path.Combine(Application.StartupPath, "Scores.txt");
        Game game;
        public SkorManager(Game game)
        {
            this.game = game;
            skorList = new List<Skor>();
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += DeletePoints;
            timer.Start();
        }
        public int GetHighestScore()
        {
            int HighestScore = 0;
            if (File.Exists(ScoreFile))
            {
                string[] lines = File.ReadAllLines(ScoreFile);
                foreach (string line in lines)
                {
                    int score;
                    if(int.TryParse(line, out score))
                    {
                        if(score > HighestScore) HighestScore = score;
                    }
                }
            }
            else
            {
                // Eğer dosya yoksa, dosyayı oluştur ve high score'u sıfır yap
                File.WriteAllText(ScoreFile, "0");
            }
            return HighestScore;
        }
        public void SaveScoreToFile()
        {
            File.AppendAllText(ScoreFile, TotalSkor.ToString() + Environment.NewLine);
        }
   
        public void AddPointAndPicture(Enemy enemy)
        {
            TotalSkor += enemy.Point;
            Skor skor = new Skor(enemy.Point, enemy.EnemyImg.Location);
            game.GameForm.Controls.Add(skor.skorImg);
            skorList.Add(skor);
        }
        public void DeletePoints(object sender, EventArgs e)
        {
            for(int i = skorList.Count - 1; i >= 0; i--)
            {
                Skor skor = skorList[i];
                skor.ElapsedTime += timer.Interval;
                if(skor.ElapsedTime >= 800)
                {
                    skor.DeletePointPic();
                    skorList.RemoveAt(i);
                }
            }
        }
    }
}
