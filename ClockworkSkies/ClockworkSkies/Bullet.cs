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

        private int visibleBuffer = 100; // The amount of padding to go off screen before it despawns

        public Bullet(float dir, Vector2 position, int width, int height) : base(GameVariables.BulletImage, dir, position, width, height)
        {

        }

        public override void Update(KeyboardState kState, GamePadState gState)
        {
            double xComp = GameVariables.BulletSpeed * Math.Sin(direction);
            double yComp = GameVariables.BulletSpeed * Math.Cos(direction);

            image.PosX += (int)xComp;
            image.PosY -= (int)yComp;

            if(image.PosX > GameVariables.WindowWidth + visibleBuffer || image.PosX < -visibleBuffer)
            {
                Remove();
            }

            if (image.PosY > GameVariables.WindowHeight + visibleBuffer || image.PosY < -visibleBuffer)
            {
                Remove();
            }
        }
    }
}
