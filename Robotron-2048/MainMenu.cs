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

        public override void Draw(GameTime gameTime)
        {
            // TODO
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                getStage().TransitionInto(new GameScene(graphicsDevice));
            }
        }
    }
}
