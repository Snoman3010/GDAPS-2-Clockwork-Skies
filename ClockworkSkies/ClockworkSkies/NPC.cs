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

        //constructor
        public NPC(Texture2D image, Vector2 position, float direction)
        {
            //create plane
            plane = new Plane(image, position, direction);
        }

        public abstract void Update();
    }
}
