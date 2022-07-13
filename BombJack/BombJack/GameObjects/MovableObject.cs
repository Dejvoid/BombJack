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
        public virtual void UpdatePosition(List<MovableObject> movable, int width, int height)
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
                if (item != this && isCollision(item))
                {
                    // Collide
                }
            }
        }

        private bool isCollision(GameObject item)
        {
            return Math.Pow(item.Position.X - position.X, 2) + Math.Pow(item.Position.Y - position.Y, 2) <= 32;
        }
    }
}
