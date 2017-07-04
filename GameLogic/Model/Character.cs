using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameLogic.Util;
using GameLogic.Scene;

namespace GameLogic.Model
{
    /// <summary>
    /// The player character.
    /// </summary>
    public sealed class Character : IEntity
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
        public Texture2D currentTexture = LoadedContent.characterDownTex;

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
        /// The velocity at which the character can currently move.
        /// </summary>
        public int velocity = MovementVelocity;

        /// <summary>
        /// The corresponding behaviour.
        /// </summary>
        private IEntityBehaviour behaviour;

        /// <summary>
        /// Creates a new Character.
        /// </summary>
        public Character(IEntityBehaviour behaviour) : base(new Vector2(AppConfig.appWidth / 2, AppConfig.appHeight / 2))
        {
            this.behaviour = behaviour;
        }

        public override void Update(GameTime gameTime)
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

            if (behaviour != null)
            {
                behaviour.Act(this, gameTime);
            }
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            int width = currentTexture.Width / Columns;
            int height = currentTexture.Height / Rows;
            int row = (int) ((float) currentFrame / Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int) position.X, (int) position.Y, width, height);

            batch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        /// <summary>
        /// Moves the position of this character to the specified coordinates.
        /// </summary>
        public void MoveTo(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        /// <summary>
        /// Returns a Rectangle instance of the Character containing its frame size and absolute coordinates
        /// on the screen.
        /// </summary>
        public override Rectangle EntityRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, currentTexture.Width / 3, currentTexture.Height);
        }
    }
}
