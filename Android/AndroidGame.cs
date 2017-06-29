using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameLogic;
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
        /// The stage.
        /// </summary>
        private Stage stage;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public AndroidGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
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

            AppConfig.appWidth = GraphicsDevice.DisplayMode.Width;
            AppConfig.appHeight = GraphicsDevice.DisplayMode.Height;

            stage = new Stage(GraphicsDevice);
            stage.TransitionInto(new GameScene(GraphicsDevice));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

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

            LoadedContent.SquareMine = Content.Load<Texture2D>("Image/SquareMine");

            LoadedContent.Life = Content.Load<Texture2D>("Image/Life");
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

            // TODO: Add your drawing code here

            stage.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
