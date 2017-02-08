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

            lblPlayer1.Text = "Player 1";
            lblPlayer2.Text = "Player 2";
            lblPlaysPlayer1.Text = "Plays left : 0";
            lblPlaysPlayer2.Text = "Plays left : 0";
            lblScorePlayer1.Text = "000";
            lblScorePlayer2.Text = "000";
            gbxDice.Text = "Dice :";
            btnRoll.Text = "Roll";
            btnTake.Text = "Take";
            btnNewGame.Text = "New game";
            lblTokensPlayer1.Text = "0";
            lblTokensPlayer2.Text = "0";
            lblTotalTokens.Text = "0";
            btnPhase.Text = string.Empty;

            SetMainComponentsState(false);

            btnNewGame.Click += NewGame;
        }

        private void SetMainComponentsState(bool state)
        {
            lblPlayer1.Enabled = state;
            lblPlayer2.Enabled = state;
            lblPlaysPlayer1.Enabled = state;
            lblPlaysPlayer2.Enabled = state;
            lblScorePlayer1.Enabled = state;
            lblScorePlayer2.Enabled = state;
            gbxDice.Enabled = state;
            btnRoll.Enabled = state;
            btnTake.Enabled = state;
            lblTokensPlayer1.Enabled = state;
            lblTokensPlayer2.Enabled = state;
            lblTotalTokens.Enabled = state;
            btnPhase.Enabled = state;
        }

        private void NewGame(object sender, EventArgs e)
        {
            _myGameInstance = new GameInstance();
            SetMainComponentsState(true);
        }
    }
}
