using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
//using System.Reflection.Emit;

namespace SpaceWar
{
    /*Bu sınıf, oyunun genel akışını yönetmelidir ve tüm nesneler arasındaki ilişkileri kontrol
    etmelidir.Oyuncunun uzay aracı, düşmanlar ve oyun döngüsü gibi bileşenler bu sınıf
    tarafından yönetilmelidir.*/
    internal class Game
    {
        public bool IsGameOver = false;
        public bool right, left, up, down;
        public int EnemyCounter = 0, EnemyShootCounter = 0, AsteroidCounter = 0;
        public int Level = 1, LevelUpCounter = 0, AddPowerUpCounter = 0;
        public List<Enemy> enemies = new List<Enemy>();
        public List<Asteroid> asteroids = new List<Asteroid>();
        public List<PowerUp> powerups = new List<PowerUp>();
        public CollisionDetector collisionDetector = new CollisionDetector();
        public Random random = new Random();
        public Label SkorLabel = new Label();
        public Timer timer = new Timer();
        public Timer FormTimer;
        public SkorManager skorManager;
        public Spaceship player;
        public Form GameForm;
        public PictureBox LevelUpImg;
        public Font EndGameFont, HighScoreFont;
        public Game(Form form)
        {
            this.GameForm = form;
        }
        
