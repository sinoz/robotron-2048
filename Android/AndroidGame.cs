using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using GameLogic;
using GameLogic.Model;
using GameLogic.Scene;
using GameLogic.Util;

namespace Android
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public sealed class AndroidGame : Game
    {
        /// <summary>
        /// The virtual width and height to scale to.
        /// </summary>
        public const int VirtualWidth = 1366, VirtualHeight = 768;

        /// <summary>
        /// The stage.
        /// </summary>
        private Stage stage;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// TODO
        /// </summary>
        private RenderTarget2D renderTarget;

        public AndroidGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = VirtualWidth;
            graphics.PreferredBackBufferHeight = VirtualHeight;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;

            TouchPanel.EnableMouseTouchPoint = true;
            TouchPanel.EnabledGestures = GestureType.Hold | GestureType.Tap |  GestureType.DoubleTap | GestureType.FreeDrag | GestureType.Flick | GestureType.Pinch;

            TouchPanel.DisplayWidth = VirtualWidth;
            TouchPanel.DisplayHeight = VirtualHeight;

            AppConfig.deviceType = DeviceType.Android;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            AppConfig.appWidth = VirtualWidth;
            AppConfig.appHeight = VirtualHeight;

            PresentationParameters pp = graphics.GraphicsDevice.PresentationParameters;

            renderTarget = new RenderTarget2D(graphics.GraphicsDevice, VirtualWidth, VirtualHeight, false,
            SurfaceFormat.Color, DepthFormat.None, pp.MultiSampleCount, RenderTargetUsage.DiscardContents);

            stage = new Stage(spriteBatch);
            stage.TransitionInto(new MainMenu(GraphicsDevice));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here

            LoadedContent.characterDownTex = Content.Load<Texture2D>("Image/characterdownfinalized");
            LoadedContent.characterUpTex = Content.Load<Texture2D>("Image/characterupfinalized");
            LoadedContent.characterLeftTex = Content.Load<Texture2D>("Image/characterleftfinalized");
            LoadedContent.characterRightTex = Content.Load<Texture2D>("Image/characterrightfinalized");

            LoadedContent.RobotTex = Content.Load<Texture2D>("Image/RobotTex");
            LoadedContent.RobotBossTex = Content.Load<Texture2D>("Image/RobotBossTex");

            LoadedContent.humanDownTex = Content.Load<Texture2D>("Image/humanDown");
            LoadedContent.humanUpTex = Content.Load<Texture2D>("Image/humanUp");
            LoadedContent.humanLeftTex = Content.Load<Texture2D>("Image/humanLeft");
            LoadedContent.humanRighTex = Content.Load<Texture2D>("Image/humanRight");

            LoadedContent.gameBackground = Content.Load<Texture2D>("Image/Stars");
            LoadedContent.font = Content.Load<SpriteFont>("Score");
            LoadedContent.titelFont = Content.Load<SpriteFont>("TitelFont");

            LoadedContent.SquareMine = Content.Load<Texture2D>("Image/SquareMine");

            LoadedContent.Life = Content.Load<Texture2D>("Image/Life");

            LoadedContent.bulletSound = Content.Load<SoundEffect>("Sound/bullet");
            LoadedContent.characterDeathSound = Content.Load<SoundEffect>("Sound/characterDeath");
            LoadedContent.robotDeathSound = Content.Load<SoundEffect>("Sound/robotDeath");
            LoadedContent.humanPickup = Content.Load<SoundEffect>("Sound/humanPickup");
            LoadedContent.nextLevelSound = Content.Load<SoundEffect>("Sound/nextLevel");
            LoadedContent.mineExplosionSound = Content.Load<SoundEffect>("Sound/mineExplosion");
            LoadedContent.lifeLossSound = Content.Load<SoundEffect>("Sound/lifeLoss");
            LoadedContent.mainMenuSong = Content.Load<Song>("Sound/mainMenuSong");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

            LoadedContent.characterDownTex.Dispose();
            LoadedContent.characterUpTex.Dispose();
            LoadedContent.characterLeftTex.Dispose();
            LoadedContent.characterRightTex.Dispose();
            LoadedContent.gameBackground.Dispose();
            LoadedContent.font.Texture.Dispose();
            LoadedContent.Life.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                //Exit();
            }

            // TODO: Add your update logic here

            stage.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            graphics.GraphicsDevice.SetRenderTarget(renderTarget);

            stage.Draw(gameTime);

            #region Borrowed code
            // draw render target
            float outputAspect = Window.ClientBounds.Width / (float)Window.ClientBounds.Height;
            float preferredAspect = VirtualWidth / (float)VirtualHeight;

            Rectangle dst;

            if (outputAspect <= preferredAspect)
            {
                // output is taller than it is wider, bars on top/bottom
                int presentHeight = (int)((Window.ClientBounds.Width / preferredAspect) + 0.5f);
                int barHeight = (Window.ClientBounds.Height - presentHeight) / 2;

                dst = new Rectangle(0, barHeight, Window.ClientBounds.Width, presentHeight);
            }
            else
            {
                // output is wider than it is tall, bars left/right
                int presentWidth = (int)((Window.ClientBounds.Height * preferredAspect) + 0.5f);
                int barWidth = (Window.ClientBounds.Width - presentWidth) / 2;

                dst = new Rectangle(barWidth, 0, presentWidth, Window.ClientBounds.Height);
            }
            #endregion

            graphics.GraphicsDevice.SetRenderTarget(null);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            spriteBatch.Draw(renderTarget, dst, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
