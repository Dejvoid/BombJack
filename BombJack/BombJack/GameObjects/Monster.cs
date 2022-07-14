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
            switch (CheckHorizontalWalls(walls))
            {
                case Hit.UP:
                    moveVector.Y = 5;
                    break;
                case Hit.DOWN:
                    moveVector.Y = 0;
                    inAir = false;
                    break;
                case Hit.NONE:
                    inAir = true;
                    moveVector.X = 0;
                    break;

            }
            switch (CheckVerticalWalls(walls))
            {
                case Hit.LEFT:
                    direction = -direction;
                    break;
                case Hit.RIGHT:
                    direction = -direction;
                    break;
                case Hit.NONE:
                    break;
            }
            position.X += moveVector.X;
            position.Y += moveVector.Y;
            RecalculatePos();
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, position);
            g.DrawLines(Pens.Black, new Point[] { ULPos, LLPos, LRPos, URPos, ULPos });
        }
    }
}
