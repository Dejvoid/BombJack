using System.Text.Json.Serialization;

namespace BombJack
{
    public class Wall : GameObject
    {
        private Point position2;
        public Point Position2 { get { return position2; } }
        [JsonConstructor]
        public Wall(Point position, Point position2) : base()
        {
            this.position = position;
            this.position2 = position2;
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
