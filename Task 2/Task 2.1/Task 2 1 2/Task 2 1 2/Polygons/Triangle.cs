using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2.Polygons
{
    //треугольник
    public class Triangle : Figure
    {
        private Line _line1;
        private Line _line2;
        private Line _line3;

        public Triangle(Point p1, Point p2, Point p3) : base("Треугольник")
        {
            _line1 = new Line(p1, p2);
            _line2 = new Line(p2, p3);
            _line3 = new Line(p1, p3);
        }

        public Line Line1 { get => _line1; }
        public Line Line2 { get => _line2; }
        public Line Line3 { get => _line3; }

        public override double Perimeter => Line1.Perimeter + Line2.Perimeter + Line3.Perimeter;

        public override double Area
        {
            get
            {
                double  semiperimeter = Perimeter / 2;
                return Math.Sqrt(semiperimeter * (semiperimeter - Line1.Perimeter) * (semiperimeter - Line2.Perimeter) * (semiperimeter - Line3.Perimeter));
            }
        }

        public override string ToString() => $"{Name}: координаты вершин: {Line1.P1}, {Line1.P2}, {Line2.P2}";
    }
}
