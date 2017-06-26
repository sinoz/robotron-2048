using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shared.Source.Util;
using Shared.Source.Scene;
using Shared.Source.Model;
using Shared.Source.Model.Levels;

namespace Shared.Source.Model
{
    /// <summary>
    /// A representation of a single life.
    /// </summary>
    public sealed class Life : IEntity
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
        /// The position.
        /// </summary>
        private readonly Vector2 position;

        /// <summary>
        /// Creates a new life.
        /// </summary>
        /// <param name="position">The drawing position of this life.</param>
        public Life(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            batch.Draw(LoadedContent.Life, position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            // nothing
        }

        public Rectangle EntityRectangle()
        {
            return new Rectangle((int) position.X, (int) position.Y, Width, Height);
        }
    }
}
