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
    public abstract class NPC
    {
        //attrubutes
        protected Plane plane;
        protected bool wasOffScreen = false;

        //constructor
        public NPC(Texture2D image, Vector2 position, float direction, bool ally)
        {
            //create plane
            plane = new Plane(image, position, direction, ally);
        }

        public virtual void Update()
        {

            //getting back on screen logic
            if(plane.Image.PosX < 0 || plane.Image.PosX > GameVariables.WindowWidth || plane.Image.PosY < 0 || plane.Image.PosY > GameVariables.WindowHeight)
            {
                if (!wasOffScreen)
                {
                    if (plane.Image.PosX < 0)
                    {
                        plane.keyPressed["upKey"] = false;
                        plane.keyPressed["downKey"] = true;
                        plane.keyPressed["spaceKey"] = false;

                        if (plane.Direction < Math.PI * 1.5)
                        {
                            plane.keyPressed["leftKey"] = true;
                            plane.keyPressed["rightKey"] = false;
                        }
                        else
                        {
                            plane.keyPressed["leftKey"] = false;
                            plane.keyPressed["rightKey"] = true;
                        }
                    }
                    else if (plane.Image.PosX > GameVariables.WindowWidth)
                    {
                        plane.keyPressed["upKey"] = false;
                        plane.keyPressed["downKey"] = true;
                        plane.keyPressed["spaceKey"] = false;

                        if (plane.Direction < Math.PI * 0.5)
                        {
                            plane.keyPressed["leftKey"] = true;
                            plane.keyPressed["rightKey"] = false;
                        }
                        else
                        {
                            plane.keyPressed["leftKey"] = false;
                            plane.keyPressed["rightKey"] = true;
                        }
                    }
                    else if (plane.Image.PosY < 0)
                    {
                        plane.keyPressed["upKey"] = false;
                        plane.keyPressed["downKey"] = true;
                        plane.keyPressed["spaceKey"] = false;

                        if (plane.Direction < Math.PI)
                        {
                            plane.keyPressed["leftKey"] = false;
                            plane.keyPressed["rightKey"] = true;
                        }
                        else
                        {
                            plane.keyPressed["leftKey"] = true;
                            plane.keyPressed["rightKey"] = false;
                        }
                    }
                    else if (plane.Image.PosY > GameVariables.WindowHeight)
                    {
                        plane.keyPressed["upKey"] = false;
                        plane.keyPressed["downKey"] = true;
                        plane.keyPressed["spaceKey"] = false;

                        if (plane.Direction < Math.PI)
                        {
                            plane.keyPressed["leftKey"] = true;
                            plane.keyPressed["rightKey"] = false;
                        }
                        else
                        {
                            plane.keyPressed["leftKey"] = false;
                            plane.keyPressed["rightKey"] = true;
                        }
                    }
                }
                wasOffScreen = true;
            }
            else
            {
                if (wasOffScreen)
                {
                    plane.keyPressed["upKey"] = false;
                    plane.keyPressed["downKey"] = false;
                    plane.keyPressed["spaceKey"] = false;
                    plane.keyPressed["leftKey"] = false;
                    plane.keyPressed["rightKey"] = false;
                }
                wasOffScreen = false;
            }
            //end getting back on screen logic
        }

        public bool IsDead()
        {
            return plane.dead;
        }

    }
}
