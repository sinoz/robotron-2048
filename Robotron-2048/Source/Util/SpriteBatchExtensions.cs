using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robotron_2048.Source.Util
{
    /// <summary>
    /// Contains extension methods specific to SpriteBatch's.
    /// </summary>
    static class SpriteBatchExtensions
    {
        #region Computing a single pixel in the form of a Texture to use to draw lines. - Borrowed code from MonoGame.Extended
        /// <summary>
        /// The produced single pixel texture.
        /// </summary>
        private static Texture2D singlePixelTexture;

        /// <summary>
        /// Computes a single pixel in the form of a Texture2D instance.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to produce the pixel Texture2D with.</param>
        /// <returns></returns>
        private static Texture2D GetTexture(SpriteBatch spriteBatch)
        {
            if (singlePixelTexture == null)
            {
                singlePixelTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
                singlePixelTexture.SetData(new[] { Color.White });
            }

            return singlePixelTexture;
        }
        #endregion

        #region Drawing lines logic - Borrowed code from MonoGame.Extended
        /// <summary>
        /// Draws a straight line from one point to another.
        /// </summary>
        /// <param name="batch">The batch to have draw the line.</param>
        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
        {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);

            DrawLine(spriteBatch, point1, distance, angle, color, thickness);
        }

        /// <summary>
        /// Draws a straight line from one point to another.
        /// </summary>
        /// <param name="batch">The batch to have draw the line.</param>
        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point, float length, float angle, Color color, float thickness = 1f)
        {
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(length, thickness);

            spriteBatch.Draw(GetTexture(spriteBatch), point, null, color, angle, origin, scale, SpriteEffects.None, 0);
        }
        #endregion
    }
}
