using System;

namespace Task_3_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            WeakestLinkUI.StartLauncher();
        }
    }

    public static class WeakestLinkUI
    {
        public static void StartLauncher()
        {
            string select;
            do
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Начать новую игру");
                Console.WriteLine("2. Выйти");

                Console.Write("Ввод: ");
                select = Console.ReadLine();

                if (select == "1")
                {
                    StartMenu();
                }
                else if (select != "2")
                {
                    Console.WriteLine("Такого действия нет");
                }

            } while (select != "2");
        }

        private static void StartMenu()
        {
            var gameLogic = new WeakestLink(InputPositiveValue("Введите N (число игроков): "));

            int step = InputPositiveValue("Введите, какой по номеру человек будет вычеркиваться в каждом раунде: ");

            int round = 0;
            while (gameLogic.Count >= step)
            {
                round++;
                int deleted = gameLogic.Step(step);

                Console.WriteLine($"Раунд {round}. Вычеркнут человек ({deleted}). Людей осталось: {gameLogic.Count}");
            }

            Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше людей.");
            Console.Write("Оставшиеся игроки: ");
            foreach (int item in gameLogic.Members)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static int InputPositiveValue(string message)
        {
            int result;
            bool retry;

            do
            {
                Console.Write(message);
                retry = !(int.TryParse(Console.ReadLine(), out result));
            } while (retry || result < 1);

            return result;
        }
    }
}
