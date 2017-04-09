namespace _421Game
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlaysPlayer1 = new System.Windows.Forms.Label();
            this.lblDiceRollPlayer1 = new System.Windows.Forms.Label();
            this.lblDiceRollPlayer2 = new System.Windows.Forms.Label();
            this.lblPlaysPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.gbxDice = new System.Windows.Forms.GroupBox();
            this.btnRoll = new System.Windows.Forms.Button();
            this.btnTake = new System.Windows.Forms.Button();
            this.lblTotalTokens = new System.Windows.Forms.Label();
            this.lblTokensPlayer1 = new System.Windows.Forms.Label();
            this.lblTokensPlayer2 = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.lblPhase = new System.Windows.Forms.Label();
            this.lblLastRollPlayer2 = new System.Windows.Forms.Label();
            this.lblLastRollPlayer1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.Location = new System.Drawing.Point(12, 59);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(103, 13);
            this.lblPlayer1.TabIndex = 0;
            this.lblPlayer1.Text = "label1";
            // 
            // lblPlaysPlayer1
            // 
            this.lblPlaysPlayer1.Location = new System.Drawing.Point(12, 84);
            this.lblPlaysPlayer1.Name = "lblPlaysPlayer1";
            this.lblPlaysPlayer1.Size = new System.Drawing.Size(125, 13);
            this.lblPlaysPlayer1.TabIndex = 2;
            this.lblPlaysPlayer1.Text = "lblPlaysPlayer1";
            // 
            // lblDiceRollPlayer1
            // 
            this.lblDiceRollPlayer1.Location = new System.Drawing.Point(12, 109);
            this.lblDiceRollPlayer1.Name = "lblDiceRollPlayer1";
            this.lblDiceRollPlayer1.Size = new System.Drawing.Size(103, 13);
            this.lblDiceRollPlayer1.TabIndex = 3;
            this.lblDiceRollPlayer1.Text = "label1";
            // 
            // lblDiceRollPlayer2
            // 
            this.lblDiceRollPlayer2.Location = new System.Drawing.Point(625, 109);
            this.lblDiceRollPlayer2.Name = "lblDiceRollPlayer2";
            this.lblDiceRollPlayer2.Size = new System.Drawing.Size(101, 13);
            this.lblDiceRollPlayer2.TabIndex = 6;
            this.lblDiceRollPlayer2.Text = "label1";
            this.lblDiceRollPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlaysPlayer2
            // 
            this.lblPlaysPlayer2.Location = new System.Drawing.Point(597, 84);
            this.lblPlaysPlayer2.Name = "lblPlaysPlayer2";
            this.lblPlaysPlayer2.Size = new System.Drawing.Size(129, 13);
            this.lblPlaysPlayer2.TabIndex = 5;
            this.lblPlaysPlayer2.Text = "label2";
            this.lblPlaysPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.Location = new System.Drawing.Point(628, 59);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(98, 13);
            this.lblPlayer2.TabIndex = 4;
            this.lblPlayer2.Text = "label1";
            this.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbxDice
            // 
            this.gbxDice.Location = new System.Drawing.Point(143, 59);
            this.gbxDice.Name = "gbxDice";
            this.gbxDice.Size = new System.Drawing.Size(448, 100);
            this.gbxDice.TabIndex = 7;
            this.gbxDice.TabStop = false;
            this.gbxDice.Text = "groupBox1";
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(168, 165);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(148, 93);
            this.btnRoll.TabIndex = 8;
            this.btnRoll.Text = "button1";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.Roll);
            // 
            // btnTake
            // 
            this.btnTake.Location = new System.Drawing.Point(419, 165);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(148, 93);
            this.btnTake.TabIndex = 9;
            this.btnTake.Text = "button2";
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.Take);
            // 
            // lblTotalTokens
            // 
            this.lblTotalTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTokens.Location = new System.Drawing.Point(298, 280);
            this.lblTotalTokens.Name = "lblTotalTokens";
            this.lblTotalTokens.Size = new System.Drawing.Size(143, 107);
            this.lblTotalTokens.TabIndex = 10;
            this.lblTotalTokens.Text = "label1";
            this.lblTotalTokens.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTokensPlayer1
            // 
            this.lblTokensPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokensPlayer1.Location = new System.Drawing.Point(9, 213);
            this.lblTokensPlayer1.Name = "lblTokensPlayer1";
            this.lblTokensPlayer1.Size = new System.Drawing.Size(143, 107);
            this.lblTokensPlayer1.TabIndex = 11;
            this.lblTokensPlayer1.Text = "label1";
            this.lblTokensPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTokensPlayer2
            // 
            this.lblTokensPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokensPlayer2.Location = new System.Drawing.Point(583, 213);
            this.lblTokensPlayer2.Name = "lblTokensPlayer2";
            this.lblTokensPlayer2.Size = new System.Drawing.Size(143, 107);
            this.lblTokensPlayer2.TabIndex = 12;
            this.lblTokensPlayer2.Text = "label2";
            this.lblTokensPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(12, 355);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(714, 23);
            this.btnNewGame.TabIndex = 13;
            this.btnNewGame.Text = "button1";
            this.btnNewGame.UseVisualStyleBackColor = true;
            // 
            // lblPhase
            // 
            this.lblPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase.Location = new System.Drawing.Point(12, 6);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(714, 50);
            this.lblPhase.TabIndex = 14;
            this.lblPhase.Text = "label1";
            this.lblPhase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastRollPlayer2
            // 
            this.lblLastRollPlayer2.Location = new System.Drawing.Point(625, 135);
            this.lblLastRollPlayer2.Name = "lblLastRollPlayer2";
            this.lblLastRollPlayer2.Size = new System.Drawing.Size(101, 13);
            this.lblLastRollPlayer2.TabIndex = 15;
            this.lblLastRollPlayer2.Text = "label1";
            this.lblLastRollPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastRollPlayer1
            // 
            this.lblLastRollPlayer1.Location = new System.Drawing.Point(12, 135);
            this.lblLastRollPlayer1.Name = "lblLastRollPlayer1";
            this.lblLastRollPlayer1.Size = new System.Drawing.Size(103, 13);
            this.lblLastRollPlayer1.TabIndex = 16;
            this.lblLastRollPlayer1.Text = "label1";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 391);
            this.Controls.Add(this.lblLastRollPlayer1);
            this.Controls.Add(this.lblLastRollPlayer2);
            this.Controls.Add(this.lblPhase);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lblTokensPlayer2);
            this.Controls.Add(this.lblTokensPlayer1);
            this.Controls.Add(this.lblTotalTokens);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.gbxDice);
            this.Controls.Add(this.lblDiceRollPlayer2);
            this.Controls.Add(this.lblPlaysPlayer2);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblDiceRollPlayer1);
            this.Controls.Add(this.lblPlaysPlayer1);
            this.Controls.Add(this.lblPlayer1);
            this.Name = "GameWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlaysPlayer1;
        private System.Windows.Forms.Label lblDiceRollPlayer1;
        private System.Windows.Forms.Label lblDiceRollPlayer2;
        private System.Windows.Forms.Label lblPlaysPlayer2;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.GroupBox gbxDice;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.Label lblTotalTokens;
        private System.Windows.Forms.Label lblTokensPlayer1;
        private System.Windows.Forms.Label lblTokensPlayer2;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label lblPhase;
        private System.Windows.Forms.Label lblLastRollPlayer2;
        private System.Windows.Forms.Label lblLastRollPlayer1;
    }
}

