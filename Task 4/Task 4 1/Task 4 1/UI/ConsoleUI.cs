using System;
using System.Collections.Generic;
using System.Text;
using Task_4_1.Logic;

namespace Task_4_1.UI
{
    public class ConsoleUI
    {
        private IBackup _backupLogic;
        private IObservation _observation;

        public ConsoleUI()
        {
            _backupLogic = DependencyResolver.BackupLogic;
            _observation = DependencyResolver.DirectoryWatcher;
        }

        public void StartMenu()
        {
            Console.Clear();

            string path;

            while (!ConsoleUISupporting.TryInputDirectory("Введите путь до отслеживаемой директории: ", out path))
            {
                Console.WriteLine("Указанной директории не существует");
            }

            _backupLogic.Path = path;

            MainMenu();
        }

        private void MainMenu()
        {
            Console.Clear();

            Console.WriteLine(_backupLogic.Path);
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

            } while (select is not "0");
        }

        private void BackChanges()
        {
            var commitList = new List<DateTime>(_backupLogic.GetCommitList());


            Console.WriteLine($"Список фиксаций({_backupLogic.Path}):");
            for (int i = 0; i < commitList.Count; i++)
            {
                Console.WriteLine($"\t{i}. {commitList[i].ToString()}");
            }

            int select = ConsoleUISupporting.InputValueInRange("Ваш выбор: ", 0, commitList.Count);


            _backupLogic.RollbackFolder(commitList[select]);
        }

        private void TrackingMode()
        {
            _observation.Saved += OnSaved;
            _observation.Start(_backupLogic);

            using (_observation)
            {
                Console.WriteLine($"Режим наблюдения включен ({_backupLogic.Path})");
                Console.WriteLine();
                Console.WriteLine("Нажмите на любую клавишу чтобы выйти");
                Console.ReadKey();
                Console.WriteLine();
            }
        }

        private void OnSaved(object sender)
        {
            Console.WriteLine($"{DateTime.Now.ToString()} Изменения зафиксированы");
        }
    }
}
