using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_2.Entities;
using Task_2_2.Entities.Bonuses;
using Task_2_2.Entities.Obstacles;
using Task_2_2.Interfaces;

namespace Task_2_2
{
    class GameLogic
    {
        private Map _map;
        private Player _player;
        public void StartGame()
        {
            _player = new Player();

            Console.WriteLine("Выберите сложность игры:");
            Console.WriteLine("1. Легкий");
            Console.WriteLine("2. Средний");
            Console.WriteLine("3. Сложный");
            Console.WriteLine("0. Выйти");
            Console.WriteLine();

            Console.Write("Ввод: ");
            string selection = Console.ReadLine();
            while (selection != "0")
            {
                switch (selection)
                {
                    case "1":
                        
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        
                        break;
                }
            }
        }

        private void CreateEasyMap()
        {
            Star star = new Star(new Point(3, 3));
            Flower flower = new Flower(new Point(1, 3));
            Moondust dust = new Moondust(new Point(3, 1));
            List<IBonus> bonuses = new List<IBonus>();
            bonuses.Add(star);
            bonuses.Add(flower);
            bonuses.Add(dust);

            List<IEnemy> enemies = new List<IEnemy>();

            List<IObstacle> obstacles = new List<IObstacle>();
            obstacles.Add(new Tree(new Point(2, 2)));

            _map = new Map(3, 3, bonuses, enemies, obstacles);
        }

    }
}
