using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombJack
{
    public partial class MapEditor : Form
    {
        private List<GameObject> gameObjects = new List<GameObject>();
        private List<MovableObject> movableObjects = new List<MovableObject>();
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
                        gameObjects.Add(new Wall(tmpPoint,new Point(x, y)));
                        tmpLine = true;
                    }
                    break;
                case 2: // mob
                    movableObjects.Add(new Monster("Bomb_Jack_Goblin.gif", x, y));
                    break;
                case 3: // player spawn
                    movableObjects.Add(new Player("Bomb_Jack_Jack2.png", x, y));
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string json = JsonSerializer.Serialize<List<GameObject>>(gameObjects);
            using (FileStream fs = File.OpenWrite("exampleMap.json"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(json);
                fs.Write(info, 0, info.Length);
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MainGameForm mf = new MainGameForm(movableObjects, gameObjects);
            mf.Show();
        }
    }
}
