using System;
using System.Windows.Forms;

namespace ThreeInRow2
{
    [Serializable]
    internal class Game
    {
        private int[] indexImage;
        [NonSerialized]
        private Button[] buttons;
        [NonSerialized]
        private ImageList imgList;

        public Game(Control.ControlCollection control)
        {
            buttons = createButton.ButtonsCreate();
            indexImage = new int[buttons.Length];
            imgList = ImageLibrary.addImage();
            Random rnd = new Random();
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = rnd.Next(0, 5);
                buttons[i].ImageList = imgList;
                buttons[i].ImageIndex = index;
                indexImage[i] = buttons[i].ImageIndex;
            }
            control.AddRange(buttons);
            Choice();
        }

        public void NewGame()
        {
            Random rnd = new Random();
            ImageList imageList = ImageLibrary.addImage();
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = rnd.Next(0, 5);
                buttons[i].ImageList = imageList;
                buttons[i].ImageIndex = index;
                indexImage[i] = buttons[i].ImageIndex;
            }      
        }

        public void Resume(Control.ControlCollection control)
        {
            buttons = createButton.ButtonsCreate();
            ImageList imageList = ImageLibrary.addImage();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].ImageList = imageList;
                buttons[i].ImageIndex = indexImage[i];
            }
            control.AddRange(buttons);
            Choice();
        }
        private void Choice()
        {
            int ButtonsIndex1 = 0;
            int ButtonsIndex2 = 0;
            int btnIndexImage1 = 0;
            int btnIndexImage2 = 0;
            int step = 0;

            foreach (var item in buttons)
            {
                item.Click += Item_Click;
            }

            void Item_Click(object sender, EventArgs e)
            {

                if (step == 0 && sender is Button button1)
                {
                    ButtonsIndex1 = Array.IndexOf(buttons, button1);
                    btnIndexImage1 = button1.ImageIndex;
                }
                if (step == 1 && sender is Button button2)
                {
                    ButtonsIndex2 = Array.IndexOf(buttons, button2);
                    btnIndexImage2 = button2.ImageIndex;
                }
                step++;
                if (step == 2)
                {
                    if (Math.Abs(ButtonsIndex1 - ButtonsIndex2) == 1 || Math.Abs(ButtonsIndex1 - ButtonsIndex2) == 6)
                    {
                        buttons[ButtonsIndex1].ImageIndex = btnIndexImage2;
                        buttons[ButtonsIndex2].ImageIndex = btnIndexImage1;
                        for (int i = 0; i < buttons.Length; i++)
                        {
                            indexImage[i] = buttons[i].ImageIndex;
                        }

                        imageRemove(ButtonsIndex2, btnIndexImage1);
                        imageRemove(ButtonsIndex1, btnIndexImage2);

                        ButtonsIndex1 = 0;
                        ButtonsIndex2 = 0;
                        btnIndexImage1 = 0;
                        btnIndexImage2 = 0;
                        step = 0;
                    }
                    else
                    {
                        ButtonsIndex1 = 0;
                        ButtonsIndex2 = 0;
                        btnIndexImage1 = 0;
                        btnIndexImage2 = 0;
                        step = 0;
                    }
                }

            }
        }
        public void imageRemove(int indBtn, int indImg)
        {
            int row = 0;
            int col = 0;
            int val = 0;
            int[,] tmpImageIndex = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    tmpImageIndex[i, j] = indexImage[val];
                    if (indBtn == val)
                    {
                        row = i; col = j;
                    }
                    val++;
                }
            }
            int right = 0;
            int left = right = col;
            int cntHor = 1;
            for (int i = col + 1; i < tmpImageIndex.GetLength(0); i++)
            {
                if (tmpImageIndex[row, i] == indImg)
                {
                    cntHor++;
                    right++;
                }
                else break;
            }
            for (int i = col - 1; i >= 0; i--)
            {
                if (tmpImageIndex[row, i] == indImg)
                {
                    cntHor++;
                    left--;
                }
                else break;
            }
            int up = 0;
            int down = up = row;
            int cntVertic = 1;
            for (int i = row + 1; i < tmpImageIndex.GetLength(1); i++)
            {
                if (tmpImageIndex[i, col] == indImg)
                {
                    cntVertic++;
                    down++;
                }
                else break;
            }
            for (int i = row - 1; i >= 0; i--)
            {
                if (tmpImageIndex[i, col] == indImg)
                {
                    cntVertic++;
                    up--;
                }
                else break;
            }

            Random rnd = new Random();
            if (cntHor >= 3)
            {
                for (int i = 0; i <= right - left; i++)
                {
                    int index = rnd.Next(0, 5);
                    buttons[row * tmpImageIndex.GetLength(0) + left + i].ImageIndex = index;
                }
            }
            if (cntVertic >= 3)
            {
                for (int i = up; i <= down; i++)
                {
                    int index = rnd.Next(0, 5);
                    buttons[i * tmpImageIndex.GetLength(1) + col].ImageIndex = index;
                }

            }
            for (int i = 0; i < buttons.Length; i++)
            {
                indexImage[i] = buttons[i].ImageIndex;
            }

        }

    }
}
