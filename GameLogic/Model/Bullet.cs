using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

using GameLogic.Scene;
using GameLogic.Util;

namespace GameLogic.Model
{
    /// <summary>
    /// A fired bullet interpolating in a specific direction.
    /// </summary>
    public sealed class Bullet : Entity
    {
        /// <summary>
        /// The default length of a bullet line.
        /// </summary>
        public const int Length = 20;

        /// <summary>
        /// The velocity at which the bullet moves in a specific direction.
        /// </summary>
        public const int MovementVelocity = 550;

        /// <summary>
        /// The entity that fired this bullet.
        /// </summary>
        private Entity entity;

        /// <summary>
        /// The color of the bullet line.
        /// </summary>
        private Color color;

        /// <summary>
        /// The direction at which the bullet moves.
        /// </summary>
        private Vector2 direction;

        /// <summary>
        /// Creates a new Bullet.
        /// </summary>
        public Bullet(Entity entity, Vector2 direction) : base(new Vector2(entity.position.X + 10, entity.position.Y + 10))
        {
            this.entity = entity;
            this.direction = direction;
            this.color = Color.White;
        }

        /// <summary>
        /// Returns whether this bullet is out of bounds and should therefore be considered a
        /// candidate for removal.
        /// </summary>
        /// <returns>Whether the bullet is a candidate for removal.</returns>
        public bool isOutOfBounds()
        {
            return position.X < -Bullet.Length || position.Y < -Bullet.Length || position.X > AppConfig.appWidth || position.Y > AppConfig.appHeight;   
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            batch.DrawLine(position, new Vector2(position.X + (direction.X * Length), position.Y + (direction.Y * Length)), color);
        }

        public override void Update(GameTime gameTime)
        {
            position.X += (direction.X * (int)(MovementVelocity * gameTime.ElapsedGameTime.TotalSeconds));
            position.Y += (direction.Y * (int)(MovementVelocity * gameTime.ElapsedGameTime.TotalSeconds));
        }

        public override Rectangle EntityRectangle()
        {
            return new Rectangle((int) position.X, (int) position.Y, 1, Length);
        }
    }
}
