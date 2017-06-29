﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameLogic.Scene;

namespace GameLogic.Model
{
        /// <summary>
        /// Keeps track of the player's score whilst in game.
        /// </summary>
        public sealed class Wave : Scene.IDrawable
        {
            /// <summary>
            /// The score value.
            /// </summary>
            public int value;

            /// <summary>
            /// The draw position of the score.
            /// </summary>
            private Label scoreLabel;

            /// <summary>
            /// Creates a new Score.
            /// </summary>
            public Wave()
            {
                scoreLabel = new Label("Wave: " + value, (int)(AppConfig.appWidth * 0.895F), 8);
            }

            public void Draw(SpriteBatch batch, GameTime gameTime)
            {
                scoreLabel.Draw(batch, gameTime);
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