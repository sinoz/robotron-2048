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
    public abstract class Entity : Scene.IDrawable, IUpdatable
    {
        /// <summary>
        /// The position for the robot updated.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="position"></param>
        public Entity(Vector2 position)
        {
            this.position = position;
        }

        /// <summary>
        /// Sets the position of this entity to the specified coordinates.
        /// </summary>
        public void UpdatePosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public abstract void Draw(SpriteBatch batch, GameTime gameTime);
        public abstract void Update(GameTime gameTime);

        public abstract Rectangle EntityRectangle();
    }

    /// <summary>
    /// Describes the behaviour of an entity whilst alive.
    /// </summary>
    public interface IEntityBehaviour
    {
        /// <summary>
        /// Performs the behavioural act for the given Robot.
        /// </summary>
        /// <param name="robot">The Robot.</param>
        /// <param name="gameTime">The delta time.</param>
        void Act(Robot robot, GameTime gameTime);

        /// <summary>
        /// Performs the behavioural act for the given Human.
        /// </summary>
        /// <param name="human">The Human.</param>
        /// <param name="gameTime">The delta time.</param>
        void Act(Human human, GameTime gameTime);

        /// <summary>
        /// Performs the behavioural act for the given Mine.
        /// </summary>
        /// <param name="mine">The Mine.</param>
        /// <param name="gameTime">The delta time.</param>
        void Act(Mine mine, GameTime gameTime);

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="character"></param>
        /// <param name="gameTime"></param>
        void Act(Character character, GameTime gameTime);
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
        public static bool IntersectsWith(this Entity entity, Entity with)
        {
            Rectangle subjectRect = entity.EntityRectangle();
            Rectangle matchWithRect = with.EntityRectangle();

            return subjectRect.Intersects(matchWithRect);
        }
    }
}
