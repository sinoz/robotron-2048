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
    /// A Robot that has health points.
    /// </summary>
    public sealed class StrongRobot : Robot
    {
        /// <summary>
        /// The movement velocity of this robot.
        /// </summary>
        public const int MovementVelocity = 60;

        /// <summary>
        /// The current and max amount of healthpoints.
        /// </summary>
        public int currentHealthpoints, maxHealthpoints;

        /// <summary>
        /// The rows.
        /// </summary>
        public const int Rows = 1;

        /// <summary>
        /// The columns.
        /// </summary>
        public const int Columns = 3;

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
        /// The total amount of frames to transition across.
        /// </summary>
        private const int TotalAmtOfFrames = Rows * Columns;

        /// <summary>
        /// The current texture frame.
        /// </summary>
        private Texture2D currentTexture = LoadedContent.RobotBossTex;

        private Texture2D healthBar = LoadedContent.healthBar;

        /// <summary>
        /// TODO
        /// </summary>
        private IEntityBehaviour behaviour;

        /// <summary>
        /// Creates a new StrongRobot.
        /// </summary>
        public StrongRobot(Vector2 position, int maxHealthpoints, IEntityBehaviour behaviour = null) : base(position, MovementVelocity)
        {
            this.behaviour = behaviour;
            this.currentHealthpoints = maxHealthpoints;
            this.maxHealthpoints = maxHealthpoints;
        }

        public override Rectangle EntityRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, currentTexture.Width / 3, currentTexture.Height);
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            int width = currentTexture.Width / Columns;
            int height = currentTexture.Height / Rows;
            int row = (int)((float)currentFrame / Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            Rectangle healthRectangle = new Rectangle((int)150, (int)70, currentHealthpoints, 30);

            batch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
            batch.Draw(healthBar, healthRectangle, Color.Red);

            // TODO
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

        public override RobotType robotType()
        {
            return RobotType.Strong;
        }

    }
}
