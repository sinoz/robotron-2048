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
    /// TODO
    /// </summary>
    public sealed class TextButton : Widget
    {
        /// <summary>
        /// TODO
        /// </summary>
        private Button button;

        /// <summary>
        /// TODO
        /// </summary>
        private Label label;

        /// <summary>
        /// Creates a new TextButton.
        /// </summary>
        public TextButton(SpriteFont CurrentFont ,string text, Vector2 position, int width, int height, Action action) : base(position)
        {
            this.button = new Button(position, width, height, action);
            this.label = new GameLogic.Scene.Label(CurrentFont, text, 0, 0);
        }

        public override void Update(GameTime gameTime)
        {
            button.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            button.Draw(batch, gameTime);
            label.Draw(batch, gameTime);

            base.Draw(batch, gameTime);
        }
    }
}
