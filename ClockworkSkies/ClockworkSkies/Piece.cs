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
        private bool friendly;
        protected bool shouldDraw;

        public float Direction
        {
            get { return direction; }
        }

        // The sprite of the piece
        public Sprite Image
        {
            get { return image; }
        }

        // Whether or not the piece is friendly
        public bool Friendly
        {
            get { return friendly; }
        }

        // Whether or not the piece should be drawn
        public bool ShouldDraw
        {
            get { return shouldDraw; }
        }

        //constructor
        public Piece(Texture2D img, float dir, Vector2 position, int width, int height, bool allied)
        {
            image = new Sprite(img, position, width, height);
            direction = dir;
            friendly = allied;
            shouldDraw = true;
            GameVariables.pieces.Add(this); // Adds the piece to the pieces list
        }
        
        // Removes the piece from the pieces list
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

        // Returns the center position of the piece
        public Vector2 FindCenter()
        {
            float xCenter = image.PosX + (image.Width / 2);
            float yCenter = image.PosY + (image.Height / 2);
            return new Vector2(xCenter, yCenter);
        }

        // Returns the distance between two points
        private float FindDistance(Vector2 pointA, Vector2 pointB)
        {
            float xDistance = pointB.X - pointA.X;
            float yDistance = pointB.Y - pointA.Y;
            float distance = (float) Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
            return distance;
        }

        // Returns true if two pieces are colliding, otherwise false
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

        public float FindDistance(Piece other)
        {
            Vector2 thisCenter = FindCenter();
            Vector2 otherCenter = other.FindCenter();
            return FindDistance(thisCenter, otherCenter);
        }
    }
}
