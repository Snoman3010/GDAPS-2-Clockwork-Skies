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
        private bool buttonsDrawn;
        
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
            buttons.Add("Credit", new Button(new Rectangle(0, 0, 0, 0), "Credits"));
            buttons.Add("Resume", new Button(new Rectangle(0, 0, 0, 0), "Resume"));
            buttons.Add("Exit", new Button(new Rectangle(0, 0, 0, 0), "Exit game"));

            buttonsDrawn = false;
        }

        private void SetButtons()
        {
            switch (state)
            {
                case MenuState.Title:
                    {
                        
                        break;
                    }
                case MenuState.Main:
                    {
                        break;
                    }
                case MenuState.Play:
                    {
                        break;
                    }
                case MenuState.Tutorial:
                    {
                        break;
                    }
                case MenuState.Options:
                    {
                        break;
                    }
                case MenuState.Credits:
                    {
                        break;
                    }
                case MenuState.Pause:
                    {
                        break;
                    }
            }
        }

        // Updates if either one of its buttons is clicked
        public void Update()
        {
            
        }
    }
}
