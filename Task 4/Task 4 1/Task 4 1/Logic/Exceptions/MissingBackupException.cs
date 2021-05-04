using System;

namespace Task_4_1.Logic
{
    class MissingBackupException : ArgumentException
    {
        public MissingBackupException(string message) : base(message)
        {

        }
    }
}
