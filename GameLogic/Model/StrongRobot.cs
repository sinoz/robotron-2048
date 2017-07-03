using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameLogic.Util;

namespace GameLogic.Model
{
    public sealed class StrongRobot : Robot
    {
        public const int MovementVelocity = 60;

        public StrongRobot(Vector2 position) : base(position, MovementVelocity)
        {
            // TODO
        }

        public override void Draw(SpriteBatch batch, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override Rectangle EntityRectangle()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
