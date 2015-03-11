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
    class Sprite
    {
        private Rectangle spriteBox;
        private Texture2D image;

        // The X position of the spriteBox
        public int PosX
        {
            get { return spriteBox.X; }
            set { spriteBox.X = value; }
        }

        // The Y position of the spriteBox
        public int PosY
        {
            get { return spriteBox.Y; }
            set { spriteBox.Y = value; }
        }

        // The width of the spriteBox (not necessarily the image width)
        public int Width
        {
            get { return spriteBox.Width; }
        }

        // The height of the spriteBox (not necessarily the image height)
        public int Height
        {
            get { return spriteBox.Height; }
        }

        // Constructor
        public Sprite(Texture2D img, Rectangle boundingBox)
        {
            spriteBox = boundingBox;
            image = img;
        }

        // Called by the main Draw() method to draw all Sprites
        public void Draw(SpriteBatch spriteBatch, double direction)
        {
            //spriteBatch.Draw(image, spriteBox, Color.White);
            spriteBatch.Draw(image, new Vector2(PosX, PosY), null, Color.White, (float)direction, new Vector2(spriteBox.Width / 2, spriteBox.Height / 2), (float)spriteBox.Width / (float)image.Width, SpriteEffects.None, 0);
        }
    }
}
