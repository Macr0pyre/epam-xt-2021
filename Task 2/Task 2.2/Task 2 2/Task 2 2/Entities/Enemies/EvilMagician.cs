﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_2.Interfaces;

namespace Task_2_2.Entities.Enemies
{
    public class EvilMagician : IEnemy
    {
        private Point _location;

        public EvilMagician(Point location)
        {
            _location = location;
        }

        public Point Location => _location;

        public int Damage() => 40;

        public void Move(Point newLocation)
        {
            _location = newLocation;
        }
    }
}
