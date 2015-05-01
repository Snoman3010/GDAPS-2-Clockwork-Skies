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
    public class Button
    {
        // attributes
        public Rectangle rect;
        private string text;
        public bool clicked;
        public bool clickable;
        private bool previousMouse;

        public string Text
        {
            get { return text; }
        }

        // constructor
        public Button(Rectangle r, string txt)
        {
            rect = r;
            text = txt;
            clicked = false;
            clickable = false;
            previousMouse = false;
        }

        // Update method
        public void Update(MouseState mState)
        {
            if (clickable && !previousMouse)
            {
                // checks to see if the mouse location is inside the button
                if (mState.X >= rect.X && mState.X <= rect.X + rect.Width && mState.Y >= rect.Y && mState.Y <= rect.Y + rect.Height)
                {
                    // checks if the left mouse button is pressed and if it is, sets clicked to true
                    if (mState.LeftButton == ButtonState.Pressed)
                    {
                        clicked = true;
                    }
                }
            }
            previousMouse = (mState.LeftButton == ButtonState.Pressed);
        }

        // Draw
        public void Draw(SpriteBatch image)
        {
            if (clickable)
            {
                image.Draw(GameVariables.ButtonImage, rect, Color.White);
                Vector2 textSize = GameVariables.TextFont.MeasureString(text);
                Vector2 fontScale = new Vector2(0.75f * GameVariables.WidthMultiplier, 0.75f * GameVariables.HeightMultiplier);
                image.DrawString(GameVariables.TextFont, text, new Vector2(rect.Center.X - (textSize.X / 2) * fontScale.X, rect.Center.Y - (textSize.Y / 2) * fontScale.Y), Color.Yellow, 0, new Vector2(0, 0), fontScale, 0, 0);
            }
            
        }
    }
}
