using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shared.Source.Scene;

namespace Shared.Source.Model
{
    /// <summary>
    /// Describes a single level.
    /// </summary>
    public abstract class Level
    {
        /// <summary>
        /// The game scene.
        /// </summary>
        protected readonly GameScene scene;

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
        /// Describes what to do when a character has collided with a robot.
        /// </summary>
        public abstract void CharacterCollidedWithRobot(Robot robot);

        /// <summary>
        /// Describes what to do when a bullet has collided with a robot.
        /// </summary>
        public abstract void BulletCollidedWithRobot(Robot robot);


        /// <summary>
        /// Describes what to do when a human has collided with the character.
        /// </summary>
        public abstract void HumanCollidedWithCharacter(Human human);

    }
}
