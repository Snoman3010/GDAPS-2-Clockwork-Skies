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
    public enum MenuState { Title, Main, Play, Tutorial, Options, Credits, Pause, GameOver };

    public class Menu
    {
        // attribute
        private Dictionary<String, Button> buttons;
        private MenuState state;
        private bool buttonsSet;
        public LevelList levels;
        private Options options;
        private Game1 mainGame;
        private string gameOverMessage;

        public MenuState State
        {
            get { return state; }
            set { state = value; }
        }

        public string GameOverMessage
        {
            get { return gameOverMessage; }
            set { gameOverMessage = value; }
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

            options = new Options(this);

            buttonsSet = false;

            mainGame = mG;

            gameOverMessage = "";
        }

        public void SetButtons()
        {
            switch (state)
            {
                case MenuState.Title:
                    {
                        buttons["Main"].rect.X = (GameVariables.WindowWidth / 2) - (GameVariables.ButtonWidth / 2);
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
                case MenuState.Main:
                    {
                        buttons["Play"].rect.X = (GameVariables.WindowWidth / 2) - (int)(3.5 * GameVariables.ButtonWidth);
                        buttons["Play"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Play"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Play"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Play"].clickable = true;
                        buttons["Tutorial"].rect.X = (GameVariables.WindowWidth / 2) - (2 * GameVariables.ButtonWidth);
                        buttons["Tutorial"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Tutorial"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Tutorial"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Tutorial"].clickable = true;
                        buttons["Options"].rect.X = (GameVariables.WindowWidth / 2) - (GameVariables.ButtonWidth / 2);
                        buttons["Options"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Options"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Options"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Options"].clickable = true;
                        buttons["Credits"].rect.X = (GameVariables.WindowWidth / 2) + GameVariables.ButtonWidth;
                        buttons["Credits"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Credits"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Credits"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Credits"].clickable = true;
                        buttons["Exit"].rect.X = (GameVariables.WindowWidth / 2) + (int)(2.5 * GameVariables.ButtonWidth);
                        buttons["Exit"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Exit"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Exit"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Exit"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
                case MenuState.Play:
                    {
                        buttons["Main"].rect.X = (GameVariables.WindowWidth / 2) - (GameVariables.ButtonWidth / 2);
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        levels.ShowLevels();
                        buttonsSet = true;
                        switch (GameVariables.GetRandom(0, 3))
                        {
                            case 0:
                                {
                                    GameVariables.CurrentBackground = GameVariables.BarrenRiverBackground;
                                    break;
                                }
                            case 1:
                                {
                                    GameVariables.CurrentBackground = GameVariables.CoastalTroubleBackground;
                                    break;
                                }
                            case 2:
                                {
                                    GameVariables.CurrentBackground = GameVariables.DestroyedCityBackground;
                                    break;
                                }
                            default:
                                {
                                    GameVariables.CurrentBackground = GameVariables.BarrenRiverBackground;
                                    break;
                                }
                        }
                        break;
                    }
                case MenuState.Tutorial:
                    {
                        buttons["Main"].rect.X = (GameVariables.WindowWidth / 2) - (GameVariables.ButtonWidth / 2);
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
                case MenuState.Options:
                    {
                        buttons["Main"].rect.X = (GameVariables.WindowWidth / 2) - (GameVariables.ButtonWidth / 2);
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        buttonsSet = true;
                        options.ShowOptions();
                        break;
                    }
                case MenuState.Credits:
                    {
                        buttons["Main"].rect.X = (GameVariables.WindowWidth / 2) - (GameVariables.ButtonWidth / 2);
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
                case MenuState.Pause:
                    {
                        buttons["Resume"].rect.X = (GameVariables.WindowWidth / 2) - (int)(1.5 * GameVariables.ButtonWidth);
                        buttons["Resume"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Resume"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Resume"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Resume"].clickable = true;
                        buttons["Main"].rect.X = (GameVariables.WindowWidth / 2) + (int)(GameVariables.ButtonWidth / 2);
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
                        buttons["Main"].rect.Height = GameVariables.ButtonHeight;
                        buttons["Main"].clickable = true;
                        buttonsSet = true;
                        break;
                    }
                case MenuState.GameOver:
                    {
                        buttons["Main"].rect.X = (GameVariables.WindowWidth / 2) - (GameVariables.ButtonWidth / 2);
                        buttons["Main"].rect.Width = GameVariables.ButtonWidth;
                        buttons["Main"].rect.Y = GameVariables.WindowHeight - (3 * GameVariables.ButtonHeight);
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
            options.HideOptions();
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
                options.Update(mState);
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
                        GameVariables.GameUnpaused = true;
                        break;
                    }
                    if (buttons["Resume"].clicked)
                    {
                        GameVariables.GameUnpaused = true;
                        Hide();
                    }
                    break;
                case MenuState.GameOver:
                    {
                        if (buttons["Main"].clicked)
                        {
                            buttonsSet = false;
                            state = MenuState.Main;
                        }
                        break;
                    }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            levels.Draw(spriteBatch);
            options.Draw(spriteBatch);

            foreach (KeyValuePair<string, Button> pair in buttons)
            {
                pair.Value.Draw(spriteBatch);
            }

            if (state == MenuState.Title && GameVariables.OALError)
            {
                spriteBatch.DrawString(GameVariables.TextFont, "OpenAL not found, no sound will play.", Vector2.Zero, Color.Red, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
            }

            if (state == MenuState.GameOver)
            {
                Vector2 messageSize = GameVariables.TextFont.MeasureString(gameOverMessage);
                messageSize.X = messageSize.X * GameVariables.WidthMultiplier;
                messageSize.Y = messageSize.Y * GameVariables.HeightMultiplier;
                spriteBatch.Draw(GameVariables.BronzePlaque, new Rectangle((int)((GameVariables.WindowWidth / 2) - (messageSize.X)), (int)(messageSize.Y * 8), (int)(messageSize.X * 2), (int)(messageSize.Y * 3)), Color.White);
                spriteBatch.DrawString(GameVariables.TextFont, gameOverMessage, new Vector2((GameVariables.WindowWidth / 2) - (messageSize.X / 2), messageSize.Y * 9), Color.Yellow, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
            }

            if (state == MenuState.Credits)
            {
                Vector2 messageSize = GameVariables.TextFont.MeasureString("This game was created by:");
                messageSize.X = messageSize.X * GameVariables.WidthMultiplier;
                messageSize.Y = messageSize.Y * GameVariables.HeightMultiplier;
                spriteBatch.Draw(GameVariables.BronzePlaque, new Rectangle(GameVariables.WindowWidth / 4, GameVariables.WindowHeight / 6, GameVariables.WindowWidth / 2, (int)(messageSize.Y * 5)), Color.White);
                spriteBatch.DrawString(GameVariables.TextFont, "This game was created by:", new Vector2((GameVariables.WindowWidth / 2) - (messageSize.X / 2), (GameVariables.WindowHeight / 6) + messageSize.Y), Color.Yellow, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
                Vector2 messageSize2 = GameVariables.TextFont.MeasureString("William Allen, Ryan Jones, Erin McAnany, and Ellen Chen");
                messageSize2.X = messageSize2.X * GameVariables.WidthMultiplier;
                messageSize2.Y = messageSize2.Y * GameVariables.HeightMultiplier;
                spriteBatch.DrawString(GameVariables.TextFont, "William Allen, Ryan Jones, Erin McAnany, and Ellen Chen", new Vector2((GameVariables.WindowWidth / 2) - (messageSize2.X / 2), (GameVariables.WindowHeight / 6) + (messageSize2.Y * 3)), Color.Yellow, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
                Vector2 messageSize3 = GameVariables.TextFont.MeasureString("BGM created by Connum and licensed under the Creative Commons Attribution-NonCommercial license");
                messageSize3.X = messageSize3.X * GameVariables.WidthMultiplier;
                messageSize3.Y = messageSize3.Y * GameVariables.HeightMultiplier;
                spriteBatch.Draw(GameVariables.BronzePlaque, new Rectangle((int)(GameVariables.WindowWidth * .115), (GameVariables.WindowHeight / 6) * 3, (int)(GameVariables.WindowWidth / 1.3),(int)(messageSize3.Y * 4)), Color.White);
                spriteBatch.DrawString(GameVariables.TextFont, "BGM created by Connum and licensed under the Creative Commons Attribution-NonCommercial license", new Vector2((GameVariables.WindowWidth / 2) - (messageSize3.X / 2), ((GameVariables.WindowHeight / 6) * 3) + (messageSize3.Y)), Color.Yellow, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
                Vector2 messageSize4 = GameVariables.TextFont.MeasureString("Art assets created by Ellen Chen");
                messageSize4.X = messageSize4.X * GameVariables.WidthMultiplier;
                messageSize4.Y = messageSize4.Y * GameVariables.HeightMultiplier;
                spriteBatch.DrawString(GameVariables.TextFont, "Art assets created by Ellen Chen", new Vector2((GameVariables.WindowWidth / 2) - (messageSize4.X / 2), ((GameVariables.WindowHeight / 6) * 3) + (messageSize4.Y * 2)), Color.Yellow, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
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
