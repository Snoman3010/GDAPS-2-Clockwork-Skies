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
    class Options
    {
        private Menu menu;
        private List<Button> buttons;
        private Button currentResolutionButton;
        private bool drawOptions = false;

        public Options(Menu gMenu)
        {
            menu = gMenu;
            buttons = new List<Button>();
        }

        public void ShowOptions()
        {
            drawOptions = true;
            currentResolutionButton = new Button(new Rectangle(GameVariables.WindowWidth / 6, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + "x" + GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            currentResolutionButton.clickable = true;
            buttons.Add(currentResolutionButton);

            List<DisplayMode> resolutions = GraphicsAdapter.DefaultAdapter.SupportedDisplayModes.ToList();

            for(int i = 0; i < resolutions.Count; i++)
            {
                if (resolutions[i].Width == 1920 && resolutions[i].Height == 1080 && resolutions[i].RefreshRate == 60)
                {
                    Button button = new Button(new Rectangle(GameVariables.WindowWidth / 6 + i * GameVariables.ButtonWidth, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), resolutions[i].Width + "x" + resolutions[i].Height);
                    button.clickable = true;
                    buttons.Add(button);
                }

                if (resolutions[i].Width == 1366 && resolutions[i].Height == 768 && resolutions[i].RefreshRate == 60)
                {
                    Button button = new Button(new Rectangle(GameVariables.WindowWidth / 6 + i * GameVariables.ButtonWidth, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), resolutions[i].Width + "x" + resolutions[i].Height);
                    button.clickable = true;
                    buttons.Add(button);
                }

                if (resolutions[i].Width == 1360 && resolutions[i].Height == 768 && resolutions[i].RefreshRate == 60)
                {
                    Button button = new Button(new Rectangle(GameVariables.WindowWidth / 6 + i * GameVariables.ButtonWidth, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), resolutions[i].Width + "x" + resolutions[i].Height);
                    button.clickable = true;
                    buttons.Add(button);
                }

                if (resolutions[i].Width == 1280 && resolutions[i].Height == 1024 && resolutions[i].RefreshRate == 60)
                {
                    Button button = new Button(new Rectangle(GameVariables.WindowWidth / 6 + i * GameVariables.ButtonWidth, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), resolutions[i].Width + "x" + resolutions[i].Height);
                    button.clickable = true;
                    buttons.Add(button);
                }

                if (resolutions[i].Width == 1280 && resolutions[i].Height == 720 && resolutions[i].RefreshRate == 60)
                {
                    Button button = new Button(new Rectangle(GameVariables.WindowWidth / 6 + i * GameVariables.ButtonWidth, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), resolutions[i].Width + "x" + resolutions[i].Height);
                    button.clickable = true;
                    buttons.Add(button);
                }

                if (resolutions[i].Width == 1024 && resolutions[i].Height == 768 && resolutions[i].RefreshRate == 60)
                {
                    Button button = new Button(new Rectangle(GameVariables.WindowWidth / 6 + i * GameVariables.ButtonWidth, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), resolutions[i].Width + "x" + resolutions[i].Height);
                    button.clickable = true;
                    buttons.Add(button);
                }

                if (resolutions[i].Width == 800 && resolutions[i].Height == 600 && resolutions[i].RefreshRate == 60)
                {
                    Button button = new Button(new Rectangle(GameVariables.WindowWidth / 6 + i * GameVariables.ButtonWidth, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), resolutions[i].Width + "x" + resolutions[i].Height);
                    button.clickable = true;
                    buttons.Add(button);
                }

                if (resolutions[i].Width == 640 && resolutions[i].Height == 480 && resolutions[i].RefreshRate == 60)
                {
                    Button button = new Button(new Rectangle(GameVariables.WindowWidth / 6 + i * GameVariables.ButtonWidth, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), resolutions[i].Width + "x" + resolutions[i].Height);
                    button.clickable = true;
                    buttons.Add(button);
                }
            }
        }

        public void Update(MouseState mState)
        {
            foreach (Button x in buttons)
            {
                x.Update(mState);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (drawOptions)
            {
                spriteBatch.DrawString(GameVariables.TextFont, "Resolutions: ", new Vector2(GameVariables.WindowWidth / 6, GameVariables.WindowHeight / 4), Color.White);

                foreach (Button x in buttons)
                {
                    x.Draw(spriteBatch);
                }

                spriteBatch.Draw(GameVariables.SelectorImage, currentResolutionButton.rect, Color.White);
            }
        }

        internal void HideOptions()
        {
            foreach (Button x in buttons)
            {
                x.clickable = false;
            }
            drawOptions = false;
        }
    }
}
