using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Robotron_2048.Source.Model;
using Robotron_2048.Source.Util;

namespace Robotron_2048.Source.Scene
{
    /// <summary>
    /// The game scene.
    /// </summary>
    sealed class GameScene : Scene
    {
        /// <summary>
        /// The sprite batch specifically for this game scene to draw the game character
        /// and other entities on.
        /// </summary>
        private readonly SpriteBatch entityBatch;

        /// <summary>
        /// The graphics device.
        /// </summary>
        private readonly GraphicsDevice graphicsDevice;

        /// <summary>
        /// The list of fired bullets.
        /// </summary>
        private IList<Bullet> bullets = new List<Bullet>();

        /// <summary>
        /// The time elapsed since the last bullet was fired.
        /// </summary>
        private int timeSinceLastbullet = 0;

        /// <summary>
        /// The time span between firing bullets.
        /// </summary>
        private int millisecondsPerbullet = 250;

        /// <summary>
        /// The last direction bullets moved towards.
        /// </summary>
        private int lastBulletDirectionX = 0, lastBulletDirectionY = 1;

        /// <summary>
        /// The game character.
        /// </summary>
        private Character character;

        /// <summary>
        /// The enemy Robots.
        /// </summary>
        private IList<Robot> robots = new List<Robot>();

        /// <summary>
        /// amount of robots to spawn
        /// </summary>
        public int spawn = 25;

        /// <summary>
        /// Random method.
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// The score of the player.
        /// </summary>
        private Score score;

        /// <summary>
        /// Creates a new game scene.
        /// </summary>
        public GameScene(GraphicsDevice device)
        {
            this.graphicsDevice = device;

            this.entityBatch = new SpriteBatch(device);
            this.character = new Character();

            this.score = new Score();

            #region Adding the robots
            for (int i = 1; i <= spawn; i++)
            {
                int Rand_Y = random.Next(1, 3) == 1 ? random.Next(0, 240) : random.Next(340, 550);
                int Rand_X = random.Next(1, 3) == 1 ? random.Next(0, 340) : random.Next(440, 750);
                robots.Add(new Robot(new Vector2(Rand_X, Rand_Y)));
            }
            #endregion
            
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            DrawEntities(batch, gameTime);
            DrawScore(batch, gameTime);
        }

        /// <summary>
        /// Draws all of the entities such as player characters and bullets.
        /// </summary>
        /// <param name="batch">The SpriteBatch to draw the entities on.</param>
        /// <param name="gameTime">The delta time.</param>
        private void DrawEntities(SpriteBatch batch, GameTime gameTime)
        {
            entityBatch.Begin();

            #region Drawing the player character
            character.Draw(entityBatch, gameTime);
            #endregion

            #region Drawing the enemy robots
            if (robots.Count > 0)
            {
                int count = 0;
                while (count < robots.Count)
                {
                    Robot robot = robots[count];

                    robot.Draw(entityBatch, gameTime);

                    count += 1;
                }
            }
            #endregion

            #region Drawing the fired bullets
            if (bullets.Count > 0)
            {
                int count = 0;
                while (count < bullets.Count)
                {
                    Bullet bullet = bullets[count];

                    bullet.Draw(entityBatch, gameTime);
                    
                    count += 1;
                }
            }
            #endregion
            
            entityBatch.End();
        }

        /// <summary>
        /// Draws the player's current score.
        /// </summary>
        /// <param name="batch">The SpriteBatch to draw the player's score on. </param>
        /// <param name="gameTime">The delta time.</param>
        private void DrawScore(SpriteBatch batch, GameTime gameTime)
        {
            batch.Begin();
            score.Draw(batch, gameTime);
            batch.End();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateEntities(gameTime);
            TransitionToMainMenuOnKey(gameTime);
        }

        /// <summary>
        /// Updates the entities.
        /// </summary>
        /// <param name="gameTime">The delta time.</param>
        private void UpdateEntities(GameTime gameTime)
        {
            #region Adding new bullets
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                lastBulletDirectionY = -1;
                lastBulletDirectionX = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                lastBulletDirectionY = 1;
                lastBulletDirectionX = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                lastBulletDirectionX = 1;
                lastBulletDirectionY = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                lastBulletDirectionX = -1;
                lastBulletDirectionY = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                lastBulletDirectionY = -1;
                lastBulletDirectionX = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                lastBulletDirectionY = 1;
                lastBulletDirectionX = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                lastBulletDirectionY = -1;
                lastBulletDirectionX = -1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                lastBulletDirectionY = 1;
                lastBulletDirectionX = -1;
            }

            timeSinceLastbullet += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastbullet > millisecondsPerbullet)
            {
                bullets.Add(new Bullet(character, new Vector2(lastBulletDirectionX, lastBulletDirectionY)));

                timeSinceLastbullet = 0;
            }
            #endregion

            #region Updating of Bullets

            if (bullets.Count > 0)
            {
                int count = 0;
                while (count < bullets.Count)
                {
                    Bullet bullet = bullets[count];
                    
                    if (bullet.shouldBeRemoved())
                    {
                        bullets.Remove(bullet);  
                    }
                    else
                    {
                        bullet.Update(gameTime);
                    }

                    count += 1;
                }
            }
            #endregion

            #region Updating of the player character
            character.Update(gameTime);
            Rectangle char_rect = character.getRectangleCharacter();

            #endregion

            #region Updating the robots
            foreach (Robot robot in robots)
                robot.Update(gameTime);

            #endregion

            #region Checks the intersection between character, robots and bullets.
            if (bullets.Count > 0)
            {
                int count = 0;
                while (count < bullets.Count)
                {
                    Bullet bullet = bullets[count];
                    Rectangle rect1 = bullet.getrectanglebullet();
                    int count2 = 0;
                    while (count2 < robots.Count)
                    {
                        Robot robot = robots[count2];
                        Rectangle rect2 = robot.getRectangleRobot();
                        if (rect1.Intersects(rect2)) 
                        {
                            bullets.Remove(bullet);
                            robots.Remove(robot);

                        }
                        else if (rect2.Intersects(char_rect))
                        {
                            character.position.X = 390;
                            character.position.Y = 290;
                        }
                        count2 +=  1;
                    }


                    count += 1;
                }
            }
            #endregion
        }

        /// <summary>
        /// Transitions into the main menu scene when the user has pressed the 'Enter' key.
        /// </summary>
        /// <param name="gameTime">The delta time.</param>
        private void TransitionToMainMenuOnKey(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                stage.TransitionInto(new MainMenu(graphicsDevice));
            }
        }
    }
}
