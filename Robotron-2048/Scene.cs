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
    /// Describes the different types of behaviours of a scene on a stage.
    /// </summary>
    abstract class Scene : Drawable, Updatable {
        /// <summary>
        /// The stage reference.
        /// </summary>
        private Stage stage;

        /// <summary>
        /// Returns the stage.
        /// </summary>
        /// <returns>The stage.</returns>
        public Stage getStage()
        {
            return stage;
        }

        /// <summary>
        /// Assigns this scene to the specified stage.
        /// </summary>
        /// <param name="stage">The stage this scene is asssigned to.</param>
        public void setStage(Stage stage)
        {
            this.stage = stage;
        }

        /// <summary>
        /// Draws this scene onto the given SpriteBatch.
        /// </summary>
        public abstract void Draw(SpriteBatch batch, GameTime gameTime);

        /// <summary>
        /// Updates this scene.
        /// </summary>
        public abstract void Update(GameTime gameTime);
    }
}
