using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameLogic.Util;

namespace GameLogic.Model
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

        /// <summary>
        /// Performs the behavioural act for the given Human.
        /// </summary>
        /// <param name="human">The Human.</param>
        /// <param name="gameTime">The delta time.</param>
        void Act(Human human, GameTime gameTime);

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="mine"></param>
        /// <param name="gameTime"></param>
        void Act(Mine mine, GameTime gameTime);
    }

    /// <summary>
    /// A Robot behavioural act where Robots simply walk around.
    /// </summary>
    sealed class WalkAroundBehaviour : IMobBehaviour
    {
        private static Random random = new Random();
        private Vector2 direction = new Vector2(0, 0);

        private int timeSinceLastFrame;
        private int millisecondsPerFrame;

        public void Act(Robot robot, GameTime gameTime)
        {
            // TODO
        }

        public void Act(Human human, GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame >= millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;

                direction.X = random.Next(-1, 2);
                direction.Y = random.Next(-1, 2);

                millisecondsPerFrame = random.Next(400, 3500);
            }

            var x = human.position.X;
            var y = human.position.Y;

            x += (direction.X * (int)(human.velocity * gameTime.ElapsedGameTime.TotalSeconds));
            y += (direction.Y * (int)(human.velocity * gameTime.ElapsedGameTime.TotalSeconds));

            if (direction.Y == -1)
            {
                human.currentTexture = LoadedContent.humanUpTex;
            }

            if (direction.Y == 1)
            {
                human.currentTexture = LoadedContent.humanDownTex;
            }

            if (direction.X == -1)
            {
                human.currentTexture = LoadedContent.humanLeftTex;

            }

            if (direction.X == 1)
            {
                human.currentTexture = LoadedContent.humanRighTex;
            }

            if (x < 0)
            {
                x = 0;
            }

            if (y < 35)
            {
                y = 35;
            }

            if (y > AppConfig.appHeight - human.currentTexture.Height)
            {
                y = AppConfig.appHeight - human.currentTexture.Height;
            }

            if (x > AppConfig.appWidth - (human.currentTexture.Width / 3))
            {
                x = AppConfig.appWidth - (human.currentTexture.Width / 3);
            }

            human.position.X = x;
            human.position.Y = y;
        }

        public void Act(Mine mine, GameTime gameTime)
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
            Vector2 direction = character.position - robot.position;
            direction.Normalize();
            Vector2 velocity1 = direction *(int)( robot.velocity* gameTime.ElapsedGameTime.TotalSeconds)/3;
            robot.position += velocity1;
        }

        public void Act(Human human, GameTime gameTime)
        {
            // TODO
        }

        public void Act(Mine mine, GameTime gameTime)
        {
            // TODO
        }
    }
}
