using System.Text.Json.Serialization;

namespace BombJack
{
    public class Bomb : GameObject
    {
        private Image img;
        [JsonConstructor]
        public Bomb(Point position) : base()
        {
            img = Image.FromFile("Bomb_Jack_Bomb1.gif");
            this.position = position;
        }
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
