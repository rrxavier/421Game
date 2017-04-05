using System;
using System.Linq;
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
        private Phases _phase;

        public GameInstance(string player1, string player2)
        {
            // I reversed their IDs so it's easier for me to finish a turn.
            this._players = new Players(new Player[2] { new Player(player1, 1), new Player(player2, 0) });
            this._dice1 = new Dice();
            this._dice2 = new Dice();
            this._dice3 = new Dice();
            this._tokens = 20;
            this._phase = Phases.Load;
        }

        /// <summary>
        /// If the players didn't chose a name.
        /// </summary>
        public GameInstance() : this("Player1", "Player2") { }

        public Dice Dice1
        {
            get { return _dice1; }
        }

        public Dice Dice2
        {
            get { return _dice2; }
        }

        public Dice Dice3
        {
            get { return _dice3; }
        }

        public Players GamePlayers
        {
            get { return _players; }
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
            // If both players played.
            if (GamePlayers.GamePlayers[0].DiceRoll > 0 && GamePlayers.GamePlayers[1].DiceRoll > 0)
            {
                // If the first has the biggest combination.
                if (GamePlayers.GamePlayers[0].Combi.Priority > GamePlayers.GamePlayers[1].Combi.Priority)
                {
                    /*GamePlayers.GamePlayers[1].Tokens += GamePlayers.GamePlayers[0].Combi.TokenValue;
                    Tokens -= GamePlayers.GamePlayers[0].Combi.TokenValue;*/
                    ProcessTokenMovement(GamePlayers.GamePlayers[1], GamePlayers.GamePlayers[0].Combi.TokenValue);
                }
                else if (GamePlayers.GamePlayers[0].Combi.Priority < GamePlayers.GamePlayers[1].Combi.Priority) // If the second has the biggest combination.
                {
                    /*GamePlayers.GamePlayers[0].Tokens += GamePlayers.GamePlayers[0].Combi.TokenValue;
                    Tokens -= GamePlayers.GamePlayers[0].Combi.TokenValue;*/
                    ProcessTokenMovement(GamePlayers.GamePlayers[0], GamePlayers.GamePlayers[1].Combi.TokenValue);
                }
                else // If they both have the same combination.
                {
                    if (GamePlayers.GamePlayers[0].DiceRoll > GamePlayers.GamePlayers[1].DiceRoll)
                    {
                        /*GamePlayers.GamePlayers[1].Tokens += GamePlayers.GamePlayers[0].Combi.TokenValue;
                        Tokens -= GamePlayers.GamePlayers[0].Combi.TokenValue;*/
                        ProcessTokenMovement(GamePlayers.GamePlayers[1], GamePlayers.GamePlayers[0].Combi.TokenValue);
                    }
                    else if (GamePlayers.GamePlayers[0].DiceRoll < GamePlayers.GamePlayers[1].DiceRoll)
                    {
                        /*GamePlayers.GamePlayers[0].Tokens += GamePlayers.GamePlayers[1].Combi.TokenValue;
                        Tokens -= GamePlayers.GamePlayers[0].Combi.TokenValue;*/
                        ProcessTokenMovement(GamePlayers.GamePlayers[0], GamePlayers.GamePlayers[1].Combi.TokenValue);
                    }
                }

                GamePlayers.ResetRolls();
                GamePlayers.CurrentPlayer.PlaysLeft = 1;
                MessageBox.Show("TEST");
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

        /// <summary>
        /// Moves an amount of tokens from the token pool to a player's token pool.
        /// </summary>
        /// <param name="loser">The players who gets the tokens.</param>
        /// <param name="amount">The amount of tokens to move.</param>
        /// <returns>True if we have to change phase, false if we don't.</returns>
        private bool MoveTokenFromPool(ref Player loser, int amount)
        {
            if (this.Tokens - amount >= 0)
            {
                this.Tokens -= amount;
                loser.Tokens += amount;

                return false;
            }
            else
            {
                loser.Tokens += this.Tokens;
                this.Tokens = 0;

                return true;
            }
        }

        /// <summary>
        /// Moves an amount of tokens from a player to the other.
        /// </summary>
        /// <param name="loser">The players who gets the tokens.</param>
        /// <param name="amount">The amount of tokens to move.</param>
        /// <returns>True if we have to change phase, false if we don't.</returns>
        private bool MoveTokenFromPlayer(ref Player loser, int amount)
        {
            Player winner = this.GamePlayers.GamePlayers[loser.Id];
            if (winner.Tokens - amount >= 0)
            {
                winner.Tokens -= amount;
                loser.Tokens += amount;

                return false;
            }
            else
            {
                loser.Tokens += winner.Tokens;
                winner.Tokens = 0;

                return true;
            }
        }

        private void ProcessTokenMovement(Player loser, int amount)
        {
            if (this._phase == Phases.Load)
            {
                if (MoveTokenFromPool(ref loser, amount))
                    this._phase = Phases.Unload;
            }
            else if (this._phase == Phases.Load)
                if (MoveTokenFromPlayer(ref loser, amount))
                    this._phase = Phases.Unload;
        }

        public enum Phases : int { Load, Unload, Finished }   // enum that defines in which phase we're in.
    }
}
