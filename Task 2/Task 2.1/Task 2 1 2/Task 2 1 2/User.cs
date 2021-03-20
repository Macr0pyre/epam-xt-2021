using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    public class User
    {
        private string _name;
        private List<Figure> _figures;
        public User(string name)
        {
            Name = name;
            Figures = new List<Figure>();
        }

        public string Name { get => _name; private set => _name = value; }
        public List<Figure> Figures { get => _figures; private set => _figures = value; }

        public void AddFigure(Figure figure) => Figures.Add(figure);

        public void DeleteAllFigures() => Figures.Clear();
    }
}
