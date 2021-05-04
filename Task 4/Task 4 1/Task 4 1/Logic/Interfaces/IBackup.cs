using System;
using System.Collections.Generic;

namespace Task_4_1.Logic
{
    public interface IBackup
    {
        string Path { get; set; }

        void BackupDirectory();

        void RollbackFolder(DateTime dateTime);

        IEnumerable<DateTime> GetCommitList();
    }
}
