namespace _421Game
{
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
