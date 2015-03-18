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
    class Plane : Piece
    {
        public int speed;
        private double angularSpeed;
        private int speedChangeTimer;

        // Constructor
        public Plane(Texture2D image, Rectangle bounds, double direction, double angleSpeed) : base(image, direction, bounds)
        {
            angularSpeed = angleSpeed;
            speed = GameVariables.PlaneMinSpeed;
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
                    if (speed > GameVariables.PlaneMaxSpeed)
                    {
                        speed = GameVariables.PlaneMaxSpeed;
                    }
                    speedChangeTimer = 20;
                }

                if (kState.IsKeyDown(Keys.Down))
                {
                    speed--;
                    if (speed < GameVariables.PlaneMinSpeed)
                    {
                        speed = GameVariables.PlaneMinSpeed;
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

            if(kState.IsKeyDown(Keys.Space))
            {
                Bullet bullet = new Bullet(direction, new Rectangle(image.PosX, image.PosY, GameVariables.BulletImage.Width, GameVariables.BulletImage.Height));
            }
        }
    }
}
