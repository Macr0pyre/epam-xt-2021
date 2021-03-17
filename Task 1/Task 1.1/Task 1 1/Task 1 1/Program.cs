using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Список задач и их номера:");
            Console.WriteLine("0. Выйти");
            Console.WriteLine("1. 1.1.1 Rectangle");
            Console.WriteLine("2. 1.1.2 Triangle");
            Console.WriteLine("3. 1.1.3 Another Triangle");
            Console.WriteLine("4. 1.1.4 X-mas tree");
            Console.WriteLine("5. 1.1.5 Sum of numbers");
            Console.WriteLine("6. 1.1.6 Font Adjustment");
            Console.WriteLine("7. 1.1.7 Array processing");
            Console.WriteLine("8. 1.1.8 No positive");
            Console.WriteLine("9. 1.1.9 Non-negative sum");
            Console.WriteLine("10. 1.1.10 2D array");
            Console.WriteLine();

            string selection = string.Empty;
            while (selection != "0")
            {
                Console.WriteLine("Введите номер задачи: ");
                selection = Console.ReadLine();
                switch(selection)
                {
                    case "1":
                        RectangleArea();
                        Console.WriteLine();
                        break;
                    case "2":
                        Triangle();
                        Console.WriteLine();
                        break;
                    case "3":
                        AnotherTriangle();
                        Console.WriteLine();
                        break;
                    case "4":
                        Tree();
                        Console.WriteLine();
                        break;
                    case "5":
                        Sum();
                        Console.WriteLine();
                        break;
                    case "6":
                        Fonts();
                        Console.WriteLine();
                        break;
                    case "7":
                        ArrayProcessing();
                        Console.WriteLine();
                        break;
                    case "8":
                        NoPositive();
                        Console.WriteLine();
                        break;
                    case "9":
                        NonNegativeSum();
                        Console.WriteLine();
                        break;
                    case "10":
                        SumOfEvens();
                        Console.WriteLine();
                        break;
                }
            }
        }

        //Task 1.1.1 Rectangle
        static void RectangleArea()
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            if (a <= 0)
            {
                Console.WriteLine("Неправильный ввод данных!");
                return;
            }

            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            if (b <= 0)
            {
                Console.WriteLine("Неправильный ввод данных!");
                return;
            }

            Console.WriteLine($"Площадь прямоугольника со сторонами {a} и {b} равна {a * b}");
        }

        //Task 1.1.2 Triangle
        static void Triangle()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            for (int line = 1; line <= n; line++)
            {
                for (int column = 1; column <= line; column++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        //Task 1.1.3 Another Triangle
        static void AnotherTriangle()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            int spaceCnt = n - 1;
            int starCnt = 1;

            for (int i = 0; i < n; i++)
            {
                for (int space = spaceCnt; space > 0; space--)
                {
                    Console.Write(" ");
                }
                for (int star = starCnt; star > 0; star--)
                {
                    Console.Write("*");
                }
                spaceCnt--;
                starCnt += 2;
                Console.WriteLine();
            }
        }

        //Task 1.1.4 X-mas tree
        static void Tree()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            for (int tree = 1; tree <= n; tree++)
            {
                int spaceCnt = n - 1;
                int starCnt = 1;

                for (int line = 0; line < tree; line++)
                {
                    for (int space = spaceCnt; space > 0; space--)
                    {
                        Console.Write(" ");
                    }
                    for (int star = starCnt; star > 0; star--)
                    {
                        Console.Write("*");
                    }
                    spaceCnt--;
                    starCnt += 2;
                    Console.WriteLine();
                }
            }
        }

        //Task 1.1.5 Sum of numbers
        static void Sum()
        {
            int sum = 0;
            for (int num = 3; num < 1000; num++)
            {
                if (num % 3 == 0 || num % 5 == 0)
                {
                    sum += num;
                }
            }

            Console.WriteLine($"Сумма всех чисел меньше 1000, кратных 3 или 5: {sum}");
        }

        //Task 1.1.6 Font Adjustment
        static void Fonts()
        {
            Dictionary<string, bool> fonts = new Dictionary<string, bool>
            {
                { "Bold", false },
                { "Italic", false },
                { "Underline", false }
            };

            string selection = "";
            while (selection != "0")
            {
                List<string> selectedFonts = fonts.Where(x => x.Value == true).Select(x => x.Key).ToList();
                Console.Write("Параметры надписи: ");
                if (selectedFonts.Count == 0)
                {
                    Console.Write("None");
                }
                else
                {
                    foreach (string s in selectedFonts)
                    {
                        if(s == selectedFonts.Last())
                            Console.Write(s);
                        else
                            Console.Write(s + ", ");
                    }
                }
                Console.WriteLine();

                Console.WriteLine("Введите:\n" +
                    "\t0: Закончить выбор\n" +
                    "\t1: Bold\n" +
                    "\t2: Italic\n" +
                    "\t3: Underline");
                selection = Console.ReadLine();

                switch(selection)
                {
                    case "1":
                        {
                            fonts["Bold"] = !fonts["Bold"];
                            break;
                        }
                    case "2":
                        {
                            fonts["Italic"] = !fonts["Italic"];
                            break;
                        }
                    case "3":
                        {
                            fonts["Underline"] = !fonts["Underline"];
                            break;
                        }
                }
            }
        }

        //Task 1.1.7 Array processing
        static void ArrayProcessing()
        {
            Random random = new Random();
            int[] arr = new int[100];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-1000, 1001);
            }

            Console.WriteLine("Элементы исходного целочисленного массива со 100 элементами из диапазона [-1000, 1000]:");
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            int min = 1001;
            foreach (int it in arr)
            {
                if (it < min)
                    min = it;
            }
            Console.WriteLine($"Минимальный элемент массива: {min}");

            int max = -1001;
            foreach (int it in arr)
            {
                if (it > max)
                    max = it;
            }
            Console.WriteLine($"Максимальный элемент массива: {max}");

            //обычная сортировка пузырьком
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            Console.WriteLine("Отсортированный массив:");
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        //Task 1.1.8 No positive
        static void NoPositive()
        {
            int[,,] arr = new int[3, 3, 3];
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = rand.Next(-100, 101);
                    }
                }
            }

            Console.WriteLine("Элементы массива:");
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }

            Console.WriteLine("Элементы измененного массива (NO POSITIVE):");
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        //Task 1.1.9 Non-negative sum
        static void NonNegativeSum()
        {
            int[] arr = new int[20];
            Random random = new Random();
            Console.WriteLine("Элементы массива: ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-10, 11);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            int sum = 0;
            foreach (int item in arr)
            {
                if (item >= 0)
                {
                    sum += item;
                }
            }

            Console.WriteLine($"Сумма неотрицательных элементов массива: {sum}");
        }

        //Task 1.1.10 2D array
        static void SumOfEvens()
        {
            int[,] arr = new int[4, 4];
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(-10, 11);
                }
            }

            Console.WriteLine("Элементы массива:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0,4}", arr[i, j]);
                }
                Console.WriteLine();
            }

            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }

            Console.WriteLine($"Сумма элементов массива, стоящих на четных позициях: {sum}");
        }
    }
}
