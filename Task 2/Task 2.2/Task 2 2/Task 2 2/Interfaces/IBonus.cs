﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_2.Interfaces
{
    public interface IBonus : ILocated
    {
        public int GiveHP();
        public int GiveSpeed();
    }
}