        //Oyunu başlatmalıdır, oyuncu ve düşmanları oluşturur.
        public void StartGame()
        {
            player = new Spaceship(this);
            timer.Interval = 500;
            timer.Tick += GameTimer;
            timer.Start();
            skorManager = new SkorManager(this);
            for (int i = 0; i < 2; i++) 
            { 
                BasicEnemy basicEnemy = new BasicEnemy(this);
                enemies.Add(basicEnemy);
                FastEnemy fastEnemy = new FastEnemy(this);
                enemies.Add(fastEnemy);
            }
        }
        //Oyunun her turunda(frame) oyuncu ve düşmanların hareketlerini ve atışlarını günceller.
        public void UpdateGame() 
        {
            SkorLabel.Text ="LEVEL " + Level + " | SKOR " + skorManager.TotalSkor;
            CheckCollisions()
            if(player != null) player.Move(right,left,up,down);
            for (int i = player.bullets.Count - 1; i >= 0; i--)
            {
                player.bullets[i].Move();
            }
            for (int i = enemies.Count - 1; i >= 0;i--)
            {
                enemies[i].Move();
            }
            if(asteroids.Count > 0)
            {
                for(int i = asteroids.Count - 1; i >= 0; i--)
                {
                    asteroids[i].Move();
                }
            }
            if(IsGameOver || Level == 11) EndGame();
        }
        //Mermiler ve düşmanların birbirleriyle çarpışıp çarpışmadığını kontrol eder.
        public void CheckCollisions()
        {
            //collisionDetector.CheckCollision(player,enemies);
            collisionDetector.CheckCollision1(this);
            //collisionDetector.CheckBulletCollision(player, enemies);
            collisionDetector.CheckBulletCollision1(this);
        }
        public void GameTimer(object sender, EventArgs e)
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i] is FastEnemy fastEnemy)
                {
                    fastEnemy.FindDistance(timer.Interval);
                }
                if (enemies[i] is StrongEnemy strongEnemy)
                {
                    strongEnemy.FindDistance(timer.Interval);
                }
            }
            if (IsReadyForLevelUp())
            {
                AddEnemies(EnemyNumberByLevel(Level));
            }
            if(enemies.Count > 0)
            {
                EnemyShoot();
                AddAsteroid();
                AddPowerUp();
            }
            if(enemies.Count == 0)
            {
                for(int i = asteroids.Count - 1;i >= 0; i--)
                {
                    asteroids[i].Destroy();
                }
            }
        }

        public void AddPowerUp()
        {
            if(AddPowerUpCounter == 16)
            {
                PowerUp powerUp = new PowerUp(this);
                AddPowerUpCounter = 0;
            }
            if(powerups.Count > 0)
            {
                for(int i = powerups.Count - 1; i >= 0; i--)
                {
                    if (powerups[i].IsTaken)
                    {
                        powerups[i].TakenTime++;
                        if (powerups[i].TakenTime == 3)
                        {
                            powerups[i].RemoveImg();

                        }
                        if (powerups[i].TakenTime == 12)
                        {
                            powerups[i].UndoPowerUp();
                        }
                    }
                }
            }
            AddPowerUpCounter++;
        }
        public bool IsReadyForLevelUp()
        {
            if (EnemyCounter <= EnemyNumberByLevel(Level)) return true;
            if (enemies.Count == 0)
            {
                if(LevelUpCounter == 0)
                {
                    AddOrDeleteLevelUpImg(1);
                    LevelUpCounter++;
                    return false;
                }
                if(LevelUpCounter == 2)
                {
                    AddOrDeleteLevelUpImg(0);
                    LevelUpCounter++;
                    return false;
                }
                if(LevelUpCounter == 6)
                {
                    return true;
                }
                else
                {
                    LevelUpCounter++;
                    return false;
                }
            }
            else return false;
        }
        public void AddEnemies(int EnemyNum)
        {
            int RandomEnemy;
            if(EnemyCounter <= EnemyNum)
            {
                EnemyCounter++;
                if (Level < 3) RandomEnemy = random.Next(0, 2);
                else if (Level < 5) RandomEnemy = random.Next(0, 3);
                else RandomEnemy = random.Next(0, 4);
                if (RandomEnemy == 0)
                {
                    BasicEnemy basicEnemy = new BasicEnemy(this);
                    enemies.Add(basicEnemy);
                }
                else if (RandomEnemy == 1)
                {
                    FastEnemy fastEnemy = new FastEnemy(this);
                    enemies.Add(fastEnemy);
                }
                else if (RandomEnemy == 2)
                {
                    StrongEnemy strongEnemy = new StrongEnemy(this);
                    enemies.Add(strongEnemy);
                }
                else if (RandomEnemy == 3)
                {
                    BossEnemy bossEnemy = new BossEnemy(this);
                    enemies.Add(bossEnemy);
                }
            }
            else
            {
                Level++;
                EnemyCounter = 0;
                LevelUpCounter = 0;
            }
        }
        public int EnemyNumberByLevel(int level)
        {
            if  (level == 11) return 0;
            else return level*5;
        }

        public void EnemyShoot()
        {
            if(EnemyShootCounter == 8)
            {
                for(int i = enemies.Count - 1; i >= 0; i--)
                {
                    if(enemies[i] is BossEnemy bossEnemy)
                    {
                        enemies[i].Shoot();
                    }
                }
                EnemyShootCounter = 0;
            }
            else EnemyShootCounter++;

        }

        public void AddAsteroid()
        {
            if(Level < 5)
            {
                if(AsteroidCounter == 20)
                {
                    Asteroid asteroid = new Asteroid(this);
                    AsteroidCounter = 0;
                }
                else AsteroidCounter++;
            }
            else
            {
                if(AsteroidCounter == 10)
                {
                    Asteroid asteroid = new Asteroid(this);
                    AsteroidCounter = 0;
                }
                else AsteroidCounter++;
            }
        }
        public void AddOrDeleteLevelUpImg(int Delete0_Add1)
        {
            if(Delete0_Add1 == 1 && Level != 10)
            {
                LevelUpImg = new PictureBox();
                LevelUpImg.Size = new Size(600, 120);
                LevelUpImg.Location = new Point(300, 250);
                LevelUpImg.SizeMode = PictureBoxSizeMode.StretchImage;
                LevelUpImg.BackColor = Color.Transparent;
                LevelUpImg.Image = Properties.Resources.LevelUp;
                GameForm.Controls.Add(LevelUpImg);
            }
            if(Delete0_Add1 == 0)
            {
                if(LevelUpImg.Parent != null) GameForm.Controls.Remove(LevelUpImg);
                if(LevelUpImg != null) LevelUpImg.Dispose();
            }
        }
        //Oyun sona erdiğinde çağrılır, skoru ve oyun sonu mesajlarını gösterir. Oyun skorunu bir text dosyasına kaydeder.
        public void EndGame()
        {
            GameForm.Controls.Clear();
            skorManager.SaveScoreToFile();
            if (Level <= 10)
            {
                GameForm.BackgroundImage = Properties.Resources.GameOverScreen;
            }
            else if (Level > 10)
            {
                GameForm.BackgroundImage = Properties.Resources.WinScreen;
            }
            Label LastScore = new Label
            {
                Text = "YOURSCORE " + skorManager.TotalSkor,
                Font = EndGameFont,
                Location = new Point(270, 392),
                Size = new Size(335, 40),
                ForeColor = Color.Yellow,
                BackColor = Color.FromArgb(13, 3, 27)
            };
            Label HighScore = new Label
            {
                Text = "HİGHSCORE " + skorManager.GetHighestScore(),
                Font = EndGameFont,
                Location = new Point(600, 392),
                Size = new Size(350, 40),
                ForeColor = Color.Yellow,
                BackColor = Color.FromArgb(13, 3, 27)
            };
            if (skorManager.TotalSkor == skorManager.GetHighestScore())
            {
                Label NewHighScore = new Label
                {
                    Text = "NEW HİGHSCORE!",
                    Font = HighScoreFont,
                    Location = new Point(350, 490),
                    Size = new Size(520, 60),
                    ForeColor = Color.Red,
                    BackColor = Color.FromArgb(13, 3, 27)
                };
                GameForm.Controls.Add(NewHighScore);
            }
            GameForm.Controls.Add(LastScore);
            GameForm.Controls.Add(HighScore);
            FormTimer.Stop();
            skorManager.timer.Stop();
            timer.Stop();
        }
    }
}
