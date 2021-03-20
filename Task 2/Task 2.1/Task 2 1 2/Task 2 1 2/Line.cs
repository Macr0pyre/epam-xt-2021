using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    public class Line : Figure
    {
        private Point _p1;
        private Point _p2;

        public Line(Point p1, Point p2) : base("Линия")
        {
            _p1 = p1;
            _p2 = p2;
        }

        public Point P1 { get => _p1;}
        public Point P2 { get => _p2; }

        public override double Perimeter => Math.Sqrt((P2.X - P1.X) * (P2.X - P1.X) + (P2.Y - P1.Y) * (P2.Y - P1.Y));

        public override double Area => 0;

        public override string ToString() => $"{Name}: координаты двух ее точек: ({P1.X}; {P1.Y}), ({P2.X}; {P2.Y})";

        public static bool IsPerpendicular(Line line1, Line line2) => (line1.P2.X - line1.P1.X) * (line2.P2.X - line2.P1.X) + (line1.P2.Y - line1.P1.Y) * (line2.P2.Y - line2.P1.Y) == 0;
    }
}
