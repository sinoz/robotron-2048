using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameLogic.Scene
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Button : Widget
    {
        /// <summary>
        /// TODO
        /// </summary>
        private int width, height;

        /// <summary>
        /// TODO
        /// </summary>
        private Action action;

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Button(int x, int y, int width, int height, Action action) : base(new Vector2(x, y))
        {
            this.width = width;
            this.height = height;
            this.action = action;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool intersectsWith(int x, int y)
        {
            return x > absolute.X && y > absolute.Y && x < absolute.X + width && y < absolute.Y + height;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            if (intersectsWith(state.Position.X, state.Position.Y))
            {
                action.Invoke();
            }

            base.Update(gameTime);
        }
    }
}
