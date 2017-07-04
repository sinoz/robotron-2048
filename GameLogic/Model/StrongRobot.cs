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
        /// Creates a new StrongRobot.
        /// </summary>
        public StrongRobot(Vector2 position, int maxHealthpoints) : base(position, MovementVelocity)
        {
            this.currentHealthpoints = maxHealthpoints;
            this.maxHealthpoints = maxHealthpoints;
        }

        public override Rectangle EntityRectangle()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            // TODO
        }

        public override void Update(GameTime gameTime)
        {
            // TODO
        }

        public override RobotType robotType()
        {
            return RobotType.Strong;
        }
    }
}
