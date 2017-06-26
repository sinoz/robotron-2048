using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robotron_2048.Source.Model
{
    interface IBullet
    {
        void Draw(SpriteBatch batch, GameTime gameTime);
        void Update(GameTime gameTime);
    }
}