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
    /// The player character.
    /// </summary>
    sealed class Character : IEntity
    {
        /// <summary>
        /// The default velocity at which a character can move across the screen.
        /// </summary>
        public const int MovementVelocity = 250;

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
        private Texture2D currentTexture = RobotronGame.characterDownTex;

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
        /// The coordinates of this character.
        /// </summary>
        public Vector2 position = new Vector2(200, 200);

        /// <summary>
        /// The velocity at which the character can currently move.
        /// </summary>
        private int velocity = MovementVelocity;
        
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

            var x = position.X;
            var y = position.Y;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                y -= (int) (velocity * gameTime.ElapsedGameTime.TotalSeconds);
                currentTexture = RobotronGame.characterUpTex;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                y += (int) (velocity * gameTime.ElapsedGameTime.TotalSeconds);
                currentTexture = RobotronGame.characterDownTex;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                x -= (int) (velocity * gameTime.ElapsedGameTime.TotalSeconds);
                currentTexture = RobotronGame.characterLeftTex;
                
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                x += (int) (velocity * gameTime.ElapsedGameTime.TotalSeconds);
                currentTexture = RobotronGame.characterRightTex;
            }
            
            if (x < 0)
            {
                x = 0;
            }

            if (y < 0)
            {
                y = 0;
            }

            if (y > RobotronGame.appHeight - currentTexture.Height)
            {
                y = RobotronGame.appHeight - currentTexture.Height;
            }

            if (x > RobotronGame.appWidth - (currentTexture.Width / 3))
            {
                x = RobotronGame.appWidth - (currentTexture.Width / 3);
            }

            position.X = x;
            position.Y = y;
        }
        
        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            int width = currentTexture.Width / Columns;
            int height = currentTexture.Height / Rows;
            int row = (int) ((float) currentFrame / Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int) position.X, (int) position.Y, width, height);

            batch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
