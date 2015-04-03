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

        private int loadLevelTimer = 0;

        //constructor
        public LevelList(Menu gMenu)
        {
            levels = new List<string>();
            buttons = new List<Button>();
            npcs = new List<Vector4>();
            GetLevels();
            gameMenu = gMenu;
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
            for(int i = 0; i < levels.Count; i++)
            {
                Button button = new Button(new Rectangle(50, 50 + 100 * i, 200, 100), levels[i]);
                button.clickable = true;
                buttons.Add(button);

            }
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

                                    alliedTargetInfo.X = int.Parse(targetAlliedValues[0]);
                                    alliedTargetInfo.Y = int.Parse(targetAlliedValues[1]);
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

                                    enemyTargetInfo.X = int.Parse(targetEnemyValues[0]);
                                    enemyTargetInfo.Y = int.Parse(targetEnemyValues[1]);
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

                                    alliedBase.X = int.Parse(alliedBaseValues[0]); ;
                                    alliedBase.Y = int.Parse(alliedBaseValues[1]);
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

                                    enemyBase.X = int.Parse(enemyBaseValues[0]);
                                    enemyBase.Y = int.Parse(enemyBaseValues[1]);
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

                                    playerInfo.X = int.Parse(playerStartValues[0]);
                                    playerInfo.Y = int.Parse(playerStartValues[1]);
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

                                    int npcXPos = int.Parse(npcValues[0]);
                                    int npcYPos = int.Parse(npcValues[1]);
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
                gameMenu.Hide();
                currentLevel = new Level(timeLimit, victoryCondition, playerInfo, alliedTargetInfo, enemyTargetInfo, alliedBase, enemyBase, npcs);
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
            foreach (Button x in buttons)
            {
                x.Update(mState);

                if(x.clicked && loadLevelTimer == 0)
                {
                    // Load corresponding level
                    LoadLevel(x.Text);
                    loadLevelTimer++;
                }
            }
            if (currentLevel != null)
            {
                currentLevel.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw an error message string if need be
            if (showErrorMessage)
            {
                spriteBatch.DrawString(GameVariables.TextFont, errorMessage, new Vector2(50, 400), Color.Red);
            }

            foreach (Button x in buttons)
            {
                x.Draw(spriteBatch);
            }
        }
    }
}
