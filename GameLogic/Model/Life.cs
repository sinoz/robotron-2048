using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameLogic.Util;
using GameLogic.Scene;
using GameLogic.Model;
using GameLogic.Model.Levels;

namespace GameLogic.Model
{
    /// <summary>
    /// A representation of a single life.
    /// </summary>
    public sealed class Life : Entity
    {
        /// <summary>
        /// The width of a single frame of a life texture.
        /// </summary>
        public const int Width = 41;

        /// <summary>
        /// The height of a single frame of a life texture.
        /// </summary>
        public const int Height = 45;

        /// <summary>
        /// Creates a new life.
        /// </summary>
        /// <param name="position">The drawing position of this life.</param>
        public Life(Vector2 position) : base(new Vector2(position.X, position.Y))
        {
            // nothing
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            batch.Draw(LoadedContent.Life, position, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            // nothing
        }

        public override Rectangle EntityRectangle()
        {
            return new Rectangle((int) position.X, (int) position.Y, Width, Height);
        }
    }
}
