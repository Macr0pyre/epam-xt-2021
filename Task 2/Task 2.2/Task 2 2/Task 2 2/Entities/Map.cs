using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_2.Interfaces;

namespace Task_2_2.Entities
{
    public class Map
    {
        private int _width;
        private int _height;
        private List<IBonus> _bonuses;
        private List<IEnemy> _enemies;
        private List<IObstacle> _obstacles;

        public Map(int width, int height, List<IBonus> bonuses, List<IEnemy> enemies, List<IObstacle> obstacles)
        {
            _width = width;
            _height = height;
            _bonuses = bonuses;
            _enemies = enemies;
            _obstacles = obstacles;
        }

        public int Width { get => _width; }
        public int Height { get => _height; }
        public List<IBonus> Bonuses { get => _bonuses; }
        public List<IEnemy> Enemies { get => _enemies; }
        public List<IObstacle> Obstacles { get => _obstacles; }
    }
}
