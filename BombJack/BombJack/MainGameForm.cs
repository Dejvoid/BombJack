﻿using System;
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
        

        public MainGameForm()
        {
            monsters = new List<Monster>();
            this.Width = Constants.GAMEWIDTH + 50;
            this.Height = Constants.GAMEHEIGHT + 50;
            movableObjects = new List<MovableObject>();
            player = new Player("Bomb_Jack_Jack2.gif", 10,10);
            movableObjects.Add(player);
            monsters.Add(new Monster("Bomb_Jack_Goblin.gif", 100, 10));
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

            bombs.Add(new Bomb("Bomb_Jack_Bomb1.gif", Constants.GAMEWIDTH - Constants.IMGSIZE, 340));
            bombs.Add(new Bomb("Bomb_Jack_Bomb1.gif", Constants.GAMEWIDTH - 2*Constants.IMGSIZE, 340));
            bombs.Add(new Bomb("Bomb_Jack_Bomb1.gif", 550, 500));
            //LoadMap();
        }

        public MainGameForm(string jsonPath)
        {
            this.Width = Constants.GAMEWIDTH + 50;
            this.Height = Constants.GAMEHEIGHT + 50;
            var summary = JsonSerializer.Deserialize<Summary>(File.OpenRead(jsonPath));
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
        public MainGameForm(List<GameObject> objects) { }

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
            player.Draw(e.Graphics);
            foreach (var item in monsters)
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
                this.Close();
            }
            if(player.Lives < 0)
            {
                timer1.Stop();
                MessageBox.Show("Game Over!");
                this.Close();
            }
            Invalidate();
        }
    }
}
