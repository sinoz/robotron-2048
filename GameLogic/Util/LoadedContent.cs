﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

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
        public static SpriteFont titelFont;
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
        public static Texture2D RobotTex, RobotBossTex, RobotBossTexFinalForm;

        /// <summary>
        /// The mine texture.
        /// </summary>
        public static Texture2D SquareMine;
        
        /// <summary>
        /// All of the Human textures.
        /// </summary>
        public static Texture2D humanDownTex, humanUpTex, humanLeftTex, humanRighTex;

        /// <summary>
        /// Sound effects
        /// </summary>
        public static SoundEffect bulletSound, characterDeathSound, robotDeathSound, humanPickup, nextLevelSound, mineExplosionSound, lifeLossSound;

        /// <summary>
        /// Health bar
        /// </summary>
        public static Texture2D healthBar;

        /// <summary>
        /// Sound music
        /// </summary>
        public static Song mainMenuSong;

    }
}
