using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameLogic.Scene
{
    /// <summary>
    /// An actor that updates and draws subordinate actors.
    /// </summary>
    public abstract class Actor : IUpdatable, IDrawable
    {
        /// <summary>
        /// The list of subordinate actors.
        /// </summary>
        private IList<Actor> actors = new List<Actor>();

        /// <summary>
        /// The parent of this actor.
        /// </summary>
        public Actor parent;

        /// <summary>
        /// The absolute position of this actor.
        /// </summary>
        public Vector2 absolute;

        /// <summary>
        /// The position of this actor within its parent.
        /// </summary>
        public Vector2 relative;

        /// <summary>
        /// Creates a new root actor.
        /// </summary>
        public Actor() : this(new Vector2(0, 0))
        {
            // nothing
        }

        /// <summary>
        /// Creates a new actor.
        /// </summary>
        /// <param name="relative"></param>
        public Actor(Vector2 relative)
        {
            this.relative = relative;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (actors.Count > 0)
            {
                int count = 0;
                while (count < actors.Count)
                {
                    Actor actor = actors[count];
                    if (actor != null)
                    {
                        actor.Update(gameTime);
                    }

                    count += 1;
                }
            }
        }

        public virtual void Draw(SpriteBatch batch, GameTime gameTime)
        {
            if (actors.Count > 0)
            {
                int count = 0;
                while (count < actors.Count)
                {
                    Actor actor = actors[count];
                    if (actor != null)
                    {
                        actor.Draw(batch, gameTime);
                    }

                    count += 1;
                }
            }
        }

        /// <summary>
        /// Adds the given Actor to this Scene.
        /// </summary>
        /// <param name="actor">The Actor to add.</param>
        public void Add(Actor actor)
        {
            actors.Add(actor);

            actor.parent = this;

            actor.absolute.X = absolute.X + actor.relative.X;
            actor.absolute.Y = absolute.Y + actor.relative.Y;
        }

        /// <summary>
        /// Removes the given Actor from this Scene.
        /// </summary>
        /// <param name="actor">The Actor to remove.</param>
        public void Remove(Actor actor)
        {
            actors.Remove(actor);
            actor.parent = null;
        }
    }
}
