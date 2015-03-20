using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace ClockworkSkies
{
    class GameVariables
    {
        public static Texture2D PlayerImage
        {
            get;
            set;
        }
        public static Texture2D BulletImage
        {
            get;
            set;
        }
        public static int WindowWidth
        {
            get { return 1360; }
        }
        public static int WindowHeight
        {
            get { return 768; }
        }

        public static List<Piece> pieces = new List<Piece>();

        public static int PlaneMaxSpeed
        {
            get { return 8; }
        }

        public static int PlaneMinSpeed
        {
            get { return 5; }
        }

        public static int BulletSpeed
        {
            get { return 15; }
        }

        public static Texture2D ButtonImage
        {
            get;
            set;
        }

        public static SpriteFont TextFont
        {
            get;
            set;
        }
    }
}
