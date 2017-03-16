/**
 * Régles :
 * Première phase : Charge
 * Les 20 pions sont distribués avec la règle de distribution.
 * Pas besoin d'intervention de l'utilisateur.
 * Deuxième phase : Décharge
 * Les joueurs s'affrontent.
 * Le joueur qui perd peut jouer jusqu'à 3 fois ce tour.
 * Le joueur qui n'a plus de pions gagne.
 **/

/** 
 * Distribution : 
 * La personne qui tire la combinaison la plus haute fait prendre des pions à l'autre.
 * Il y a des combinaisons plus fortes que d'autres.
 **/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _421Game
{
    public partial class GameWindow : Form
    {
        GameInstance _myGameInstance;

        public GameWindow()
        {
            InitializeComponent();

            lblDice1.Text = string.Empty;
            lblDice2.Text = string.Empty;
            lblDice3.Text = string.Empty;
            lblPlayer1.Text = "Player 1";
            lblPlayer2.Text = "Player 2";
            lblPlaysPlayer1.Text = "Plays left : 0";
            lblPlaysPlayer2.Text = "Plays left : 0";
            lblDiceRollPlayer1.Text = "Dice Roll : 0";
            lblDiceRollPlayer2.Text = "Dice Roll : 0";
            gbxDice.Text = "Dice :";
            btnRoll.Text = "Roll";
            btnTake.Text = "Take";
            btnNewGame.Text = "New game";
            lblTokensPlayer1.Text = "Tokens\n0";
            lblTokensPlayer2.Text = "Tokens\n0";
            lblTotalTokens.Text = "0";
            lblPhase.Text = string.Empty;
            SetMainComponentsState(false);
            var test = new
            {
                amount = 108, Message = "test"
            };

            // New game
            btnNewGame.Click += delegate (object sender, EventArgs e)
            {
                MyGameInstance = new GameInstance();
                this.Roll(sender, e);

                RefreshView();
            };
        }

        internal GameInstance MyGameInstance
        {
            get
            {
                return _myGameInstance;
            }

            private set
            {
                _myGameInstance = value;
            }
        }

        private void SetMainComponentsState(bool state)
        {
            lblPlayer1.Enabled = state;
            lblPlayer2.Enabled = state;
            lblPlaysPlayer1.Enabled = state;
            lblPlaysPlayer2.Enabled = state;
            lblDiceRollPlayer1.Enabled = state;
            lblDiceRollPlayer2.Enabled = state;
            gbxDice.Enabled = state;
            btnRoll.Enabled = state;
            btnTake.Enabled = state;
            lblTokensPlayer1.Enabled = state;
            lblTokensPlayer2.Enabled = state;
            lblTotalTokens.Enabled = state;
            lblPhase.Enabled = state;
        }

        private void RefreshView()
        {
            lblDice1.Text = MyGameInstance.Dice1.LastRoll.ToString();
            lblDice2.Text = MyGameInstance.Dice2.LastRoll.ToString();
            lblDice3.Text = MyGameInstance.Dice3.LastRoll.ToString();
            lblDiceRollPlayer1.Text = string.Format("Dice Roll : {0}", MyGameInstance.GamePlayers.GamePlayers[1].DiceRoll.ToString());
            lblDiceRollPlayer2.Text = string.Format("Dice Roll : {0}", MyGameInstance.GamePlayers.GamePlayers[0].DiceRoll.ToString());
            lblTokensPlayer1.Text = string.Format("Tokens\n{0}", MyGameInstance.GamePlayers.GamePlayers[1].Tokens.ToString());
            lblTokensPlayer2.Text = string.Format("Tokens\n{0}", MyGameInstance.GamePlayers.GamePlayers[0].Tokens.ToString());
            lblTotalTokens.Text = MyGameInstance.Tokens.ToString();
            EnableCurrentPlayerControls();
        }

        private void EnableCurrentPlayerControls()
        {
            switch (MyGameInstance.GamePlayers.CurrentPlayer.Id)
            {
                case 0:
                    SetMainComponentsState(false);
                    lblPlayer1.Enabled = true;
                    lblPlaysPlayer1.Enabled = true;
                    lblDiceRollPlayer1.Enabled = true;
                    lblTokensPlayer1.Enabled = true;
                    lblTotalTokens.Enabled = true;
                    lblPhase.Enabled = true;
                    gbxDice.Enabled = true;
                    btnNewGame.Enabled = true;
                    btnTake.Enabled = (MyGameInstance.Dice1.LastRoll == 0 && MyGameInstance.Dice1.LastRoll == 0 && MyGameInstance.Dice1.LastRoll == 0) ? false : true;
                    btnRoll.Enabled = MyGameInstance.GamePlayers.CurrentPlayer.PlaysLeft > 0 ? true : false;
                    break;
                case 1:
                    SetMainComponentsState(false);
                    lblPlayer2.Enabled = true;
                    lblPlaysPlayer2.Enabled = true;
                    lblDiceRollPlayer2.Enabled = true;
                    lblTokensPlayer2.Enabled = true;
                    lblTotalTokens.Enabled = true;
                    lblPhase.Enabled = true;
                    gbxDice.Enabled = true;
                    btnNewGame.Enabled = true;
                    btnTake.Enabled = (MyGameInstance.Dice1.LastRoll == 0 && MyGameInstance.Dice1.LastRoll == 0 && MyGameInstance.Dice1.LastRoll == 0) ? false : true;
                    btnRoll.Enabled = MyGameInstance.GamePlayers.CurrentPlayer.PlaysLeft > 0 ? true : false;
                    break;
            }
        }

        private void Roll(object sender, EventArgs e)
        {
            MyGameInstance.RollDices(true, true, true);
            RefreshView();
        }

        private void Take(object sender, EventArgs e)
        {
            MyGameInstance.CurrentPlayerTakes();
            RefreshView();
        }
    }
}