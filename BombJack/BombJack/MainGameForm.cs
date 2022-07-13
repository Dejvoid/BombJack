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
    public partial class MainGameForm : Form
    {
        private List<MovableObject> movableObjects;
        private List<Wall> walls;
        private List<Bomb> bombs;
        private Player player;

        public MainGameForm()
        {
            movableObjects = new List<MovableObject>();
            player = new Player("Bomb_Jack_Jack2.png");
            movableObjects.Add(player);
            walls = new List<Wall>();
            bombs = new List<Bomb>();
            
            InitializeComponent();
            walls.Add(new Wall(new Point(100, 256), new Point(160, 256)));
            walls.Add(new Wall(new Point(0, Height-50), new Point(Width, Height-50)));

            bombs.Add(new Bomb("Bomb_Jack_Bomb2.gif", 120, 120));
            //LoadMap();
        }

        public MainGameForm(List<MovableObject> movableObjects, List<GameObject> gameObjects)
        {
            this.movableObjects = movableObjects;
        }

        private void LoadMap()
        {
            string path = "exampleMap.json";
            var gameData = JsonSerializer.Deserialize(path, typeof(List<GameObject>));

        }

        private void MainGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    break;
                case Keys.Down:
                    // Change gravity modifier
                    break;
                case Keys.Left:
                    player.Move(-1,0);
                    break;
                case Keys.Right:
                    player.Move(1, 0);
                    break;
                case Keys.Space:
                    player.Jump();
                    break;

            }
        }
        private void MainGameForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    break;
                case Keys.Down:
                    // Change gravity modifier
                    break;
                case Keys.Left:
                    player.StopMoveX();
                    break;
                case Keys.Right:
                    player.StopMoveX();
                    break;
                case Keys.Space:
                    player.ResetGravity();
                    break;
            }
        }

        private void MainGameForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in movableObjects)
            {
                item.Draw(e.Graphics);
            }
            foreach (var wall in walls)
            {
                wall.Draw(e.Graphics);
            }
            foreach (var bomb in bombs)
            {
                bomb.Draw(e.Graphics);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in movableObjects)
            {
                ((MovableObject)item).UpdatePosition(movableObjects,walls,bombs, Width - 64, Height-64);
            }
            Invalidate();
        }
    }
}
