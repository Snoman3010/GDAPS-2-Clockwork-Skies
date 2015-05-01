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
    public class Player
    {
        // attributes
        private Plane plane;
        public KeyboardState kState;

        public Plane Plane
        {
            get { return plane; }
        }

        // constructor
        public Player(Vector2 position, float direction)
        {
            plane = new Plane(GameVariables.PlayerImage, position, direction, true);
            kState = new KeyboardState();
        }

        // Update method
        public void Update()
        {
            // goes through each key, if the key is down it sets the keypressed value to true, if the key is not down it sets the keypressed value to false
            //if (plane.Image.PosX < 0)
            //{
            //    plane.Image.PosX = plane.Image.PosX + GameVariables.WindowWidth;
            //}
            //else if(plane.Image.PosX > GameVariables.WindowWidth)
            //{
            //    plane.Image.PosX = plane.Image.PosX - GameVariables.WindowWidth;
            //}

            //if(plane.Image.PosY < 0)
            //{
            //    plane.Image.PosY = plane.Image.PosY + GameVariables.WindowHeight;
            //}
            //else if (plane.Image.PosY > GameVariables.WindowHeight)
            //{
            //    plane.Image.PosY = plane.Image.PosY - GameVariables.WindowHeight;
            //}
            
            if(kState.IsKeyDown(Keys.Up))
            {
                plane.keyPressed["upKey"] = true;
            }
            else
            {
                plane.keyPressed["upKey"] = false;
            }
            if (kState.IsKeyDown(Keys.Left))
            {
                plane.keyPressed["leftKey"] = true;
            }
            else
            {
                plane.keyPressed["leftKey"] = false;
            }
            if (kState.IsKeyDown(Keys.Down))
            {
                plane.keyPressed["downKey"] = true;
            }
            else
            {
                plane.keyPressed["downKey"] = false;
            }
            if (kState.IsKeyDown(Keys.Right))
            {
                plane.keyPressed["rightKey"] = true;
            }
            else
            {
                plane.keyPressed["rightKey"] = false;
            }
            if(kState.IsKeyDown(Keys.Space))
            {
                plane.keyPressed["spaceKey"] = true;
            }
            else
            {
                plane.keyPressed["spaceKey"] = false;
            }

            if (kState.IsKeyDown(Keys.Escape))
            {
                GameVariables.GameUnpaused = false;
                GameVariables.MainGame.gameMenu.State = MenuState.Pause;
                GameVariables.MainGame.gameMenu.Show();
                GameVariables.MainGame.gameMenu.levels.loadLevelTimer = 0;
            }
        }

        public bool IsDead()
        {
            return plane.dead;
        }
    }
}
