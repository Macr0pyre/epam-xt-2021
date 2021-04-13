using System;
using System.Collections.Generic;
using DynamicArrayLibrary;

namespace Task_3_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> test = new DynamicArray<int>() { 0, 1, 2, 3, 4, 5 };
            ShowArray(test);

            test.Insert(0, 9);
            test.Insert(4, 9);
            test.Insert(8, 9);
            ShowArray(test);

            test.Remove(9);
            test.Remove(9);
            ShowArray(test);

            test.Add(1);
            test.AddRange(new List<int>() { 2, 3, 4 });
            ShowArray(test);

            Console.WriteLine($"Array[-1] = {test[-1]}");
            Console.WriteLine($"Array[-2] = {test[-2]}");

            Console.WriteLine();
            test.SetCapacity(7);
            ShowArray(test);
        }

        static void ShowArray<T>(DynamicArray<T> dynamicArray)
        {
            Console.WriteLine($"Length = {dynamicArray.Length}; Capacity = {dynamicArray.Capacity}");

            for (int i = 0; i < dynamicArray.Length; i++)
            {
                Console.WriteLine($"Array[{i}] = {dynamicArray[i]}");
            }
        }
    }
}
