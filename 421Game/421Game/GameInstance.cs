using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _421Game
{
    class GameInstance
    {
        private Dice _dice1;
        private Dice _dice2;
        private Dice _dice3;
        string[] _players;

        public GameInstance(string player1, string player2)
        {
            _players = new string[] { player1, player2 };
        }

        /// <summary>
        /// If the players didn't chose a name.
        /// </summary>
        public GameInstance() : this("Player1", "Player2") { }

        private class Dice
        {
            private int _lastRoll;

            public Dice()
            {
                _lastRoll = -1;
            }

            /// <summary>
            /// The value of the last roll. If this contains -1, it means that the Dice hasn't been rolled yet.
            /// </summary>
            public int LastRoll
            {
                get { return _lastRoll; }
            }

            /// <summary>
            /// Roll a number between 1 and 6.
            /// </summary>
            public void Roll()
            {
                // 7 Because the last value's exclusive.
                _lastRoll = new Random().Next(1, 7);
            }
        }
    }
}
