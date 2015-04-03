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
        protected Plane plane;

        public NPC(Texture2D image, Vector2 position, int width, int height, float direction, float angleSpeed, float rate)
        {
            plane = new Plane(image, position, width, height, direction, angleSpeed, rate);
        }

        public abstract void Update();
    }
}
