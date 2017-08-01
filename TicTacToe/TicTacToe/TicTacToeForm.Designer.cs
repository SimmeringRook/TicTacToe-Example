namespace TicTacToe
{
    partial class TicTacToeForm
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
            this.currentPlayerLabel = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.gameTile1 = new System.Windows.Forms.Button();
            this.gameTile2 = new System.Windows.Forms.Button();
            this.gameTile3 = new System.Windows.Forms.Button();
            this.gameTile6 = new System.Windows.Forms.Button();
            this.gameTile5 = new System.Windows.Forms.Button();
            this.gameTile4 = new System.Windows.Forms.Button();
            this.gameTile9 = new System.Windows.Forms.Button();
            this.gameTile8 = new System.Windows.Forms.Button();
            this.gameTile7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentPlayerLabel
            // 
            this.currentPlayerLabel.AutoSize = true;
            this.currentPlayerLabel.Location = new System.Drawing.Point(312, 37);
            this.currentPlayerLabel.Name = "currentPlayerLabel";
            this.currentPlayerLabel.Size = new System.Drawing.Size(91, 25);
            this.currentPlayerLabel.TabIndex = 0;
            this.currentPlayerLabel.Text = "X\'s Turn";
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(57, 28);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(140, 43);
            this.newGameButton.TabIndex = 1;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // gameTile1
            // 
            this.gameTile1.Location = new System.Drawing.Point(257, 238);
            this.gameTile1.Name = "gameTile1";
            this.gameTile1.Size = new System.Drawing.Size(64, 64);
            this.gameTile1.TabIndex = 2;
            this.gameTile1.Text = " ";
            this.gameTile1.UseVisualStyleBackColor = true;
            this.gameTile1.Click += new System.EventHandler(this.gameTile1_Click);
            // 
            // gameTile2
            // 
            this.gameTile2.Location = new System.Drawing.Point(327, 238);
            this.gameTile2.Name = "gameTile2";
            this.gameTile2.Size = new System.Drawing.Size(64, 64);
            this.gameTile2.TabIndex = 3;
            this.gameTile2.Text = " ";
            this.gameTile2.UseVisualStyleBackColor = true;
            this.gameTile2.Click += new System.EventHandler(this.gameTile2_Click);
            // 
            // gameTile3
            // 
            this.gameTile3.Location = new System.Drawing.Point(397, 238);
            this.gameTile3.Name = "gameTile3";
            this.gameTile3.Size = new System.Drawing.Size(64, 64);
            this.gameTile3.TabIndex = 4;
            this.gameTile3.Text = " ";
            this.gameTile3.UseVisualStyleBackColor = true;
            this.gameTile3.Click += new System.EventHandler(this.gameTile3_Click);
            // 
            // gameTile6
            // 
            this.gameTile6.Location = new System.Drawing.Point(397, 308);
            this.gameTile6.Name = "gameTile6";
            this.gameTile6.Size = new System.Drawing.Size(64, 64);
            this.gameTile6.TabIndex = 7;
            this.gameTile6.Text = " ";
            this.gameTile6.UseVisualStyleBackColor = true;
            this.gameTile6.Click += new System.EventHandler(this.gameTile6_Click);
            // 
            // gameTile5
            // 
            this.gameTile5.Location = new System.Drawing.Point(327, 308);
            this.gameTile5.Name = "gameTile5";
            this.gameTile5.Size = new System.Drawing.Size(64, 64);
            this.gameTile5.TabIndex = 6;
            this.gameTile5.Text = " ";
            this.gameTile5.UseVisualStyleBackColor = true;
            this.gameTile5.Click += new System.EventHandler(this.gameTile5_Click);
            // 
            // gameTile4
            // 
            this.gameTile4.Location = new System.Drawing.Point(257, 308);
            this.gameTile4.Name = "gameTile4";
            this.gameTile4.Size = new System.Drawing.Size(64, 64);
            this.gameTile4.TabIndex = 5;
            this.gameTile4.Text = " ";
            this.gameTile4.UseVisualStyleBackColor = true;
            this.gameTile4.Click += new System.EventHandler(this.gameTile4_Click);
            // 
            // gameTile9
            // 
            this.gameTile9.Location = new System.Drawing.Point(397, 378);
            this.gameTile9.Name = "gameTile9";
            this.gameTile9.Size = new System.Drawing.Size(64, 64);
            this.gameTile9.TabIndex = 10;
            this.gameTile9.Text = " ";
            this.gameTile9.UseVisualStyleBackColor = true;
            this.gameTile9.Click += new System.EventHandler(this.gameTile9_Click);
            // 
            // gameTile8
            // 
            this.gameTile8.Location = new System.Drawing.Point(327, 378);
            this.gameTile8.Name = "gameTile8";
            this.gameTile8.Size = new System.Drawing.Size(64, 64);
            this.gameTile8.TabIndex = 9;
            this.gameTile8.Text = " ";
            this.gameTile8.UseVisualStyleBackColor = true;
            this.gameTile8.Click += new System.EventHandler(this.gameTile8_Click);
            // 
            // gameTile7
            // 
            this.gameTile7.Location = new System.Drawing.Point(257, 378);
            this.gameTile7.Name = "gameTile7";
            this.gameTile7.Size = new System.Drawing.Size(64, 64);
            this.gameTile7.TabIndex = 8;
            this.gameTile7.Text = " ";
            this.gameTile7.UseVisualStyleBackColor = true;
            this.gameTile7.Click += new System.EventHandler(this.gameTile7_Click);
            // 
            // TicTacToeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 681);
            this.Controls.Add(this.gameTile9);
            this.Controls.Add(this.gameTile8);
            this.Controls.Add(this.gameTile7);
            this.Controls.Add(this.gameTile6);
            this.Controls.Add(this.gameTile5);
            this.Controls.Add(this.gameTile4);
            this.Controls.Add(this.gameTile3);
            this.Controls.Add(this.gameTile2);
            this.Controls.Add(this.gameTile1);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.currentPlayerLabel);
            this.Name = "TicTacToeForm";
            this.Text = "Tic Tac Toe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentPlayerLabel;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button gameTile1;
        private System.Windows.Forms.Button gameTile2;
        private System.Windows.Forms.Button gameTile3;
        private System.Windows.Forms.Button gameTile6;
        private System.Windows.Forms.Button gameTile5;
        private System.Windows.Forms.Button gameTile4;
        private System.Windows.Forms.Button gameTile9;
        private System.Windows.Forms.Button gameTile8;
        private System.Windows.Forms.Button gameTile7;
    }
}

