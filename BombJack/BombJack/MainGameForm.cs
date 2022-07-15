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
        private List<Monster> monsters;
        private Player player;
        
        // Example map - not used (used for Debugging)
        public MainGameForm()
        {
            monsters = new List<Monster>();
            movableObjects = new List<MovableObject>();
            player = new Player("Resources/Bomb_Jack_Jack2.gif", 10,10);
            movableObjects.Add(player);

            //movableObjects.Add(new Bonus());
            monsters.Add(new Monster("Resources/Bomb_Jack_Goblin.gif", 100, 10));
            foreach (var monster in monsters)
            {
                movableObjects.Add(monster);
            }
            walls = new List<Wall>();
            bombs = new List<Bomb>();
            
            InitializeComponent();
            walls.Add(new Wall(new Point(100, 256), new Point(200, 256)));
            walls.Add(new Wall(new Point(500, 600), new Point(600, 600)));
            walls.Add(new Wall(new Point(0, Constants.GAMEHEIGHT), new Point(Constants.GAMEWIDTH, Constants.GAMEHEIGHT)));
            walls.Add(new Wall(new Point(0, 0), new Point(Constants.GAMEWIDTH, 0)));
            walls.Add(new Wall(new Point(Constants.GAMEWIDTH,0), new Point(Constants.GAMEWIDTH, Constants.GAMEHEIGHT)));
            walls.Add(new Wall(new Point(0, 0), new Point(0, Constants.GAMEHEIGHT)));
            walls.Add(new Wall(new Point(Constants.GAMEWIDTH-100, 400), new Point(Constants.GAMEWIDTH, 400)));

            bombs.Add(new Bomb("Resources/Bomb_Jack_Bomb1.gif", Constants.GAMEWIDTH - Constants.IMGSIZE, 340));
            bombs.Add(new Bomb("Resources/Bomb_Jack_Bomb1.gif", Constants.GAMEWIDTH - 2*Constants.IMGSIZE, 340));
            bombs.Add(new Bomb("Resources/Bomb_Jack_Bomb1.gif", 550, 500));
        }

        // Map from json 
        public MainGameForm(string jsonPath)
        {
            var summary = JsonSerializer.Deserialize<Summary>(File.OpenRead(jsonPath)); // Load summary from file 
            player = summary.Player;
            walls = summary.Walls;
            bombs= summary.Bombs;
            monsters = summary.Monsters;
            movableObjects = new List<MovableObject>();
            movableObjects.Add(player);
            foreach (var item in monsters)
            {
                movableObjects.Add(item);
            }
            InitializeComponent();
        }

        // Map passed from MapEditor
        public MainGameForm(Summary summary)
        {
            player = summary.Player;
            walls = summary.Walls;
            bombs = summary.Bombs;
            monsters = summary.Monsters;
            movableObjects = new List<MovableObject>();
            movableObjects.Add(player);
            foreach (var item in monsters)
            {
                movableObjects.Add(item);
            }
            InitializeComponent();
        }

        private void MainGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    break;
                case Keys.Down:
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

        // Draws each group of game objects
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

        // Game frame
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < movableObjects.Count; i++)
            {
                movableObjects[i].Move(1,0);
            }
            foreach (var item in movableObjects)
            {
                ((MovableObject)item).UpdatePosition(movableObjects,walls,bombs, Width - (int)Constants.IMGSIZE, Height - (int)Constants.IMGSIZE);
                this.Text = $"Score: {player.Score}     Remaining lives: {player.Lives}";
            }
            if(bombs.Count == 0)
            {
                timer1.Stop();
                MessageBox.Show("You won!");
                DialogResult = DialogResult.Continue;
                this.Close();
            }
            if(player.Lives < 0)
            {
                timer1.Stop();
                MessageBox.Show("Game Over!");
                DialogResult = DialogResult.TryAgain;
                this.Close();
            }
            Invalidate();
        }
    }
}
