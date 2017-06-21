using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Robotron_2048
{
    /// <summary>
    /// The game scene.
    /// </summary>
    sealed class GameScene : Scene
    {
        /// <summary>
        /// The default velocity at which a character can move across the screen.
        /// </summary>
        const int CharacterVelocity = 350;

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
            this.character = new Character(Game1.characterDownTex, 1, 3, CharacterVelocity);

            this.score = new Score();
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            entityBatch.Begin();
            character.Draw(entityBatch, gameTime);

            if (bullets.Count > 0)
            {
                int count = 0;
                while (count < bullets.Count)
                {
                    Bullet bullet = bullets[count];
                    
                    bullet.Draw(entityBatch, gameTime);
                }
            }
            entityBatch.End();

            batch.Begin();
            score.Draw(batch, gameTime);
            batch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (bullets.Count > 0)
            {
                int count = 0;
                while (count < bullets.Count)
                {
                    Bullet bullet = bullets[count];

                    // TODO check if bullet should be removed
                    bullet.Update(gameTime);
                }
            }

            character.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                getStage().TransitionInto(new MainMenu(graphicsDevice));
            }
        }
    }
}
