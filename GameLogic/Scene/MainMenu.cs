using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameLogic.Util;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;
using GameLogic.Model;

namespace GameLogic.Scene
{
    /// <summary>
    /// Describes a main menu scene.
    /// </summary>
    public class MainMenu : Scene
    {
        /// <summary>
        /// The graphics device.
        /// </summary>
        private GraphicsDevice graphicsDevice;

        public const int Rows = 1;

        /// <summary>
        /// The columns.
        /// </summary>
        public const int Columns = 3;

        /// <summary>
        /// The total amount of frames to transition across.
        /// </summary>
        private const int TotalAmtOfFrames = Rows * Columns;

        /// <summary>
        /// The current texture frame.
        /// </summary>
        public Texture2D currentTexture = LoadedContent.characterDownTex;

        /// <summary>
        /// The current frame being rendered.
        /// </summary>
        private int currentFrame;

        /// <summary>
        /// The time since the last frame.
        /// </summary>
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 1;


        private Label menuLabel;
        private Label titelLabel;
        private SpriteFont Font = LoadedContent.titelFont;
        private SpriteFont normalFont = LoadedContent.font;

        private Character character;
        private Character female;
        private Character robot;
        private Character robot2;

        public int velocity = 2;
        /// <summary>
        /// Creates a new main menu scene.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public MainMenu(GraphicsDevice graphicsDevice)
        {
            MediaPlayer.Play(LoadedContent.mainMenuSong);

            this.graphicsDevice = graphicsDevice;

            this.character = new Character();
            this.female = new Character();
            this.robot = new Character();
            this.robot2 = new Character();
            Add(titelLabel = new Label(Font, "  Robotron 2048", AppConfig.appWidth / 6, AppConfig.appHeight / 4, Color.White));

            if (AppConfig.deviceType == DeviceType.Android)
            {
                Add(menuLabel = new Label(normalFont, "TOUCH TO START GAME: ", AppConfig.appWidth / 3, AppConfig.appHeight / 2, Color.White));
            }
            else
            {
                Add(menuLabel = new Label(normalFont, "PRESS ENTER TO START GAME: ", AppConfig.appWidth / 2.5f, AppConfig.appHeight / 1.5f, Color.White));

            }

            character.currentTexture = LoadedContent.characterRightTex;
            female.currentTexture = LoadedContent.humanLeftTex;
            female.position.X = AppConfig.appWidth / 2.2f;
            robot.position.X = AppConfig.appWidth / 2.1f;
            robot2.position.X = AppConfig.appWidth / 2.1f;

        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            DrawEntities(batch, gameTime);

            base.Draw(batch, gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateChars(gameTime);

            TransitionToGameSceneOnKey(gameTime);

            base.Update(gameTime);

        }

        private void UpdateChars(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            robot2.currentTexture = LoadedContent.RobotTex;
            robot.currentTexture = LoadedContent.RobotTex;
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
                character.Update(gameTime);
                female.Update(gameTime);
                robot.Update(gameTime);
                robot2.Update(gameTime);
            }

            character.position.X += velocity;
            female.position.X -= velocity;
            robot.position.Y += velocity;
            robot2.position.Y -= velocity;

            if (character.position.X > AppConfig.appWidth - 400)
            {
                velocity = -2;
                female.currentTexture = LoadedContent.humanRighTex;
                character.currentTexture = LoadedContent.characterLeftTex;
            }
            if (character.position.X < AppConfig.appWidth - AppConfig.appWidth + 400)
            {

                velocity = 2; female.currentTexture = LoadedContent.humanLeftTex;
                character.currentTexture = LoadedContent.characterRightTex;

            }
            female.Update(gameTime);
        }

        private void DrawEntities(SpriteBatch batch, GameTime gameTime)
        {
            #region Drawing the player character
            robot2.Draw(batch, gameTime);
            robot.Draw(batch, gameTime);
            character.Draw(batch, gameTime);
            female.Draw(batch, gameTime);


            #endregion
        }
        private void TransitionToGameSceneOnKey(GameTime gameTime)
        {
            var touchPanelState = TouchPanel.GetState();

            foreach (var touch in touchPanelState)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    MediaPlayer.Stop();

                    stage.TransitionInto(new GameScene(graphicsDevice));

                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                MediaPlayer.Stop();

                stage.TransitionInto(new GameScene(graphicsDevice));
            }
        }
    }
}
