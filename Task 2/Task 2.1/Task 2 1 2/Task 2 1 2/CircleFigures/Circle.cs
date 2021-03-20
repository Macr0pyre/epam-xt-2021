using System;

namespace Task_2_1_2.CircleFigures
{
    //окружность
    public class Circle : Figure
    {
        private Point _centre;
        private double _radius;

        public Circle(Point centre, double radius) : base("Окружность")
        {
            if (radius < 0)
                throw new Exception("The radius is negative.");
            _centre = centre;
            _radius = radius;
        }
        
        public override double Perimeter => 2 * Math.PI * Radius;

        public override double Area => 0;

        public Point Centre { get => _centre; }
        public double Radius { get => _radius; }

        public override string ToString() => $"{Name}: радиус {Radius}; центр: {Centre}";


    }
}
