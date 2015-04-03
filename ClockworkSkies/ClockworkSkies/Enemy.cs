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
    class Enemy
    {
        // attributes
        Plane plane;
        Player target;
        
        // Constructor
        public Enemy(Texture2D image, Vector2 position, int width, int height, float direction, float angleSpeed, float rate, Player play)
        {
            plane = new Plane(image, position, width, height, direction, angleSpeed, rate);  // create new plane
            target = play;
        }

        // AI stuff
        public void Update()
        {
            
        }

        // Check if the player is in sight - must be within enemy's range of sight
        private bool CheckForTarget(Vector2 enemyDirection, Vector2 enemyPosition, Vector2 playerPosition) 
        { 
            return false;  // placeholder 
        }
    }
}
