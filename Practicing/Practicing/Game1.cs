using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Practicing
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        static float start_pos_X = 200;
        static float start_pos_Y = 200;
        public float speedX = 125f;

        private Character ourCharacter;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>("Image/robotronguydown");
            ourCharacter = new Character(texture, 1, 3);
            

            // TODO: use this.Content to load your game content here
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


            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;



            // TODO: Add your update logic here
            ourCharacter.Update(gameTime);
            Texture2D textureW = Content.Load<Texture2D>("Image/robotronguyup");
            Texture2D textureS = Content.Load<Texture2D>("Image/robotronguydown");
            Texture2D textureA = Content.Load<Texture2D>("Image/robotronguyleft");
            Texture2D textureD = Content.Load<Texture2D>("Image/robotronguyright");

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                start_pos_Y -= speedX * delta;
                //ourCharacter = new Character(textureW, 1, 3);
                ourCharacter.Texture = textureW;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                start_pos_Y += speedX * delta;
                //ourCharacter = new Character(textureS, 1, 3);
                ourCharacter.Texture = textureS;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                start_pos_X -= speedX * delta;
                //ourCharacter = new Character(textureA, 1, 3);
                ourCharacter.Texture = textureA;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                start_pos_X += speedX * delta;
                //ourCharacter = new Character(textureD, 1, 3);
                ourCharacter.Texture = textureD;

            }
            
            base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            ourCharacter.Draw(spriteBatch, new Vector2(start_pos_X,start_pos_Y));
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
