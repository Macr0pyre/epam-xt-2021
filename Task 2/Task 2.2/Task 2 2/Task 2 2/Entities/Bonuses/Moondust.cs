using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_2.Interfaces;

namespace Task_2_2.Entities.Bonuses
{
    public class Moondust : IBonus
    {
        private Point _location;

        public Moondust(Point location)
        {
            _location = location;
        }

        public Point Location => _location;

        public int GiveHP() => 0;

        public int GiveSpeed() => 1;
    }
}
