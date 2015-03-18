using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClockworkSkies
{
    class LevelList
    {
        private List<string> levels;

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
    }
}
