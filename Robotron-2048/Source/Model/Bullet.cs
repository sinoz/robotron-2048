using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Robotron_2048.Source.Scene;

using Robotron_2048.Source.Util;

namespace Robotron_2048.Source.Model
{
    /// <summary>
    /// A fired bullet interpolating in a specific direction.
    /// </summary>
    sealed class Bullet : IEntity
    {
        /// <summary>
        /// The default length of a bullet line.
        /// </summary>
        public const int Length = 20;

        /// <summary>
        /// The character that fired this bullet.
        /// </summary>
        private readonly Character character;

        /// <summary>
        /// The current position of this bullet.
        /// </summary>
        private Vector2 position { get; set; }

        /// <summary>
        /// Creates a new Bullet.
        /// </summary>
        /// <param name="character">The Character for this Bullet.</param>
        public Bullet(Character character)
        {
            this.character = character;
            this.position = character.position;
        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            batch.DrawLine(position, new Vector2(position.X, position.Y + Length), Color.Red);
        }

        public void Update(GameTime gameTime)
        {
            // TODO
        }
    }
}
