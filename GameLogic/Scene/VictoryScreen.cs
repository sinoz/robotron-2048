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
    public class VictoryScreen : Scene
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



        private Label menuLabel;
        private Label titelLabel;
        private SpriteFont Font = LoadedContent.titelFont;
        private SpriteFont normalFont = LoadedContent.font;



        public int velocity = 2;
        /// <summary>
        /// Creates a new main menu scene.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public VictoryScreen(GraphicsDevice graphicsDevice)
        {
            MediaPlayer.Play(LoadedContent.mainMenuSong);

            this.graphicsDevice = graphicsDevice;


            Add(titelLabel = new Label(Font, "YOU WON!", AppConfig.appWidth / 3.1f, AppConfig.appHeight / 4, Color.MediumVioletRed));

            if (AppConfig.deviceType == DeviceType.Android)
            {
                Add(menuLabel = new Label(normalFont, "TOUCH TO RETURN TO THE MAIN MENU ", AppConfig.appWidth / 2.8f, AppConfig.appHeight / 2, Color.White));

            }
            else
            {

                Add(menuLabel = new Label(normalFont, "PRESS ENTER TO RETURN TO THE MAIN MENU ", AppConfig.appWidth / 2.8f, AppConfig.appHeight / 1.5f, Color.White));

            }



        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {


            base.Draw(batch, gameTime);
        }

        public override void Update(GameTime gameTime)
        {


            TransitionToGameSceneOnKey(gameTime);

            base.Update(gameTime);

        }




        private void TransitionToGameSceneOnKey(GameTime gameTime)
        {
            var touchPanelState = TouchPanel.GetState();

            foreach (var touch in touchPanelState)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    MediaPlayer.Stop();

                    stage.TransitionInto(new MainMenu(graphicsDevice));

                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                MediaPlayer.Stop();

                stage.TransitionInto(new MainMenu(graphicsDevice));
            }
        }
    }
}
