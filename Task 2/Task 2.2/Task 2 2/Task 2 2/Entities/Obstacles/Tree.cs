using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_2.Interfaces;

namespace Task_2_2.Entities.Obstacles
{
    public class Tree : IObstacle
    {
        private Point _location;

        public Tree(Point location)
        {
            _location = location;
        }

        public Point Location => _location;
    }
}
