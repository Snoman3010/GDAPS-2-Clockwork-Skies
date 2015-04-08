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
    public class Smoke
    {
        // attributes
        private Sprite puffy;
        private int timer;  // how long will the smoke be visible
        private int orgWidth;

        // Constructor
        public Smoke(Vector2 position)
        {
            puffy = new Sprite(GameVariables.SmokeImage, position, 16, 16);
            timer = 120;
            GameVariables.smokeList.Add(this);
            orgWidth = 16;
        }

        // Update
        public void Update()
        {
            timer--;
            
            // Decrease itself at certain time

            double pctSize = timer / 120.0;
            puffy.Width = (int)(orgWidth * pctSize);

            if (puffy.Width <= 0)
            {
                if (GameVariables.smokeList.Contains(this))
                {
                    GameVariables.smokeList.Remove(this);
                }
            }
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            if (timer > 0)
            {
                puffy.Draw(spriteBatch, (float)(timer / (Math.PI * 3)));
            }
        }
    }
}
