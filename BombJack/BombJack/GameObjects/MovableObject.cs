namespace BombJack
{
    public abstract class MovableObject : GameObject
    {
        // 4 points for detecting collisions of the bounding box
        protected Point ULPos; // Upper Left corner
        protected Point LLPos; // Lower Left corner
        protected Point URPos; // Upper Right corner
        protected Point LRPos; // Lower Right corner
        protected Point moveVector;
        protected Image img;
        protected int gravity = 10;
        protected MovableObject(string filename) : base()
        {
            img = Image.FromFile(filename);
            ULPos = position;
            LLPos = new Point(position.X, position.Y + Constants.IMGSIZE);
            URPos = new Point(position.X + Constants.IMGSIZE, position.Y );
            LRPos = new Point(position.X + Constants.IMGSIZE, position.Y + Constants.IMGSIZE);
        }

        protected MovableObject()
        {
        }

        public abstract void Move(int x, int y);
        public virtual void UpdatePosition(List<MovableObject> movable, List<Wall> walls, List<Bomb> bombs, int width, int height)
        {
            position.X += moveVector.X;
            position.Y += moveVector.Y;
            foreach (var item in movable)
            {
                if (item != this && IsCollision(item))
                {
                    // Collide
                }
            }
            RecalculatePos();
        }

        // Checks collision with horizontal walls
        // If after applying movevector is some part behind wall, return hit
        protected virtual Hit CheckHorizontalWalls(List<Wall> walls)
        {
            foreach (var wall in walls)
            {
                if (wall.Position.X < ULPos.X && wall.Position2.X > ULPos.X  // is somewhere above/below line
                    || wall.Position2.X < ULPos.X && wall.Position.X > ULPos.X
                    || wall.Position.X < URPos.X && wall.Position2.X > URPos.X
                    || wall.Position2.X < URPos.X && wall.Position.X > URPos.X)
                {
                    if(wall.Position.Y >= LLPos.Y && LLPos.Y + moveVector.Y >= wall.Position.Y) // Hit.DOWN candidate
                    {
                            return Hit.DOWN;
                    }
                    if (wall.Position.Y <= ULPos.Y && ULPos.Y + moveVector.Y <= wall.Position.Y) // Hit.UP candidate
                    {
                            return Hit.UP;
                    }
                }
            }
            return Hit.NONE;
        }

        // Checks collision with vertical walls
        // If after applying movevector is some part behind wall, return hit
        protected virtual Hit CheckVerticalWalls(List<Wall> walls)
        {
            foreach (var wall in walls)
            {
                if (wall.Position.Y < ULPos.Y && wall.Position2.Y > ULPos.Y  // is somewhere next to line
                    || wall.Position2.Y < ULPos.Y && wall.Position.Y > ULPos.Y
                    || wall.Position.Y < LLPos.Y && wall.Position2.Y > LLPos.Y
                    || wall.Position2.Y < LLPos.Y && wall.Position.Y > LLPos.Y)
                {
                    if (wall.Position.X >= LRPos.X && LRPos.X + moveVector.X >= wall.Position.X) // Hit.RIGHT candidate
                    {
                        return Hit.RIGHT;
                    }
                    if (wall.Position.X <= ULPos.X && ULPos.X+moveVector.X <= wall.Position.X) // Hit.UP candidate
                    {
                        return Hit.LEFT;
                    }
                }
            }
            return Hit.NONE;
        }

        // Tells if object collided with another
        protected virtual bool IsCollision(GameObject item)
        {
            return Math.Pow(item.Position.X - position.X, 2) + Math.Pow(item.Position.Y - position.Y, 2) <= (Constants.IMGSIZE/2) * (Constants.IMGSIZE / 2);
        }
        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X,2) + Math.Pow(p1.Y - p2.Y,2));
        }
        protected void RecalculatePos()
        {
            ULPos = position;
            LLPos.X = position.X;
            LLPos.Y = position.Y + Constants.IMGSIZE;
            URPos.X = position.X + Constants.IMGSIZE;
            URPos.Y = position.Y;
            LRPos.X = position.X + Constants.IMGSIZE;
            LRPos.Y = position.Y + Constants.IMGSIZE;
        }
        protected void ApplyGravity()
        {
            if (moveVector.Y < 10)
                moveVector.Y += gravity;
        }
    }
    public enum Hit
    {
        UP, DOWN, LEFT, RIGHT, NONE,
    }
}
