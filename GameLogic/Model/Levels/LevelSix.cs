using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using GameLogic.Scene;
using GameLogic.Model;
using GameLogic;
using GameLogic.Util;
using GameLogic.Model.Behaviours;

namespace GameLogic.Model.Levels
{
    /// <summary>
    /// Describes the sixth level in the game.
    /// </summary>
    sealed class LevelSix : Level
    {
        /// <summary>
        /// The time since the last frame.
        /// </summary>
        private int timeSinceLastBullet = 0;
        private int millisecondsPerBullet = 2000;

        /// <summary>
        /// The initial amount of robots to spawn in this level.
        /// </summary>
        private const int RobotSpawnCount = 0;

        /// <summary>
        /// The initial amount of mines to spawn in this level.
        /// </summary>
        private const int MineSpawnCount = 20;

        /// <summary>
        /// The initial amount of humans to spawn in this level.
        /// </summary>
        private const int HumanSpawnCount = 0;
        /// <summary>
        /// The random number generator.
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// The boss robot.
        /// </summary>
        private StrongRobot boss;

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

            IEntityBehaviour behaviour = new AttractedToPlayerCharacterBehaviour(scene.character);

            boss = RobotFactory.Produce<StrongRobot>(RobotType.Strong, new Vector2(x, y), behaviour, 1000);
            boss.velocity = 150;

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
            if (boss != null)
            {
                timeSinceLastBullet += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastBullet > millisecondsPerBullet)
                {
                    timeSinceLastBullet -= millisecondsPerBullet;

                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            scene.bullets.Add(new Bullet(boss, new Vector2(x, y), thickness: 10F));
                        }
                    }
                    timeSinceLastBullet = 0;
                }
            }
        }

        /// <summary>
        /// Instantly moves the player character back to the center.
        /// </summary>
        private void MoveCharacterToCenter()
        {
            var centerX = AppConfig.appWidth / 3;
            var centerY = AppConfig.appHeight / 3;

            scene.character.UpdatePosition(x: centerX, y: centerY);
        }

        public override void BulletCollidedWithRobot(Robot boss)
        {
            if (boss.robotType() == RobotType.Strong)
            {
                StrongRobot strongRobot = (StrongRobot)boss;
                strongRobot.currentHealthpoints -= 100;
                if (strongRobot.currentHealthpoints <= 0)
                {
                    remove(boss);
                    this.boss = null;
                    
                    scene.score.Increment(amount: 1000000);
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

        public override string displayAs()
        {
            return "Wave: 6";
        }

        public override void BulletCollidedWithCharacter(Character character)
        {
            // TODO
        }
    }
}
