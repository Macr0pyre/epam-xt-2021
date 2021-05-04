using System;

namespace Task_4_1.Logic
{
    public class IncorrectPathException : ArgumentException
    {
        public IncorrectPathException(string message) : base(message)
        {

        }
    }
}
