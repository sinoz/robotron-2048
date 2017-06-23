using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Robotron_2048.Source.Scene;

namespace Robotron_2048.Source.Model
{
    /// <summary>
    /// The enemy robot character.
    /// </summary>
    sealed class Robot : IEntity
    {
        /// <summary>
        /// The default velocity at which a Robot can move across the screen.
        /// </summary>
        public const int MovementVelocity = 50;

        /// <summary>
        /// The rows.
        /// </summary>
        public const int Rows = 1;

        /// <summary>
        /// The columns.
        /// </summary>
        public const int Columns = 3;

        /// <summary>
        /// The total amount of frames to transition across.
        /// </summary>
        private const int TotalAmtOfFrames = Rows * Columns;

        /// <summary>
        /// The current texture frame.
        /// </summary>
        private Texture2D currentTexture = RobotronGame.RobotTex;

        /// <summary>
        /// The current frame being rendered.
        /// </summary>
        private int currentFrame;

        /// <summary>
        /// The time since the last frame.
        /// </summary>
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 100;

        /// <summary>
        /// the random method
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// The random position for the robot.
        /// </summary>
        public readonly Vector2 randomposition;

        /// <summary>
        /// The position for the robot updated.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// The velocity at which the character can currently move.
        /// </summary>
        private int velocity = MovementVelocity;

        public bool isVisible = true;

        public Robot(Vector2 randomposition)
        {
            this.randomposition = randomposition;
            this.position = new Vector2(randomposition.X, randomposition.Y);            
        }

        public Rectangle getRectangleRobot()
        {
            Rectangle Robot_rect = new Rectangle((int)position.X, (int)position.Y, 25, 25);
            return Robot_rect;
        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {

            int width = currentTexture.Width / Columns;
            int height = currentTexture.Height / Rows;
            int row = (int)((float)currentFrame / Columns);
            int column = currentFrame % Columns;
                   
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            
            batch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;

                // increment current frame
                currentFrame++;
                timeSinceLastFrame = 0;

                if (currentFrame == TotalAmtOfFrames)
                {
                    currentFrame = 0;
                }
            }
        }
    }
}
