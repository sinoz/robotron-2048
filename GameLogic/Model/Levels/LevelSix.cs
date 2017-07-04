using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using GameLogic.Scene;
using GameLogic.Model;
using GameLogic;

sealed class LevelSix : Level
    {
        /// <summary>
        /// The initial amount of robots to spawn in this level.
        /// </summary>
        private const int RobotSpawnCount = 0;

        /// <summary>
        /// The initial amount of mines to spawn in this level.
        /// </summary>
        private const int MineSpawnCount = 0;

        /// <summary>
        /// The initial amount of humans to spawn in this level.
        /// </summary>
        private const int HumanSpawnCount = 0;
        /// <summary>
        /// The random number generator.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Creates the first level in the game.
        /// </summary>
        public LevelSix(GameScene scene) : base(scene)
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

                int x = AppConfig.appWidth / 2;
                int y = AppConfig.appHeight / 2;

                IMobBehaviour behaviour = new AttractedToPlayerCharacterBehaviour(scene.character);

                StrongRobot boss = RobotFactory.Produce<StrongRobot>(RobotType.Strong, new Vector2(x, y), null, 1000);
                boss.velocity = 0;

                Add(boss);
            #endregion
        }

        /// <summary>
        /// Adds all of the mines corresponding to this level.
        /// </summary>
        private void AddMines()
        {
            for (int i = 1; i <= MineSpawnCount; i++)
            {
                int x = random.Next(1, 3) == 1 ? random.Next(0, 340) : random.Next(440, 750);
                int y = random.Next(1, 3) == 1 ? random.Next(35, 240) : random.Next(340, 550);

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
                int x = random.Next(1, 3) == 1 ? random.Next(0, 340) : random.Next(440, 750);
                int y = random.Next(1, 3) == 1 ? random.Next(35, 240) : random.Next(340, 550);

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
            var centerX = AppConfig.appWidth / 3;
            var centerY = AppConfig.appHeight / 3;

            scene.character.MoveTo(x: centerX, y: centerY);
        }

        public override void BulletCollidedWithRobot(Robot boss)
        {
        if (boss.robotType() == RobotType.Strong)
        {
            StrongRobot strongRobot = (StrongRobot)boss;
            strongRobot.maxHealthpoints -= 10;
            if (strongRobot.maxHealthpoints <= 0)
            {
                remove(boss);
                scene.score.Increment(amount: 100);
            }
        }

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
    }
