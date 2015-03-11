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
    class Plane : MobilePiece
    {
        private int speed;
        private double angularSpeed;

        // Constructor
        public Plane(Texture2D image, Rectangle bounds, double direction, int spd, double angleSpeed) : base(image, bounds, direction)
        {
            speed = spd;
            angularSpeed = angleSpeed;
        }

        public override void Update(KeyboardState kState, GamePadState gState)
        {           

            //if(kState.IsKeyDown(Keys.Up))
            //{
            //    image.PosY -= speed;
            //}

            //if (kState.IsKeyDown(Keys.Down))
            //{
            //    image.PosY += speed;
            //}

            if (kState.IsKeyDown(Keys.Left))
            {
                direction -= angularSpeed;

                if(direction < 0)
                {
                    direction += 2 * Math.PI;
                }
            }

            if (kState.IsKeyDown(Keys.Right))
            {
                direction += angularSpeed;

                if (direction > 2 * Math.PI)
                {
                    direction -= 2 * Math.PI;
                }
            }

            double xComp = speed * Math.Sin(direction);
            double yComp = speed * Math.Cos(direction);

            image.PosX += (int)xComp;
            image.PosY -= (int)yComp;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            image.Draw(spriteBatch, direction);
        }
    }
}
