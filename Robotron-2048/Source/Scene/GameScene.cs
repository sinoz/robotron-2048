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

            bullets.Add(new Bullet(character ));
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
            // TODO
            #endregion

            #region Updating of Bullets
            if (bullets.Count > 0)
            {
                int count = 0;
                while (count < bullets.Count)
                {
                    Bullet bullet = bullets[count];

                    // TODO check if bullet should be removed
                    bullet.Update(gameTime);
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
