namespace BombJack
{
    public abstract class MovableObject : GameObject
    {
        protected Point moveVector;
        protected Image img;
        protected MovableObject(string filename) : base()
        {
            img = Image.FromFile(filename);
        }

        public abstract void Move(int x, int y);
        public virtual void UpdatePosition(List<MovableObject> movable, List<Wall> walls, List<Bomb> bombs, int width, int height)
        {

            position.X += moveVector.X;
            position.Y += moveVector.Y;
            if (position.X < 0){
                position.X = 0;
            }
            if (position.X > width - 64){
                position.X = width - 64;
            }
            if (position.Y > height-64){
                position.Y = height - 64;
            }
            foreach (var item in movable)
            {
                if (item != this && IsCollision(item))
                {
                    // Collide
                }
            }
        }

        protected virtual bool HitWalls(List<Wall> walls)
        {
            var tmpPos = new Point(position.X,position.Y);
            tmpPos.Y += 64;
            foreach (var wall in walls)
            {
                if (Distance(Position, wall.Position) + Distance(Position, wall.Position2) - Distance(wall.Position,wall.Position2) <= 1)
                {
                    return true;
                }
                if (Distance(tmpPos, wall.Position) + Distance(tmpPos, wall.Position2) - Distance(wall.Position, wall.Position2) <= 1)
                {
                    return true;
                }
            }
            return false;
        }
        protected virtual bool IsCollision(GameObject item)
        {
            return Math.Pow(item.Position.X - position.X, 2) + Math.Pow(item.Position.Y - position.Y, 2) <= 32;
        }
        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X,2) + Math.Pow(p1.Y - p2.Y,2));
        }
    }
    public enum Direction
    {
        HORIZONTAL, VERTICAL
    }
}
