using System;
using System.IO;

namespace Task_4_1.Logic
{
    public class FIleManagementSystem
    {
        public event Action<object> Saved = delegate { };

        private Backup _backup;

        private Observation _observation;

        private string _path;

        public string Path
        {
            get => _path;
            set
            {
                _path = Directory.Exists(value) ? value : throw new IncorrectPathException("Указанный путь не существует");

                _backup = new Backup(Path);
                _observation = new Observation(_backup);
            }
        }

        public void TrackingModeStart()
        {
            _observation.Saved += Saved;
            _observation.Start();
        }

        public void TrackingModeEnd()
        {
            _observation.Saved -= Saved;
            _observation.End();
        }
    }
}
