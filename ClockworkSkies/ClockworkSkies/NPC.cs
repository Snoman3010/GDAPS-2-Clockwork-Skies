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
        private int burstTimer = 0;
        private int burstTimerMax = 25;
        private int burstTimerDelay = 30;
        private bool isBursting = false;

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

        public bool Friendly
        {
            get { return plane.Friendly; }
        }

        public Plane Plane
        {
            get { return plane; }
        }


        public virtual void Update()
        {
            


            //getting back on screen logic
            //if(plane.Image.PosX < 0 || plane.Image.PosX > GameVariables.WindowWidth || plane.Image.PosY < 0 || plane.Image.PosY > GameVariables.WindowHeight)
            //{
                //if (!wasOffScreen)
                //{
                //    if (plane.Image.PosX < 0)
                //    {
                //        plane.keyPressed["upKey"] = false;
                //        plane.keyPressed["downKey"] = true;
                //        plane.keyPressed["spaceKey"] = false;

                //        if (plane.Direction < Math.PI * 1.5)
                //        {
                //            plane.keyPressed["leftKey"] = true;
                //            plane.keyPressed["rightKey"] = false;
                //        }
                //        else
                //        {
                //            plane.keyPressed["leftKey"] = false;
                //            plane.keyPressed["rightKey"] = true;
                //        }
                //    }
                //    else if (plane.Image.PosX > GameVariables.WindowWidth)
                //    {
                //        plane.keyPressed["upKey"] = false;
                //        plane.keyPressed["downKey"] = true;
                //        plane.keyPressed["spaceKey"] = false;

                //        if (plane.Direction < Math.PI * 0.5)
                //        {
                //            plane.keyPressed["leftKey"] = true;
                //            plane.keyPressed["rightKey"] = false;
                //        }
                //        else
                //        {
                //            plane.keyPressed["leftKey"] = false;
                //            plane.keyPressed["rightKey"] = true;
                //        }
                //    }
                //    else if (plane.Image.PosY < 0)
                //    {
                //        plane.keyPressed["upKey"] = false;
                //        plane.keyPressed["downKey"] = true;
                //        plane.keyPressed["spaceKey"] = false;

                //        if (plane.Direction < Math.PI)
                //        {
                //            plane.keyPressed["leftKey"] = false;
                //            plane.keyPressed["rightKey"] = true;
                //        }
                //        else
                //        {
                //            plane.keyPressed["leftKey"] = true;
                //            plane.keyPressed["rightKey"] = false;
                //        }
                //    }
                //    else if (plane.Image.PosY > GameVariables.WindowHeight)
                //    {
                //        plane.keyPressed["upKey"] = false;
                //        plane.keyPressed["downKey"] = true;
                //        plane.keyPressed["spaceKey"] = false;

                //        if (plane.Direction < Math.PI)
                //        {
                //            plane.keyPressed["leftKey"] = true;
                //            plane.keyPressed["rightKey"] = false;
                //        }
                //        else
                //        {
                //            plane.keyPressed["leftKey"] = false;
                //            plane.keyPressed["rightKey"] = true;
                //        }
                //    }
                //}
                //wasOffScreen = true;
            //}
            //else
            //{
                //if (wasOffScreen)
                //{
                //    plane.keyPressed["upKey"] = false;
                //    plane.keyPressed["downKey"] = false;
                //    plane.keyPressed["spaceKey"] = false;
                //    plane.keyPressed["leftKey"] = false;
                //    plane.keyPressed["rightKey"] = false;
                //}
                //wasOffScreen = false;
                //On-screen AI Logic
                if (hunting)
                {
                    burstTimer++;

                    if(burstTimer >= burstTimerMax && isBursting)
                    {
                        burstTimer = 0;
                        plane.keyPressed["spaceKey"] = false;
                        isBursting = false;
                    }
                    else if(burstTimer >= burstTimerDelay && !isBursting)
                    {
                        burstTimer = 0;
                        plane.keyPressed["spaceKey"] = true;
                        isBursting = true;
                    }

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
                    float targetDirection = 0;
                    if (xDistance > 0 && yDistance > 0)
                    {
                        targetDirection = (float)(Math.Atan(yDistance / xDistance) + (1.5 * Math.PI));
                    }
                    else if (xDistance > 0 && yDistance < 0)
                    {
                        targetDirection = (float)((1.5 * Math.PI) - Math.Atan(-yDistance / xDistance));
                    }
                    else if (xDistance < 0 && yDistance < 0)
                    {
                        targetDirection = (float)(Math.Atan(-yDistance / -xDistance) + (Math.PI / 2));
                    }
                    else if (xDistance < 0 && yDistance > 0)
                    {
                        targetDirection = (float)((Math.PI / 2) - Math.Atan(yDistance / -xDistance));
                    }

                    float angle = targetDirection - plane.Direction;
                    if (angle < 0)
                    {
                        angle = angle + (float)(2 * Math.PI);
                    }

                    //Console.WriteLine(angle * 180 / Math.PI);
                    if (angle > Math.PI)
                    {
                        plane.keyPressed["leftKey"] = true;
                        plane.keyPressed["rightKey"] = false;
                    }
                    else if (angle <= Math.PI / 8)
                    {
                        plane.keyPressed["leftKey"] = false;
                        plane.keyPressed["rightKey"] = false;
                    }
                    else
                    {
                        plane.keyPressed["leftKey"] = false;
                        plane.keyPressed["rightKey"] = true;
                    }
                    //test for switching to avoid mode
                    for (int i = 0; i < GameVariables.pieces.Count; i++)
                    {
                        if (!(GameVariables.pieces[i] is Bullet) && plane.Friendly != GameVariables.pieces[i].Friendly)
                        {
                            if (plane.FindDistance(GameVariables.pieces[i]) <= (8 * GameVariables.PlaneSize))
                            {
                                hunting = false;
                            }
                        }
                    }
                }
                else
                {
                    plane.keyPressed["spaceKey"] = false;
                    plane.keyPressed["upKey"] = true;
                    plane.keyPressed["downKey"] = false;
                    Piece avoidMe = null;
                    for (int i = 0; i < GameVariables.pieces.Count; i++)
                    {
                        if (!(GameVariables.pieces[i] is Bullet) && plane.Friendly != GameVariables.pieces[i].Friendly)
                        {
                            if (plane.FindDistance(GameVariables.pieces[i]) <= (16 * GameVariables.PlaneSize))
                            {
                                avoidMe = GameVariables.pieces[i];
                            }
                        }
                    }
                    if (avoidMe == null && target != null)
                    {
                        hunting = true;
                    }
                    else if (avoidMe != null)
                    {
                        float xDistance = plane.Image.PosX - avoidMe.Image.PosX;
                        float yDistance = plane.Image.PosY - avoidMe.Image.PosY;
                        float avoidDirection = 0;
                        if (xDistance > 0 && yDistance > 0)
                        {
                            avoidDirection = (float)(Math.Atan(yDistance / xDistance) + (1.5 * Math.PI));
                        }
                        else if (xDistance > 0 && yDistance < 0)
                        {
                            avoidDirection = (float)((1.5 * Math.PI) - Math.Atan(-yDistance / xDistance));
                        }
                        else if (xDistance < 0 && yDistance < 0)
                        {
                            avoidDirection = (float)(Math.Atan(-yDistance / -xDistance) + (Math.PI / 2));
                        }
                        else if (xDistance < 0 && yDistance > 0)
                        {
                            avoidDirection = (float)((Math.PI / 2) - Math.Atan(yDistance / -xDistance));
                        }

                        float angle = avoidDirection - plane.Direction;
                        if (angle < 0)
                        {
                            angle = angle + (float)(2 * Math.PI);
                        }

                        if (angle < Math.PI)
                        {
                            plane.keyPressed["leftKey"] = true;
                            plane.keyPressed["rightKey"] = false;
                        }
                        else if (angle <  Math.PI + 0.05 && angle > Math.PI - 0.05)
                        {
                            plane.keyPressed["leftKey"] = false;
                            plane.keyPressed["rightKey"] = false;
                        }
                        else
                        {
                            plane.keyPressed["leftKey"] = false;
                            plane.keyPressed["rightKey"] = true;
                        }
                    }
                }
            //}
        }

        public bool IsDead()
        {
            return plane.dead;
        }

    }
}
