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
    /// A stage in charge of a scenery, updating and drawing subordinate widgets.
    /// </summary>
    sealed class Stage
    {
        /// <summary>
        /// The rendering batch.
        /// </summary>
        private readonly SpriteBatch batch;

        /// <summary>
        /// The current Scene acting on this stage.
        /// </summary>
        private Scene scene;

        /// <summary>
        /// Creates a new Stage.
        /// </summary>
        /// <param name="device"></param>
        public Stage(GraphicsDevice device)
        {
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
            scene.setStage(this);

            // TODO scene.Show();
        }

        /// <summary>
        /// Draws the stage.
        /// </summary>
        public void Draw(GameTime gameTime)
        {
            batch.Begin();
            batch.Draw(Game1.gameBackground, new Rectangle(new Point(0, 0), new Point(Game1.gameBackground.Width, Game1.gameBackground.Height)), Color.White);
            batch.End();

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
    interface Drawable
    {
        /// <summary>
        /// Draws the element onto the specified SpriteBatch.
        /// </summary>
        void Draw(SpriteBatch batch, GameTime gameTime);
    }

    /// <summary>
    /// An updatable element.
    /// </summary>
    interface Updatable
    {
        /// <summary>
        /// Updates this element.
        /// </summary>
        void Update(GameTime gameTime);
    }

    /// <summary>
    /// A disposable element.
    /// </summary>
    interface Disposable
    {
        /// <summary>
        /// Disposes all of the resources for the element.
        /// </summary>
        void Dispose();
    }
}
