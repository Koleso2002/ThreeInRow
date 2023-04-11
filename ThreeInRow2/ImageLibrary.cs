using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreeInRow2
{
    public static class ImageLibrary
    {
        public static ImageList addImage()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(45, 45);
            imgList.Images.Add(Image.FromFile("1.png"));
            imgList.Images.Add(Image.FromFile("2.jpg"));
            imgList.Images.Add(Image.FromFile("3.jpg"));
            imgList.Images.Add(Image.FromFile("4.jpg"));
            imgList.Images.Add(Image.FromFile("5.jpg"));
            return imgList;
        }
    }
}
