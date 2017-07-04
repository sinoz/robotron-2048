using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameLogic.Util;

namespace GameLogic.Model
{
    /// <summary>
    /// A minion Robot.
    /// </summary>
    public sealed class MinionRobot : Robot
    {
        /// <summary>
        /// The default velocity at which a Robot can move across the screen.
        /// </summary>
        public const int MovementVelocity = 70;

        /// <summary>
        /// The width of a single frame of a Robot.
        /// </summary>
        public const int FrameWidth = 15;

        /// <summary>
        /// The height of a single frame of a Robot.
        /// </summary>
        public const int FrameHeight = 25;

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
        private Texture2D currentTexture = LoadedContent.RobotTex;

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
        /// The behaviour of this robot.
        /// </summary>
        private IMobBehaviour behaviour;

        /// <summary>
        /// Creates a new Robot.
        /// </summary>
        /// <param name="pos">The initial position of this Robot. The given position is copied.</param>
        /// <param name="behaviour">The behaviour of this Robot.</param>
        public MinionRobot(Vector2 pos, IMobBehaviour behaviour) : base(new Vector2(pos.X, pos.Y), MovementVelocity)
        {
            this.behaviour = behaviour;
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            int width = currentTexture.Width / Columns;
            int height = currentTexture.Height / Rows;
            int row = (int)((float)currentFrame / Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            batch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
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

            behaviour.Act(this, gameTime);
        }

        /// <summary>
        /// Returns a Rectangle instance of the Robot containing its frame size and absolute coordinates
        /// on the screen.
        /// </summary>
        public override Rectangle EntityRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, currentTexture.Width / 3, currentTexture.Height);
        }

        public override RobotType robotType()
        {
            return RobotType.Minion;
        }
    }
}
