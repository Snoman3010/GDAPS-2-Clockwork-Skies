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
    public class Plane : Piece
    {
        // Attributes
        public int speed; // The translational speed of the plane
        private float angularSpeed; // The speed at which the plane turns
        private int speedChangeTimer; // Prevents the plane from changing speeds instantaneously
        private float fireTime; // The time in seconds it takes to fire one bullet
        private int savedFireTime; // The time when the last bullet was fired
        public Dictionary<string, bool> keyPressed; // dictionary to hold key presses

        // Constructor
        public Plane(Texture2D image, Vector2 position, int width, int height, float direction, float angleSpeed, float rate) : base(image, direction, position, width, height)
        {
            // Sets all the default values
            angularSpeed = angleSpeed;
            speed = GameVariables.PlaneMinSpeed;
            speedChangeTimer = 0;
            fireTime = rate;
            savedFireTime = 0;
            // creates dictionary and sets keypressed values to false
            keyPressed = new Dictionary<string, bool>();
            keyPressed.Add("upKey", false);
            keyPressed.Add("leftKey", false);
            keyPressed.Add("downKey", false);
            keyPressed.Add("rightKey", false);
            keyPressed.Add("spaceKey", false);
        }

        // property
        //public Dictionary<string, bool> KeyPressed
        //{
        //    get { return keyPressed; }
        //    set { keyPressed = value; }
        //}

        public override void Update()
        {
            speedChangeTimer--;
            if (speedChangeTimer <= 0)
            {
                if (keyPressed["upKey"] == true) // Increases the speed if the up button is pressed
                {
                    speed++;
                    if (speed > GameVariables.PlaneMaxSpeed) // Limits the speed to the plane's max speed
                    {
                        speed = GameVariables.PlaneMaxSpeed;
                    }
                    speedChangeTimer = 20;
                }

                if (keyPressed["downKey"] == true) // Decreases the speed if the down button is pressed
                {
                    speed--;
                    if (speed < GameVariables.PlaneMinSpeed) // Limits the speed to the plane's min speed
                    {
                        speed = GameVariables.PlaneMinSpeed;
                    }
                    speedChangeTimer = 20;
                }
            }

            if (keyPressed["leftKey"] == true) // Turns the plane counterclockwise if left is pressed
            {
                direction -= angularSpeed;

                if(direction < 0) // Keeps the direction angle greater than 0
                {
                    direction += 2 *(float)Math.PI;
                }
            }

            if (keyPressed["rightKey"] == true) // Turns the plane clockwise if right is pressed
            {
                direction += angularSpeed;

                if (direction > 2 * Math.PI) // Keeps the direction angle less than 360
                {
                    direction -= 2 * (float)Math.PI;
                }
            }

            // Calculates the x and y components of the velocity and adds them to the x and y positions
            float xComp = speed * (float)Math.Sin(direction);
            float yComp = speed * (float)Math.Cos(direction);

            image.PosX += xComp;
            image.PosY -= yComp;

            // Fires a bullet if space is pressed and the delta time between bullets is greater than or equal to the fire time
            if (keyPressed["spaceKey"] == true && Environment.TickCount - savedFireTime >= fireTime)
            {
                // Calculates the point from which the bullet fires
                float halfWidthX = (image.Width / 2) * (float)Math.Sin(direction + Math.PI / 2);
                float halfWidthY = (image.Width / 2) * (float)Math.Cos(direction + Math.PI / 2);

                Bullet bullet = new Bullet(direction, new Vector2(image.PosX + halfWidthX, image.PosY - halfWidthY), GameVariables.BulletImage.Width, GameVariables.BulletImage.Height);
                savedFireTime = Environment.TickCount; // sets the new fire time
            }
        }
    }
}
