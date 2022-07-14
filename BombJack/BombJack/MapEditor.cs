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
            player = new Player("Resources/Bomb_Jack_Jack2.gif");
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

        // Adds gameobject based on selected item from combobox 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int x = ((MouseEventArgs)e).X;
            int y = ((MouseEventArgs)e).Y;
            int offset = -Constants.IMGSIZE / 2;
            switch (comboBox1.SelectedIndex)
            {
                case 0: //bomb
                    var b = new Bomb("Resources/Bomb_Jack_Bomb1.gif", x+offset, y + offset);
                    gameObjects.Add(b);
                    bombs.Add(b);
                    break;
                case 1: // horizontal wall
                    if (tmpLine) // needs 2 points
                    {
                        tmpPoint = new Point(x, y);
                        tmpLine = false;
                    }
                    else
                    {
                        var w = new Wall(tmpPoint, new Point(x, tmpPoint.Y));
                        if (Distance(w.Position, w.Position2) <= 64)
                            MessageBox.Show("Line is too short (<64)");
                        else
                        {
                            walls.Add(w);
                            gameObjects.Add(w);
                        }
                        tmpLine = true;
                    }
                    break;
                case 2: // monster
                    var m = new Monster("Resources/Bomb_Jack_Goblin.gif", x + offset, y + offset);
                    monsters.Add(m);
                    gameObjects.Add(m);
                    break;
                case 3: // player spawn
                    player = (new Player("Resources/Bomb_Jack_Jack2.gif", x + offset, y + offset));
                    gameObjects[0] = player;
                    break;
                case 4: // vertical wall
                    if (tmpLine) // needs 2 points
                    {
                        tmpPoint = new Point(x, y);
                        tmpLine = false;
                    }
                    else
                    {
                        var w = new Wall(tmpPoint, new Point(tmpPoint.X, y));
                        if (Distance(w.Position, w.Position2) <= 64)
                            MessageBox.Show("Line is too short (<64)");
                        else
                        {
                            walls.Add(w);
                            gameObjects.Add(w);
                        }
                        tmpLine = true;
                    }
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
            tmpLine = true;
        }

        // Saves the map using SaveFileDialog
        private void save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var summary = new Summary(player, walls, monsters, bombs);
                string summaryJson = JsonSerializer.Serialize<Summary>(summary);
                using (FileStream fs = File.OpenWrite(sfd.FileName))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(summaryJson);
                    fs.Write(info, 0, info.Length);
                }
                MessageBox.Show("File saved");
            }
            else
                MessageBox.Show("Something went wrong");
        }

        // Starts game with currently created/edited map
        private void button1_Click_1(object sender, EventArgs e)
        {
            var summary = new Summary(player, walls, monsters, bombs);
            MainGameForm game = new MainGameForm(summary);
            game.Width = Constants.GAMEWIDTH + 50;
            game.Height = Constants.GAMEHEIGHT + 50;
            this.Hide();
            switch (game.ShowDialog())
            {
                case DialogResult.TryAgain: 
                    break;
                case DialogResult.Continue:
                    break;
                default:
                    break;
            }
            this.Show();
        }
        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
