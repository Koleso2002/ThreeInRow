using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreeInRow2
{
    public static class createButton
    {
        public static Button[] ButtonsCreate()
        {
            Button[] buttons = new Button[36];
            int width = 0;
            int height = 0;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Button();
                buttons[i].Size = new Size(50, 50);
                buttons[i].Location = new Point(width, height);
                width += 51;
                if ((i + 1) % 6 == 0)
                {
                    height += 51;
                    width = 0;
                }
            }
            return buttons;
        }

    }
}
