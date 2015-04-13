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
        private int smokeTimer;
        private bool dead;
        private int flashTimer;
        private bool isHit;

        // constructor
        public Base(Vector2 pos, bool allied)
            : base(GameVariables.BaseImage, 0, pos, GameVariables.PlaneSize * 2, GameVariables.PlaneSize * 2, allied)
        {
            life = 10;
            position = pos;
            timeSinceDamage = 0;
            smokeTimer = GameVariables.GetRandom(10, 35);
            dead = false;
            flashTimer = 0;
            isHit = false;
        }

        public override void Update()
        {
            smokeTimer--;
            TestForHit();
            if(life <= 0)
            {
                Remove();
                dead = true;
            }
            if (life <= 3 && smokeTimer <= 0)
            {
                Smoke smoke = new Smoke(new Vector2(GameVariables.GetRandom((int)image.PosX - 35, (int)image.PosX + image.Width - 35), GameVariables.GetRandom((int)image.PosY - 35 , (int)image.PosY + image.Width - 35)));
                smokeTimer = GameVariables.GetRandom(10, 35);
            }

            // Checks if it is time to take away invinsibility frames
            if (timeSinceDamage > GameVariables.InvulnTimer && isHit)
            {
                timeSinceDamage = 0; // resets the invincibility timer
                isHit = false; // no longer has invincibility
                shouldDraw = true; // ensures the plane will be drawn afterward
            }

            // If the plane has invincibility frames, make the plane flash and add to the timer
            if (isHit)
            {
                if (flashTimer > 5)
                {
                    shouldDraw = !shouldDraw;
                    flashTimer = 0;
                }
                else
                {
                    flashTimer++;
                }

                timeSinceDamage++;
            }
        }

        public void TakeDamage()
        {
            isHit = true;
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
                if (colliding && !isHit)
                {
                    TakeDamage();
                }
                if (colliding && GameVariables.pieces[i] is Bullet)
                {
                    GameVariables.pieces[i].Remove();
                }
            }
        }

        public bool IsDead()
        {
            return dead;
        }
    }
}
