using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Shared.Source;
using Shared.Source.Scene;
using Shared.Source.Util;

namespace DesktopGL
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public sealed class DesktopGame : Game
    {
        /// <summary>
        /// The default width and height of the application on the desktop.
        /// </summary>
        public const int DesktopWidth = 800, DesktopHeight = 600;

        
        /// <summary>
        /// The initial title of the application.
        /// </summary>
        public const string DesktopAppTitle = "Robotron 2048";

        /// <summary>
        /// The graphics device manager.
        /// </summary>
        private readonly GraphicsDeviceManager graphics;

        /// <summary>
        /// The frames-per-second counter.
        /// </summary>
        private readonly FPSCounter fpsCounter;

        /// <summary>
        /// The stage.
        /// </summary>
        private Stage stage;

        /// <summary>
        /// Creates a new game.
        /// </summary>
        public DesktopGame()
        {
            graphics = new GraphicsDeviceManager(this);

            // TODO check if on windows or android
            graphics.PreferredBackBufferHeight = DesktopHeight;
            graphics.PreferredBackBufferWidth = DesktopWidth;

            AppConfig.appWidth = graphics.PreferredBackBufferWidth;
            AppConfig.appHeight = graphics.PreferredBackBufferHeight;

            Window.Title = DesktopAppTitle;

            fpsCounter = new FPSCounter(this);

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // First we call base.Initialize() which automatically calls LoadContent() to load all our resources.
            base.Initialize();

            // Now that all of our resources have been loaded into memory, we can do what we need to do.
            stage = new Stage(GraphicsDevice);
            stage.TransitionInto(new GameScene(GraphicsDevice));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            LoadedContent.characterDownTex = Content.Load<Texture2D>("Image/robotronguydown");
            LoadedContent.characterUpTex = Content.Load<Texture2D>("Image/robotronguyup");
            LoadedContent.characterLeftTex = Content.Load<Texture2D>("Image/robotronguyleft");
            LoadedContent.characterRightTex = Content.Load<Texture2D>("Image/robotronguyright");

            LoadedContent.RobotTex = Content.Load<Texture2D>("Image/RobotTex");

            LoadedContent.humanDownTex = Content.Load<Texture2D>("Image/humanDown");
            LoadedContent.humanUpTex = Content.Load<Texture2D>("Image/humanUp");
            LoadedContent.humanLeftTex = Content.Load<Texture2D>("Image/humanLeft");
            LoadedContent.humanRighTex = Content.Load<Texture2D>("Image/humanRight");

            LoadedContent.gameBackground = Content.Load<Texture2D>("Image/Stars");
            LoadedContent.font = Content.Load<SpriteFont>("Score");

            LoadedContent.Greenbox = Content.Load<Texture2D>("Image/Greenbox");

            LoadedContent.Life = Content.Load<Texture2D>("Image/Life");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            fpsCounter.Update(gameTime);
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

            stage.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
