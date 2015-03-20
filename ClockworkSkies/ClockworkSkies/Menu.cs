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
    enum MenuState { Title, Main, Play, Tutorial, Options, Credits, Pause };

    class Menu
    {
        // attribute
        private Dictionary<String, Button> buttons;
        private MenuState state;
        private bool buttonsSet;
        private LevelList levels;
        
        // Constructor
        public Menu(MenuState initialState)
        {
            // Set up menu state
            state = initialState;

            // Create a bunch of buttons and store it into Dictionary
            buttons = new Dictionary<String, Button>();
            buttons.Add("Main", new Button(new Rectangle(0, 0, 0, 0), "Main menu"));
            buttons.Add("Play", new Button(new Rectangle(0, 0, 0, 0), "Play"));
            buttons.Add("Help", new Button(new Rectangle(0, 0, 0, 0), "Tutorial"));
            buttons.Add("Option", new Button(new Rectangle(0, 0, 0, 0), "Options"));
            buttons.Add("Credits", new Button(new Rectangle(0, 0, 0, 0), "Credits"));
            buttons.Add("Resume", new Button(new Rectangle(0, 0, 0, 0), "Resume"));
            buttons.Add("Exit", new Button(new Rectangle(0, 0, 0, 0), "Exit game"));

            levels = new LevelList();

            buttonsSet = false;
        }

        private void SetButtons()
        {
            switch (state)
            {
                case MenuState.Title:
                    {
                        buttons["Main"].rect.X = 580;
                        buttons["Main"].rect.Width = 200;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = 100;
                        buttons["Main"].clickable = true;
                        break;
                    }
                case MenuState.Main:
                    {
                        buttons["Play"].rect.X = 60;
                        buttons["Play"].rect.Width = 200;
                        buttons["Play"].rect.Y = 568;
                        buttons["Play"].rect.Height = 100;
                        buttons["Play"].clickable = true;
                        buttons["Help"].rect.X = 320;
                        buttons["Help"].rect.Width = 200;
                        buttons["Help"].rect.Y = 568;
                        buttons["Help"].rect.Height = 100;
                        buttons["Help"].clickable = true;
                        buttons["Option"].rect.X = 580;
                        buttons["Option"].rect.Width = 200;
                        buttons["Option"].rect.Y = 568;
                        buttons["Option"].rect.Height = 100;
                        buttons["Option"].clickable = true;
                        buttons["Credits"].rect.X = 840;
                        buttons["Credits"].rect.Width = 200;
                        buttons["Credits"].rect.Y = 568;
                        buttons["Credits"].rect.Height = 100;
                        buttons["Credits"].clickable = true;
                        buttons["Exit"].rect.X = 1100;
                        buttons["Exit"].rect.Width = 200;
                        buttons["Exit"].rect.Y = 568;
                        buttons["Exit"].rect.Height = 100;
                        buttons["Exit"].clickable = true;
                        break;
                    }
                case MenuState.Play:
                    {
                        buttons["Main"].rect.X = 580;
                        buttons["Main"].rect.Width = 200;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = 100;
                        buttons["Main"].clickable = true;
                        levels.GetLevels();
                        break;
                    }
                case MenuState.Tutorial:
                    {
                        buttons["Main"].rect.X = 580;
                        buttons["Main"].rect.Width = 200;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = 100;
                        buttons["Main"].clickable = true;
                        break;
                    }
                case MenuState.Options:
                    {
                        buttons["Main"].rect.X = 580;
                        buttons["Main"].rect.Width = 200;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = 100;
                        buttons["Main"].clickable = true;
                        break;
                    }
                case MenuState.Credits:
                    {
                        buttons["Main"].rect.X = 580;
                        buttons["Main"].rect.Width = 200;
                        buttons["Main"].rect.Y = 568;
                        buttons["Main"].rect.Height = 100;
                        buttons["Main"].clickable = true;
                        break;
                    }
                case MenuState.Pause:
                    {
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
        }

        // Updates if either one of its buttons is clicked
        public void Update()
        {
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
                    if (buttons["Help"].clicked)
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
                        //Quit the game
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
                    break;
            }
        }
    }
}
