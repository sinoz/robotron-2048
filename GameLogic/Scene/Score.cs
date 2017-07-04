using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameLogic.Scene;
using GameLogic.Util;

namespace GameLogic.Model
{
    /// <summary>
    /// Keeps track of the player's score whilst in game.
    /// </summary>
    public sealed class Score
    {
        /// <summary>
        /// The score value.
        /// </summary>
        public int value { get; set; }

        /// <summary>
        /// The draw position of the score.
        /// </summary>
        private Label scoreLabel;
        private SpriteFont Font = LoadedContent.titelFont;
        private SpriteFont normalFont = LoadedContent.font;
        /// <summary>
        /// Creates a new Score.
        /// </summary>
        public Score(GameScene scene)
        {
            scoreLabel = new Label(normalFont,"Score: " + value, 15, 8, Color.White);

            scene.Add(scoreLabel);
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
