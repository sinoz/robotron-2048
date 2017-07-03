using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameLogic.Scene
{
    /// <summary>
    /// Describes the different types of behaviours of a scene on a stage.
    /// </summary>
    public abstract class Scene : Actor {
        /// <summary>
        /// The stage reference.
        /// </summary>
        public Stage stage { get; set; }
    }
}
