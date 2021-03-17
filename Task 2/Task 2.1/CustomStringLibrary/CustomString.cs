using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStringLibrary
{
    public class CustomString : IComparable<CustomString>
    {
        private readonly char[] _line;

        public CustomString()
        {
            _line = new char[] { };
        }

        public CustomString(char[] input)
        {
            _line = new char[input.Length];
            input.CopyTo(_line, 0);
        }

        public CustomString(string str)
        {
            _line = str.ToCharArray();
        }

        public char[] Line
        {
            get { return _line; }
        }

        public static CustomString operator +(CustomString str1, CustomString str2)
        {
            char[] concated = new char[str1.Line.Length + str2.Line.Length];

            str1.Line.CopyTo(concated, 0);
            str2.Line.CopyTo(concated, str1.Line.Length);

            return new CustomString(concated);
        }

        public static CustomString Concate(params CustomString[] list)
        {
            CustomString concated = new CustomString();
            foreach (var item in list)
            {
                concated += item;
            }

            return concated;
        }

        public int CompareTo(CustomString other)
        {
            if (other.Line.Length == 0 && Line.Length == 0)
            {
                return 0;
            }
            else if (other.Line.Length == 0)
            {
                return 1;
            }
            else if (Line.Length == 0)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < Math.Min(Line.Length, other.Line.Length); i++)
                {
                    if (Line[i] > other.Line[i])
                    {
                        return 1;
                    }
                    else if (Line[i] < other.Line[i])
                    {
                        return -1;
                    }
                }
                return 0;
            }
        }

        public bool Equals(CustomString other)
        {
            return CompareTo(other) == 0;
        }

        public int IndexOf(char symb)
        {
            for (int i = 0; i < Line.Length; i++)
            {
                if (Line[i] == symb)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Contains(char symb)
        {
            return IndexOf(symb) != -1;
        }

        public char[] ToCharArray()
        {
            char[] outAr = new char[Line.Length];
            Line.CopyTo(outAr, 0);
            return outAr;
        }

        public override string ToString()
        {
            return new string(Line);
        }

        /// <summary>
        /// An additional method that counts repeats of character in the line.
        /// </summary>
        public int CountCharacters(char symb)
        {
            int cnt = 0;
            foreach (char item in Line)
            {
                if (item == symb)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        /// <summary>
        /// An additional method that creates a new line by repeating the known line from parameters a specified number of times.
        /// </summary>
        public static CustomString ConcateOneLine(CustomString value, int count)
        {
            CustomString forOut = new CustomString();
            for (int i = 0; i < count; i++)
            {
                forOut += value;
            }
            return forOut;
        }

        // *индексатор
        //Нет сеттера, так как строка неизменяемая.
        public char this[int index]
        {
            get
            {
                return Line[index];
            }
        }
    }
}
