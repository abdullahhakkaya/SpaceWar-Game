using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceWar
{
    internal class CollisionDetector
    {
        //Oyuncunun uzay aracı ile düşmanın çarpışmasını kontrol eder.
        public void CheckCollision(Spaceship player, List<Enemy> enemies)
        {
            Rectangle playerR = new Rectangle(player.player.Location, player.player.Size);
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                Rectangle enemyR = new Rectangle(enemies[i].EnemyImg.Location, enemies[i].EnemyImg.Size);
                if (enemyR.IntersectsWith(playerR))
                {
                    enemies[i].Point = 0;
                    enemies[i].Attack();
                }
            }
        }
        public void CheckCollision1(Game game)
        {
            Spaceship player = game.player;
            List<Enemy> enemies = game.enemies;
            List<Asteroid> asteroids = game.asteroids;
            Rectangle playerR = new Rectangle(player.player.Location, player.player.Size);
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                Rectangle enemyR = new Rectangle(enemies[i].EnemyImg.Location, enemies[i].EnemyImg.Size);
                if (enemyR.IntersectsWith(playerR))
                {
                    enemies[i].Point = 0;
                    enemies[i].Attack();
                }
                if(asteroids.Count > 0)
                {
                    for (int j = asteroids.Count - 1; j >= 0; j--)
                    {
                        Rectangle asteroidR = new Rectangle(asteroids[j].AsteroidImg.Location, asteroids[j].AsteroidImg.Size);
                        if (asteroidR.IntersectsWith(playerR))
                        {
                            player.TakeDamage(asteroids[j].Damage);
                            asteroids[j].Destroy();
                        }
                        else if (asteroidR.IntersectsWith(enemyR))
                        {
                            enemies[i].Point = 0;
                            enemies[i].TakeDamage(2*asteroids[j].Damage);
                            asteroids[j].Destroy();
                        }
                    }
                }
            }
            if(game.powerups.Count > 0)
            {
                for(int i =  game.powerups.Count - 1;  i >= 0; i--)
                {
                    
                    if (!game.powerups[i].IsTaken)
                    {
                        Rectangle powerupR = new Rectangle(game.powerups[i].PowerUpImg.Location, game.powerups[i].PowerUpImg.Size);
                        if (powerupR.IntersectsWith(playerR))
                        {
                            game.powerups[i].TakePowerUp();
                        } 
                    }
                }
            }
        }
        //Mermilerin düşmanlara veya oyuncuya isabet edip etmediğini kontrol eder.
        public void CheckBulletCollision(Spaceship player, List<Enemy> enemies)
        {
            Rectangle playerR = new Rectangle(player.player.Location, player.player.Size);
            for (int i = player.bullets.Count - 1; i >= 0; i--)
            {
                if (!player.bullets[i].GetIsActive()) continue;
                Rectangle bulletR = new Rectangle(player.bullets[i].bulletBox.Location, player.bullets[i].bulletBox.Size);
                for (int j = enemies.Count - 1; j >= 0; j--)
                {
                    Rectangle enemyR = new Rectangle(enemies[j].EnemyImg.Location, enemies[j].EnemyImg.Size);
                    if (player.bullets[i].Direction == 1 && bulletR.IntersectsWith(enemyR))
                    {
                        enemies[j].TakeDamage(player.bullets[i].OnHit());
                        break;
                    }
                    else if (player.bullets[i].Direction == -1 && bulletR.IntersectsWith(playerR))
                    {
                        player.TakeDamage(player.bullets[i].OnHit());
                        break;
                    }
                }
            }
        }
        public void CheckBulletCollision1(Game game)
        {
            Spaceship player = game.player;
            List<Enemy> enemies = game.enemies;
            Rectangle playerR = new Rectangle(player.player.Location, player.player.Size);
            for (int i = player.bullets.Count - 1; i >= 0; i--)
            {
                if (!player.bullets[i].GetIsActive()) continue;
                Rectangle bulletR = new Rectangle(player.bullets[i].bulletBox.Location, player.bullets[i].bulletBox.Size);
                for (int j = enemies.Count - 1; j >= 0; j--)
                {
                    Rectangle enemyR = new Rectangle(enemies[j].EnemyImg.Location, enemies[j].EnemyImg.Size);
                    if (player.bullets[i].Direction == 1 && bulletR.IntersectsWith(enemyR))
                    {
                        enemies[j].TakeDamage(player.bullets[i].OnHit());
                        break;
                    }
                    else if (player.bullets[i].Direction == -1 && bulletR.IntersectsWith(playerR))
                    {
                        player.TakeDamage(player.bullets[i].OnHit());
                        break;
                    }
                }
                if (game.asteroids.Count > 0)
                {
                    for (int k = game.asteroids.Count - 1; k >= 0; k--)
                    {
                        Rectangle asteroidR = new Rectangle(game.asteroids[k].AsteroidImg.Location, game.asteroids[k].AsteroidImg.Size);
                        if (asteroidR.IntersectsWith(bulletR))
                        {
                            player.bullets[i].SetIsActive(false); 
                        }
                    }
                }
            }
        }
    }
}
