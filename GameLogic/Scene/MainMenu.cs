using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameLogic.Util;
using Microsoft.Xna.Framework.Media;

namespace GameLogic.Scene
{
    /// <summary>
    /// Describes a main menu scene.
    /// </summary>
    public class MainMenu : Scene
    {
        /// <summary>
        /// The graphics device.
        /// </summary>
        private GraphicsDevice graphicsDevice;

        /// <summary>
        /// Creates a new main menu scene.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public MainMenu(GraphicsDevice graphicsDevice)
        {
            MediaPlayer.Play(LoadedContent.mainMenuSong);
            this.graphicsDevice = graphicsDevice;
        }

        private void TransitionToGameSceneOnKey(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                MediaPlayer.Stop();
                stage.TransitionInto(new GameScene(graphicsDevice));
            }
        }
    }
}
