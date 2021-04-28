using System;
using System.IO;

namespace Task_4_1.Logic
{
    public class Observation
    {
        public event Action<object> Saved = delegate { };

        private Backup _backup;

        private FileSystemWatcher _watcher;

        public Observation(Backup backup) => _backup = backup;

        public void Start()
        {
            _watcher = new FileSystemWatcher(_backup.Path);

            _watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            _watcher.Changed += OnChanged;
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
            _watcher.Renamed += OnRenamed;

            _watcher.Filter = "*.txt";

            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }

        public void End()
        {
            _watcher.Dispose();
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            _backup.BackupDirectory();
            Saved?.Invoke(this);
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            _backup.BackupDirectory();
            Saved?.Invoke(this);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            _backup.BackupDirectory();
            Saved?.Invoke(this);
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            _backup.BackupDirectory();
            Saved?.Invoke(this);
        }
    }
}
