using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

namespace Robotron_2048
{
    /// <summary>
    /// A stage in charge of a scenery, updating and drawing subordinate widgets.
    /// </summary>
    sealed class Stage : Drawable, Updatable
    {
        /// <summary>
        /// The rendering batch.
        /// </summary>
        SpriteBatch batch;

        /// <summary>
        /// The current Scene acting on this stage.
        /// </summary>
        Scene scene;

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
        public void transitionInto(Scene scene)
        {
            if (this.scene != null)
            {
                scene.Hide();
            }

            this.scene = scene;

            scene.Show();
        }

        /// <summary>
        /// Draws the stage.
        /// </summary>
        public void Draw()
        {
            scene.Draw();
        }

        /// <summary>
        /// Updates the stage.
        /// </summary>
        public void Update()
        {
            scene.Update();
        }
    }

    /// <summary>
    /// TODO
    /// </summary>
    interface Drawable
    {
        /// <summary>
        /// TODO
        /// </summary>
        void Draw();
    }

    /// <summary>
    /// TODO
    /// </summary>
    interface Updatable
    {
        /// <summary>
        /// TODO
        /// </summary>
        void Update();
    }

    /// <summary>
    /// TODO
    /// </summary>
    interface Disposable
    {
        /// <summary>
        /// TODO
        /// </summary>
        void Dispose();
    }
}
