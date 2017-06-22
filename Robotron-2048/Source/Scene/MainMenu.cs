using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Robotron_2048.Source.Scene
{
    /// <summary>
    /// Describes a main menu scene.
    /// </summary>
    sealed class MainMenu : Scene
    {
        /// <summary>
        /// The graphics device.
        /// </summary>
        private readonly GraphicsDevice graphicsDevice;

        /// <summary>
        /// Creates a new main menu scene.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public MainMenu(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            // TODO
        }

        public override void Update(GameTime gameTime)
        {
            TransitionToGameSceneOnKey(gameTime);
        }

        private void TransitionToGameSceneOnKey(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                stage.TransitionInto(new GameScene(graphicsDevice));
            }
        }
    }
}
