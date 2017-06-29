using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

namespace GameLogic.Util
{
    /// <summary>
    /// Contains static references to loaded content.
    /// </summary>
    public sealed class LoadedContent
    {
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
        public static Texture2D characterDownTex, characterUpTex, characterLeftTex, characterRightTex, Life;

        /// <summary>
        /// All of the Robot textures.
        /// </summary>
        public static Texture2D RobotTex;

        /// <summary>
        /// The mine texture.
        /// </summary>
        public static Texture2D SquareMine;
        
        /// <summary>
        /// All of the Human textures.
        /// </summary>
        public static Texture2D humanDownTex, humanUpTex, humanLeftTex, humanRighTex;

    }
}
