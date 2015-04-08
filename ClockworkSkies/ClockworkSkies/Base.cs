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
        private int timeSinceDamage;

        // constructor
        public Base(Vector2 pos, bool allied): base(GameVariables.BaseImage, 0, pos, GameVariables.BaseImage.Width, GameVariables.BaseImage.Height, allied)
        {
            life = 10;
            position = pos;
            timeSinceDamage = 0;
        }

        public override void Update()
        {
            timeSinceDamage++;
            TestForHit();
            if(life <= 0)
            {
                this.Remove();
            }
        }

        public void TakeDamage()
        {
            //if(timeSinceDamage <=)
            life--;

        }

        public void TestForHit()
        {
            for (int i = 0; i < GameVariables.pieces.Count; i++)
            {
                bool colliding = false;
                if (GameVariables.pieces[i].Friendly != Friendly)
                {
                    colliding = IsColiding(GameVariables.pieces[i]);
                }
                if (colliding)
                {
                    TakeDamage();
                    timeSinceDamage = 0;
                    if (GameVariables.pieces[i] is Bullet)
                    {
                        GameVariables.pieces[i].Remove();
                    }
                }
            }
        }
    }
}
