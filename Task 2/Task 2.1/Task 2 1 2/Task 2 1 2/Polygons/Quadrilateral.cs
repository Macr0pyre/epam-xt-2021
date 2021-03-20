using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2.Polygons
{
    //четырехугольник
    public class Quadrilateral : Figure
    {
        private Line _line1;
        private Line _line2;
        private Line _line3;
        private Line _line4;
        private QuadrilateralType _type;

        private Point[] _points;

        private enum QuadrilateralType
        {
            Square,
            Rectangle,
            Undefined
        }

        public Quadrilateral(Point p1, Point p2, Point p3, Point p4) : base("Четырехугольник")
        {
            _line1 = new Line(p1, p2);
            _line2 = new Line(p2, p3);
            _line3 = new Line(p3, p4);
            _line4 = new Line(p4, p1);

            _points = new Point[] { p1, p2, p3, p4 };

            if (Line.IsPerpendicular(_line1, _line2) && Line.IsPerpendicular(_line3, _line4))
            {
                if (_line1.Perimeter == _line2.Perimeter)
                {
                    _type = QuadrilateralType.Square;
                    Name = "Квадрат";
                }
                else
                {
                    _type = QuadrilateralType.Rectangle;
                    Name = "Прямоугольник";
                }
            }
            else
            {
                _type = QuadrilateralType.Undefined;
            }
        }

        public Line Line1 { get => _line1; }
        public Line Line2 { get => _line2; }
        public Line Line3 { get => _line3; }
        public Line Line4 { get => _line4; }

        public override double Perimeter => _line1.Perimeter + _line2.Perimeter + _line3.Perimeter + _line4.Perimeter;

        public override double Area
        {
            //нахождение площади четырехугольника по формуле площади Гаусса
            get
            {
                return (double)1 / 2 * Math.Abs(_line1.P1.X * _line2.P1.Y + _line2.P1.X * _line3.P1.Y + _line3.P1.X * _line4.P1.Y + _line4.P1.X * _line1.P1.Y -
                    _line2.P1.X * _line1.P1.Y - _line3.P1.X * _line2.P1.Y - _line4.P1.X * _line3.P1.Y - _line1.P1.X * _line4.P1.Y);
            }
        }

        public override string ToString() => $"{Name}: координаты вершин: {Line1.P1}, {Line1.P2}, {Line2.P2}, {Line3.P2}";

    }
}
