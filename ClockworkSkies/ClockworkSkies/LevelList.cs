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

        public LevelList()
        {
            levels = new List<string>();
            buttons = new List<Button>();
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

        public void Update(MouseState mState)
        {
            foreach (Button x in buttons)
            {
                x.Update(mState);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Button x in buttons)
            {
                x.Draw(spriteBatch);
            }
        }
    }
}
