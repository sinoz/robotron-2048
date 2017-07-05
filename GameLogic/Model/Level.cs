using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using GameLogic.Scene;

namespace GameLogic.Model
{
    /// <summary>
    /// Describes a single level.
    /// </summary>
    public abstract class Level
    {
        /// <summary>
        /// The game scene.
        /// </summary>
        protected GameScene scene;

        /// <summary>
        /// Creates a new level.
        /// </summary>
        /// <param name="scene">The game scene.</param>
        public Level(GameScene scene)
        {
            this.scene = scene;
        }

        /// <summary>
        /// Adds the given robot to this level.
        /// </summary>
        /// <param name="robot">The robot to add.</param>
        protected void Add(Robot robot)
        {
            scene.robots.Add(robot);
        }

        /// <summary>
        /// Adds the given human to this level.
        /// </summary>
        /// <param name="human">The human to add.</param>
        protected void Add(Human human)
        {
            scene.humans.Add(human);
        }

        /// <summary>
        /// Removes the given robot from this level.
        /// </summary>
        /// <param name="robot">The robot to remove.</param>
        protected void remove(Robot robot)
        {
            scene.robots.Remove(robot);
        }
        
        /// <summary>
        /// Adds the given mine to this level.
        /// </summary>
        /// <param name="mine">The mine.</param>
        protected void Add(Mine mine)
        {
            scene.mines.Add(mine);
        }

        /// <summary>
        /// Removes the given mine from this level.
        /// </summary>
        /// <param name="robot">The mine to remove.</param>
        protected void remove(Mine mine)
        {
            scene.mines.Remove(mine);
        }

        /// <summary>
        /// Removes the given human from this level.
        /// </summary>
        /// <param name="human">The human to remove.</param>
        protected void remove(Human human)
        {
            scene.humans.Remove(human);
        }

        /// <summary>
        /// Describes what to do when a transition occurs to the implementation level.
        /// </summary>
        public abstract void OnTransition();

        /// <summary>
        /// Updates the level.
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Describes what to do when a character has collided with a robot.
        /// </summary>
        public abstract void CharacterCollidedWithRobot(Robot robot);

        /// <summary>
        /// Describes what to do when a robot has collided with a mine.
        /// </summary>
        public abstract void RobotCollidedWithMine(Robot robot, Mine mine);

        /// <summary>
        /// Describes what to do when a bullet has collided with a character.
        /// </summary>
        public abstract void BulletCollidedWithCharacter(Character character);

        /// <summary>
        /// Describes what to do when a bullet has collided with a robot.
        /// </summary>
        public abstract void BulletCollidedWithRobot(Robot robot);

        /// <summary>
        /// Describes what to do when a bullet has collided with a mine.
        /// </summary>
        public abstract void BulletCollidedWithMine(Mine mine);
        
        /// <summary>
        /// Describes what to do when a human has collided with the character.
        /// </summary>
        public abstract void HumanCollidedWithCharacter(Human human);

        /// <summary>
        /// Describes what to do when the character has collided with a mine.
        /// </summary>
        public abstract void CharacterCollidedWithMine(Mine mine);

        /// <summary>
        /// Describes what to present this level as in the top right corner.
        /// </summary>
        public abstract string displayAs();
    }
}
