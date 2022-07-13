namespace BombJack
{
    class Player : MovableObject
    {
        private int gravity = 10;
        private int gravityctr = 0;
        private bool canJump = false;
        public Player(string filename) : base(filename)
        {
        }

        public Player(string filename, int x, int y) : base(filename)
        {
            position.X = x;
            position.Y = y;
        }

        public override void Move(int x, int y)
        {
            moveVector.X = x * (int)Constants.speed;
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

            if (HitWalls(walls))
            {
                canJump = true;
                position.X += moveVector.X;
            }
            else
            {
                canJump = false;
                position.Y += moveVector.Y;
                position.X += moveVector.X;
            }
            foreach (var bomb in bombs)
            {
                if (IsCollision(bomb))
                {
                    Collide(bomb);
                    bombs.Remove(bomb);
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

        private void Collide(GameObject o)
        {
            if(o.GetType() == typeof(Bomb))
            {
                // collect bomb
            }
            if(o.GetType() == typeof(Monster))
            {
                // lives--;
            }
            /*if(o.GetType() == typeof(Coin))
            {
                // collect coin
            }*/
        }

        private void ApplyGravity()
        {
            if(moveVector.Y < 10)
                moveVector.Y += gravity;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, position);
        }

        internal void StopMoveX()
        {
            moveVector.X = 0;
        }
    }
}
