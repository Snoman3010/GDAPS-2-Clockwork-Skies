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
    abstract class Piece
    {
        protected Sprite image;
        
        public Sprite Image
        {
            get { return image; }
        }

        public Piece(Texture2D img, Rectangle boundingBox)
        {
            image = new Sprite(img, boundingBox);
        }

        //public abstract void Draw(SpriteBatch spriteBatch, double direction)
        //{
        //    image.Draw(spriteBatch, direction);
        //}
    }
}
