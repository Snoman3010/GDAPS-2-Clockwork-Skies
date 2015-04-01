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
    class Player
    {
        // attributes
        private Plane plane;
        private int score;
        //Dictionary<string, bool> keyPressed;

        // constructor
        public Player(Plane pln)
        {
            plane = pln;
            score = 0;
            /*
            // creates dictionary and sets keypressed values to false
            keyPressed = new Dictionary<string, bool>();
            keyPressed.Add("upKey", false);
            keyPressed.Add("leftKey", false);
            keyPressed.Add("downKey", false);
            keyPressed.Add("rightKey", false);
            keyPressed.Add("spaceKey", false);
            */
        }

        // Update method
        public void Update()
        {
            // goes through each key, if the key is down it sets the keypressed value to true, if the key is not down it sets the keypressed value to false
            KeyboardState kState = new KeyboardState();
            if(kState.IsKeyDown(Keys.Up))
            {
                plane.KeyPressed["upKey"] = true;
            }
            if (kState.IsKeyDown(Keys.Up) == false)
            {
                plane.KeyPressed["upKey"] = false;
            }
            if (kState.IsKeyDown(Keys.Left))
            {
                plane.KeyPressed["leftKey"] = true;
            }
            if (kState.IsKeyDown(Keys.Left) == false)
            {
                plane.KeyPressed["leftKey"] = false;
            }
            if (kState.IsKeyDown(Keys.Down))
            {
                plane.KeyPressed["downKey"] = true;
            }
            if (kState.IsKeyDown(Keys.Down) == false)
            {
                plane.KeyPressed["downKey"] = false;
            }
            if (kState.IsKeyDown(Keys.Right))
            {
                plane.KeyPressed["rightKey"] = true;
            }
            if (kState.IsKeyDown(Keys.Right) == false)
            {
                plane.KeyPressed["rightKey"] = false;
            }
            if(kState.IsKeyDown(Keys.Space))
            {
                plane.KeyPressed["spaceKey"] = true;
            }
            if (kState.IsKeyDown(Keys.Space) == false)
            {
                plane.KeyPressed["spaceKey"] = false;
            }
            
        }
    }
}
