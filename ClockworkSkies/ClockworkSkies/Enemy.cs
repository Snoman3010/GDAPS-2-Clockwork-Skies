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
    public class Enemy : NPC
    {
        // attributes
        Player target;
        
        // Constructor
        public Enemy(Texture2D image, Vector2 position, float direction, Player play)
            : base(image, position, direction)
        {
            target = play;
        }

        // AI stuff
        public override void Update()
        {
            
        }

        // Check if the player is in sight - must be within enemy's range of sight
        private bool CheckForTarget(Vector2 enemyDirection, Vector2 enemyPosition, Vector2 playerPosition) 
        { 
            return false;  // placeholder 
        }
    }
}
