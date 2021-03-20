using System;

namespace Task_2_1_2.CircleFigures
{
    //кольцо
    public class Ring : Figure
    {
        private Circle _outerCircle;
        private Circle _innerCircle;
        private Point _centre;

        public Ring(Point centre, double innerRadius, double outerRadius) : base("Кольцо")
        {
            if (innerRadius < 0 || outerRadius < 0)
                throw new Exception("The radius is negative.");
            if (innerRadius > outerRadius)
                throw new Exception("Inner radius is larger than outer radius.");
            _outerCircle = new Circle(centre, outerRadius);
            _innerCircle = new Circle(centre, innerRadius);
        }

        public override double Perimeter => OuterCircle.Perimeter + InnerCircle.Perimeter;

        public override double Area => Math.PI * OuterCircle.Radius * OuterCircle.Radius - Math.PI * InnerCircle.Radius * InnerCircle.Radius;

        //Может быть здесь лучше определить два поля типа Disk вместо Circle и в свойстве Area посчитать
        //через площадь внешнего минус площадь внутреннего?

        public Circle OuterCircle { get => _outerCircle; }
        public Circle InnerCircle { get => _innerCircle; }
        public Point Centre { get => InnerCircle.Centre;}

        public override string ToString() => $"{Name}: внешний радиус {OuterCircle.Radius}; внутренний радиус {InnerCircle.Radius}; центр: {Centre}";
    }
}
