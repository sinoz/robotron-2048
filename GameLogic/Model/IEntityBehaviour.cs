using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using GameLogic.Util;

namespace GameLogic.Model
{
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
    /// A behavioural act where entities simply walk around.
    /// </summary>
    sealed class WalkAroundBehaviour : IEntityBehaviour
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

        public void Act(Character character, GameTime gameTime)
        {
            // TODO
        }
    }

    /// <summary>
    /// TODO
    /// </summary>
    sealed class ControllableThroughInputBehaviour : IEntityBehaviour
    {
        public void Act(Mine mine, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Act(Character character, GameTime gameTime)
        {
            var x = character.position.X;
            var y = character.position.Y;

            if (AppConfig.deviceType == DeviceType.Android)
            {
                TouchCollection touchCollection = TouchPanel.GetState();

                if (touchCollection.Count > 0)
                {
                    Vector2 desiredVelocity = new Vector2();

                    desiredVelocity.X = touchCollection[0].Position.X - character.position.X;
                    desiredVelocity.Y = touchCollection[0].Position.Y - character.position.Y;

                    if (desiredVelocity.X != 0 || desiredVelocity.Y != 0)
                    {
                        desiredVelocity.Normalize();
                        const float desiredSpeed = 200;
                        desiredVelocity *= desiredSpeed;
                    }

                    x += desiredVelocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    y += desiredVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

                    bool movingHorizontally = Math.Abs(desiredVelocity.X) > Math.Abs(desiredVelocity.Y);
                    if (movingHorizontally)
                    {
                        if (desiredVelocity.X > 0)
                        {
                            character.currentTexture = LoadedContent.characterRightTex;
                        }
                        else
                        {
                            character.currentTexture = LoadedContent.characterLeftTex;
                        }
                    }
                    else
                    {
                        if (desiredVelocity.Y > 0)
                        {
                            character.currentTexture = LoadedContent.characterDownTex;
                        }
                        else
                        {
                            character.currentTexture = LoadedContent.characterUpTex;
                        }
                    }
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    y -= (int)(character.velocity * gameTime.ElapsedGameTime.TotalSeconds);
                    character.currentTexture = LoadedContent.characterUpTex;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    y += (int)(character.velocity * gameTime.ElapsedGameTime.TotalSeconds);
                    character.currentTexture = LoadedContent.characterDownTex;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    x -= (int)(character.velocity * gameTime.ElapsedGameTime.TotalSeconds);
                    character.currentTexture = LoadedContent.characterLeftTex;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    x += (int)(character.velocity * gameTime.ElapsedGameTime.TotalSeconds);
                    character.currentTexture = LoadedContent.characterRightTex;
                }
            }

            if (x < 0)
            {
                x = 0;
            }

            if (y < 35)
            {
                y = 35;
            }

            if (y > AppConfig.appHeight - character.currentTexture.Height)
            {
                y = AppConfig.appHeight - character.currentTexture.Height;
            }

            if (x > AppConfig.appWidth - (character.currentTexture.Width / 3))
            {
                x = AppConfig.appWidth - (character.currentTexture.Width / 3);
            }

            character.MoveTo((int)x, (int)y);
        }

        public void Act(Human human, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Act(Robot robot, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A behavioural act where entities are attracted to the player character, causing
    /// robots to move towards the player character.
    /// </summary>
    sealed class AttractedToPlayerCharacterBehaviour : IEntityBehaviour
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

        public void Act(Character character, GameTime gameTime)
        {
            // TODO
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
