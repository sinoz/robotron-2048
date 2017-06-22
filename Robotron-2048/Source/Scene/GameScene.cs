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

        private int timeSinceLastbullet = 0;

        private int millisecondsPerbullet = 250;
       

        /// <summary>
        /// The game character.
        /// </summary>
        private Character character;

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
            int Bullet_X = 0;
            int Bullet_Y = 1;
        public override void Update(GameTime gameTime)
        {

           

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Bullet_Y = -1;
                Bullet_X = 0;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Bullet_Y = 1;
                Bullet_X = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Bullet_X = 1;
                Bullet_Y = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Bullet_X = -1;
                Bullet_Y = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Bullet_Y = -1;
                Bullet_X = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Bullet_Y = 1;
                Bullet_X = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Bullet_Y = -1;
                Bullet_X = -1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Bullet_Y = 1;
                Bullet_X = -1;
            }

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
            timeSinceLastbullet += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastbullet > millisecondsPerbullet)
            {
                
                

                bullets.Add(new Bullet(character, new Vector2(Bullet_X, Bullet_Y)));
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
                    if (bullet.position.X < -Bullet.Length || bullet.position.Y <- Bullet.Length
                        || bullet.position.X > RobotronGame.appWidth || bullet.position.Y > RobotronGame.appHeight)
                    {
                        bullets.Remove(bullet);
                    }
                    else
                    {
                        // TODO check if bullet should be removed
                        bullet.Update(gameTime);
                    }

                    count += 1;
                }
            }
            #endregion

            #region Updating of the player character
            character.Update(gameTime);
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
