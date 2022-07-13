using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombJack
{
    public partial class MapEditor : Form
    {
        private List<GameObject> gameObjects = new List<GameObject>();
        private Point tmpPoint;
        private bool tmpLine;
        public MapEditor()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int x = ((MouseEventArgs)e).X;
            int y = ((MouseEventArgs)e).Y;
            x -= x % 64;
            y -= y % 64;
            switch (comboBox1.SelectedIndex)
            {
                case 0: //bom
                    gameObjects.Add(new Bomb("Bomb_Jack_Bomb2.png", x, y));
                    break;
                case 1: //wall
                    if (tmpLine)
                    {
                        tmpPoint = new Point(x, y);
                        tmpLine = false;
                    }
                    else
                    {
                        gameObjects.Add(new Wall("",tmpPoint,new Point(x, y)));
                        tmpLine = true;
                    }
                    break;
                case 2: // mob
                    gameObjects.Add(new Bomb("Bomb_Jack_Goblin.gif", x, y));
                    break;
                case 3: // player spawn
                    gameObjects.Add(new Bomb("Bomb_Jack_Jack2.png", x, y));
                    break;
                default:
                    break;
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in gameObjects)
            {
                item.Draw(e.Graphics);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmpLine = false;
        }
    }
}
