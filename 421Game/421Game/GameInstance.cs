using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            private set { _tokens = value; }
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
            GamePlayers.CurrentPlayer.DiceRoll = Convert.ToInt32(new string(arrayTmp));

            GamePlayers.CurrentPlayer.PlaysLeft--;
        }

        public void CurrentPlayerTakes()
        {
            if (GamePlayers.GamePlayers[0].DiceRoll > 0 && GamePlayers.GamePlayers[1].DiceRoll > 0)
            {
                if (GamePlayers.GamePlayers[0].Combi.Priority > GamePlayers.GamePlayers[1].Combi.Priority)
                {
                    GamePlayers.GamePlayers[1].Tokens += GamePlayers.GamePlayers[0].Combi.TokenValue;
                    Tokens -= GamePlayers.GamePlayers[0].Combi.TokenValue;
                }
                else if (GamePlayers.GamePlayers[0].Combi.Priority < GamePlayers.GamePlayers[1].Combi.Priority)
                {
                    GamePlayers.GamePlayers[0].Tokens += GamePlayers.GamePlayers[0].Combi.TokenValue;
                    Tokens -= GamePlayers.GamePlayers[0].Combi.TokenValue;
                }
                else
                {
                    if (GamePlayers.GamePlayers[0].DiceRoll > GamePlayers.GamePlayers[1].DiceRoll)
                    {
                        GamePlayers.GamePlayers[1].Tokens += GamePlayers.GamePlayers[0].Combi.TokenValue;
                        Tokens -= GamePlayers.GamePlayers[0].Combi.TokenValue;
                    }
                    else if (GamePlayers.GamePlayers[0].DiceRoll < GamePlayers.GamePlayers[1].DiceRoll)
                    {
                        GamePlayers.GamePlayers[0].Tokens += GamePlayers.GamePlayers[0].Combi.TokenValue;
                        Tokens -= GamePlayers.GamePlayers[0].Combi.TokenValue;
                    }
                }

                GamePlayers.ResetRolls();
                GamePlayers.CurrentPlayer.PlaysLeft = 1;
                ResetDices();
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
                Thread.Sleep(25);
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

            public void ResetRolls()
            {
                _playersArray[0].ResetRoll();
                _playersArray[1].ResetRoll();
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
            int _diceRoll;
            int _tokens;

            public Player(string username, int id)
            {
                this._username = username;
                this._id = id;
                this._playsLeft = 0;
                this._diceRoll = 000;
                this._tokens = 0;
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

            public int DiceRoll
            {
                get { return _diceRoll; }
                set { _diceRoll = value; }
            }

            public Combination Combi
            {
                get { return Combinations.GetCorrectCombination(this._diceRoll); }
            }

            public int Tokens
            {
                get { return _tokens; }
                set { _tokens = value; }
            }

            public void ResetRoll()
            {
                DiceRoll = 000;
            }
        }

        /// <summary>
        /// Class for a better handling of the players scores.
        /// </summary>
        /*public class Score
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

            public int Priority
            {
                get
                {
                    int priority;
                    if (this.Is421)
                        priority = 6;
                    else if (this.IsMac)
                        priority = 5;
                    else if (this.IsBrelan)
                        priority = 4;
                    else if (this.IsSuite)
                        priority = 3;
                    else if (this.IsNenette)
                        priority = 2;
                    else
                        priority = 1;
                    return priority;
                }
            }

            private bool Is421
            {
                get
                {
                    if (this.Value == 421)
                        return true;
                    else
                        return false;
                }
            }

            private bool IsMac
            {
                get
                {
                    // I do a modulo of 11 on the two last numbers because the possible combinations are : 11, 22, 33, 44, etc..
                    // So ifthe modulo returns 0, it means that there are two numbers that are the same.
                    if (Convert.ToInt32(this.Value.ToString().Substring(1)) % 11 == 0)
                        return true;
                    else
                        return false;
                }
            }

            private bool IsBrelan
            {
                get
                {
                    // I do a modulo of 11 on the two last numbers because the possible combinations are : 11, 22, 33, 44, etc..
                    // So if the modulo returns 0, it means that there are two numbers that are the same.
                    // Then, I check if the first digit is the same as the last one.
                    if (Convert.ToInt32(this.Value.ToString().Substring(1)) % 11 == 0 && this.Value.ToString()[0] == this.Value.ToString()[2])
                        return true;
                    else
                        return false;
                }
            }

            private bool IsSuite
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

            private bool IsNenette
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
        }*/
        
        /// <summary>
        /// Class that returns the correct Combination.
        /// </summary>
        public static class Combinations
        {
            public static Combination GetCorrectCombination(int diceRoll)
            {
                if (Is421(diceRoll))
                    return Get421();
                else if (IsMac(diceRoll))
                    return GetMac(diceRoll);
                else if (IsBrelan(diceRoll))
                    return GetBrelan(diceRoll);
                else if (IsSuite(diceRoll))
                    return GetSuite();
                else if (IsNenette(diceRoll))
                    return GetNennette();
                else
                    return GetOther();
            }

            private static bool Is421(int diceRoll)
            {
                    if (diceRoll == 421)
                        return true;
                    else
                        return false;
            }

            private static bool IsMac(int diceRoll)
            {
                    // I do a modulo of 11 on the two last numbers because the possible combinations are : 11, 22, 33, 44, etc..
                    // So ifthe modulo returns 0, it means that there are two numbers that are the same.
                    if (Convert.ToInt32(diceRoll.ToString().Substring(1)) % 11 == 0)
                        return true;
                    else
                        return false;
            }

            private static bool IsBrelan(int diceRoll)
            {
                    // I do a modulo of 11 on the two last numbers because the possible combinations are : 11, 22, 33, 44, etc..
                    // So if the modulo returns 0, it means that there are two numbers that are the same.
                    // Then, I check if the first digit is the same as the last one.
                    if (Convert.ToInt32(diceRoll.ToString().Substring(1)) % 11 == 0 && diceRoll.ToString()[0] == diceRoll.ToString()[2])
                        return true;
                    else
                        return false;
            }

            private static bool IsSuite(int diceRoll)
            {
                    var digitsList = new List<int>();

                    // Taking each digit individually
                    for (int tmpValue = diceRoll; tmpValue != 0; tmpValue /= 10)
                        digitsList.Add(tmpValue % 10);

                    int[] digitsArray = digitsList.ToArray();
                    Array.Reverse(digitsArray);

                    if (digitsArray[2] + 1 == digitsArray[1] && digitsArray[1] + 1 == digitsArray[0])
                        return true;
                    else
                        return false;
            }

            private static bool IsNenette(int diceRoll)
            {
                    if (diceRoll == 221)
                        return true;
                    else
                        return false;
            }

            private static Combination Get421()
            {
                return new Combination(6, 10, "421");
            }

            private static Combination GetMac(int diceRoll)
            {
                int tokenValue = Convert.ToInt32(diceRoll.ToString()[0].ToString());
                    return new Combination(5, tokenValue, "Mac");
            }

            private static Combination GetBrelan(int diceRoll)
            {
                int tokenValue = Convert.ToInt32(diceRoll.ToString()[0].ToString());
                return new Combination(4, tokenValue, "Brelan");
            }

            private static Combination GetSuite()
            {
                return new Combination(3, 2, "Suite");
            }

            private static Combination GetNennette()
            {
                return new Combination(2, 4, "Nennette");
            }

            private static Combination GetOther()
            {
                return new Combination(1, 1, "Normal combination");
            }
        }

        /// <summary>
        /// Combination class.
        /// </summary>
        public struct Combination
        {
            int _priority;
            int _tokenValue;
            string _name;

            public Combination(int priority, int tokenValue, string name)
            {
                this._name = name;
                this._priority = priority;
                this._tokenValue = tokenValue;
            }

            public int Priority
            {
                get { return _priority; }
            }

            public int TokenValue
            {
                get { return _tokenValue; }
            }

            public string Name
            {
                get { return _name; }
            }
        }
    }
}
