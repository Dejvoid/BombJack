using System.Text.Json.Serialization;

namespace BombJack
{
    public class Monster : MovableObject
    {
        private bool inAir = true; // Used to restrict movement in air
        private int direction = -1;

        [JsonConstructor]
        public Monster(Point position) : base()
        {
            img = Image.FromFile("Resources/Bomb_Jack_Goblin.gif");
            this.position = position;
        }
        public Monster(string filename, int x, int y) : base(filename)
        {
            position.X = x;
            position.Y = y;
        }

        public override void Move(int x, int y)
        {
            if (!inAir) 
                moveVector.X = x * Constants.MONSTERSPEED * direction;
        }

        public override void UpdatePosition(List<MovableObject> movableObjects,List<Wall> walls, List<Bomb> bombs, int width, int height)
        {
            ApplyGravity();
            switch (HitWalls(walls))
            {
                case Hit.UP:
                    moveVector.Y = 5;
                    position.Y += moveVector.Y;
                    position.X += moveVector.X;
                    break;
                case Hit.DOWN:
                    inAir = false;
                    position.X += moveVector.X;
                    break;
                case Hit.SIDE:
                    position.Y += moveVector.Y;
                    break;
                case Hit.NONE:
                    inAir = true;
                    moveVector.X = 0;
                    position.Y += moveVector.Y;
                    position.X += moveVector.X;
                    break;
                case Hit.LBARIER:
                    direction = -direction;
                    position.X += 2;
                    break;
                case Hit.RBARIER:
                    direction = -direction;
                    position.X -= 2;
                    break;
                default:
                    
                    break;
            }
            RecalculatePos();
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, position);
            g.DrawLines(Pens.Black, new Point[] { ULPos, LLPos, LRPos, URPos, ULPos });
        }
    }
}
