using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Robotron_2048
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        /// <summary>
        /// The graphics device manager.
        /// </summary>
        GraphicsDeviceManager graphics;

        /// <summary>
        /// The stage.
        /// </summary>
        Stage stage;

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
        /// The set resolution of the application.
        /// </summary>
        public static int appWidth, appHeight;

        /// <summary>
        /// The default width and height of the application on the desktop.
        /// </summary>
        public const int DesktopWidth = 800, DesktopHeight = 600;

        /// <summary>
        /// Creates a new game.
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            // TODO check if on windows or android
            graphics.PreferredBackBufferHeight = DesktopHeight;
            graphics.PreferredBackBufferWidth = DesktopWidth;

            appWidth = graphics.PreferredBackBufferWidth;
            appHeight = graphics.PreferredBackBufferHeight;

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
            // For now we load content here until we find a solution to a NPE caused by
            // Initialize() being called before LoadContent()
            characterDownTex = Content.Load<Texture2D>("Image/robotronguydown");
            characterUpTex = Content.Load<Texture2D>("Image/robotronguyup");
            characterLeftTex = Content.Load<Texture2D>("Image/robotronguyleft");
            characterRightTex = Content.Load<Texture2D>("Image/robotronguyright");
            gameBackground = Content.Load<Texture2D>("Image/Stars");
            font = Content.Load<SpriteFont>("Score");

            // TODO: Add your initialization logic here

            stage = new Stage(GraphicsDevice);
            stage.TransitionInto(new GameScene(GraphicsDevice));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: Load all of your content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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
