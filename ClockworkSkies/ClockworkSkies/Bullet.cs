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
    class Bullet : Piece
    {

        public Bullet(double dir, Rectangle bounds) : base(GameVariables.BulletImage, dir, bounds)
        {

        }

        public override void Update(KeyboardState kState, GamePadState gState)
        {
            double xComp = GameVariables.BulletSpeed * Math.Sin(direction);
            double yComp = GameVariables.BulletSpeed * Math.Cos(direction);

            image.PosX += (int)xComp;
            image.PosY -= (int)yComp;
        }
    }
}
