﻿using System.Text.Json.Serialization;

namespace BombJack
{
    public class Player : MovableObject
    {
        private int gravity = 10;
        private int gravityctr = 0;
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
            img = Image.FromFile("Bomb_Jack_Jack2.gif");
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

        public override void Move(int x, int y)
        {
            moveVector.X = x * Constants.SPEED;
        }
        public void Jump()
        {
            //canJump = true;
            if (canJump)
            {
                gravityctr = 15;
                position.Y -= 15;
                moveVector.Y = -20;
            }
            else
                gravity = 5;
        }
        public void ResetGravity()
        {
            if (--gravityctr <= 0)
            {
                gravityctr = 0;
                gravity = 10;
            }
        }

        public override void UpdatePosition(List<MovableObject> movable, List<Wall> walls, List<Bomb> bombs, int width, int height)
        {
            if (--gravityctr <= 0)
            {
                gravityctr = 0;
                ApplyGravity(); 
            }

            switch (HitWalls(walls))
            {
                case Hit.UP:
                    moveVector.Y = 5;
                    position.Y += moveVector.Y;
                    position.X += moveVector.X;
                    break;
                case Hit.DOWN:
                    canJump = true;
                    position.X += moveVector.X;
                    break;
                case Hit.SIDE:
                    position.Y += moveVector.Y;
                    position.X -= Math.Sign(moveVector.X);
                    break;
                case Hit.NONE:
                    canJump = false;
                    position.Y += moveVector.Y;
                    position.X += moveVector.X;
                    break;
                case Hit.LBARIER:
                    if (position.X + moveVector.X >= 0)
                    {
                        position.X += moveVector.X;
                    }
                    break;
                case Hit.RBARIER:
                    if (URPos.X + moveVector.X <= Constants.GAMEWIDTH)
                    {
                        position.X += moveVector.X;
                    }
                    break;
                default:
                    break;
            }
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
                    --lives;
                    position.X = spawn.X;
                    position.Y = spawn.Y;
                    RecalculatePos();
                    //Collide(item);
                }
            }
        }

        private void ApplyGravity()
        {
            if(moveVector.Y < 10)
                moveVector.Y += gravity;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, position);
            g.DrawLines(Pens.Black, new Point[] { ULPos, LLPos, LRPos, URPos, ULPos});
        }

        internal void StopMoveX()
        {
            moveVector.X = 0;
        }
    }
}
