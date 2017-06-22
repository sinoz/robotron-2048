using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Robotron_2048.Source.Scene;
using Robotron_2048.Source.Util;

namespace Robotron_2048.Source
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public sealed class RobotronGame : Game
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
        /// The default SpriteFont to utilize for drawing labels.
        /// </summary>
        public static SpriteFont font;

        /// <summary>
        /// The game scene background texture.
        /// </summary>
        public static Texture2D gameBackground;

        /// <summary>
        /// All of the character textures.
        /// </summary>
        public static Texture2D characterDownTex, characterUpTex, characterLeftTex, characterRightTex;

        /// <summary>
        /// All of the Robot textures.
        /// </summary>
        public static Texture2D RobotTex;
        /// <summary>
        /// The set resolution of the application.
        /// </summary>
        public static int appWidth, appHeight;

        /// <summary>
        /// Creates a new game.
        /// </summary>
        public RobotronGame()
        {
            graphics = new GraphicsDeviceManager(this);

            // TODO check if on windows or android
            graphics.PreferredBackBufferHeight = DesktopHeight;
            graphics.PreferredBackBufferWidth = DesktopWidth;

            appWidth = graphics.PreferredBackBufferWidth;
            appHeight = graphics.PreferredBackBufferHeight;

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
            characterDownTex = Content.Load<Texture2D>("Image/robotronguydown");
            characterUpTex = Content.Load<Texture2D>("Image/robotronguyup");
            characterLeftTex = Content.Load<Texture2D>("Image/robotronguyleft");
            characterRightTex = Content.Load<Texture2D>("Image/robotronguyright");

            RobotTex = Content.Load<Texture2D>("Image/RobotTex");
            gameBackground = Content.Load<Texture2D>("Image/Stars");
            font = Content.Load<SpriteFont>("Score");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            characterDownTex.Dispose();
            characterUpTex.Dispose();
            characterLeftTex.Dispose();
            characterRightTex.Dispose();
            gameBackground.Dispose();
            font.Texture.Dispose();
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
