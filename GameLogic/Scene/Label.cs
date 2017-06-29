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
    /// A drawable and updatable Label widget.
    /// </summary>
    public sealed class Label : IDrawable, IUpdatable
    {
        /// <summary>
        /// The position of this label.
        /// </summary>
        public Vector2 position { get; set; }

        /// <summary>
        /// The text contents of this label.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The color of the text content.
        /// </summary>
        private Color Color { get; set; }

        /// <summary>
        /// Creates a new Label.
        /// </summary>
        /// <param name="text">The text content.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Label(string text, int x, int y)
        {
            this.Text = text;
            this.position = new Vector2(x, y);
            this.Color = Color.White;
        }

        public void Update(GameTime gameTime)
        {
            // TODO
        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            batch.DrawString(LoadedContent.font, Text, position, Color);
        }
    }
}
