using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Shared.Source.Scene;

namespace Shared.Source.Model
{
    /// <summary>
    /// Keeps track of the player's score whilst in game.
    /// </summary>
    public sealed class Score : Scene.IDrawable
    {
        /// <summary>
        /// The score value.
        /// </summary>
        public int value { get; set; }

        /// <summary>
        /// The draw position of the score.
        /// </summary>
        private Label scoreLabel;

        /// <summary>
        /// Creates a new Score.
        /// </summary>
        public Score()
        {
            scoreLabel = new Label("Score: " + value, 15, 5);
        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            scoreLabel.Draw(batch, gameTime);
        }

        /// <summary>
        /// Increments the current score by the specified amount.
        /// </summary>
        /// <param name="amount">The amount to increment by, set to 1 by default.</param>
        public void Increment(int amount = 1)
        {
            if (amount <= 0)
            {
                amount = 1;
            }

            value += amount;

            Refresh();
        }

        /// <summary>
        /// Decrements the current score by the specified amount.
        /// </summary>
        /// <param name="amount">The amount to decrement by, set to 1 by default.</param>
        public void Decrement(int amount = 1)
        {
            if (amount <= 0)
            {
                amount = 1;
            }

            value -= amount;

            Refresh();
        }

        /// <summary>
        /// Refreshes the Label's text contents to display the player's current score.
        /// </summary>
        private void Refresh()
        {
            scoreLabel.Text = "Score: " + value;
        }
    }
}
