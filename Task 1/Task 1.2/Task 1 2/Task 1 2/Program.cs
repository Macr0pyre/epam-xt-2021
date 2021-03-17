using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        static void ShowMenu()
        {
            Console.WriteLine("Список задач и их номера:");
            Console.WriteLine("0. Выйти");
            Console.WriteLine("1. 1.2.1 Averages");
            Console.WriteLine("2. 1.2.2 Doubler");
            Console.WriteLine("3. 1.2.3 Lowercase");
            Console.WriteLine("4. 1.2.4 Validator");
            Console.WriteLine();

            string selection = string.Empty;
            while (selection != "0")
            {
                Console.WriteLine("Введите номер задачи: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Averages();
                        Console.WriteLine();
                        break;
                    case "2":
                        Doubler();
                        Console.WriteLine();
                        break;
                    case "3":
                        Lowercase();
                        Console.WriteLine();
                        break;
                    case "4":
                        Validator();
                        Console.WriteLine();
                        break;
                }
            }
        }

        //Task 1.2.1 Averages
        static void Averages()
        {
            //Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате!

            Console.Write("ВВОД: ");
            string input = Console.ReadLine();
            string[] words = input.Trim().Split(new char[] { ',', '.', ' ', '?', ';', ':', '!'}, StringSplitOptions.RemoveEmptyEntries);

            double aver = 0;
            foreach (string item in words)
            {
                aver += item.Length;
            }
            aver /= words.Length;

            Console.WriteLine($"Средняя длина слова из строки: {aver}");
        }

        //Task 1.2.2 Doubler
        static void Doubler()
        {
            Console.Write("ВВОД 1: ");
            //написать программу, которая
            string input1 = Console.ReadLine();
            Console.Write("ВВОД 2: ");
            //описание
            string input2 = Console.ReadLine();

            StringBuilder outStr = new StringBuilder(); 
            foreach (char item in input1)
            {
                outStr.Append(item);
                if (input2.Contains(item))
                {
                    outStr.Append(item);
                }
            }

            Console.WriteLine($"ВЫВОД: {outStr}");
        }

        //Task 1.2.3 Lowercase
        static void Lowercase()
        {
            //Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны
            Console.Write("ВВОД: ");
            string input = Console.ReadLine();
            string[] words = input.Trim().Split(new char[] { ',', '.', ' ', '?', ';', ':', '!' }, StringSplitOptions.RemoveEmptyEntries);

            int counter = 0;
            foreach (string s in words)
            {
                if (Char.IsLower(s[0]))
                {
                    counter++;
                }
            }

            Console.WriteLine($"Количество слов, начинающихся с маленькой буквы: {counter}");
        }

        //Task 1.2.4 Validator
        static void Validator()
        {
            //я плохо учил русский язык. забываю начинать предложения с заглавной. хорошо, что можно написать программу!
            Console.Write("ВВОД: ");
            StringBuilder input = new StringBuilder(Console.ReadLine());
            string[] sentences = input.ToString().Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in sentences)
            {
                if(Char.IsWhiteSpace(s[0]))
                {
                    input.Replace(s, " " + s[1].ToString().ToUpper() + s.Substring(2));
                }
                else
                {
                    input.Replace(s, s.First().ToString().ToUpper() + s.Substring(1));
                }
            }

            Console.WriteLine($"ВЫВОД: {input}");
        }
    }
}
