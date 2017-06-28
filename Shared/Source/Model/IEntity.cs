using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shared.Source.Scene;
using Microsoft.Xna.Framework;

namespace Shared.Source.Model
{
    /// <summary>
    /// A drawable and updatable entity.
    /// </summary>
    interface IEntity : Scene.IDrawable, IUpdatable
    {
        Rectangle EntityRectangle();
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
