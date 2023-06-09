﻿using System.Text.Json.Serialization;

namespace BombJack
{
    public class Player : MovableObject
    {
        private int gravityctr = 0; // Used for restricting the gravity effect during jumping
        private bool canJump = false;
        private int score = 0;
        private int lives = 3;
        private Point spawn;
        public int Lives { get { return lives; } }
        public int Score { get { return score; } }
        public Player(string filename) : base(filename)
        {
        }

        [JsonConstructor]
        public Player(int lives, int score, Point position) : base()
        {
            img = Image.FromFile("Resources/Bomb_Jack_Jack2.gif");
            spawn = position;
            this.position = position;
            ULPos = position;
            URPos = new Point(position.X + Constants.IMGSIZE, position.Y);
            LLPos = new Point(position.X, position.Y + Constants.IMGSIZE);
            LRPos = new Point(position.X + Constants.IMGSIZE, position.Y + Constants.IMGSIZE);
        }
        public Player(string filename, int x, int y) : base(filename)
        {
            spawn = new Point(x, y);
            position.X = x;
            position.Y = y;
            ULPos = position;
            URPos = new Point(x + Constants.IMGSIZE, y);
            LLPos = new Point(x, y + Constants.IMGSIZE);
            LRPos = new Point(x + Constants.IMGSIZE, y + Constants.IMGSIZE);
        }

        // Desired object movement, could be wrong -> checked in UpdatePosition
        public override void Move(int x, int y)
        {
            moveVector.X = x * Constants.SPEED;
        }
        public void Jump()
        {
            if (canJump)
            {
                gravityctr = 15;
                position.Y -= 15;
                moveVector.Y = -20;
            }
            else
                gravity = 5;
        }

        // Remove gravity restriction after jump
        public void ResetGravity()
        {
            if (--gravityctr <= 0)
            {
                gravityctr = 0;
                gravity = 10;
            }
        }

        // Determines if object can move and moves it. Also solves collision with other objects (e.g. bombs)
        public override void UpdatePosition(List<MovableObject> movable, List<Wall> walls, List<Bomb> bombs, int width, int height)
        {
            if (--gravityctr <= 0)
            {
                gravityctr = 0;
                ApplyGravity(); 
            }
            var hits = CheckWalls(walls);
            switch (hits.Item1) // solve horizontal wall collisions
            {
                case Hit.LEFT:
                    moveVector.X = 0;
                    break;
                case Hit.RIGHT:
                    moveVector.X = 0;
                    break;
                case Hit.NONE:
                    break;
            }
            switch (hits.Item2) // solve vertical wall collisions
            {
                case Hit.UP:
                    canJump = false;
                    moveVector.Y = 5;
                    break;
                case Hit.DOWN:
                    canJump = true;
                    moveVector.Y = 0;
                    break;
                case Hit.NONE:
                    canJump = false;
                    break;
            }
            position.Y += moveVector.Y;
            position.X += moveVector.X;
            RecalculatePos();
            foreach (var bomb in bombs)
            {
                if (IsCollision(bomb))
                {
                    //Collide(bomb);
                    bombs.Remove(bomb);
                    score += 200;
                    break;
                }
            }
            foreach (var item in movable)
            {
                if (item != this && IsCollision(item))
                {
                    Collide(item);
                }
            }
        }

        // Solves collision with movable objects - possible features: add bonuses
        private void Collide(MovableObject item) 
        {
            if (item.GetType() == typeof(Monster))
            {
                --lives;
                position.X = spawn.X;
                position.Y = spawn.Y;
                RecalculatePos();
            }
            if(item.GetType() == typeof(Bonus))
            {
                ++lives;
            }
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, position);
            //g.DrawLines(Pens.Black, new Point[] { ULPos, LLPos, LRPos, URPos, ULPos}); // Debug bounding box
        }

        // Used when key is no longer pressed to stop movement
        internal void StopMoveX()
        {
            moveVector.X = 0;
        }
    }
}
