using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameLogic.Model;
using GameLogic.Model.Behaviours;
using GameLogic.Model.Levels;
using GameLogic.Util;

namespace GameLogic.Scene
{
    /// <summary>
    /// The game scene.
    /// </summary>
    public sealed class GameScene : Scene
    {
        /// <summary>
        /// The graphics device.
        /// </summary>
        private GraphicsDevice graphicsDevice;

        /// <summary>
        /// The initial amount of lives the player starts with.
        /// </summary>
        public int InitialAmountOfLives = 3;

        /// <summary>
        /// The time elapsed since the last bullet was fired.
        /// </summary>
        private int timeSinceLastbullet = 0;

        /// <summary>
        /// The time span between firing bullets.
        /// </summary>
        private int millisecondsPerbullet = 250;

        /// <summary>
        /// The last direction bullets moved towards.
        /// </summary>
        private int lastBulletDirectionX = 0, lastBulletDirectionY = 1;

        /// <summary>
        /// The game character.
        /// </summary>
        public Character character;

        /// <summary>
        /// The list of fired bullets.
        /// </summary>
        public IList<Bullet> bullets = new List<Bullet>();

        /// <summary>
        /// The list of mines.
        /// </summary>
        public IList<Mine> mines = new List<Mine>();

        /// <summary>
        /// The enemy Robots.
        /// </summary>
        public IList<Robot> robots = new List<Robot>();

        /// <summary>
        /// The Humans.
        /// </summary>
        public IList<Human> humans = new List<Human>();

        /// <summary>
        /// The collection of remaining lives.
        /// </summary>
        public IList<Life> lives = new List<Life>();

        /// <summary>
        /// TODO
        /// </summary>
        private int gainlife;

        /// <summary>
        /// The score of the player.
        /// </summary>
        public readonly Score score;

        /// <summary>
        /// The current wave.
        /// </summary>
        public readonly Wave wave;

        /// <summary>
        /// The current level.
        /// </summary>
        public Level currentLevel;

        #region All levels
        public Level level1;
        public Level level2;
        public Level level3;
        public Level level4;
        public Level level5;
        public Level level6;
        #endregion

