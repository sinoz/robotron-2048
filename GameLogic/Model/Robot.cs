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
    /// The enemy robot character.
    /// </summary>
    public abstract class Robot : IEntity
    {
        /// <summary>
        /// The velocity at which the character can currently move.
        /// </summary>
        public int velocity;

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="position"></param>
        protected Robot(Vector2 position, int velocity) : base(position)
        {
            this.velocity = velocity;
        }

        public abstract override void Draw(SpriteBatch batch, GameTime gameTime);

        public abstract override Rectangle EntityRectangle();

        public abstract override void Update(GameTime gameTime);
    }

    public sealed class RobotFactory
    {
        public static T Produce<T>(RobotType robotType, Vector2 position, IMobBehaviour robotBehaviour, int maxHealthpoints = 0) where T : Robot
        {
            Robot robot = null;

            switch (robotType)
            {
                case RobotType.Strong:
                    robot = new StrongRobot(position, maxHealthpoints);

                    break;

                case RobotType.Minion:
                    robot = new MinionRobot(position, robotBehaviour);

                    break;
                default:
                    //TODO

                    break;
            }

            return (T)robot;
        }
    }

    public enum RobotType
    {
        Strong, Minion
    }
}
