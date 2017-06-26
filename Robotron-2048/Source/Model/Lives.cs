using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shared.Source.Util;
using Shared.Source.Scene;

namespace Shared.Source.Model
{
    public sealed class Lives : IEntity
    {
        private Texture2D available_lives = LoadedContent.Life;
        private Vector2 life_1 = new Vector2();
        private Vector2 life_2 = new Vector2();
        private Vector2 life_3 = new Vector2();

        public const int widt = 41;

        /// <summary>
        /// The height of a single frame of a character.
        /// </summary>
        public const int heigt = 45;
        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            batch.Draw(available_lives, life_1, Color.White);
        }

        public Rectangle EntityRectangle()
        {
            return new Rectangle((int)life_1.X, (int)life_1.Y, widt, heigt);
        }

        public void Update(GameTime gameTime)
        {

            life_1.X = 70;
            life_1.Y = 0;

            
        }
    }
}
