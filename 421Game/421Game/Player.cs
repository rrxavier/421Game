namespace _421Game
{
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
        int _lastRoll;

        public Player(string username, int id)
        {
            this._username = username;
            this._id = id;
            this._playsLeft = 1;
            this._diceRoll = 000;
            this._lastRoll = 0;
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

        public int LastRoll
        {
            get { return this._lastRoll; }
            set { this._lastRoll = value; }
        }

        public void ResetRoll()
        {
            DiceRoll = 000;
        }
    }
}
