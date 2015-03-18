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
    class Button
    {
        // attributes
        Rectangle rect;
        string text;
        bool clicked;

        // constructor
        public Button(Rectangle r, string txt, bool clckd)
        {
            rect = r;
            text = txt;
            clicked = clckd;
        }

        // Update method
        public void Update()
        {

        }
    }
}
