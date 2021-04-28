using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Task_4_1.Logic
{
    public class Backup
    {
        public string Path { get; }

        public Backup(string path) => Path = path;

        public void BackupDirectory()
        {
            if (!Directory.Exists(Path))
                throw new IncorrectPathException("Указанный путь не существует.");

            DirectoryInfo directory = new DirectoryInfo(Path);
            DirectoryInfo serviceDirectory = new DirectoryInfo($@"{Path}\.fms");

            if (!serviceDirectory.Exists)
            {
                serviceDirectory.Create();
                serviceDirectory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            List<BackupFile> files = new List<BackupFile>();

            foreach (var item in directory.GetFiles("*.txt", SearchOption.AllDirectories))
            {
                files.Add(new BackupFile
                {
                    Name = item.Name,
                    Content = File.ReadAllText(item.FullName),
                    Path = item.DirectoryName
                });
            }

            var backupFilePath = $@"{serviceDirectory.FullName}\{DateTime.Now.ToString().Replace(':', '-')}.json";
            var backupFileContent = JsonConvert.SerializeObject(files);

            File.WriteAllText(backupFilePath, backupFileContent);
        }
    }
}
