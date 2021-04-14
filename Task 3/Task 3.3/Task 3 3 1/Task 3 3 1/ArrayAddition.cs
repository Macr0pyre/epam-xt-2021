using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_1
{
    public static class ArrayAddition
    {
        //Расширьте массивы чисел методом, производящим действия с каждым конкретным элементом.
        //Действие должно передаваться в метод с помощью делегата.
        #region PROCESS
        public static void Process(this int[] array, Func<int, int> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);

            }
        }

        public static void Process(this uint[] array, Func<uint, uint> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);
            }
        }

        public static void Process(this long[] array, Func<long, long> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);
            }
        }

        public static void Process(this ulong[] array, Func<ulong, ulong> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);
            }
        }

        public static void Process(this float[] array, Func<float, float> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);
            }
        }

        public static void Process(this double[] array, Func<double, double> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);
            }
        }

        public static void Process(this byte[] array, Func<byte, byte> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);
            }
        }

        public static void Process(this sbyte[] array, Func<sbyte, sbyte> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);
            }
        }

        public static void Process(this short[] array, Func<short, short> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);
            }
        }

        public static void Process(this ushort[] array, Func<ushort, ushort> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);
            }
        }

        public static void Process(this decimal[] array, Func<decimal, decimal> process)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = process(array[i]);
            }
        }
        #endregion

        //Кроме указанного функционала выше, добавьте методы расширения для поиска:
        //- суммы всех элементов;
        #region SUM
        public static int MySum(this int[] array) => array.Sum();

        public static uint MySum(this uint[] array)
        {
            uint sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static long MySum(this long[] array) => array.Sum();

        public static ulong MySum(this ulong[] array)
        {
            ulong sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static float MySum(this float[] array) => array.Sum();

        public static double MySum(this double[] array) => array.Sum();

        public static byte MySum(this byte[] array)
        {
            byte sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static sbyte MySum(this sbyte[] array)
        {
            sbyte sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static short MySum(this short[] array)
        {
            short sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static ushort MySum(this ushort[] array)
        {
            ushort sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        public static decimal MySum(this decimal[] array) => array.Sum();

        #endregion

        //- среднего значения в массиве;
        #region AVERAGE
        public static double MyAverage(this int[] array) => array.Average();

        public static double MyAverage(this uint[] array) => (double)array.MySum() / array.Length;

        public static double MyAverage(this long[] array) => array.Average();

        public static double MyAverage(this ulong[] array) => (double)array.MySum() / array.Length;

        public static float MyAverage(this float[] array) => array.Average();

        public static double MyAverage(this double[] array) => array.Average();

        public static double MyAverage(this byte[] array) => (double)array.MySum() / array.Length;

        public static double MyAverage(this sbyte[] array) => (double)array.MySum() / array.Length;

        public static double MyAverage(this short[] array) => (double)array.MySum() / array.Length;

        public static double MyAverage(this ushort[] array) => (double)array.MySum() / array.Length;

        public static decimal MyAverage(this decimal[] array) => array.Average();

        #endregion

        //- самого часто повторяемого элемента;
        #region MOST FREQUENTLY REPEATED
        public static int MostRepetitive(this int[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static uint MostRepetitive(this uint[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static long MostRepetitive(this long[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static ulong MostRepetitive(this ulong[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static float MostRepetitive(this float[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static double MostRepetitive(this double[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static byte MostRepetitive(this byte[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static sbyte MostRepetitive(this sbyte[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static short MostRepetitive(this short[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static ushort MostRepetitive(this ushort[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;

        public static decimal MostRepetitive(this decimal[] array)
            => array
                    .GroupBy(item => item)
                    .OrderByDescending(item => item.Count())
                    .First()
                    .Key;
        #endregion
    }
}