        /// <summary>
        /// Creates a new game scene.
        /// </summary>
        public GameScene(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            
            this.character = new Character(new ControllableThroughInputBehaviour());

            this.score = new Score(this);

            this.wave = new Wave(this);

            #region levels
            this.level1 = new LevelOne(this);
            this.level2 = new LevelTwo(this);
            this.level3 = new LevelThree(this);
            this.level4 = new LevelFour(this);
            this.level5 = new LevelFive(this);
            this.level6 = new LevelSix(this);

            this.currentLevel = level1;
            #endregion

            TransitionInto(currentLevel);

            #region Appends the initial amount of lives for display
            for (int i = 0; i < InitialAmountOfLives; i++)
            {
                lives.Add(new Life(new Vector2(90 + (i * Life.Width), 0)));
           
            }
            #endregion
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            DrawEntities(batch, gameTime);
            DrawHUD(batch, gameTime);

            base.Draw(batch, gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateEntities(gameTime);
            TransitionToMainMenuOnKey(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws all of the entities such as player characters and bullets.
        /// </summary>
        /// <param name="batch">The SpriteBatch to draw the entities on.</param>
        /// <param name="gameTime">The delta time.</param>
        private void DrawEntities(SpriteBatch batch, GameTime gameTime)
        {
            #region Drawing the player character
            character.Draw(batch, gameTime);
            #endregion

            #region Drawing the enemy robots
            if (robots.Count > 0)
            {
                int count = 0;
                while (count < robots.Count)
                {
                    Robot robot = robots[count];

                    robot.Draw(batch, gameTime);

                    count += 1;
                }
            }
            #endregion

            #region Drawing the humans
            if (humans.Count > 0)
            {
                int count = 0;
                while (count < humans.Count)
                {
                    Human human = humans[count];
                    if (human != null)
                    {
                        human.Draw(batch, gameTime);
                    }

                    count += 1;
                }
            }
            #endregion

            #region Drawing the fired bullets
            if (bullets.Count > 0)
            {
                int count = 0;
                while (count < bullets.Count)
                {
                    Bullet bullet = bullets[count];

                    bullet.Draw(batch, gameTime);
                    
                    count += 1;
                }
            }
            #endregion

            #region Drawing the mines
            if (mines.Count > 0)
            {
                int count = 0;
                while (count < mines.Count)
                {
                    Mine mine = mines[count];

                    mine.Draw(batch, gameTime);

                    count += 1;
                }
            }
            #endregion
        }
        
        /// <summary>
        /// Draws an in-game HUD.
        /// </summary>
        /// <param name="batch">The SpriteBatch to draw the hud on. </param>
        /// <param name="gameTime">The delta time.</param>
        private void DrawHUD(SpriteBatch batch, GameTime gameTime)
        {
            #region Draws the score.
            batch.DrawLine(new Vector2(0, 35), new Vector2(AppConfig.appWidth, 35), Color.White, 5);
            #endregion

            #region Drawing lives.
            if (lives.Count > 0)
            {
                int count = 0;
                while (count < lives.Count)
                {
                    Life life = lives[count];
                    if (life != null)
                    {
                        life.Draw(batch, gameTime);
                    }

                    count += 1;
                }
            }
            
            #endregion
        }
        
        /// <summary>
        /// Updates the entities.
        /// </summary>
        /// <param name="gameTime">The delta time.</param>
        private void UpdateEntities(GameTime gameTime)
        {
            #region gain life
            if (gainlife >= 200)
            {
                lives.Add(new Life(new Vector2(90 + (lives.Count * Life.Width), 0)));
                gainlife = 0;
            }
            #endregion

            #region Adding new bullets
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                lastBulletDirectionY = -1;
                lastBulletDirectionX = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                lastBulletDirectionY = 1;
                lastBulletDirectionX = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                lastBulletDirectionX = 1;
                lastBulletDirectionY = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                lastBulletDirectionX = -1;
                lastBulletDirectionY = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                lastBulletDirectionY = -1;
                lastBulletDirectionX = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                lastBulletDirectionY = 1;
                lastBulletDirectionX = 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                lastBulletDirectionY = -1;
                lastBulletDirectionX = -1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                lastBulletDirectionY = 1;
                lastBulletDirectionX = -1;
            }

            timeSinceLastbullet += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastbullet > millisecondsPerbullet)
            {
                bullets.Add(new Bullet(character, new Vector2(lastBulletDirectionX, lastBulletDirectionY)));
                LoadedContent.bulletSound.Play();
                timeSinceLastbullet = 0;
            }
            #endregion

            #region Updating of Bullets
            int count = 0;
            while (count < bullets.Count)
            {
                Bullet bullet = bullets[count];
                if (bullet != null)
                {
                    #region Checks the intersection between the character, robots and bullets.
                    int robotCount = 0;
                    int mineCount = 0;
                    
                    while (robotCount < robots.Count)
                    {
                        Robot robot = robots[robotCount];
                        if (robot != null)
                        {
                            if (bullet.IntersectsWith(robot) && !bullet.shooter.Equals(robot))
                            {
                                bullets.Remove(bullet);
                                currentLevel.BulletCollidedWithRobot(robot);
                                if (currentLevel != level6)
                                {
                                gainlife = gainlife + 10;
                                }
                               
                                LoadedContent.robotDeathSound.Play();
                                #region switching levels
                                if (currentLevel == level1 && robots.Count == 0)
                                {
                                    currentLevel = level2;
                                    TransitionInto(currentLevel);
                                    character.UpdatePosition(AppConfig.appWidth / 2 , AppConfig.appHeight / 2);
                                    wave.value += 1;
                                    LoadedContent.nextLevelSound.Play();

                                }
                                if (currentLevel == level2 && robots.Count == 0)
                                {
                                    currentLevel = level3;
                                    TransitionInto(currentLevel);
                                    character.UpdatePosition(AppConfig.appWidth / 2, AppConfig.appHeight / 2);
                                    wave.value += 1;
                                    LoadedContent.nextLevelSound.Play();
                                }
                                if (currentLevel == level3 && robots.Count == 0)
                                {
                                    currentLevel = level4;
                                    TransitionInto(currentLevel);
                                    character.UpdatePosition(AppConfig.appWidth / 2, AppConfig.appHeight / 2);
                                    wave.value += 1;
                                    LoadedContent.nextLevelSound.Play();
                                }
                                if (currentLevel == level4 && robots.Count == 0)
                                {
                                    currentLevel = level5;
                                    TransitionInto(currentLevel);
                                    character.UpdatePosition(AppConfig.appWidth / 2, AppConfig.appHeight / 2);
                                    wave.value += 1;
                                    LoadedContent.nextLevelSound.Play();
                                }
                                if (currentLevel == level5 && robots.Count == 0)
                                {
                                    currentLevel = level6;
                                    TransitionInto(currentLevel);
                                    character.UpdatePosition(x: 390, y: 290);
                                    wave.value += 1;
                                    LoadedContent.nextLevelSound.Play();
                                }
                                if(currentLevel == level6 && robots.Count == 0)
                                {
                                    stage.TransitionInto(new VictoryScreen(graphicsDevice));
                                }

                                wave.Refresh();
                                #endregion
                            }

                            if (bullet.IntersectsWith(character) && !bullet.shooter.Equals(character))
                            {
                                #region Removal of a remaining life
                                if (lives.Count > 1)
                                {
                                    lives.RemoveAt(lives.Count - 1);
                                    currentLevel.BulletCollidedWithCharacter(character);
                                    bullets.Remove(bullet);
                                }
                                else
                                {
                                    GameOver();
                                }
                                #endregion
                            }

                            if (robot.IntersectsWith(character))
                            {
                                #region Removal of a remaining life
                                if (lives.Count > 1)
                                {
                                    lives.RemoveAt(lives.Count - 1);
                                    currentLevel.CharacterCollidedWithRobot(robot);
                                    LoadedContent.lifeLossSound.Play();
                                    TransitionInto(currentLevel);
                                }
                                else
                                {
                                    GameOver();
                                }
                                #endregion
                            }           
                        }

                        robotCount += 1;
                    }
                    while (mineCount < mines.Count)
                    {
                        Mine mine = mines[mineCount];
                        if (mine != null)
                        {
                            if (bullet.IntersectsWith(mine))
                            {
   
                                currentLevel.BulletCollidedWithMine(mine);
                                LoadedContent.mineExplosionSound.Play();
                            }
                            if (mine.IntersectsWith(character))
                            {
                                #region Removal of a remaining life
                                if (lives.Count > 1)
                                {
                                    lives.RemoveAt(lives.Count - 1);
                                    currentLevel.CharacterCollidedWithMine(mine);
                                    LoadedContent.lifeLossSound.Play();
                                    TransitionInto(currentLevel);
                                }
                                else
                                {
                                    GameOver();
                                }
                                #endregion
                            }                            
                        }
                        mineCount += 1;
                    }
                    if (bullet.isOutOfBounds())
                    {
                        bullets.Remove(bullet);
                    }
                    else
                    {
                        bullet.Update(gameTime);
                    }
                    #endregion
                }

                count += 1;
            }

            count = 0;
            #endregion

            #region Updating the robots
            while (count < robots.Count)
            {
                Robot robot = robots[count];
                if (robot != null)
                {
                    int urmum = 0;
                    while (urmum < mines.Count)
                    {
                        Mine mine = mines[urmum];
                        if (mine != null)
                        {
                            if (mine.IntersectsWith(robot))
                            {

                                mines.Remove(mine);
                                currentLevel.RobotCollidedWithMine(robot, mine);
                                LoadedContent.mineExplosionSound.Play();
                                LoadedContent.robotDeathSound.Play();
                                #region switching levels
                                if (currentLevel == level1 && robots.Count == 0)
                                {
                                    currentLevel = level2;
                                    TransitionInto(currentLevel);
                                    character.UpdatePosition(AppConfig.appWidth / 2, AppConfig.appHeight / 2);
                                    wave.value += 1;
                                    LoadedContent.nextLevelSound.Play();

                                }
                                if (currentLevel == level2 && robots.Count == 0)
                                {
                                    currentLevel = level3;
                                    TransitionInto(currentLevel);
                                    character.UpdatePosition(AppConfig.appWidth / 2, AppConfig.appHeight / 2);
                                    wave.value += 1;
                                    LoadedContent.nextLevelSound.Play();
                                }
                                if (currentLevel == level3 && robots.Count == 0)
                                {
                                    currentLevel = level4;
                                    TransitionInto(currentLevel);
                                    character.UpdatePosition(AppConfig.appWidth / 2, AppConfig.appHeight / 2);
                                    wave.value += 1;
                                    LoadedContent.nextLevelSound.Play();
                                }
                                if (currentLevel == level4 && robots.Count == 0)
                                {
                                    currentLevel = level5;
                                    TransitionInto(currentLevel);
                                    character.UpdatePosition(AppConfig.appWidth / 2, AppConfig.appHeight / 2);
                                    wave.value += 1;
                                    LoadedContent.nextLevelSound.Play();
                                }
                                if (currentLevel == level5 && robots.Count == 0)
                                {
                                    currentLevel = level6;
                                    TransitionInto(currentLevel);
                                    character.UpdatePosition(x: 390, y: 290);
                                    wave.value += 1;
                                    LoadedContent.nextLevelSound.Play();
                                }
                                if (currentLevel == level6 && robots.Count == 0)
                                {
                                    stage.TransitionInto(new VictoryScreen(graphicsDevice));
                                }

                                wave.Refresh();
                                #endregion

                            }
                        }

                        urmum += 1;
                    }

                    if (robot.IntersectsWith(character))
                    {
                        currentLevel.CharacterCollidedWithRobot(robot);
                        LoadedContent.lifeLossSound.Play();
                    }

                    robot.Update(gameTime);
                }

                count += 1;
            }

            count = 0;
            #endregion

            #region Updating the humans
            while (count < humans.Count)
            {
                Human human = humans[count];
                if (human != null)
                {
                    if (character.IntersectsWith(human))
                    {
                        currentLevel.HumanCollidedWithCharacter(human);
                        gainlife = gainlife + 10;
                        LoadedContent.humanPickup.Play();
                    }                                     
                    human.Update(gameTime);
                }
                count += 1;
            }

            count = 0;
            #endregion

            #region Updating of the player character
            character.Update(gameTime);

            #endregion

            #region Updating the mines
            
            while (count < mines.Count)
            {
                Mine mine = mines[count];
                if (mine != null)
                {
                    if (mine.IntersectsWith(character))
                    {
                        #region Removal of a remaining life
                        if (lives.Count > 1)
                        {
                            LoadedContent.lifeLossSound.Play();
                            LoadedContent.mineExplosionSound.Play();
                            lives.RemoveAt(lives.Count - 1);
                            currentLevel.CharacterCollidedWithMine(mine);
                        }
                        else
                        {
                            GameOver();
                        }
                        #endregion

                    }
                    
                    mine.Update(gameTime);
                }

                count += 1;
            }
   
            count = 0;
            #endregion

            #region Updating the current level
            currentLevel.Update(gameTime);
            #endregion
        }

        /// <summary>
        /// Transitions into the main menu scene when the user has pressed the 'Enter' key.
        /// </summary>
        /// <param name="gameTime">The delta time.</param>
        private void TransitionToMainMenuOnKey(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                stage.TransitionInto(new MainMenu(graphicsDevice));
            }
        }

        /// <summary>
        /// Transitions into the game over screen, ending the game.
        /// </summary>
        public void GameOver()
        {
            LoadedContent.characterDeathSound.Play();
            stage.TransitionInto(new GameOverScreen(graphicsDevice));
        }

        /// <summary>
        /// Transitions from the current level to the specified level.
        /// </summary>
        /// <param name="level">The level to transition to.</param>
        public void TransitionInto(Level level)
        {
            // TODO more stuff when the player changes levels

            robots.Clear();
            bullets.Clear();
            humans.Clear();
            mines.Clear();

            
            this.currentLevel = level;
            this.currentLevel.OnTransition();
        }
    }
}