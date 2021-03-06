﻿using System;
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
        //attributes
        private int visibleBuffer = 100; // The amount of padding to go off screen before it despawns

        //constructor
        public Bullet(float dir, Vector2 position, bool allied)
            : base(GameVariables.BulletImage, dir, position, GameVariables.PlaneSize / 5, GameVariables.PlaneSize / 5, allied)
        {
            if (!allied)
                image = new Sprite(GameVariables.EnemyBulletImage, position, GameVariables.PlaneSize / 5, GameVariables.PlaneSize / 5);
        }

        public override void Update()
        {
            //calculate x and y components of movement
            double xComp = GameVariables.BulletSpeed * Math.Sin(direction);
            double yComp = GameVariables.BulletSpeed * Math.Cos(direction);

            //modify x and y positions
            image.PosX += (int)xComp;
            image.PosY -= (int)yComp;

            //delete if off screen
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
