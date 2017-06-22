using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robotron_2048.Source.Scene
{
    /// <summary>
    /// Describes the different types of behaviours of a scene on a stage.
    /// </summary>
    abstract class Scene : IDrawable, IUpdatable {
        /// <summary>
        /// The stage reference.
        /// </summary>
        public Stage stage { get; set; }

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
