using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_1_2.CircleFigures;
using Task_2_1_2.Polygons;

namespace Task_2_1_2
{
    class PaintUI
    {
        private Dictionary<int, User> _users;
        private int _currentUserID;

        public PaintUI()
        {
            _users = new Dictionary<int, User>();
        }

        public void ShowMenu()
        {
            AddUser();

            string selection;
            do
            {
                Console.WriteLine($"{_users[_currentUserID].Name}, выбери действие:");
                Console.WriteLine("0. Выйти");
                Console.WriteLine("1. Добавить фигуру");
                Console.WriteLine("2. Вывести все фигуры на экран с характеристиками");
                Console.WriteLine("3. Очистить холст (удалить все фигуры)");
                Console.WriteLine("4. Сменить или добавить пользователя");
                Console.WriteLine();

                Console.Write("Ввод: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        AddFigureMenu();
                        Console.WriteLine();
                        break;
                    case "2":
                        ShowFigures();
                        Console.WriteLine();
                        break;
                    case "3":
                        DeleteALLFigures();
                        Console.WriteLine();
                        break;
                    case "4":
                        SwitchOrAddUser();
                        Console.WriteLine();
                        break;
                }
            }
            while (selection != "0");
        }

        private void AddUser()
        {
            int newID;
            if (_users.Count == 0)
            {
                newID = 0;
            }
            else
            {
                newID = _users.Keys.Max() + 1;
            }

            Console.Write("Введите имя нового пользователя: ");
            User newUser = new User(Console.ReadLine());

            _users.Add(newID, newUser);
            _currentUserID = newID;
        }

        private void AddFigureMenu()
        {
            Console.WriteLine($"{_users[_currentUserID].Name}, выбери тип желаемой фигуры:");
            Console.WriteLine("0. Вернуться в меню");
            Console.WriteLine("1. Окружность");
            Console.WriteLine("2. Круг");
            Console.WriteLine("3. Кольцо");
            Console.WriteLine("4. Линия");
            Console.WriteLine("5. Треугольник");
            Console.WriteLine("6. Четырехугольник (квадарт, прямоугольник или другой)");
            Console.WriteLine();

            Console.Write("Ввод: ");
            switch (Console.ReadLine())
            {
                case "1":
                    _users[_currentUserID].AddFigure(new Circle(InputPoint("центр окружности"), InputRadius("радиус окружности")));
                    break;
                case "2":
                    _users[_currentUserID].AddFigure(new Disk(InputPoint("центр круга"), InputRadius("радиус круга")));
                    break;
                case "3":
                    _users[_currentUserID].AddFigure(new Ring(InputPoint("центр кольца"), InputRadius("внутренний радиус"), InputRadius("внешний радиус")));
                    break;
                case "4":
                    _users[_currentUserID].AddFigure(new Line(InputPoint("координаты первой точки"), InputPoint("координаты второй точки")));
                    break;
                case "5":
                    _users[_currentUserID].AddFigure(new Triangle(InputPoint("точку А"), InputPoint("точку B"), InputPoint("точку C")));
                    break;
                case "6":
                    _users[_currentUserID].AddFigure(new Quadrilateral(InputPoint("точку А"), InputPoint("точку B"), InputPoint("точку C"), InputPoint("точку D")));
                    break;
            }
        }

        private void ShowFigures()
        {
            if (_users[_currentUserID].Figures.Count == 0)
            {
                Console.WriteLine("Нет фигур!");
            }
            foreach (Figure item in _users[_currentUserID].Figures)
            {
                Console.WriteLine($"{item}. Периметр: {item.Perimeter:F2}. Площадь: {item.Area:F2}.");
            }
        }

        private void DeleteALLFigures() => _users[_currentUserID].DeleteAllFigures();

        private void SwitchOrAddUser()
        {
            Console.WriteLine("Cписок пользователей:");
            foreach (var item in _users)
            {
                Console.WriteLine($"{item.Key}. {item.Value.Name}");
            }
            Console.WriteLine();

            Console.WriteLine($"{_users[_currentUserID].Name}, выбери действие:");
            Console.WriteLine("0. Вернуться в меню");
            Console.WriteLine("1. Сменить пользователя");
            Console.WriteLine("2. Добавить пользователя");
            Console.WriteLine();

            string selection = string.Empty;
            Console.WriteLine("Введи номер действия: ");
            selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    Console.Write("Введите ID пользователя из списка пользователей выше: ");
                    int userID;
                    int.TryParse(Console.ReadLine(), out userID);
                    if (_users.ContainsKey(userID))
                    {
                        _currentUserID = userID;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели не то!");
                    }
                    break;
                case "2":
                    AddUser();
                    break;
            }
        }

        private Point InputPoint(string name)
        {
            Console.WriteLine($"Введите {name}:");

            double x;
            double y;

            Console.Write("Введите х: ");
            double.TryParse(Console.ReadLine(), out x);
            Console.Write("Введите y: ");
            double.TryParse(Console.ReadLine(), out y);

            return new Point(x, y);
        }

        private Double InputRadius(string name)
        {
            Console.Write($"Введите {name}: ");

            double radius;
            double.TryParse(Console.ReadLine(), out radius);

            return radius;
        }

    }
}
