using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using GameLogic.Model;
using GameLogic.Util;

namespace GameLogic.Model.Behaviours
{
    /// <summary>
    /// A behavioural act where entities simply walk around.
    /// </summary>
    public sealed class WalkAroundBehaviour : IEntityBehaviour
    {
        private static Random random = new Random();
        private Vector2 direction = new Vector2(0, 0);

        private int timeSinceLastFrame;
        private int millisecondsPerFrame;

        public void Act(Robot robot, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Act(Human human, GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame >= millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;

                direction.X = random.Next(-1, 2);
                direction.Y = random.Next(-1, 2);

                millisecondsPerFrame = random.Next(400, 3500);
            }

            var x = human.position.X;
            var y = human.position.Y;

            x += (direction.X * (int)(human.velocity * gameTime.ElapsedGameTime.TotalSeconds));
            y += (direction.Y * (int)(human.velocity * gameTime.ElapsedGameTime.TotalSeconds));

            if (direction.Y == -1)
            {
                human.currentTexture = LoadedContent.humanUpTex;
            }

            if (direction.Y == 1)
            {
                human.currentTexture = LoadedContent.humanDownTex;
            }

            if (direction.X == -1)
            {
                human.currentTexture = LoadedContent.humanLeftTex;

            }

            if (direction.X == 1)
            {
                human.currentTexture = LoadedContent.humanRighTex;
            }

            if (x < 0)
            {
                x = 0;
            }

            if (y < 35)
            {
                y = 35;
            }

            if (y > AppConfig.appHeight - human.currentTexture.Height)
            {
                y = AppConfig.appHeight - human.currentTexture.Height;
            }

            if (x > AppConfig.appWidth - (human.currentTexture.Width / 3))
            {
                x = AppConfig.appWidth - (human.currentTexture.Width / 3);
            }

            human.position.X = x;
            human.position.Y = y;
        }

        public void Act(Mine mine, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Act(Character character, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
