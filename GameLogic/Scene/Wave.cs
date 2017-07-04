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
    public sealed class Wave
    {
        /// <summary>
        /// The score value.
        /// </summary>
        public int value = 1;

        /// <summary>
        /// The draw position of the score.
        /// </summary>
        private Label scoreLabel;
        private SpriteFont Font = LoadedContent.titelFont;
        private SpriteFont normalFont = LoadedContent.font;
        /// <summary>
        /// Creates a new Score.
        /// </summary>
        public Wave(GameScene scene)
        {
            scoreLabel = new Label(normalFont ,"Wave: " + value, (int)(AppConfig.appWidth * 0.895F), 8);
            scene.Add(scoreLabel);
        }

        /// <summary>
        /// Refreshes the Label's text contents to display the player's current score.
        /// </summary>
        public void Refresh()
        {
            scoreLabel.Text = "Wave: " + value;
        }
    }
}
