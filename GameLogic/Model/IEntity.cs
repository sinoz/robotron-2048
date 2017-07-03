using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLogic.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameLogic.Model
{
    /// <summary>
    /// A drawable and updatable entity.
    /// </summary>
    public abstract class IEntity : Scene.IDrawable, IUpdatable
    {
        /// <summary>
        /// The position for the robot updated.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="position"></param>
        public IEntity(Vector2 position)
        {
            this.position = position;
        }

        public abstract void Draw(SpriteBatch batch, GameTime gameTime);
        public abstract void Update(GameTime gameTime);

        public abstract Rectangle EntityRectangle();
    }

    /// <summary>
    /// Contains extension methods specific to IEntity. A work-around for default interface
    /// methods.
    /// </summary>
    static class EntityExtensions
    {
        /// <summary>
        /// Returns whether the given entity intersects with the entity of subject.
        /// </summary>
        /// <param name="entity">The entity of subject.</param>
        /// <param name="with">The entity to possibly intersect with the entity of subject.</param>
        /// <returns></returns>
        public static bool IntersectsWith(this IEntity entity, IEntity with)
        {
            Rectangle subjectRect = entity.EntityRectangle();
            Rectangle matchWithRect = with.EntityRectangle();

            return subjectRect.Intersects(matchWithRect);
        }
    }
}
