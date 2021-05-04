using System;
using System.IO;

namespace Task_4_1.Logic
{
    public class Observation : IObservation
    {
        public event Action<object> Saved = delegate { };

        private IBackup _backupLogic;

        private FileSystemWatcher _watcher;

        public void Start(IBackup backupLogic)
        {
            _backupLogic = backupLogic;

            _watcher = new FileSystemWatcher(_backupLogic.Path);

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

        public void Dispose()
        {
            End();
        }
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            _backupLogic.BackupDirectory();
            Saved?.Invoke(this);
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            _backupLogic.BackupDirectory();
            Saved?.Invoke(this);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            _backupLogic.BackupDirectory();
            Saved?.Invoke(this);
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            _backupLogic.BackupDirectory();
            Saved?.Invoke(this);
        }
    }
}
