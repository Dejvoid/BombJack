namespace BombJack
{
    class Player : MovableObject
    {
        private int gravity = 10;
        private int gravityctr = 0;
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
            moveVector.Y = y * (int)Constants.speed;
        }
        public void Jump()
        {
            if (isOnGround())
            {
                gravityctr = 15;
                moveVector.Y = -15;
            }
        }

        private bool isOnGround()
        {
            return true;
        }

        public override void UpdatePosition(List<MovableObject> objects, int width, int height)
        {
            if(--gravityctr <= 0)
                ApplyGravity();
            base.UpdatePosition(objects, width, height);
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
