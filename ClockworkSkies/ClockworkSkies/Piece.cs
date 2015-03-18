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
        public double direction;

        public Sprite Image
        {
            get { return image; }
        }

        public Piece(Texture2D img, double dir, Rectangle boundingBox)
        {
            image = new Sprite(img, boundingBox);
            direction = dir;
            GameVariables.pieces.Add(this);
        }

        public abstract void Update(KeyboardState kState, GamePadState gState);

        public void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch, direction);
        }
    }
}
