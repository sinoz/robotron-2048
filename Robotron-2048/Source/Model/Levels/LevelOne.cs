﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using Shared.Source.Scene;

namespace Shared.Source.Model.Levels
{
    /// <summary>
    /// Describes the first level in the game.
    /// </summary>
    sealed class LevelOne : Level
    {
        /// <summary>
        /// The initial amount of robots to spawn in this level.
        /// </summary>
        private const int RobotSpawnCount = 20;

        private const int MineSpawnCount = 7;
        
        /// <summary>
        /// The initial amount of humans to spawn in this level.
        /// </summary>
        private const int HumanSpawnCount = 10;

        /// <summary>
        /// The random number generator.
        /// </summary>
        private readonly Random random = new Random();

        /// <summary>
        /// Creates the first level in the game.
        /// </summary>
        public LevelOne(GameScene scene) : base(scene)
        {
            // nothing
        }

        public override void OnTransition()
        {
            AddRobots();
            AddHumans();
            AddMines();
        }

        /// <summary>
        /// Adds all of the robots corresponding to this level.
        /// </summary>
        private void AddRobots()
        {
            IMobBehaviour attracted = new AttractedToPlayerCharacterBehaviour(scene.character);
            IMobBehaviour walkAround = new WalkAroundBehaviour();

            #region Adding the robots
            for (int i = 1; i <= RobotSpawnCount; i++)
            {
                int x = random.Next(1, 3) == 1 ? random.Next(0, 340) : random.Next(440, 750);
                int y = random.Next(1, 3) == 1 ? random.Next(35, 240) : random.Next(340, 550);

                IMobBehaviour behaviour = random.Next(1, 3) == 1 ? attracted : walkAround;
                Add(new Robot(new Vector2(x, y), behaviour));
            }
            #endregion
        }
        private void AddMines()
        {
            for (int i = 1; i <= MineSpawnCount; i++)
            {
                int x = random.Next(1, 3) == 1 ? random.Next(0, 340) : random.Next(440, 750);
                int y = random.Next(1, 3) == 1 ? random.Next(35, 240) : random.Next(340, 550);

                
                Add(new Mines(new Vector2(x, y)));
            }
        }


        private void AddHumans()
        {
            IMobBehaviour attracted = new AttractedToPlayerCharacterBehaviour(scene.character);
            IMobBehaviour walkAround = new WalkAroundBehaviour();

            #region Adding the humans
            for (int i = 1; i <= HumanSpawnCount; i++)
            {
                int x = random.Next(1, 3) == 1 ? random.Next(0, 340) : random.Next(440, 750);
                int y = random.Next(1, 3) == 1 ? random.Next(35, 240) : random.Next(340, 550);

                IMobBehaviour behaviour = random.Next(1, 3) == 1 ? attracted : walkAround;
                Add(new Human(new Vector2(x, y), behaviour));
            }
            #endregion
        }

        public override void CharacterCollidedWithRobot(Robot robot)
        {
            MoveCharacterToCenter();
        }

        /// <summary>
        /// Instantly moves the player character back to the center.
        /// </summary>
        private void MoveCharacterToCenter()
        {
            scene.character.MoveTo(x: 390, y: 290);
        }

        public override void BulletCollidedWithRobot(Robot robot)
        {
            remove(robot);
            scene.score.Increment(10);

        }

        public override void HumanCollidedWithCharacter(Human human)
        {
            remove(human);
            scene.score.Increment(10);

        }
    }
}
