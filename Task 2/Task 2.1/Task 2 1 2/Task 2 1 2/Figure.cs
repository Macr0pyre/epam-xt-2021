using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    public abstract class Figure
    {
        public string Name { get; protected set; }
        public Figure(string name) => Name = name;
        public abstract double Perimeter { get; }
        public abstract double Area { get; }
        public abstract override string ToString();
    }
}
