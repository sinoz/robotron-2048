using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameLogic.Scene;
using GameLogic.Util;

namespace GameLogic.Model
{
    /// <summary>
    /// The enemy mine character.
    /// </summary>
    public sealed class Mine : IEntity
    {
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
        private Texture2D currentTexture = LoadedContent.SquareMine;

        /// <summary>
        /// The current frame being rendered.
        /// </summary>
        private int currentFrame;

        /// <summary>
        /// The time since the last frame.
        /// </summary>
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 1000;
        
        /// <summary>
        /// The position for the Mine updated.
        /// </summary>
        public Vector2 position;

        /// <summary>
        /// Creates a new Mine.
        /// </summary>
        /// <param name="pos">The initial position of this Mine. The given position is copied.</param>
        /// <param name="behaviour">The behaviour of this Mine.</param>
        public Mine(Vector2 pos)
        {
            this.position = new Vector2(pos.X, pos.Y);
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
        
        /// <summary>
        /// Returns a Rectangle instance of the Robot containing its frame size and absolute coordinates
        /// on the screen.
        /// </summary>
        public Rectangle EntityRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, currentTexture.Width, currentTexture.Height);
        }
    }
}