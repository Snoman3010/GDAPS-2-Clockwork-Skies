using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace ClockworkSkies
{
    public class LevelList
    {
        //attributes
        public static List<string> levels;
        public static List<Button> buttons;
        
        private Menu gameMenu;
        public Level currentLevel;

        private string levelName;
        private int timeLimit;
        private int victoryCondition;
        private Vector3 alliedTargetInfo; // X: x position  Y: y position   Z: direction
        private Vector3 enemyTargetInfo; // X: x position  Y: y position   Z: direction
        private Vector2 alliedBase; // X: x position    Y: y position
        private Vector2 enemyBase; // X: x position    Y: y position
        private Vector3 playerInfo; // X: x position  Y: y position   Z: direction
        private List<Vector4> npcs; // // X: x position  Y: y position   Z: direction   W: NPC type

        private bool showErrorMessage = false;
        private string errorMessage = "";

        public int loadLevelTimer = 0;

        private Button play;
        private Button next;
        private Button previous;
        private int page;
        private int pageMax;

        //constructor
        public LevelList(Menu gMenu)
        {
            levels = new List<string>();
            buttons = new List<Button>();
            npcs = new List<Vector4>();
            GetLevels();
            gameMenu = gMenu;
            play = new Button(new Rectangle((int)(GameVariables.ButtonWidth * 6.25), (int)(GameVariables.ButtonHeight * 6.5), GameVariables.ButtonWidth, GameVariables.ButtonHeight), "Play Level");
            next = new Button(new Rectangle((int)(GameVariables.ButtonWidth * 2.25), (int)(GameVariables.ButtonHeight * 6.5), GameVariables.ButtonWidth, GameVariables.ButtonHeight), "Next Page");
            previous = new Button(new Rectangle((GameVariables.ButtonWidth / 4), (int)(GameVariables.ButtonHeight * 6.5), GameVariables.ButtonWidth, GameVariables.ButtonHeight), "Previous Page");
            play.clickable = true;
            next.clickable = true;
            previous.clickable = true;
            page = 0;
            pageMax = 0;
        }

        //Find level files
        public void GetLevels()
        {
            try
            {
                //Level filenames should be CSkiesL#
                //If there are holes in the sequence the later levels won't be found
                //Looks for levels in an infinite loop until file isn't found
                for (int i = 1; i > 0; i++)
                {
                    StreamReader reader = new StreamReader("Levels/CSkiesL" + i + ".txt");
                    levels.Add("Levels/CSkiesL" + i + ".txt");
                    reader.Close();
                }
            }
            catch (FileNotFoundException)
            {
                return;
            }
        }

        //Creates a button for each level
        public void ShowLevels()
        {
            buttons.Clear();  // reset number of buttons
            
            for(int i = 0; i < levels.Count; i++)
            {
                LoadLevel(levels[i]);
                int vPos = i;
                int hPos = 0;
                while (vPos >= 6)
                {
                    vPos = vPos - 6;
                    hPos++;
                }
                if (hPos < 3)
                {
                    Button button = new Button(new Rectangle((GameVariables.ButtonWidth / 4) + GameVariables.ButtonWidth * hPos, (GameVariables.ButtonHeight / 2) + GameVariables.ButtonHeight * vPos, GameVariables.ButtonWidth, GameVariables.ButtonHeight), levelName);
                    button.clickable = true;
                    buttons.Add(button);
                }
                else
                {
                    int currentPage = 0;
                    while (hPos >= 3)
                    {
                        hPos = hPos - 3;
                        currentPage++;
                        if (pageMax < currentPage)
                        {
                            pageMax = currentPage;
                        }
                    }
                    Button button = new Button(new Rectangle((GameVariables.ButtonWidth / 4) + GameVariables.ButtonWidth * hPos, (GameVariables.ButtonHeight / 2) + GameVariables.ButtonHeight * vPos, GameVariables.ButtonWidth, GameVariables.ButtonHeight), levelName);
                    buttons.Add(button);
                }
                

            }

            levelName = null;
            timeLimit = 0;
            victoryCondition = -1;
        }

        public void HideLevels()
        {
            foreach (Button x in buttons)
            {
                x.clickable = false;
            }
        }

        // Loads the specified level
        public void LoadLevel(string level)
        {
            npcs.Clear();
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(level);

                string line = null;
                while((line = reader.ReadLine()) != null) // Reads until there is nothing left to read
                {
                    if(line[0] == ':') // The first character of a readable line must be :
                    {
                        string lineData = line.Substring(3); // Starts reading from the 3rd character position in the string (Format should be :E-content)

                        switch(line[1]) // Saves the data differently depending on the line header
                        {
                            case 'L': // The level name
                                levelName = lineData;
                                break;
                            case 'T': // The time limit
                                try
                                {
                                    timeLimit = int.Parse(lineData);
                                }
                                catch(Exception)
                                {
                                    showErrorMessage = true;
                                    errorMessage = "Failed to load the level's time limit.";
                                    return;
                                }
                                break;
                            case 'V': // The victory condition
                                try
                                {
                                    victoryCondition = int.Parse(lineData);
                                }
                                catch(Exception)
                                {
                                    showErrorMessage = true;
                                    errorMessage = "Failed to load the level's victory condition.";
                                    return;
                                }
                                break;
                            case 'A': // The target ally
                                try
                                {
                                    string[] targetAlliedValues = lineData.Split(',');

                                    alliedTargetInfo.X = GameVariables.WidthMultiplier * int.Parse(targetAlliedValues[0]);
                                    alliedTargetInfo.Y = GameVariables.HeightMultiplier * int.Parse(targetAlliedValues[1]);
                                    alliedTargetInfo.Z = int.Parse(targetAlliedValues[2]);
                                }
                                catch(Exception)
                                {
                                    showErrorMessage = true;
                                    errorMessage = "Failed to load the level's target ally.";
                                    return;
                                }
                                break;
                            case 'R': // The target enemy
                                try
                                {
                                    string[] targetEnemyValues = lineData.Split(',');

                                    enemyTargetInfo.X = GameVariables.WidthMultiplier * int.Parse(targetEnemyValues[0]);
                                    enemyTargetInfo.Y = GameVariables.HeightMultiplier * int.Parse(targetEnemyValues[1]);
                                    enemyTargetInfo.Z = int.Parse(targetEnemyValues[2]);
                                }
                                catch(Exception)
                                {
                                    showErrorMessage = true;
                                    errorMessage = "Failed to load the level's target enemy.";
                                    return;
                                }
                                break;
                            case 'F': // The allied base
                                try
                                {
                                    string[] alliedBaseValues = lineData.Split(',');

                                    alliedBase.X = GameVariables.WidthMultiplier * int.Parse(alliedBaseValues[0]); ;
                                    alliedBase.Y = GameVariables.HeightMultiplier * int.Parse(alliedBaseValues[1]);
                                }
                                catch(Exception)
                                {
                                    showErrorMessage = true;
                                    errorMessage = "Failed to load the level's allied base.";
                                    return;
                                }
                                break;
                            case 'B': // The enemy base
                                try
                                {
                                    string[] enemyBaseValues = lineData.Split(',');

                                    enemyBase.X = GameVariables.WidthMultiplier * int.Parse(enemyBaseValues[0]);
                                    enemyBase.Y = GameVariables.HeightMultiplier * int.Parse(enemyBaseValues[1]);
                                }
                                catch(Exception)
                                {
                                    showErrorMessage = true;
                                    errorMessage = "Failed to load the level's enemy base.";
                                    return;
                                }
                                break;
                            case 'P': // The player
                                try
                                {
                                    string[] playerStartValues = lineData.Split(',');

                                    playerInfo.X = GameVariables.WidthMultiplier * int.Parse(playerStartValues[0]);
                                    playerInfo.Y = GameVariables.HeightMultiplier * int.Parse(playerStartValues[1]);
                                    playerInfo.Z = int.Parse(playerStartValues[2]);
                                }
                                catch(Exception)
                                {
                                    showErrorMessage = true;
                                    errorMessage = "Failed to load the player.";
                                    return;
                                }
                                break;
                            case 'E': // The npcs
                                try
                                {
                                    string[] npcValues = lineData.Split(',');

                                    float npcXPos = GameVariables.WidthMultiplier * int.Parse(npcValues[0]);
                                    float npcYPos = GameVariables.HeightMultiplier * int.Parse(npcValues[1]);
                                    int npcDirection = int.Parse(npcValues[2]);
                                    int npcType = int.Parse(npcValues[3]);

                                    npcs.Add(new Vector4(npcXPos, npcYPos, npcDirection, npcType));
                                }
                                catch(Exception)
                                {
                                    showErrorMessage = true;
                                    errorMessage = "Failed to load an NPC.";
                                    return;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }

                loadLevelTimer = 0;
                
            }
            catch(IOException e) // If there is a problem reading the file, show an error message
            {
                showErrorMessage = true;
                errorMessage = e.Message;
            }
            finally // Close the file if it's opened
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public void Update(MouseState mState)
        {
            if (gameMenu.State == MenuState.Play && currentLevel == null)
            {
                play.Update(mState);
                next.Update(mState);
                previous.Update(mState);

                if (play.clicked)
                {
                    play.clicked = false;
                    if (levelName != null)
                    {
                        gameMenu.Hide();
                        currentLevel = new Level(timeLimit, victoryCondition, playerInfo, alliedTargetInfo, enemyTargetInfo, alliedBase, enemyBase, npcs, levelName);

                        npcs.Clear();
                    }
                }

                if (next.clicked)
                {
                    next.clicked = false;
                    if (page < pageMax)
                    {
                        try
                        {
                            for (int i = 0 + (18 * page); i < 18 + (18 * page); i++)
                            {
                                buttons[i].clickable = false;
                            }
                        }
                        catch (ArgumentOutOfRangeException e)
                        {

                        }
                        page++;
                        try
                        {
                            for (int i = 0 + (18 * page); i < 18 + (18 * page); i++)
                            {
                                buttons[i].clickable = true;
                            }
                        }
                        catch (ArgumentOutOfRangeException e)
                        {

                        }
                    }
                }
                else if (previous.clicked)
                {
                    previous.clicked = false;
                    if (page > 0)
                    {
                        try
                        {
                            for (int i = 0 + (18 * page); i < 18 + (18 * page); i++)
                            {
                                buttons[i].clickable = false;
                            }
                        }
                        catch (ArgumentOutOfRangeException e)
                        {

                        }
                        page--;
                        try
                        {
                            for (int i = 0 + (18 * page); i < 18 + (18 * page); i++)
                            {
                                buttons[i].clickable = true;
                            }
                        }
                        catch (ArgumentOutOfRangeException e)
                        {

                        }
                    }
                }
            }
            for (int i = 0; i < buttons.Count; i++ )
            {
                buttons[i].Update(mState);

                if (buttons[i].clicked && loadLevelTimer == 0)
                {
                    // Load corresponding level
                    buttons[i].clicked = false;
                    LoadLevel(levels[i]);
                    //loadLevelTimer++;
                }
            }
            if (currentLevel != null)
            {
                currentLevel.Update();
                if (currentLevel.currentState == gameState.Lost || currentLevel.currentState == gameState.Won)
                {
                    if (currentLevel.currentState == gameState.Lost)
                    {
                        gameMenu.GameOverMessage = "You Lost!";
                    }
                    else
                    {
                        gameMenu.GameOverMessage = "You Won!";
                    }
                    currentLevel.Clear();
                    currentLevel = null;
                    gameMenu.State = MenuState.GameOver;
                    gameMenu.Show();
                    loadLevelTimer = 0;
                }
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw an error message string if need be
            if (showErrorMessage)
            {
                spriteBatch.DrawString(GameVariables.TextFont, errorMessage, new Vector2(50, 400), Color.Red);
            }

            if (gameMenu.State == MenuState.Play && currentLevel == null)
            {
                play.Draw(spriteBatch);
                next.Draw(spriteBatch);
                previous.Draw(spriteBatch);
                spriteBatch.DrawString(GameVariables.TextFont, "Selected Level:", new Vector2(900 * GameVariables.WidthMultiplier, 70 * GameVariables.HeightMultiplier), Color.BlueViolet, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
                if (levelName != null)
                {
                    spriteBatch.DrawString(GameVariables.TextFont, levelName, new Vector2(1200 * GameVariables.WidthMultiplier, 70 * GameVariables.HeightMultiplier), Color.BlueViolet, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
                }
                else
                {
                    spriteBatch.DrawString(GameVariables.TextFont, "Please choose a level", new Vector2(1200 * GameVariables.WidthMultiplier, 70 * GameVariables.HeightMultiplier), Color.BlueViolet, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
                }
                spriteBatch.DrawString(GameVariables.TextFont, "Time Limit:", new Vector2(900 * GameVariables.WidthMultiplier, 120 * GameVariables.HeightMultiplier), Color.BlueViolet, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
                spriteBatch.DrawString(GameVariables.TextFont, "" + timeLimit, new Vector2(1200 * GameVariables.WidthMultiplier, 120 * GameVariables.HeightMultiplier), Color.BlueViolet, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
                spriteBatch.DrawString(GameVariables.TextFont, "Victory Condition:", new Vector2(900 * GameVariables.WidthMultiplier, 170 * GameVariables.HeightMultiplier), Color.BlueViolet, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
                if (victoryCondition != -1)
                {
                    spriteBatch.DrawString(GameVariables.TextFont, "" + (victoryConditions)victoryCondition, new Vector2(1200 * GameVariables.WidthMultiplier, 170 * GameVariables.HeightMultiplier), Color.BlueViolet, 0, Vector2.Zero, new Vector2(GameVariables.WidthMultiplier, GameVariables.HeightMultiplier), SpriteEffects.None, 0);
                }
            }

            foreach (Button x in buttons)
            {
                x.Draw(spriteBatch);
            }
        }
    }
}
