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
    public abstract class Piece
    {
        protected Sprite image;
        protected float direction;

        public Sprite Image
        {
            get { return image; }
        }

        public Piece(Texture2D img, float dir, Vector2 position, int width, int height)
        {
            image = new Sprite(img, position, width, height);
            direction = dir;
            GameVariables.pieces.Add(this);
        }

        public bool Remove()
        {
            if(GameVariables.pieces.Contains(this))
            {
                GameVariables.pieces.Remove(this);
            }

            return false;
        }

        public abstract void Update();

        public void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch, direction);
        }
    }
}
