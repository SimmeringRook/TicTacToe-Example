using System;
using System.Windows.Forms;

/* Tic Tac Toe v1.0.6
 * Thomas Knudson - 12 Aug 2017
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
        /* The gameEngine will now be responsible for handling all 
         * of the game logic related to TicTacToe */
        private TicTacToeEngine gameEngine;

        public TicTacToeForm()
        {
            InitializeComponent();

            //Populate the two dimensional array of buttons
            InitializeGameBoard();

            //Disable the game board until the New Game button has been clicked
            gameEngine.ToggleGameBoard(false);
        }

        private void InitializeGameBoard()
        {
            gameEngine = new TicTacToeEngine();

            //Initialize the array, 2-Dimensions, 3 rows and 3 columns
            Button[,] gameBoard = new Button[3, 3];

            //Save the first row of tiles to the array
            gameBoard[0, 0] = gameTile1;
            gameBoard[0, 1] = gameTile2;
            gameBoard[0, 2] = gameTile3;

            //Save the second row of tiles
            gameBoard[1, 0] = gameTile4;
            gameBoard[1, 1] = gameTile5;
            gameBoard[1, 2] = gameTile6;

            //Save the third row of tiles
            gameBoard[2, 0] = gameTile7;
            gameBoard[2, 1] = gameTile8;
            gameBoard[2, 2] = gameTile9;

            //Assign the gameBoard to the gameEngine
            gameEngine.Initialize(gameBoard);
        }

        private void gameTile_Click(object sender, EventArgs e)
        {
            //Save a copy of the button that was clicked
            Button gameTile = (Button)sender;

            //Make sure the tile is empty
            if (gameTile.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile.Text = gameEngine.CurrentPlayerMark;

                //disable the button, to prevent it from being clicked again
                gameTile.Enabled = false;

                //End the Current Player's turn
                gameEngine.NextTurn();

                //Update the label, informing the player of whose turn it is
                currentPlayerLabel.Text = gameEngine.GetPlayerTurnMessage();
            }
        }

        /// <summary>
        /// Ensure all tiles are reset and enabled for a new match
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameButton_Click(object sender, EventArgs e)
        {
            gameEngine.InitializeNewGame();
        }
    }
}
