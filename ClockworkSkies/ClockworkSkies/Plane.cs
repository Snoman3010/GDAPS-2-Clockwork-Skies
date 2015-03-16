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
        public int speed;
        private double angularSpeed;
        private int minSpeed;
        private int maxSpeed;
        private int speedChangeTimer;

        // Constructor
        public Plane(Texture2D image, Rectangle bounds, double direction, int minSpd, int maxSpd, double angleSpeed) : base(image, bounds, direction)
        {
            angularSpeed = angleSpeed;
            minSpeed = minSpd;
            maxSpeed = maxSpd;
            speed = minSpeed;
            speedChangeTimer = 0;
        }

        public override void Update(KeyboardState kState, GamePadState gState)
        {
            speedChangeTimer--;
            if (speedChangeTimer <= 0)
            {
                if (kState.IsKeyDown(Keys.Up))
                {
                    speed++;
                    if (speed > maxSpeed)
                    {
                        speed = maxSpeed;
                    }
                    speedChangeTimer = 20;
                }

                if (kState.IsKeyDown(Keys.Down))
                {
                    speed--;
                    if (speed < minSpeed)
                    {
                        speed = minSpeed;
                    }
                    speedChangeTimer = 20;
                }
            }

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
