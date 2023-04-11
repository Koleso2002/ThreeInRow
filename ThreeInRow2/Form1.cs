using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreeInRow2
{
    public partial class Form1 : Form
    {
        Game game;
        BinaryFormatter bf;
        public Form1()
        {
            InitializeComponent();
            bf = new BinaryFormatter();
            game = LoadGame();
            this.FormClosed += Form1_FormClosed;
            button1.Text = "Новая игра!";

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            using (Stream write = File.Create("Save"))
            {
                bf.Serialize(write, game);
            }
        }

        private Game LoadGame()
        {
            if (File.Exists("Save"))
                using (Stream read = File.OpenRead("Save"))
                {
                    object value = bf.Deserialize(read);
                    if (value is Game)
                    {
                        Game o = value as Game;
                        o.Resume(this.Controls);
                        return o;
                    }
                }
            return new Game(this.Controls);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Delete("Save");
            game.NewGame();
        }
    }
}
