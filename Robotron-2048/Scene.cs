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
        /// Returns a reference to the stage.
        /// </summary>
        /// <returns></returns>
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
        /// TODO
        /// </summary>
        public abstract void Hide();
        
        /// <summary>
        /// TODO
        /// </summary>
        public abstract void Show();

        /// <summary>
        /// Disposes off all of the resources this scene is entitled to.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// TODO
        /// </summary>
        public abstract void Draw(GameTime gameTime);

        /// <summary>
        /// TODO
        /// </summary>
        public abstract void Update(GameTime gameTime);
    }
}
