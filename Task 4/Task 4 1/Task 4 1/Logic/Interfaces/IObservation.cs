using System;

namespace Task_4_1.Logic
{
    public interface IObservation : IDisposable
    {
        event Action<object> Saved;

        void Start(IBackup backupLogic);

        void End();
    }
}
