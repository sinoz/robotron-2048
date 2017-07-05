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
        public Entity shooter;

        /// <summary>
        /// The color of the bullet line.
        /// </summary>
        private Color color;

        /// <summary>
        /// The direction at which the bullet moves.
        /// </summary>
        private Vector2 direction;

        /// <summary>
        /// The thickness of the bullet.
        /// </summary>
        private float thickness;

        /// <summary>
        /// Creates a new Bullet.
        /// </summary>
        public Bullet(Entity shooter, Vector2 direction, float thickness = 1F) : base(new Vector2(shooter.position.X, shooter.position.Y))
        {
            this.shooter = shooter;
            this.direction = direction;
            this.color = Color.White;
            this.thickness = thickness;

            CenterBullet();
        }

        private void CenterBullet()
        {
            Rectangle rect = shooter.EntityRectangle();

            float x = position.X + rect.Width / 2;
            float y = position.Y + rect.Height / 2;

            position = new Vector2(x, y);
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
            batch.DrawLine(position, new Vector2(position.X + (direction.X * Length), position.Y + (direction.Y * Length)), color, thickness);
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
