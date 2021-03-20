using System;

namespace Task_2_1_2.CircleFigures
{
    //круг
    public class Disk : Circle
    {
        public Disk(Point centre, double radius) : base(centre, radius) => Name = "Круг";

        public override double Area => Math.PI * Radius * Radius;
    }
}
