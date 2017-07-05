using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLogic.Model;

using Microsoft.Xna.Framework;

namespace GameLogic.Model.Behaviours
{
    /// <summary>
    /// A behavioural act where entities are attracted to the player character, causing
    /// robots to move towards the player character.
    /// </summary>
    public sealed class AttractedToPlayerCharacterBehaviour : IEntityBehaviour
    {
        /// <summary>
        /// The random number generator.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// The character of subject.
        /// </summary>
        private Character character;

        /// <summary>
        /// Creates a new behaviour.
        /// </summary>
        /// <param name="character">The character of subject.</param>
        public AttractedToPlayerCharacterBehaviour(Character character)
        {
            this.character = character;
        }

        public void Act(Robot robot, GameTime gameTime)
        {
            System.Diagnostics.Debug.WriteLine("LOL CHASIN U");

            Vector2 direction = character.position - robot.position;
            direction.Normalize();
            Vector2 velocity1 = direction * (int)(robot.velocity * gameTime.ElapsedGameTime.TotalSeconds) / 3;
            robot.position += velocity1;
        }

        public void Act(Character character, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Act(Human human, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Act(Mine mine, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
