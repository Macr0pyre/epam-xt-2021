using System;
using System.Collections.Generic;
using System.Text;
using Task_4_1.Logic;

namespace Task_4_1.UI
{
    public class ConsoleUI
    {
        private FIleManagementSystem _logic;

        public ConsoleUI() => _logic = new FIleManagementSystem();

        public void StartMenu()
        {
            Console.Clear();

            string path;

            while (!ConsoleUISupporting.TryInputDirectory("Введите путь до отслеживаемой директории: ", out path))
            {
                Console.WriteLine("Указанной директории не существует");
            }

            _logic.Path = path;

            MainMenu();
        }

        private void MainMenu()
        {
            Console.Clear();

            Console.WriteLine(_logic.Path);
            Console.WriteLine();

            string select = string.Empty;
            do
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("0. Выйти");
                Console.WriteLine("1. Перейти в режим наблюдения");
                Console.WriteLine("2. Откат изменений");
                Console.Write("Ввод: ");

                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        TrackingMode();
                        break;
                    case "2":
                        BackChanges();
                        break;
                    default:
                        break;
                }

            } while (select != "0");
        }

        private void BackChanges()
        {
            //TODO
        }

        private void TrackingMode()
        {
            _logic.Saved += OnSaved;
            _logic.TrackingModeStart();

            Console.WriteLine($"Режим наблюдения включен ({_logic.Path})");
            Console.WriteLine("Нажмите на любую клавишу, чтобы выйти");
            Console.ReadKey();
            Console.WriteLine();

            _logic.TrackingModeEnd();
        }

        private void OnSaved(object sender)
        {
            Console.WriteLine($"{DateTime.Now.ToString()} Изменения зафиксированы");
        }
    }
}
