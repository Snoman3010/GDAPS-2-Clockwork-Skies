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
        private int score;
        public KeyboardState kState;

        // constructor
        public Player(Texture2D image, Vector2 position, float direction)
        {
            plane = new Plane(GameVariables.PlayerImage, position, direction);
            score = 0;
            kState = new KeyboardState();
        }

        // Update method
        public void Update()
        {
            // goes through each key, if the key is down it sets the keypressed value to true, if the key is not down it sets the keypressed value to false
            
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
            
        }
    }
}
