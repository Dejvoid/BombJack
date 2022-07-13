namespace BombJack
{
    class Monster : MovableObject
    {

        public Monster(string filename, int x, int y) : base(filename)
        {
            position.X = x;
            position.Y = y;
        }

        public override void Move(int x, int y)
        {
            throw new NotImplementedException();
        }
        public override void UpdatePosition(List<MovableObject> movableObjects,List<Wall> walls, List<Bomb> bombs, int width, int height)
        {
            throw new NotImplementedException();
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, position);
        }
    }
}
