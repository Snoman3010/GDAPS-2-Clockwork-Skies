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
        private Resolution[] supportedResolutions;

        public Options(Menu gMenu)
        {
            menu = gMenu;

            buttons = new List<Button>();

            supportedResolutions = new Resolution[7];
            supportedResolutions[0] = new Resolution(1920, 1080, "1920x1080");
            supportedResolutions[1] = new Resolution(1366, 768, "1366x768");
            supportedResolutions[2] = new Resolution(1280, 1024, "1280x1024");
            supportedResolutions[3] = new Resolution(1280, 720, "1280x720");
            supportedResolutions[4] = new Resolution(1024, 768, "1024x768");
            supportedResolutions[5] = new Resolution(800, 600, "800x600");
            supportedResolutions[6] = new Resolution(640, 480, "640x480");
        }

        protected struct Resolution
        {
            private int width;
            private int height;
            private string name;

            public int Width
            {
                get { return width; }
            }
            public int Height
            {
                get { return height; }
            }
            public string Name
            {
                get { return name; }
            }

            public Resolution(int width, int height, string name)
            {
                this.width = width;
                this.height = height;
                this.name = name;
            }
        }

        public void ShowOptions()
        {
            drawOptions = true;
            Button nativeResolutionButton = new Button(new Rectangle(GameVariables.WindowWidth / 6, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width + "x" + GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            nativeResolutionButton.clickable = true;
            buttons.Add(nativeResolutionButton);
            currentResolutionButton = nativeResolutionButton;

            for (int i = 0; i < supportedResolutions.Length; i++)
            {
                if(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width > supportedResolutions[i].Width && GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height > supportedResolutions[i].Height)
                {
                    Button button = new Button(new Rectangle(GameVariables.WindowWidth / 6 + buttons.Count * GameVariables.ButtonWidth, GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight, GameVariables.ButtonWidth, GameVariables.ButtonHeight), supportedResolutions[i].Name);
                    button.clickable = true;
                    buttons.Add(button);

                    if(supportedResolutions[i].Width == GameVariables.GraphicsDeviceManager.PreferredBackBufferWidth && supportedResolutions[i].Height == GameVariables.GraphicsDeviceManager.PreferredBackBufferHeight)
                    {
                        currentResolutionButton = button;
                    }
                }
            }
        }

        public void Update(MouseState mState)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Update(mState);

                if (buttons[i].clicked)
                {
                    string buttonText = buttons[i].Text;
                    string buttonTextWidth = buttonText.Substring(0, buttonText.IndexOf('x'));
                    string buttonTextHeight = buttonText.Substring(buttonText.IndexOf('x') + 1);

                    int width = 0;
                    int height = 0;

                    int.TryParse(buttonTextWidth, out width);
                    int.TryParse(buttonTextHeight, out height);

                    if (width > 0 && height > 0)
                    {
                        currentResolutionButton = buttons[i];

                        GameVariables.GraphicsDeviceManager.PreferredBackBufferWidth = width;
                        GameVariables.GraphicsDeviceManager.PreferredBackBufferHeight = height;
                        GameVariables.GraphicsDeviceManager.ApplyChanges();
                    }

                    for (int j = 0; j < buttons.Count; j++)
                    {
                        buttons[j].rect.X = GameVariables.WindowWidth / 6 + j * GameVariables.ButtonWidth;
                        buttons[j].rect.Y = GameVariables.WindowHeight / 4 + GameVariables.ButtonHeight;
                        buttons[j].rect.Width = GameVariables.ButtonWidth;
                        buttons[j].rect.Height = GameVariables.ButtonHeight;
                    }

                    buttons.Clear();
                    menu.SetButtons();
                }
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

                if (currentResolutionButton != null)
                {
                    spriteBatch.Draw(GameVariables.SelectorImage, currentResolutionButton.rect, Color.White);
                }
            }
        }

        internal void HideOptions()
        {
            foreach (Button x in buttons)
            {
                x.clickable = false;
            }
            drawOptions = false;
            currentResolutionButton = null;
            buttons.Clear();
        }
    }
}
