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
    public class Ally : NPC
    {
        //constructor
        public Ally(Texture2D image, Vector2 position, float direction)
            : base(image, position, direction, true)
        {
            
        }

        public override void Update()
        {
            //AI for allied planes goes here
        }
    }
}
