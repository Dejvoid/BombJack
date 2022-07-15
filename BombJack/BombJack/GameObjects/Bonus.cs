using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombJack
{
    public class Bonus : MovableObject
    {
        public Bonus() : base()
        {
            moveVector.X = 5;
            moveVector.Y = 5;
            img = Image.FromFile("Resources/Bomb_Jack_Bonus.gif");
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, position);
        }

        public override void Move(int x, int y)
        {
        }
        public override void UpdatePosition(List<MovableObject> movableObjects, List<Wall> walls, List<Bomb> bombs, int width, int height)
        {
            var hits = CheckWalls(walls);
            switch (hits.Item2)
            {
                case Hit.UP:
                    moveVector.Y = -moveVector.Y;
                    break;
                case Hit.DOWN:
                    moveVector.Y = -moveVector.Y;
                    break;
                case Hit.NONE:
                    break;
            }
            switch (hits.Item1)
            {
                case Hit.LEFT:
                    moveVector.X = -moveVector.X;
                    break;
                case Hit.RIGHT:
                    moveVector.X = -moveVector.X;
                    break;
                case Hit.NONE:
                    break;
            }
            position.X += moveVector.X;
            position.Y += moveVector.Y;
            RecalculatePos();
        }
    }
}
