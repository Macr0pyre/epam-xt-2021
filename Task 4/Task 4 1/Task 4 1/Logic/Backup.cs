using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Task_4_1.Logic
{
    public class Backup : IBackup
    {
        private DirectoryInfo _directory;
        private DirectoryInfo _serviceDirectory;

        public string Path
        {

            get => _directory?.FullName;

            set
            {
                if (!Directory.Exists(value))
                    throw new IncorrectPathException("Указанный путь не существует");

                _directory = new DirectoryInfo(value);
                _serviceDirectory = new DirectoryInfo($@"{value}\.fms");

                if (!_serviceDirectory.Exists)
                {
                    _serviceDirectory.Create();
                    _serviceDirectory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

                    BackupDirectory();
                }
            }
        }

        public void BackupDirectory()
        {
            Path ??= Directory.GetCurrentDirectory();

            var files = new List<BackupFile>();

            foreach (var item in _directory.GetFiles("*.txt", SearchOption.AllDirectories))
            {
                files.Add(new BackupFile
                {
                    Name = item.Name,
                    Content = File.ReadAllText(item.FullName),
                    Path = item.DirectoryName
                });
            }

            var backupFilePath = $@"{_serviceDirectory.FullName}\{DateTime.Now.ToString().Replace(':', '-')}.json";
            var backupFileContent = JsonConvert.SerializeObject(files);

            File.WriteAllText(backupFilePath, backupFileContent);
        }

        public void RollbackFolder(DateTime dateTime)
        {
            Path ??= Directory.GetCurrentDirectory();

            var dataPath = $@"{_serviceDirectory.FullName}\{dateTime.ToString().Replace(':', '-')}.json";

            if (!File.Exists(dataPath))
                throw new MissingBackupException("Фиксации с заданным временем не найдено");

            var backupFiles
                = JsonConvert.DeserializeObject<IEnumerable<BackupFile>>(File.ReadAllText(dataPath));

            //_directory.Clean(".fms");
            _directory.RemoveFiles("#.txt");

            foreach (var item in backupFiles)
            {
                if (!Directory.Exists(item.Path))
                    Directory.CreateDirectory(item.Path);

                File.WriteAllText($@"{item.Path}\{item.Name}", item.Content);
            }
        }

        public IEnumerable<DateTime> GetCommitList()
            => _serviceDirectory?.GetFiles()
                                .Select(item => FileNameToDateTime(item.Name));

        private DateTime FileNameToDateTime(string fileName)
        {
            fileName = fileName.Substring(0, 19); // cut the date from the file name
            DateTime result = DateTime.ParseExact(fileName, "dd.MM.yyyy HH-mm-ss", CultureInfo.InvariantCulture);

            return result;
        }


    }
}
