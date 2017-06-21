using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Robotron_2048
{
    /// <summary>
    /// The player character.
    /// </summary>
    sealed class Character : Updatable, Drawable
    {
        /// <summary>
        /// The current texture frame.
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// The rows.
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// The columns.
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// The sprite batch to draw this character on.
        /// </summary>
        private readonly SpriteBatch batch;

        /// <summary>
        /// The current frame being rendered.
        /// </summary>
        private int currentFrame;

        /// <summary>
        /// The total amount of frames to transition across.
        /// </summary>
        private int totalFrames;
        
        /// <summary>
        /// The time since the last frame.
        /// </summary>
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 100;

        /// <summary>
        /// The coordinates of this character. TODO there's a better way to do this
        /// </summary>
        int x = 200;
        int y = 200;

        /// <summary>
        /// The velocity at which the character moves.
        /// </summary>
        int velocity;

        /// <summary>
        /// Creates a new character.
        /// </summary>
        /// <param name="batch">The SpriteBatch to draw this character onto. </param>
        /// <param name="texture">The initial texture frame.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        public Character(SpriteBatch batch, Texture2D texture, int rows, int columns, int velocity)
        {
            this.Texture = texture;
            this.batch = batch;
            this.Rows = rows;
            this.Columns = columns;
            this.currentFrame = 0;
            this.totalFrames = Rows * Columns;
            this.velocity = velocity;
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

                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                y -= (int) (velocity * gameTime.ElapsedGameTime.TotalSeconds);
                Texture = Game1.characterUpTex;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                y += (int) (velocity * gameTime.ElapsedGameTime.TotalSeconds);
                Texture = Game1.characterDownTex;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                x -= (int) (velocity * gameTime.ElapsedGameTime.TotalSeconds);
                Texture = Game1.characterLeftTex;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                x += (int) (velocity * gameTime.ElapsedGameTime.TotalSeconds);
                Texture = Game1.characterRightTex;
            }
            if(x < 0){ x = 0; }
            if (y < 0) { y = 0; }
            if (y > 600 - Texture.Height) { y = 600 - Texture.Height; }
            if (x > 800 - (Texture.Width/3)) { x = 800 - (Texture.Width/3); }

        }
        
        public void Draw(GameTime gameTime)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(x, y, width, height);

            batch.Begin();
            batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            batch.End();
        }
    }
}
