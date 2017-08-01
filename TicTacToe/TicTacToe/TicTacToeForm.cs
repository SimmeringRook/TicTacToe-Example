using System;
using System.Windows.Forms;

/* Tic Tac Toe v1.0
 * Thomas Knudson - 01 Aug 2017
 * 
 * This is a simple example of re-creating Tic Tac Toe using C# and WinForms.
 * 
 * Upon running the program, the game board (3x3 box of buttons, "gameTile") is disabled.
 * The player who desires to be Player 1 (X), must click the New Game button. newGameButton
 * has a click event which handles all the logic for starting a new game (either from a fresh
 * start, or after a match has been completed).
 * 
 * When starting a new game:
 *  -currentPlayerMark is set to "X" (for player 1)
 *  -Each gameTile's Text property is set to " " (Empty)
 *  -The game board is enabled (meaning each gameTile can respond to the players clicking on them)
 * 
 * Player's Turn:
 *  -The player choose which tile to mark, and then clicks on it
 *  -We check to make sure the title has not been marked before
 *      If it is empty:
 *          -The Current Player claims that tile
 *      Otherwise:
 *          -It remains the Current Player's turn, until they make a valid move
 *  -This ends the current player's turn.
 *  
 * Between Turns:
 *  -We check to see if the game has ended (3 in a row, column, or diagonally)
 *      If a victory condition has been met:
 *          -Disable the game board
 *          -Display a message to the Players that the Current Player has won
 *      If the game is a draw:
 *          -Disable the game board
 *          -Display a message to the Players
 *      Otherwise:
 *          -Change currentPlayerMark to the next player's mark
 */

