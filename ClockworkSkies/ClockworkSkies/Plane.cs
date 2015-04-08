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
        private int timeSinceDamage;
        private int life;
        private int smokeTimer;

        // Constructor
        public Plane(Texture2D image, Vector2 position, float direction, bool allied) : base(image, direction, position, GameVariables.PlaneSize, GameVariables.PlaneSize, allied)
        {
            // Sets all the default values
            angularSpeed = GameVariables.PlaneAngleSpeed;
            speed = GameVariables.PlaneMinSpeed;
            speedChangeTimer = 0;
            fireTime = GameVariables.FireRate;
            timeSinceDamage = 0;
            savedFireTime = 0;
            life = 4;
            smokeTimer = new Random().Next(150, 600);
            // creates dictionary and sets keypressed values to false
            keyPressed = new Dictionary<string, bool>();
            keyPressed.Add("upKey", false);
            keyPressed.Add("leftKey", false);
            keyPressed.Add("downKey", false);
            keyPressed.Add("rightKey", false);
            keyPressed.Add("spaceKey", false);
        }

        public override void Update()
        {
            TestForHit();
            if (life <= 0)
            {
                Remove();
                return;
            }
            speedChangeTimer--;
            timeSinceDamage++;
            smokeTimer--;
            if (life <= 2 && smokeTimer <=0)
            {
                //new smoke puff
                smokeTimer = new Random().Next(150, 600);
            }
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

                Bullet bullet = new Bullet(direction, new Vector2(image.PosX + halfWidthX, image.PosY - halfWidthY), Friendly);
                savedFireTime = Environment.TickCount; // sets the new fire time
            }
        }

        public void TakeDamage()
        {
            if (timeSinceDamage >= GameVariables.InvulnTimer)
            {
                life--;
                timeSinceDamage = 0;
            }
        }

        public void TestForHit()
        {
            for (int i = 0; i < GameVariables.pieces.Count; i++)
            {
                bool colliding = false;
                if (GameVariables.pieces[i].Friendly != Friendly)
                {
                    colliding = IsColiding(GameVariables.pieces[i]);
                }
                if (colliding)
                {
                    TakeDamage();
                    if (GameVariables.pieces[i] is Bullet)
                    {
                        GameVariables.pieces[i].Remove();
                    }
                }
            }
        }
    }
}
