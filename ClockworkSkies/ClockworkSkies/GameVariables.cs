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
        private static Random rng = new Random();

        private static bool running = true;

        public static bool GameUnpaused
        {
            get { return running; }
            set { running = value; }
        }

        public static Game1 MainGame
        {
            get;
            set;
        }

        public static Texture2D GameTitle
        {
            get;
            set;
        }

        //Player sprite
        public static Texture2D PlayerImage
        {
            get;
            set;
        }

        public static Texture2D AllyImage
        {
            get;
            set;
        }

        public static Texture2D EnemyImage
        {
            get;
            set;
        }
        //bullet sprite
        public static Texture2D BulletImage
        {
            get;
            set;
        }
        public static Texture2D EnemyBulletImage
        {
            get;
            set;
        }
        // smoke sprite
        public static Texture2D SmokeImage
        {
            get;
            set;
        }

        //Width of game window
        public static int WindowWidth
        {
            get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; }
        }
        //height of game window
        public static int WindowHeight
        {
            get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; }
        }
        //List of all pieces
        public static List<Piece> pieces = new List<Piece>();

        public static List<Smoke> smokeList = new List<Smoke>();
        //Max speed of plane
        public static int PlaneMaxSpeed
        {
            get { return 8; }
        }
        //Min speed of plane
        public static int PlaneMinSpeed
        {
            get { return 5; }
        }
        //bullet speed
        public static int BulletSpeed
        {
            get { return 15; }
        }
        //button sprite
        public static Texture2D ButtonImage
        {
            get;
            set;
        }
        //base sprite
        public static Texture2D BaseImage
        {
            get;
            set;
        }
        //game font
        public static SpriteFont TextFont
        {
            get;
            set;
        }
        //size of the plane
        public static int PlaneSize
        {
            get { return WindowWidth / 50; } //made it a function of window width so it will be easier to make it playable on multiple resolutions
        }
        //how fast the plane can turn
        public static float PlaneAngleSpeed
        {
            get { return (3 * (float)(Math.PI / 180)); }
        }
        //how often the plane can shoot
        public static float FireRate
        {
            get { return 150; }
        }

        //invincibility timer
        public static float InvulnTimer
        {
            get { return 150; }
        }

        public static int ButtonWidth
        {
            get { return (int)(WindowWidth / 9.6); }
        }

        public static int ButtonHeight
        {
            get { return (int)(WindowHeight / 10.8); }
        }

        public static int GetRandom(int min, int max)
        {
            return rng.Next(min, max);
        }

        public static float WidthMultiplier
        {
            get { return (float)(WindowWidth / 1920.0); }
        }

        public static float HeightMultiplier
        {
            get { return (float)(WindowHeight / 1080.0); }
        }

        // Background
        public static Texture2D MainMenu
        {
            get;
            set;
        }
    }
}
