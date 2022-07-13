namespace BombJack
{
    class Wall : GameObject
    {
        private Point position2;
        public Wall(string filename, Point p1, Point p2) : base()
        {
            position = p1;
            position2 = p2;
        }
        public override void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 10.0f);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.DrawLine(p, position, position2);
        }
    }
}
