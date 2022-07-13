using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombJack
{
    enum Constants
    {
        speed = 10,
    }
    public abstract class GameObject
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
