using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shared.Source.Scene;

namespace Shared.Source.Util
{
    /// <summary>
    /// A frame-per-second counter to keep track of the application's
    /// overall graphical performance.
    /// </summary>
    public sealed class FPSCounter : IUpdatable
    {
        /// <summary>
        /// The time span in between FPS updating.
        /// </summary>
        private TimeSpan fpsCounterElapsedTime = TimeSpan.Zero;

        /// <summary>
        /// The FPS counter.
        /// </summary>
        private int fpsCounter = 0;

        /// <summary>
        /// The initial window title assigned on startup.
        /// </summary>
        private string initialTitle;

        /// <summary>
        /// A reference to the Game instance to have access to the application title.
        /// </summary>
        private Game game;

        /// <summary>
        /// Creates a new FPSCounter.
        /// </summary>
        /// <param name="game">The RobotronGame instance.</param>
        public FPSCounter(Game game)
        {
            this.game = game;
            this.initialTitle = game.Window.Title;
        }

        public void Update(GameTime gameTime)
        {
            #region FPS Counting logic - Borrowed code from Nez
            fpsCounter++;
            fpsCounterElapsedTime += gameTime.ElapsedGameTime;
            if (fpsCounterElapsedTime >= TimeSpan.FromSeconds(1))
            {
                var totalMemory = (GC.GetTotalMemory(false) / 1048576f).ToString("F");
                game.Window.Title = string.Format("{0} {1} fps - {2} MB", initialTitle, fpsCounter, totalMemory);

                fpsCounter = 0;
                fpsCounterElapsedTime -= TimeSpan.FromSeconds(1);
            }
            #endregion
        }
    }
}
