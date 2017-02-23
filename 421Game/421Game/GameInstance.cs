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
        private int _tokens;

        public GameInstance(string player1, string player2)
        {
            // I reversed their IDs so it's easier for me to finish a turn.
            this._players = new Players(new Player[2] { new Player(player1, 1), new Player(player2, 0) });
            this._dice1 = new Dice();
            this._dice2 = new Dice();
            this._dice3 = new Dice();
            this._tokens = 20;
        }

        /// <summary>
        /// If the players didn't chose a name.
        /// </summary>
        public GameInstance() : this("Player1", "Player2") { }

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
            set { _players = value; }
        }

        public int Tokens
        {
            get { return _tokens; }
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

            // Sorts the score so it's shown from the bigger number to the lowest.
            char[] arrayTmp = (Dice1.ToString() + Dice2.ToString() + Dice3.ToString()).ToArray();
            Array.Sort(arrayTmp);
            Array.Reverse(arrayTmp);
            GamePlayers.CurrentPlayer.PlayerScore = Convert.ToInt32(new string(arrayTmp));

            GamePlayers.CurrentPlayer.PlaysLeft--;
        }

        public void CurrentPlayerTakes()
        {
            if (GamePlayers.GamePlayers[0].PlayerScore > 0 && GamePlayers.GamePlayers[1].PlayerScore > 0)
            {
                // À REMETTRE EN PLACE
                if (GamePlayers.GamePlayers[0].PlayerScore.Is421)
                    System.Windows.Forms.MessageBox.Show("421 !!!");
                else if (GamePlayers.GamePlayers[0].PlayerScore.IsMac)
                    System.Windows.Forms.MessageBox.Show("Mac !!!");
                else if (GamePlayers.GamePlayers[0].PlayerScore.IsSuite)
                    System.Windows.Forms.MessageBox.Show("Suite !!!");
                else if (GamePlayers.GamePlayers[0].PlayerScore.IsNenette)
                    System.Windows.Forms.MessageBox.Show("Nénette !!!");
                else
                    System.Windows.Forms.MessageBox.Show("Loul !!!");
            }
            else
            {
                GamePlayers.NextPlayer();
                GamePlayers.CurrentPlayer.PlaysLeft = 1;
                ResetDices();
            }
        }

        private void ResetDices()
        {
            Dice1.Reset();
            Dice2.Reset();
            Dice3.Reset();
        }

        public class Dice
        {
            private int _lastRoll;

            public Dice()
            {
                _lastRoll = -1;
            }

            /// <summary>
            /// The value of the last roll. If this contains 0, it means that the Dice hasn't been rolled yet.
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

            public void Reset()
            {
                this._lastRoll = 0;
            }

            public override string ToString()
            {
                return LastRoll.ToString();
            }
        }

        /// <summary>
        /// Class for a better handling of all players. Uses the Player class.
        /// </summary>
        public class Players
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
                set { _currentPlayer = value; }
            }

            public void NextPlayer()
            {
                this._currentPlayer = GamePlayers[this.CurrentPlayer.Id];
            }
        }

        /// <summary>
        /// Class for a better handling of one player.
        /// </summary>
        public class Player
        {
            string _username;
            int _id;
            int _playsLeft;
            Score _playerScore;
            int _points;

            public Player(string username, int id)
            {
                this._username = username;
                this._id = id;
                this._playsLeft = 0;
                this._playerScore = 000;
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
                set { _playsLeft = value; }
            }

            public Score PlayerScore
            {
                get { return _playerScore; }
                set { _playerScore = value; }
            }

            public int Points
            {
                get { return _points; }
                set { _points = value; }
            }
        }

        /// <summary>
        /// Class for a better handling of the players scores.
        /// </summary>
        public class Score
        {
            private int _value;

            public Score(int value)
            {
                this._value = value;
            }

            private Score() : this(000) { }

            public int Value
            {
                get { return _value; }
            }

            public bool Is421
            {
                get
                {
                    if (this.Value == 421)
                        return true;
                    else
                        return false;
                }
            }

            public bool IsMac
            {
                get
                {
                    //GamePlayers.GamePlayers[0].Points = Convert.ToInt32(GamePlayers.GamePlayers[0].PlayerScore.ToString().Substring(0, 1));

                    // I do a modulo of 11 on the two last numbers because the possible combinations are : 11, 22, 33, 44, etc..
                    // So ifthe modulo returns 0, it means that there are two numbers that are the same.
                    if (Convert.ToInt32(this.Value.ToString().Substring(1)) % 11 == 0)
                        return true;
                    else
                        return false;
                }
            }

            public bool IsSuite
            {
                get
                {
                    var digitsList = new List<int>();

                    // Taking each digit individually
                    for (int tmpValue = this.Value; tmpValue != 0; tmpValue /= 10)
                        digitsList.Add(tmpValue % 10);

                    int[] digitsArray = digitsList.ToArray();
                    Array.Reverse(digitsArray);

                    if (digitsArray[2] + 1 == digitsArray[1] && digitsArray[1] + 1 == digitsArray[0])
                        return true;
                    else
                        return false;
                }
            }

            public bool IsNenette
            {
                get
                {
                    if (this.Value == 221)
                        return true;
                    else
                        return false;
                }
            }

            // For Score = Int
            public static implicit operator Score(int val)
            {
                return new Score(val);
            }

            // For Int = Score
            public static implicit operator int(Score score)
            {
                return score.Value;
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }
    }
}
