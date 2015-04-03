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
    public class Sprite
    {
        //attributes
        private Vector2 position;
        private int width;
        private int height;
        private Texture2D image;

        // The X position of the sprite
        public float PosX
        {
            get { return position.X; }
            set { position.X = value; }
        }

        // The Y position of the sprite
        public float PosY
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        // The width of the sprite
        public int Width
        {
            get { return width; }
        }

        // The height of the sprite
        public int Height
        {
            get { return height; }
        }

        // Constructor
        public Sprite(Texture2D img, Vector2 pos, int w, int h)
        {
            image = img;
            position = pos;
            width = w;
            height = h;
        }

        // Called by the main Draw() method to draw all Sprites
        public void Draw(SpriteBatch spriteBatch, float direction)
        {
            spriteBatch.Draw(image, position, null, Color.White, direction, new Vector2(width / 2, height / 2), width / (float)image.Width, SpriteEffects.None, 0);
        }
    }
}
