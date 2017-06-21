﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robotron_2048
{
    /// <summary>
    /// Keeps track of the player's score whilst in game.
    /// </summary>
    sealed class Score : Drawable
    {
        /// <summary>
        /// The score value.
        /// </summary>
        private int value = 100;

        /// <summary>
        /// The draw position of the score.
        /// </summary>
        private readonly Vector2 position;

        /// <summary>
        /// Creates a new Score.
        /// </summary>
        public Score()
        {
            position = new Vector2(15, 5);
        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            // TODO replace with Label
            batch.DrawString(Game1.font, "Score: " + value, position, Color.White);
        }
    }
}
