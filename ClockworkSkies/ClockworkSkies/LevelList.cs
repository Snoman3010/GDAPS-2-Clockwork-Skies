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
    class LevelList
    {
        public static List<string> levels;
        public static List<Button> buttons;

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

        public LevelList()
        {
            levels = new List<string>();
            buttons = new List<Button>();
            npcs = new List<Vector4>();
            GetLevels();
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
            catch (FileNotFoundException fnf)
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

        public void LoadLevel(string level)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(level);

                string line = null;
                while((line = reader.ReadLine()) != null)
                {
                    if(line[0] == ':')
                    {
                        string lineData = line.Substring(3);

                        switch(line[1])
                        {
                            case 'L':
                                levelName = lineData;
                                break;
                            case 'T':
                                int.TryParse(lineData, out timeLimit); // Fail to load time error
                                break;
                            case 'V':
                                int.TryParse(lineData, out victoryCondition); // Fail to load victory condition error
                                break;
                            case 'A':
                                string[] targetAlliedValues = lineData.Split(','); // Failed to load allied base error

                                int targetAliedXPos = 0;
                                int.TryParse(targetAlliedValues[0], out targetAliedXPos);
                                alliedTargetInfo.X = targetAliedXPos;

                                int targetAliedYPos = 0;
                                int.TryParse(targetAlliedValues[1], out targetAliedYPos);
                                alliedTargetInfo.Y = targetAliedYPos;

                                int targetAliedDirection = 0;
                                int.TryParse(targetAlliedValues[2], out targetAliedDirection);
                                alliedTargetInfo.Z = targetAliedDirection;
                                break;
                            case 'R':
                                string[] targetEnemyValues = lineData.Split(',');

                                int targetEnemyXPos = 0;
                                int.TryParse(targetEnemyValues[0], out targetEnemyXPos);
                                enemyTargetInfo.X = targetEnemyXPos;

                                int targetEnemyYPos = 0;
                                int.TryParse(targetEnemyValues[1], out targetEnemyYPos);
                                enemyTargetInfo.Y = targetEnemyYPos;

                                int targetEnemyDirection = 0;
                                int.TryParse(targetEnemyValues[2], out targetEnemyDirection);
                                enemyTargetInfo.Z = targetEnemyDirection;
                                break;
                            case 'F':
                                string[] alliedBaseValues = lineData.Split(',');

                                int alliedBaseXPos = 0;
                                int.TryParse(alliedBaseValues[0], out alliedBaseXPos);
                                alliedBase.X = alliedBaseXPos;

                                int alliedBaseYPos = 0;
                                int.TryParse(alliedBaseValues[1], out alliedBaseYPos);
                                alliedBase.Y = alliedBaseYPos;
                                break;
                            case 'B':
                                string[] enemyBaseValues = lineData.Split(',');

                                int enemyBaseXPos = 0;
                                int.TryParse(enemyBaseValues[0], out enemyBaseXPos);
                                enemyBase.X = enemyBaseXPos;

                                int enemyBaseYPos = 0;
                                int.TryParse(enemyBaseValues[1], out enemyBaseYPos);
                                enemyBase.Y = enemyBaseYPos;
                                break;
                            case 'P':
                                string[] playerStartValues = lineData.Split(',');

                                int playerXPos = 0;
                                int.TryParse(playerStartValues[0], out playerXPos);
                                playerInfo.X = playerXPos;

                                int playerYPos = 0;
                                int.TryParse(playerStartValues[1], out playerYPos);
                                playerInfo.Y = playerYPos;

                                int playerDirection = 0;
                                int.TryParse(playerStartValues[2], out playerDirection);
                                playerInfo.Z = playerDirection;
                                break;
                            case 'E':
                                string[] npcValues = lineData.Split(',');

                                int npcXPos = 0;
                                int.TryParse(npcValues[0], out npcXPos);

                                int npcYPos = 0;
                                int.TryParse(npcValues[1], out npcYPos);

                                int npcDirection = 0;
                                int.TryParse(npcValues[2], out npcDirection);

                                int npcType = 0;
                                int.TryParse(npcValues[2], out npcType);

                                npcs.Add(new Vector4(npcXPos, npcYPos, npcDirection, npcType));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch(IOException e)
            {
                showErrorMessage = true;
                errorMessage = e.Message;
            }
            finally
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

                if(x.clicked)
                {
                    // Load corresponding level
                    LoadLevel(x.Text);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Button x in buttons)
            {
                x.Draw(spriteBatch);
            }

            if(showErrorMessage)
            {
                spriteBatch.DrawString(GameVariables.TextFont, errorMessage, new Vector2(50, 400), Color.Red);
            }
        }
    }
}
