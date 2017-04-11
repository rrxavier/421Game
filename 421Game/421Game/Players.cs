using System;

namespace _421Game
{
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

        /// <summary>
        /// Switches to the next player.
        /// </summary>
        public void NextPlayer()
        {
            this._currentPlayer = GamePlayers[this.CurrentPlayer.Id];
        }

        /// <summary>
        /// Resets both players rolls.
        /// </summary>
        public void ResetRolls()
        {
            _playersArray[0].ResetRoll();
            _playersArray[1].ResetRoll();
        }
    }
}
