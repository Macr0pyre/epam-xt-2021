using Task_4_1.Logic;

namespace Task_4_1
{
    public static class DependencyResolver
    {
        private static IBackup _backupLogic;
        public static IBackup BackupLogic
            => _backupLogic is null ? _backupLogic = new Backup() : _backupLogic;


        private static IObservation _directoryWatcher;
        public static IObservation DirectoryWatcher
            => _directoryWatcher is null ? _directoryWatcher = new Observation() : _directoryWatcher;
    }
}
