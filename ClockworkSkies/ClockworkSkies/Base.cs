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
    class Base:Piece
    {
        // attributes
        private int life;
        private Vector2 position;

        // constructor
        public Base(Vector2 pos): base(GameVariables.BaseImage, 0, pos, GameVariables.BaseImage.Width, GameVariables.BaseImage.Height)
        {
            life = 10;
            position = pos;
        }

        public override void Update()
        {
            
        }
    }
}
