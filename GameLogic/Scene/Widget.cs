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
    /// A user interface element.
    /// </summary>
    public abstract class Widget : Actor
    {
        public Widget() : base()
        {
            // nothing
        }

        public Widget(Vector2 position) : base(position)
        {
            // nothing
        }
    }
}
