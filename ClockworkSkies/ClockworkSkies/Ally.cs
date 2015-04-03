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
        public Ally(Texture2D image, Vector2 position, int width, int height, float direction, float angleSpeed, float rate)
            : base(image, position, width, height, direction, angleSpeed, rate)
        {

        }

        public override void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
