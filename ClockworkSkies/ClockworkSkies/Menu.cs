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
    public enum MenuState { Title, Main, Play, Tutorial, Options, Credits, Pause };

    public class Menu
    {
        // attribute
        private Dictionary<String, Button> buttons;
        private MenuState state;
        private bool buttonsSet;
        public LevelList levels;
        private Game1 mainGame;

        public MenuState State
        {
            get { return state; }
            set { state = value; }
        }
        
        // Constructor
        public Menu(MenuState initialState, Game1 mG)
        {
            // Set up menu state
            state = initialState;

            // Create a bunch of buttons and store it into Dictionary
            buttons = new Dictionary<String, Button>();
            buttons.Add("Main", new Button(new Rectangle(0, 0, 0, 0), "Main menu"));
            buttons.Add("Play", new Button(new Rectangle(0, 0, 0, 0), "Play"));
            buttons.Add("Tutorial", new Button(new Rectangle(0, 0, 0, 0), "Tutorial"));
            buttons.Add("Options", new Button(new Rectangle(0, 0, 0, 0), "Options"));
            buttons.Add("Credits", new Button(new Rectangle(0, 0, 0, 0), "Credits"));
            buttons.Add("Resume", new Button(new Rectangle(0, 0, 0, 0), "Return to game"));
            buttons.Add("Exit", new Button(new Rectangle(0, 0, 0, 0), "Exit game"));

            levels = new LevelList(this);

            buttonsSet = false;

            mainGame = mG;

        }

        private void SetButtons()
        {
            switch (state)
            {
                case MenuState.Title:
                    {
                        buttons["Main"].rect.X = 580;
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
                case MenuState.Main:
                    {
                        buttons["Play"].rect.X = 60;
                        buttons["Play"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Play"].rect.Y = 568;
                        buttons["Play"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Play"].clickable = true;
                        buttons["Tutorial"].rect.X = 320;
                        buttons["Tutorial"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Tutorial"].rect.Y = 568;
                        buttons["Tutorial"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Tutorial"].clickable = true;
                        buttons["Options"].rect.X = 580;
                        buttons["Options"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Options"].rect.Y = 568;
                        buttons["Options"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Options"].clickable = true;
                        buttons["Credits"].rect.X = 840;
                        buttons["Credits"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Credits"].rect.Y = 568;
                        buttons["Credits"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Credits"].clickable = true;
                        buttons["Exit"].rect.X = 1100;
                        buttons["Exit"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Exit"].rect.Y = 568;
                        buttons["Exit"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Exit"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
                case MenuState.Play:
                    {
                        buttons["Main"].rect.X = 580;
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        levels.ShowLevels();
                        buttonsSet = true;
                        break;
                    }
                case MenuState.Tutorial:
                    {
                        buttons["Main"].rect.X = 580;
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
                case MenuState.Options:
                    {
                        buttons["Main"].rect.X = 580;
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
                case MenuState.Credits:
                    {
                        buttons["Main"].rect.X = 580;
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
                case MenuState.Pause:
                    {
                        buttons["Resume"].rect.X = 580;
                        buttons["Resume"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Resume"].rect.Y = 568;
                        buttons["Resume"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Resume"].clickable = true;
                        buttons["Main"].rect.X = 840;
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
            }
        }

        private void ClearButtons()
        {
            foreach (KeyValuePair<string, Button> pair in buttons)
            {
                pair.Value.rect.X = 0;
                pair.Value.rect.Y = 0;
                pair.Value.rect.Width = 0;
                pair.Value.rect.Height = 0;
                pair.Value.clickable = false;
                pair.Value.clicked = false;
            }
            levels.HideLevels();
        }

        // Updates if either one of its buttons is clicked
        public void Update(MouseState mState)
        {
            foreach (KeyValuePair<string, Button> pair in buttons)
            {
                pair.Value.Update(mState);
            }
            if (GameVariables.GameUnpaused)
            {
                levels.Update(mState);
            }
            if (!buttonsSet)
            {
                ClearButtons();
                SetButtons();
            }
            switch (state)
            {
                case MenuState.Title:
                    if (buttons["Main"].clicked)
                    {
                        buttonsSet = false;
                        state = MenuState.Main;
                    }
                    break;
                case MenuState.Main:
                    if (buttons["Play"].clicked)
                    {
                        buttonsSet = false;
                        state = MenuState.Play;
                        break;
                    }
                    if (buttons["Options"].clicked)
                    {
                        buttonsSet = false;
                        state = MenuState.Options;
                        break;
                    }
                    if (buttons["Tutorial"].clicked)
                    {
                        buttonsSet = false;
                        state = MenuState.Tutorial;
                        break;
                    }
                    if (buttons["Credits"].clicked)
                    {
                        buttonsSet = false;
                        state = MenuState.Credits;
                        break;
                    }
                    if (buttons["Exit"].clicked)
                    {
                        mainGame.Exit();
                    }
                    break;
                case MenuState.Options:
                    if (buttons["Main"].clicked)
                    {
                        buttonsSet = false;
                        state = MenuState.Main;
                    }
                    break;
                case MenuState.Tutorial:
                    if (buttons["Main"].clicked)
                    {
                        buttonsSet = false;
                        state = MenuState.Main;
                    }
                    break;
                case MenuState.Credits:
                    if (buttons["Main"].clicked)
                    {
                        buttonsSet = false;
                        state = MenuState.Main;
                    }
                    break;
                case MenuState.Play:
                    if (buttons["Main"].clicked)
                    {
                        buttonsSet = false;
                        state = MenuState.Main;
                    }
                    break;
                case MenuState.Pause:
                    if (buttons["Main"].clicked)
                    {
                        buttonsSet = false;
                        state = MenuState.Main;
                        levels.currentLevel.Clear();
                        levels.currentLevel = null;
                        break;
                    }
                    if (buttons["Resume"].clicked)
                    {
                        GameVariables.GameUnpaused = true;
                        Hide();
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<string, Button> pair in buttons)
            {
                pair.Value.Draw(spriteBatch);
                levels.Draw(spriteBatch);
            }
        }

        public void Hide()
        {
            ClearButtons();
        }

        public void Show()
        {
            buttonsSet = false;
        }
    }
}
