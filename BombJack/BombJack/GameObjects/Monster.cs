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

        // Desired movement (could not be possible -> checked in UpdatePosition)
        public override void Move(int x, int y)
        {
            if (!inAir) 
                moveVector.X = x * Constants.MONSTERSPEED * direction;
        }
        
        // Validate and perform move, collision with other object is irrelevant because Monster only interacts with Player (already solved in Player's method)
        public override void UpdatePosition(List<MovableObject> movableObjects,List<Wall> walls, List<Bomb> bombs, int width, int height)
        {
            ApplyGravity();
            var hits = CheckWalls(walls);
            switch (hits.Item2) // Vertical wall collision
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
            switch (hits.Item1) // Horizontal wall collision
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
