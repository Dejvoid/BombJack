using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombJack
{
    enum Constants
    {
        speed = 5,
    }
    abstract class GameObject
    {
        protected Point position;
        public Point Position { get { return position; } }
        public GameObject()
        {
            position.X = 0;
            position.Y = 0;
        }
        public abstract void Draw(Graphics g);
    }
    abstract class MovableObject : GameObject
    {
        protected Point moveVector;
        protected MovableObject() : base()
        {
        }

        public abstract void Move(int x, int y);
        public virtual void UpdatePosition(List<MovableObject> movable)
        {
            foreach (var item in movable)
            {
                if (item != this && isCollision(item))
                {
                    MessageBox.Show("BRUH");
                }
            }
        }

        private bool isCollision(GameObject item)
        {
            return Math.Pow(item.Position.X - position.X, 2) + Math.Pow(item.Position.Y - position.Y, 2) <= 32;
        }
    }
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
            g.DrawLine(Pens.Black, position, position2);
        }
    }
    class Bomb : GameObject
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
    class Player : MovableObject
    {
        private Image img;
        private int gravity = 10;
        public Player(string filename) : base()
        {
            img = Image.FromFile(filename);
        }

        public override void Move(int x, int y)
        {
            moveVector.X += x * (int)Constants.speed;
            moveVector.Y += y * (int)Constants.speed;
        }
        public void Jump()
        {

        }
        public override void UpdatePosition(List<MovableObject> objects)
        {
            base.UpdatePosition(objects);
            position.X += moveVector.X;
            position.Y += moveVector.Y;
            moveVector.X = 0;
            moveVector.Y = 0;
        }
        public void ApplyGravity()
        {
            moveVector.Y += gravity;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, position);
        }
    }
    class Monster : MovableObject
    {
        private Image img;
        public Monster(string filename) : base()
        {
            img = Image.FromFile(filename);
        }

        public override void Move(int x, int y)
        {
            throw new NotImplementedException();
        }
        public override void UpdatePosition(List<MovableObject> objects)
        {
            throw new NotImplementedException();
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, position);
        }
    }
    enum MonsterType
    {
        Bird,
        Mummy,
        Sphere,
        UFO,
        Orb,
        Horn,
        Club
    }
}
