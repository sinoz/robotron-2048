using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        public readonly SpriteBatch batch;

        /// <summary>
        /// The game character.
        /// </summary>
        private Character character;

        /// <summary>
        /// Creates a new game scene.
        /// </summary>
        public GameScene(GraphicsDevice device)
        {
            this.batch = new SpriteBatch(device);
            this.character = new Character(batch, Game1.characterDownTex, 1, 3, CharacterVelocity);
        }

        public override void Draw(GameTime gameTime)
        {
            character.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            character.Update(gameTime);
        }

        public override void Hide()
        {
            // TODO
        }

        public override void Show()
        {
            // TODO
        }

        public override void Dispose()
        {
            // TODO
        }
    }
}
