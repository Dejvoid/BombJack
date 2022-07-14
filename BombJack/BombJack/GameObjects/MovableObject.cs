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

        // Method for detecting collision with Wall objects
        protected virtual Hit HitWalls(List<Wall> walls)
        {
            foreach (var wall in walls)
            {
                if (Distance(ULPos, wall.Position) + Distance(ULPos, wall.Position2) - Distance(wall.Position,wall.Position2) <= 1 
                    || Distance(URPos, wall.Position) + Distance(URPos, wall.Position2) - Distance(wall.Position, wall.Position2) <= 1)
                {
                    
                    return Hit.UP;
                }
                if (Distance(LLPos, wall.Position) + Distance(LLPos, wall.Position2) - Distance(wall.Position, wall.Position2) <= 1
                    || Distance(LRPos, wall.Position) + Distance(LRPos, wall.Position2) - Distance(wall.Position, wall.Position2) <= 1)
                {
                    return Hit.DOWN;
                }
                if (Distance(ULPos, wall.Position) + Distance(LLPos, wall.Position) - Constants.IMGSIZE <= 1
                    || Distance(ULPos, wall.Position2) + Distance(LLPos, wall.Position2) - Constants.IMGSIZE <= 1
                    || Distance(URPos, wall.Position) + Distance(LRPos, wall.Position) - Constants.IMGSIZE <= 1
                    || Distance(URPos, wall.Position2) + Distance(LRPos, wall.Position2) - Constants.IMGSIZE <= 1)
                {
                    return Hit.SIDE;
                }
                if(ULPos.X <= 0)
                    return Hit.LBARIER;
                if(URPos.X >= Constants.GAMEWIDTH)
                    return Hit.RBARIER;
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
        UP, DOWN, SIDE, LBARIER, RBARIER, NONE,
    }
}
