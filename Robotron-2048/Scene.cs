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
