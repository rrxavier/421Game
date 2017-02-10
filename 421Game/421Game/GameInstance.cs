using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _421Game
{
    class GameInstance
    {
        private Dice _dice1;
        private Dice _dice2;
        private Dice _dice3;
        private Players _players;

        public GameInstance(string player1, string player2)
        {
            this._players = new Players(new Player[2] { new Player(player1, 1), new Player(player2, 0) });
            this._dice1 = new Dice();
            this._dice2 = new Dice();
            this._dice3 = new Dice();
        }

        public Dice Dice1
        {
            get
            { return _dice1; }
        }

        public Dice Dice2
        {
            get
            { return _dice2; }
        }

        public Dice Dice3
        {
            get
            { return _dice3; }
        }

        public Players GamePlayers
        {
            get
            { return _players; }
        }

        /// <summary>
        /// Roll the dices and return their values.
        /// </summary>
        /// <param name="dice1">First dice. If true, the dice value will be processed again.</param>
        /// <param name="dice2">Second dice. If true, the dice value will be processed again.</param>
        /// <param name="dice3">Third dice. If true, the dice value will be processed again.</param>
        public void RollDices(bool dice1, bool dice2, bool dice3)
        {
            if (dice1)
                Dice1.Roll();
            if (dice2)
                Dice2.Roll();
            if (dice3)
                Dice3.Roll();

            // À FINIR (Tri)
            // GamePlayers.CurrentPlayer.PlayerValue = Convert.ToInt32(new string((Dice1.ToString() + Dice2.ToString() + Dice3.ToString()).ToArray()));
        }

        /// <summary>
        /// If the players didn't chose a name.
        /// </summary>
        public GameInstance() : this("Player1", "Player2") { }

        public class Dice
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
                Thread.Sleep(10);
            }

            public override string ToString()
            {
                return LastRoll.ToString();
            }
        }

        /// <summary>
        /// Class for a better handling of all players. Uses the Player struct. 
        /// </summary>
        public struct Players
        {
            Player[] _playersArray;
            Player _currentPlayer;

            public Players(Player[] playersArray)
            {
                this._playersArray = playersArray;
                this._currentPlayer = _playersArray[new Random().Next(0, 2)];
            }

            public Player[] GamePlayers
            {
                get { return _playersArray; }
            }

            public Player CurrentPlayer
            {
                get { return _currentPlayer; }
            }
        }

        /// <summary>
        /// Stuct for a better handling of one player.
        /// </summary>
        public class Player
        {
            string _username;
            int _id;
            int _playsLeft;
            int _playerValue;

            public Player(string username, int id)
            {
                this._username = username;
                this._id = id;
                this._playsLeft = 0;
                this._playerValue = 000;
            }

            public string Username
            {
                get { return _username; }
            }

            public int Id
            {
                get { return _id; }
            }

            public int PlaysLeft
            {
                get { return _playsLeft; }
            }

            public int PlayerValue
            {
                get { return _playerValue; }
                set { _playerValue = value; }
            }
        }
    }
}
