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
        private List<Bomb> bombs = new List<Bomb>();
        private List<Monster> monsters = new List<Monster>();
        private List<Wall> walls = new List<Wall>();
        private Player player;
        private Point tmpPoint;
        private bool tmpLine;
        public MapEditor()
        {
            InitializeComponent();
            player = new Player("Bomb_Jack_Jack2.gif");
            gameObjects.Add(player);
            var w1 = new Wall(new Point(0, Constants.GAMEHEIGHT), new Point(Constants.GAMEWIDTH, Constants.GAMEHEIGHT));
            var w2 = new Wall(new Point(0, 0), new Point(Constants.GAMEWIDTH, 0));
            var w3 = new Wall(new Point(Constants.GAMEWIDTH, 0), new Point(Constants.GAMEWIDTH, Constants.GAMEHEIGHT));
            var w4 = new Wall(new Point(0, 0), new Point(0, Constants.GAMEHEIGHT));
            walls.Add(w1);
            walls.Add(w2);
            walls.Add(w3);
            walls.Add(w4);
            gameObjects.Add(w1);
            gameObjects.Add(w2);
            gameObjects.Add(w3);
            gameObjects.Add(w4);
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int x = ((MouseEventArgs)e).X;
            int y = ((MouseEventArgs)e).Y;
            x -= x % Constants.IMGSIZE;
            y -= y % Constants.IMGSIZE;
            switch (comboBox1.SelectedIndex)
            {
                case 0: //bom
                    var b = new Bomb("Bomb_Jack_Bomb1.gif", x, y);
                    gameObjects.Add(b);
                    bombs.Add(b);
                    break;
                case 1: //wall
                    if (tmpLine)
                    {
                        tmpPoint = new Point(x, y);
                        tmpLine = false;
                    }
                    else
                    {
                        var w = new Wall(tmpPoint, new Point(x, y));
                        walls.Add(w);
                        gameObjects.Add(w);
                        tmpLine = true;
                    }
                    break;
                case 2: // mob
                    var m = new Monster("Bomb_Jack_Goblin.gif", x, y);
                    monsters.Add(m);
                    gameObjects.Add(m);
                    break;
                case 3: // player spawn
                    player = (new Player("Bomb_Jack_Jack2.gif", x, y));
                    gameObjects[0] = player;
                    break;
                default:
                    break;
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var go in gameObjects)
            {
                go.Draw(e.Graphics);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmpLine = false;
        }


        private void save_btn_Click(object sender, EventArgs e)
        {
            var summary = new Summary(player, walls, monsters, bombs);
            string summaryJson = JsonSerializer.Serialize<Summary>(summary);

            using (FileStream fs = File.OpenWrite("exampleMap.json"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(summaryJson);
                fs.Write(info, 0, info.Length);
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //var movableObjects = new List<MovableObject>() { player};
            //foreach (var monster in monsters)
            //{
            //    movableObjects.Add(monster);
            //}
            //MainGameForm mf = new MainGameForm(gameObjects);
            //mf.Show();
        }
    }
}
