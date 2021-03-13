using CustomStringLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_1
{
    class Program
    {
        //используется CustomStringLibrary (**)
        static void Main(string[] args)
        {
            CustomString str1 = new CustomString(new char[] { 'a', 'b' });
            CustomString str2 = new CustomString(new char[] { 'c', 'd' });
            CustomString str0 = new CustomString();
            CustomString strr = new CustomString("ab");
            CustomString strNew = new CustomString(new char[] { 'a', 'b', 'c', 'b', 'a', '1' });

            Console.WriteLine("Тестирование функциональности класса CustomString\n");

            Console.WriteLine($"Конкатенация через метод: {CustomString.Concate(str1, str2, str0, strr)}");
            Console.WriteLine($"Конкатенация через оператор: {str1 + str2 + str0 + strr}" + Environment.NewLine);

            Console.WriteLine($"Сравнение через CompareTo строк {str1} и {str2}: {str1.CompareTo(str2)}");
            Console.WriteLine($"Сравнение через Equals строк {str1} и {strr}: {str1.Equals(strr)}" + Environment.NewLine);

            Console.WriteLine($"Поиск символа {'b'} в {str1} через IndexOf: {str1.IndexOf('b')} и Contains: {str1.Contains('b')}");
            Console.WriteLine($"Поиск символа {'1'} в {strr} через IndexOf: {strr.IndexOf('1')} и Contains: {strr.Contains('1')}" + Environment.NewLine);

            Console.WriteLine($"Конвертация строки {str1 + str2} в массив символов:");
            char[] converted = (str1 + str2).ToCharArray();
            foreach (var item in converted)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            //Если по заданию надо конвертацию из массива символов в свой тип, то есть просто конструктор для этого
            string convStr = new CustomString(converted).ToString();
            Console.WriteLine($"Конвертация этого массива символов в строку (String): {convStr}\n");

            Console.WriteLine("Дополнительные функции:");
            Console.WriteLine($"Подсчет количества повторений символа {'b'} в строке {strNew}: {strNew.CountCharacters('b')}");
            Console.WriteLine($"Создание новой строки, повторяя строку {strNew} 3 раза: {CustomString.ConcateOneLine(strNew, 3)}\n");

            Console.WriteLine($"Использование индексатора для взятия 1 элемента строки {strNew}: {strNew[1]}");
        }
    }
}
