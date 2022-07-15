using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombJack
{
    public class Constants
    {
        public static readonly int SPEED = 10;
        public static readonly int IMGSIZE = 64;
        public static readonly int MONSTERSPEED = 5;
        public static readonly int GAMEWIDTH = 832;
        public static readonly int GAMEHEIGHT = 832;
    }
    // Parent class for all game objects (bombs, walls, player, monsters)
    public abstract class GameObject
    {
        protected Point position; // Top left corner position
        public Point Position { get { return position; } }
        public GameObject()
        {
        }
        public abstract void Draw(Graphics g);
    }
    // Class wrapper for json serialization (used when importing game objects during initialization)
    public class Summary
    {
        public Player Player { get; set; }
        public List<Wall> Walls { get; set; }
        public List<Monster> Monsters { get; set; }
        public List<Bomb> Bombs { get; set; }
        public Summary(Player player, List<Wall> walls, List<Monster> monsters, List<Bomb> bombs)
        {
            Player = player;
            Walls = walls;
            Monsters = monsters;
            Bombs = bombs;
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
