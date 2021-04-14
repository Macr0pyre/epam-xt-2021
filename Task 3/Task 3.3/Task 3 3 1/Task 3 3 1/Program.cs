using System;

namespace Task_3_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 4 };
            a.Process(v => v * 2);
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(a.MySum());
            Console.WriteLine(a.MyAverage());
            Console.WriteLine(a.MostRepetitive());
        }
    }
}
