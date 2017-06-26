using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Shared.Source.Model;
using Shared.Source.Model.Levels;
using Shared.Source.Util;

namespace Shared.Source.Scene
{
    /// <summary>
    /// The game scene.
    /// </summary>
    public sealed class GameScene : Scene
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
        /// The time elapsed since the last bullet was fired.
        /// </summary>
        private int timeSinceLastbullet = 0;
        public Lives lives;
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
        public readonly Character character;

        /// <summary>
        /// The list of fired bullets.
        /// </summary>
        public readonly IList<Bullet> bullets = new List<Bullet>();
        public readonly IList<Mines> mine = new List<Mines>();
        /// <summary>
        /// The enemy Robots.
        /// </summary>
        public readonly IList<Robot> robots = new List<Robot>();

        /// <summary>
        /// The Humans.
        /// </summary>
        public readonly IList<Human> humans = new List<Human>();

        public readonly IList<Lives> life = new List<Lives>();

        /// <summary>
        /// The score of the player.
        /// </summary>
        public readonly Score score;

        public readonly Lives Life;

        /// <summary>
        /// The current level.
        /// </summary>
        private Level currentLevel;

        /// <summary>
        /// Creates a new game scene.
        /// </summary>
        public GameScene(GraphicsDevice device)
        {
            this.graphicsDevice = device;

            this.entityBatch = new SpriteBatch(device);
            this.character = new Character();

            this.score = new Score();
            this.Life = new Lives();
            TransitionInto(new LevelOne(this));
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

            Life.Draw(entityBatch, gameTime);

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

            #region Drawing the humans
            if (humans.Count > 0)
            {
                int count = 0;
                while (count < humans.Count)
                {
                    Human human = humans[count];

                    human.Draw(entityBatch, gameTime);

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

            #region Drawing the mines
            if (mine.Count > 0)
            {
                int count = 0;
                while (count < mine.Count)
                {
                    Mines mines = mine[count];

                    mines.Draw(entityBatch, gameTime);

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
            int count = 0;
            while (count < bullets.Count)
            {
                Bullet bullet = bullets[count];
                if (bullet != null)
                {
                    #region Checks the intersection between the character, robots and bullets.
                    int robotCount = 0;
                    while (robotCount < robots.Count)
                    {
                        Robot robot = robots[robotCount];
                        if (robot != null)
                        {
                            if (bullet.IntersectsWith(robot))
                            {
                                bullets.Remove(bullet);
                                currentLevel.BulletCollidedWithRobot(robot);
                            }

                            if (robot.IntersectsWith(character))
                            {

                                currentLevel.CharacterCollidedWithRobot(robot);
                                Life.Total_Lives -= 1;
                                if (Life.Total_Lives <= 0)
                                {
                                    
                                }
                            }
                        }

                        robotCount += 1;
                    }

                    if (bullet.isOutOfBounds())
                    {
                        bullets.Remove(bullet);
                    }
                    else
                    {
                        bullet.Update(gameTime);
                    }
                    #endregion
                }

                count += 1;
            }

            count = 0;
            #endregion

            #region Updating the robots
            while (count < robots.Count)
            {
                Robot robot = robots[count];
                if (robot != null)
                {
                    if (robot.IntersectsWith(character))
                    {
                        currentLevel.CharacterCollidedWithRobot(robot);
                    }
                    robot.Update(gameTime);
                }


                count += 1;
            }

            count = 0;
            #endregion

            #region Updating the humans
            while (count < humans.Count)
            {
                Human human = humans[count];
                if (human != null)
                {
                    if (character.IntersectsWith(human))
                    {
                        currentLevel.HumanCollidedWithCharacter(human);
                    }                                     
                    human.Update(gameTime);
                }
                count += 1;
            }

            count = 0;
            #endregion
            #region Updating of the player character
            character.Update(gameTime);

            #endregion


            #region Updating the mines
            while (count < mine.Count)
            {
                Mines mines = mine[count];
                if (mines != null)
                {
                    mines.Update(gameTime);
                }

                count += 1;
            }

            count = 0;
            #endregion

            Life.Update(gameTime);
         
        }
            //endregion

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

        /// <summary>
        /// Transitions from the current level to the specified level.
        /// </summary>
        /// <param name="level">The level to transition to.</param>
        public void TransitionInto(Level level)
        {
            // TODO more stuff when the player changes levels

            robots.Clear();
            bullets.Clear();
            
            this.currentLevel = level;
            this.currentLevel.OnTransition();
        }
    }
}