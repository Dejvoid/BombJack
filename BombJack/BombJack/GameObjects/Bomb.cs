namespace BombJack
{
    public class Bomb : GameObject
    {
        private Image img;
        public Bomb(string filename, int x, int y) : base()
        {
            img = Image.FromFile(filename);
            this.position.X = x;
            this.position.Y = y;
            img = Image.FromFile(filename);
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, position);
        }
    }
}
