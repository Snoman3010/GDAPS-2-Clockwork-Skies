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
    abstract class MobilePiece:Piece
    {
        public double direction;

        public abstract void Update(KeyboardState kState, GamePadState gState);

        public MobilePiece(Texture2D img, Rectangle boundingBox, double dir) : base(img, boundingBox)
        {
            direction = dir;
        }

        //public override void Draw(SpriteBatch spriteBatch)
        //{
            
        //}
    }
}
