using System;
using System.Threading;

namespace _421Game
{
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
}
