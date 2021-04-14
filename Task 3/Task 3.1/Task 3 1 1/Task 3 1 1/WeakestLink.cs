using System;
using System.Collections.Generic;
using System.Linq;
using DynamicArrayLibrary;

namespace Task_3_1_1
{
    //класс с использованием динамического массива из задания 3.2
    public class WeakestLink
    {
        private DynamicArray<int> _players;

        public IEnumerable<int> Members { get => _players; }

        public int Count { get => _players.Length; }

        private int Current { get; set; }

        public WeakestLink(int numberOfPlayers)
        {
            if (numberOfPlayers < 0)
                throw new ArgumentException("The number of players must be positive");
            _players = new DynamicArray<int>(Enumerable.Range(1, numberOfPlayers));
            Current = -1;
        }

        private int IndexHelper(int index) => index % _players.Length;

        public int Step(int stepWidth)
        {
            if (Count < stepWidth)
                throw new ArgumentException("Step width can not be more than number of players");

            if (Count != 0)
            {
                Current = IndexHelper(Current + stepWidth - 1);

                int deleted = _players[IndexHelper(Current + 1)];

                _players.Remove(_players[IndexHelper(Current + 1)]);

                return deleted;
            }
            else
            {
                return -1;
            }
        }
    }
}
