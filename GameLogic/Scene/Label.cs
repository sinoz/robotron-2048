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
    public sealed class Label : Widget
    {
        /// <summary>
        /// The text contents of this label.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The color of the text content.
        /// </summary>
        private Color Color { get; set; }

        
        private SpriteFont CurrentFont;
        /// <summary>
        /// Creates a new Label.
        /// </summary>
        /// <param name="text">The text content.</param>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Label(SpriteFont CurrentFont, string text, int x, int y) : base(new Vector2(x, y))
        {
            this.CurrentFont = CurrentFont;
            this.Text = text;
            this.Color = Color.White;
            
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            batch.DrawString(CurrentFont, Text, relative, Color);
            
            base.Draw(batch, gameTime);
        }
    }
}