namespace TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        //Class variable that holds the mark for Player 1 (X) or Player 2 (O)
        private string currentPlayerMark = "";

        public TicTacToeForm()
        {
            InitializeComponent();

            //Disable the game board until the New Game button has been clicked
            ToggleGameBoard(false);
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            //Set the Mark for player 1 - "X"
            currentPlayerMark = "X";

            //Make sure all the tiles are clear of player marks
            ResetGameBoard();

            //Allow the game tiles on the board to be clicked
            ToggleGameBoard(true);
        }

        private void ChangePlayers()
        {
            //Change Marks between player 1 and player 2
            if (currentPlayerMark.Equals("X"))
            {
                currentPlayerMark = "O";
            }
            else
            {
                currentPlayerMark = "X";
            }

            //Update the label, informing the player of whose turn it is
            currentPlayerLabel.Text = currentPlayerMark + "'s Turn";
        }
        
        private void NextTurn()
        {
            //Check to see if the current player has won
            if (CheckForHorizontalVictory() || CheckForVerticalVictory() || CheckForDiagonalVictory())
            {
                //The current player has won

                //Disable the game board
                ToggleGameBoard(false);

                //Inform the players that the current player has won
                MessageBox.Show(currentPlayerMark + " wins!");
            }
            else if (CheckForDraw())
            {
                //There are no moves remaining

                //Disable the game board
                ToggleGameBoard(false);

                //Inform the players the match is over
                MessageBox.Show("The Game is a Draw!");
            }
            else
            {
                //No one has won yet, change players
                ChangePlayers();
            }
        }

        private void ToggleGameBoard(bool enable)
        {
            //This method changes the Enabled state of each game tile on the board
            //if the arguement, "enable" is set to true:
            //Players will be able to click on the board
            //otherwise, the players will be unable to click any of the tiles
            gameTile1.Enabled = enable;
            gameTile2.Enabled = enable;
            gameTile3.Enabled = enable;
            gameTile4.Enabled = enable;
            gameTile5.Enabled = enable;
            gameTile6.Enabled = enable;
            gameTile7.Enabled = enable;
            gameTile8.Enabled = enable;
            gameTile9.Enabled = enable;
        }

        private void ResetGameBoard()
        {
            //This method erases all previous player moves
            //to allow for a new game to begin
            gameTile1.Text = " ";
            gameTile2.Text = " ";
            gameTile3.Text = " ";
            gameTile4.Text = " ";
            gameTile5.Text = " ";
            gameTile6.Text = " ";
            gameTile7.Text = " ";
            gameTile8.Text = " ";
            gameTile9.Text = " ";
        }

        #region Victory Conditions
        private bool CheckForHorizontalVictory()
        {
            bool horizontalVictory = false;

            //This method checks each row, to see if the current player controls all 3 tiles
            //If the player does control them, return true - the current player has won!
            if (gameTile1.Text.Equals(currentPlayerMark) && gameTile2.Text.Equals(currentPlayerMark) && gameTile3.Text.Equals(currentPlayerMark))
            {
                horizontalVictory = true;
            }
            else if (gameTile4.Text.Equals(currentPlayerMark) && gameTile5.Text.Equals(currentPlayerMark) && gameTile6.Text.Equals(currentPlayerMark))
            {
                horizontalVictory = true;
            }
            else if (gameTile7.Text.Equals(currentPlayerMark) && gameTile8.Text.Equals(currentPlayerMark) && gameTile9.Text.Equals(currentPlayerMark))
            {
                horizontalVictory = true;
            }
            
            //If the current player does not control all 3 tiles in any of the rows, return false
            return horizontalVictory;
        }

        private bool CheckForVerticalVictory()
        {
            bool verticalVictory = false;

            //This method checks each column, to see if the current player controls all 3 tiles
            //If the player does control them, return true - the current player has won!

            if (gameTile1.Text.Equals(currentPlayerMark) && gameTile4.Text.Equals(currentPlayerMark) && gameTile7.Text.Equals(currentPlayerMark))
            {
                verticalVictory = true;
            }
            else if (gameTile2.Text.Equals(currentPlayerMark) && gameTile5.Text.Equals(currentPlayerMark) && gameTile8.Text.Equals(currentPlayerMark))
            {
                verticalVictory = true;
            }
            else if (gameTile3.Text.Equals(currentPlayerMark) && gameTile6.Text.Equals(currentPlayerMark) && gameTile9.Text.Equals(currentPlayerMark))
            {
                verticalVictory = true;
            }

            //If the current player does not control all 3 tiles in any of the columns, return false
            return verticalVictory;
        }

        private bool CheckForDiagonalVictory()
        {
            bool diagonalVictory = false;

            //This method checks both diagonal possibilities;
            //If the current player controls one, return true - the current player has won!

            /* 1   3
             *   5  
             * 7   9
             */ 

            if (gameTile1.Text.Equals(currentPlayerMark) && gameTile5.Text.Equals(currentPlayerMark) && gameTile9.Text.Equals(currentPlayerMark))
            {
                diagonalVictory = true;
            }
            else if (gameTile3.Text.Equals(currentPlayerMark) && gameTile5.Text.Equals(currentPlayerMark) && gameTile7.Text.Equals(currentPlayerMark))
            {
                diagonalVictory = true;
            }

            return diagonalVictory;
        }

        #endregion

        private bool CheckForDraw()
        {
            //TODO: Improve checking such that, once none of the victory conditions can be met, the game is declared
            //a draw

            if (gameTile1.Text.Equals(" ") == false && gameTile1.Text.Equals(" ") == false && gameTile1.Text.Equals(" ") == false &&
                gameTile1.Text.Equals(" ") == false && gameTile1.Text.Equals(" ") == false && gameTile1.Text.Equals(" ") == false &&
                gameTile1.Text.Equals(" ") == false && gameTile1.Text.Equals(" ") == false && gameTile1.Text.Equals(" ") == false)
            {
                //All tiles have been claimed, but no one has won
                //It is a draw
                return true;
            }

            //Not all of the tiles have been claimed yet
            return false;
        }

        #region Game Tiles
        private void gameTile1_Click(object sender, EventArgs e)
        {
            //Make sure the tile is empty
            if (gameTile1.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile1.Text = currentPlayerMark;

                //End the current player's turn
                NextTurn();
            }
        }

        private void gameTile2_Click(object sender, EventArgs e)
        {
            //Make sure the tile is empty
            if (gameTile2.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile2.Text = currentPlayerMark;

                //End the current player's turn
                NextTurn();
            }
        }

        private void gameTile3_Click(object sender, EventArgs e)
        {
            //Make sure the tile is empty
            if (gameTile3.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile3.Text = currentPlayerMark;

                //End the current player's turn
                NextTurn();
            }
        }

        private void gameTile4_Click(object sender, EventArgs e)
        {
            //Make sure the tile is empty
            if (gameTile4.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile4.Text = currentPlayerMark;

                //End the current player's turn
                NextTurn();
            }
        }

        private void gameTile5_Click(object sender, EventArgs e)
        {
            //Make sure the tile is empty
            if (gameTile5.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile5.Text = currentPlayerMark;

                //End the current player's turn
                NextTurn();
            }
        }

        private void gameTile6_Click(object sender, EventArgs e)
        {
            //Make sure the tile is empty
            if (gameTile6.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile6.Text = currentPlayerMark;

                //End the current player's turn
                NextTurn();
            }
        }

        private void gameTile7_Click(object sender, EventArgs e)
        {
            //Make sure the tile is empty
            if (gameTile7.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile7.Text = currentPlayerMark;

                //End the current player's turn
                NextTurn();
            }
        }

        private void gameTile8_Click(object sender, EventArgs e)
        {
            //Make sure the tile is empty
            if (gameTile8.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile8.Text = currentPlayerMark;

                //End the current player's turn
                NextTurn();
            }
        }

        private void gameTile9_Click(object sender, EventArgs e)
        {
            //Make sure the tile is empty
            if (gameTile9.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile9.Text = currentPlayerMark;

                //End the current player's turn
                NextTurn();
            }
        }
        #endregion

    }
}
