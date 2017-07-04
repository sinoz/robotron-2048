﻿using System;
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

        private Label menuLabel;

        /// <summary>
        /// Creates a new main menu scene.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public MainMenu(GraphicsDevice graphicsDevice)
        {
            MediaPlayer.Play(LoadedContent.mainMenuSong);

            this.graphicsDevice = graphicsDevice;

            if (AppConfig.deviceType == DeviceType.Android)
            {
                Add(menuLabel = new Label("TOUCH TO START GAME: ", AppConfig.appWidth / 3, AppConfig.appHeight / 2));
            }
            else
            {
                Add(menuLabel = new Label("PRESS ENTER TO START GAME: ", AppConfig.appWidth / 3, AppConfig.appHeight / 2));
            }
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
