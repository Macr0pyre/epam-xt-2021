using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_2.Interfaces;

namespace Task_2_2.Entities
{
    public class Player : IMovable
    {
        private Point _location;
        private int _HP;
        private int _additionalSpeed;

        public Player()
        {
            _location = new Point(0, 0);
            _HP = 100;
            _additionalSpeed = 0;
        }

        public Point Location => _location;

        public int HP { get => _HP; }

        public int Speed { get => _additionalSpeed; }

        public void Move(Point newLocation)
        {
            _location = newLocation;
        }
    }
}
