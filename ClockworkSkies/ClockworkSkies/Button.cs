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
    class Button
    {
        // attributes
        Rectangle rect;
        string text;
        bool clicked;
        bool clickable;

        // constructor
        public Button(Rectangle r, string txt)
        {
            rect = r;
            text = txt;
            clicked = false;
            clickable = false;
        }

        // Update method
        public void Update(MouseState mState)
        {
            if (clickable)
            {
                // checks to see if the mouse location is inside the button
                if (mState.X >= rect.X && mState.X <= rect.X + rect.Width && mState.Y >= rect.Y && mState.Y <= rect.Y + rect.Height)
                {
                    // checks if the left mouse button is pressed and if it is, sets clicked to true
                    if (mState.LeftButton == ButtonState.Pressed)
                    {
                        clicked = true;
                        text = "Ow";
                    }
                }
            }
        }

        // Draw
        public void Draw(SpriteBatch image, Texture2D texture, SpriteFont font)
        {
            image.Draw(texture, rect, Color.White);
            image.DrawString(font, text, new Vector2(rect.Center.X, rect.Center.Y), Color.Black);

            clickable = true;
        }
    }
}
