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
        //attributes
        protected Sprite image;
        protected float direction;

        public Sprite Image
        {
            get { return image; }
        }

        //constructor
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

        public Vector2 FindCenter()
        {
            float xCenter = image.PosX + (image.Width / 2);
            float yCenter = image.PosY + (image.Height / 2);
            return new Vector2(xCenter, yCenter);
        }

        private float FindDistance(Vector2 pointA, Vector2 pointB)
        {
            float xDistance = pointB.X - pointA.X;
            float yDistance = pointB.Y - pointA.Y;
            float distance = (float) Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
            return distance;
        }

        public bool IsColiding(Piece other)
        {
            Vector2 thisCenter = FindCenter();
            Vector2 otherCenter = other.FindCenter();
            float currentDistance = FindDistance(thisCenter, otherCenter);
            float collideDistance = image.Width + other.Image.Width;
            if (currentDistance <= collideDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
