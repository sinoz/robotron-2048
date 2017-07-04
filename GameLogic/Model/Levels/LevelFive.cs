using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using GameLogic.Scene;

namespace GameLogic.Model.Levels
{
    /// <summary>
    /// Describes the first level in the game.
    /// </summary>
    sealed class LevelFive : Level
    {
        /// <summary>
        /// The initial amount of robots to spawn in this level.
        /// </summary>
        private const int RobotSpawnCount = 15;

        /// <summary>
        /// The initial amount of mines to spawn in this level.
        /// </summary>
        private const int MineSpawnCount = 15;

        /// <summary>
        /// The initial amount of humans to spawn in this level.
        /// </summary>
        private const int HumanSpawnCount = 7;

        /// <summary>
        /// The random number generator.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Creates the first level in the game.
        /// </summary>
        public LevelFive(GameScene scene) : base(scene)
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
            #region Adding the robots
            for (int i = 1; i <= RobotSpawnCount; i++)
            {
                int x = random.Next(1, 3) == 1 ? random.Next(0, 340) : random.Next(440, AppConfig.appWidth);
                int y = random.Next(1, 3) == 1 ? random.Next(35, 240) : random.Next(340, AppConfig.appHeight);


                IEntityBehaviour behaviour = new AttractedToPlayerCharacterBehaviour(scene.character);

                MinionRobot minion = RobotFactory.Produce<MinionRobot>(RobotType.Minion, new Vector2(x, y), behaviour);
                minion.velocity = 210;

                Add(minion);
            }
            #endregion
        }

        /// <summary>
        /// Adds all of the mines corresponding to this level.
        /// </summary>
        private void AddMines()
        {
            for (int i = 1; i <= MineSpawnCount; i++)
            {
                int x = random.Next(1, 3) == 1 ? random.Next(0, 340) : random.Next(440, AppConfig.appWidth);
                int y = random.Next(1, 3) == 1 ? random.Next(35, 240) : random.Next(340, AppConfig.appHeight);

                Add(new Mine(new Vector2(x, y)));
            }
        }

        /// <summary>
        /// Adds all of the humans corresponding to this level.
        /// </summary>
        private void AddHumans()
        {
            #region Adding the humans
            for (int i = 1; i <= HumanSpawnCount; i++)
            {
                int x = random.Next(1, 3) == 1 ? random.Next(0, 340) : random.Next(440, AppConfig.appWidth);
                int y = random.Next(1, 3) == 1 ? random.Next(35, 240) : random.Next(340, AppConfig.appHeight);

                Human human = new Human(new Vector2(x, y), new WalkAroundBehaviour());
                human.velocity = 250;
                Add(human);
            }
            #endregion
        }

        public override void CharacterCollidedWithRobot(Robot robot)
        {
            MoveCharacterToCenter();
        }

        public override void Update(GameTime gameTime)
        {
            // nothing
        }

        /// <summary>
        /// Instantly moves the player character back to the center.
        /// </summary>
        private void MoveCharacterToCenter()
        {
            var centerX = AppConfig.appWidth / 2;
            var centerY = AppConfig.appHeight / 2;

            scene.character.MoveTo(x: centerX, y: centerY);
        }

        public override void BulletCollidedWithRobot(Robot robot)
        {
            remove(robot);
            scene.score.Increment(amount: 10);

            #region Sample code casting Robot to StrongRobot if RobotType is of type Strong
            if (robot.robotType() == RobotType.Strong)
            {
                StrongRobot strongRobot = (StrongRobot)robot;
                
                // TODO
            }
            #endregion
        }

        public override void BulletCollidedWithMine(Mine mine)
        {
            remove(mine);
        }

        public override void HumanCollidedWithCharacter(Human human)
        {
            remove(human);
            scene.score.Increment(amount: 10);
        }

        public override void CharacterCollidedWithMine(Mine mine)
        {
            remove(mine);
            MoveCharacterToCenter();
        }

        public override string displayAs()
        {
            return "Wave: 5";
        }
    }
}
