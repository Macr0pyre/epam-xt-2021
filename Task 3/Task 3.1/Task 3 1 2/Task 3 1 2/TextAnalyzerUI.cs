using System;
using System.Collections.Generic;

namespace Task_3_1_2
{
    public static class TextAnalyzerUI
    {
        private static TextAnalyzerLogic _analyzer;

        static TextAnalyzerUI() => _analyzer = new TextAnalyzerLogic();

        public static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine($"Здравствуй, {Environment.UserName}!" + Environment.NewLine);


            string select;
            do
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1. Проанализировать текст");
                Console.WriteLine("2. Выйти");

                Console.Write("Ввод: ");
                select = Console.ReadLine();

                if (select == "1")
                {
                    AnalyzeMenu();
                }
                else if (select != "2")
                {
                    Console.WriteLine("Такого действия нет");
                }

            } while (select != "2");
        }

        private static void AnalyzeMenu()
        {
            _analyzer.Text = InputText("Введите текст: ");

            PrintWordsFrequency(_analyzer.WordsFrequency());
        }

        private static string InputText(string message)
        {
            string text;
            do
            {
                Console.Write(message);
                text = Console.ReadLine();
            } while (text == string.Empty);

            return text;
        }

        private static void PrintWordsFrequency(Dictionary<string, int> dictionary)
        {
            Console.WriteLine("Список использованных слов:");
            Console.WriteLine("        Слово|  Количество");
            Console.WriteLine(new String('-', 26));
            foreach (var item in dictionary)
            {
                Console.WriteLine("{0, 13}|{1, 7}", item.Key, item.Value);
            }
            Console.WriteLine(new String('-', 26));
        }
    }
}
