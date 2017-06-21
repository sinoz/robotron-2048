using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Robotron_2048.Source.Scene;

namespace Robotron_2048.Source.Model
{
    /// <summary>
    /// A fired bullet interpolating in a specific direction.
    /// </summary>
    sealed class Bullet : Entity
    {
        /// <summary>
        /// The character that fired this bullet.
        /// </summary>
        private readonly Character character;

        /// <summary>
        /// Creates a new Bullet.
        /// </summary>
        /// <param name="character">The Character for this Bullet.</param>
        public Bullet(Character character)
        {
            this.character = character;
        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            // TODO
        }

        public void Update(GameTime gameTime)
        {
            // TODO
        }
    }
}
