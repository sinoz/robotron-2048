using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameLogic.Util;

namespace GameLogic.Scene
{
    /// <summary>
    /// A stage in charge of a scenery, updating and drawing subordinate widgets.
    /// </summary>
    public sealed class Stage
    {
        /// <summary>
        /// The graphic device.
        /// </summary>
        private GraphicsDevice device;

        /// <summary>
        /// The rendering batch.
        /// </summary>
        private SpriteBatch batch;

        /// <summary>
        /// The current Scene acting on this stage.
        /// </summary>
        private Scene scene;

        /// <summary>
        /// Creates a new Stage.
        /// </summary>
        /// <param name="device">The graphics device.</param>
        public Stage(GraphicsDevice device)
        {
            this.device = device;
            this.batch = new SpriteBatch(device);
        }

        /// <summary>
        /// Transitions into the given Scene. The previously loaded scene will have all
        /// of its subordinates hidden from the stage.
        /// </summary>
        /// <param name="scene">The Scene to transition into.</param>
        public void TransitionInto(Scene scene)
        {
            if (this.scene != null)
            {
                // TODO scene.Hide();
            }

            this.scene = scene;
            scene.stage = this;

            // TODO scene.Show();
        }

        /// <summary>
        /// Draws the stage.
        /// </summary>
        public void Draw(GameTime gameTime)
        {
            #region Drawing of the background
            batch.Begin();
            batch.Draw(LoadedContent.gameBackground, new Rectangle(new Point(0, 0), new Point(device.DisplayMode.Width, device.DisplayMode.Height)), Color.White);
            batch.End();
            #endregion

            scene.Draw(batch, gameTime);
        }

        /// <summary>
        /// Updates the stage.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            scene.Update(gameTime);
        }
    }

    /// <summary>
    /// A drawable element.
    /// </summary>
    interface IDrawable
    {
        /// <summary>
        /// Draws the element onto the specified SpriteBatch.
        /// </summary>
        void Draw(SpriteBatch batch, GameTime gameTime);
    }

    /// <summary>
    /// An updatable element.
    /// </summary>
    interface IUpdatable
    {
        /// <summary>
        /// Updates this element.
        /// </summary>
        void Update(GameTime gameTime);
    }
}
