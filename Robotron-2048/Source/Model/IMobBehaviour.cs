using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared.Source.Model
{
    /// <summary>
    /// Describes the behaviour of a Robot whilst alive.
    /// </summary>
    public interface IMobBehaviour
    {
        /// <summary>
        /// Performs the behavioural act for the given Robot.
        /// </summary>
        /// <param name="robot">The Robot.</param>
        /// <param name="gameTime">The delta time.</param>
        void Act(Robot robot, GameTime gameTime);
        void Act(Human human, GameTime gameTime);
    }

    /// <summary>
    /// A Robot behavioural act where Robots simply walk around.
    /// </summary>
    sealed class WalkAroundBehaviour : IMobBehaviour
    {
        public void Act(Robot robot, GameTime gameTime)
        {
            // TODO
        }
        public void Act(Human human, GameTime gameTime)
        {
            // TODO
        }

    }

    /// <summary>
    /// A Robot behavioural act where Robots are attracted to the player character, causing
    /// robots to move towards the player character.
    /// </summary>
    sealed class AttractedToPlayerCharacterBehaviour : IMobBehaviour
    {
        /// <summary>
        /// The character of subject.
        /// </summary>
        private readonly Character character;

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
            // TODO
        }

        public void Act(Human human, GameTime gameTime)
        {
            // TODO
        }
    }
}
