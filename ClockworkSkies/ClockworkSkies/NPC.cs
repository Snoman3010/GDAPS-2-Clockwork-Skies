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
        protected Piece target;
        public bool hunting;

        //constructor
        public NPC(Texture2D image, Vector2 position, float direction, bool ally)
        {
            //create plane
            plane = new Plane(image, position, direction, ally);
            target = null;
            hunting = false;
            //if (!ally)
            //{
            //    target = GameVariables.MainGame.gameMenu.levels.currentLevel.p1.Plane;
            //    hunting = true;
            //}
        }

        public Piece Target
        {
            get { return target; }
            set { target = value; }
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
                //On-screen AI Logic
                if (hunting)
                {
                    plane.keyPressed["spaceKey"] = true;
                    if (plane.speed < 6)
                    {
                        plane.keyPressed["upKey"] = true;
                        plane.keyPressed["downKey"] = false;
                    }
                    else if (plane.speed > 7)
                    {
                        plane.keyPressed["downKey"] = true;
                        plane.keyPressed["upKey"] = false;
                    }
                    else
                    {
                        plane.keyPressed["upKey"] = false;
                        plane.keyPressed["downKey"] = false;
                    }
                    float xDistance = plane.Image.PosX - target.Image.PosX;
                    float yDistance = plane.Image.PosY - target.Image.PosY;
                    //Vector2 targetDistance = new Vector2(-xDistance, -yDistance);
                    //Vector2 planeDirection = new Vector2((float)(plane.speed * Math.Cos(plane.Direction)), (float)(plane.speed * Math.Sin(plane.Direction)));
                    //float angle = (float)Math.Acos((double)(Vector2.Dot(targetDistance, planeDirection) / (targetDistance.Length() * planeDirection.Length())));
                    
                    //if (xDistance < 0 && yDistance < 0)
                    //{
                    //    angle = angle + (float)(Math.PI / 4);
                    //}
                    //if (plane.Image.PosX - target.Image.PosX < 0 && plane.Image.PosY - target.Image.PosY < 0)
                    //{
                    //    angle = angle + (float)(Math.PI / 2);
                    //}
                    //else if (plane.Image.PosX - target.Image.PosX > 0 && plane.Image.PosY - target.Image.PosY < 0)
                    //{
                    //    angle = angle + (float)Math.PI;
                    //}
                    //else if (plane.Image.PosX - target.Image.PosX > 0 && plane.Image.PosY - target.Image.PosY > 0)
                    //{
                    //    angle = angle + (float)(1.5 * Math.PI);
                    //}
                    float angle = 0;
                    if (xDistance > 0 && yDistance > 0)
                    {
                        angle = (float)(Math.Atan(yDistance / xDistance) + (1.5 * Math.PI));
                    }
                    else if (xDistance > 0 && yDistance < 0)
                    {
                        angle = (float)((1.5 * Math.PI) - Math.Atan(-yDistance / xDistance));
                    }
                    else if (xDistance < 0 && yDistance < 0)
                    {
                        angle = (float)(Math.Atan(-yDistance / -xDistance) + (Math.PI / 2));
                    }
                    else if (xDistance < 0 && yDistance > 0)
                    {
                        angle = (float)(Math.PI - Math.Atan(yDistance / -xDistance));
                    }

                    Console.WriteLine(angle * 180 / Math.PI);
                    if (angle < Math.PI)
                    {
                        plane.keyPressed["leftKey"] = false;
                        plane.keyPressed["rightKey"] = true;
                    }
                    else if (angle > -0.05 && angle < 0.05)
                    {
                        plane.keyPressed["leftKey"] = false;
                        plane.keyPressed["rightKey"] = false;
                    }
                    else
                    {
                        plane.keyPressed["leftKey"] = true;
                        plane.keyPressed["rightKey"] = false;
                    }

                }
                else
                {

                }
            }
        }

        public bool IsDead()
        {
            return plane.dead;
        }

    }
}
