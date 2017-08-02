using System;
using System.Windows.Forms;

/* Tic Tac Toe v1.0.4
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

        //2-Dimensional array that holds all 9 gameTiles
        private Button[,] gameBoard;

        public TicTacToeForm()
        {
            InitializeComponent();

            //Populate the two dimensional array of buttons
            InitializeGameBoard();

            //Disable the game board until the New Game button has been clicked
            ToggleGameBoard(false);
        }
        #region Form Logic
        private void InitializeGameBoard()
        {
            //Initialize the array, 2-Dimensions, 3 rows and 3 columns
            gameBoard = new Button[3, 3];

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
        }

        private void gameTile_Click(object sender, EventArgs e)
        {
            //Save a copy of the button that was clicked
            Button gameTile = (Button)sender;

            //Make sure the tile is empty
            if (gameTile.Text.Equals(" "))
            {
                //If it is, award the tile to the current player
                gameTile.Text = currentPlayerMark;

                //disable the button, to prevent it from being clicked again
                gameTile.Enabled = false;

                //End the Current Player's turn
                NextTurn();
            }
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

        /// <summary>
        /// Sets the "Enabled" property on each gameTile to the value of "newState".
        /// if the value of "newState" is set to true,
        /// Players will be able to click on the board.
        /// Otherwise, the players will be unable to interact with any of the tiles.
        /// </summary>
        /// <param name="newState"></param>
        private void ToggleGameBoard(bool newState)
        {
            //Loop over each gameTile in the gameBoard, and set the Enabled property to the value of "newState"
            for (int row = gameBoard.GetLowerBound(0); row <= gameBoard.GetUpperBound(0); row++)
            {
                /* The functions "GetLowerBound(int dimension)" and "GetUpperBound(int dimension)",
                     * return the respective indexes for the first and last elements in the specified array.
                     * While this is not critical, it allows future changes to the size of the gameBoard without
                     * having to change every hardcoded upper limit on each set of nested for loops.
                     */
                for (int column = gameBoard.GetLowerBound(1); column <= gameBoard.GetUpperBound(1); column++)
                {
                    gameBoard[row, column].Enabled = newState;
                }
            }
        }

        /// <summary>
        /// Reset each gameTile to an empty state.
        /// </summary>
        private void ResetGameBoard()
        {
            //Loop over each gameTile in the gameBoard, erases any player moves
            for (int row = gameBoard.GetLowerBound(0); row <= gameBoard.GetUpperBound(0); row++)
            {
                for (int column = gameBoard.GetLowerBound(1); column <= gameBoard.GetUpperBound(1); column++)
                {
                    gameBoard[row, column].Text = " ";
                }
            }
        }
        #endregion

        #region Game Logic

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

        #region Victory Conditions

        /// <summary>
        /// Check each row to see if the current player controls all 3 tiles.
        /// </summary>
        /// <returns></returns>
        private bool CheckForHorizontalVictory()
        {
            for (int row = gameBoard.GetLowerBound(0); row <= gameBoard.GetUpperBound(0); row++)
            {
                bool rowControledByCurrentPlayer = true;
                
                for (int column = gameBoard.GetLowerBound(1); column <= gameBoard.GetUpperBound(1); column++)
                {
                    //Save a reference of the current gameTile
                    Button currentTile = gameBoard[row, column];

                    if (currentTile.Text.Equals(currentPlayerMark) == false)
                    {
                        //The Current Player does not control all the tiles in this row.
                        rowControledByCurrentPlayer = false;
                    }
                }

                //Check to see if the Current Player does control all 3 tiles
                if (rowControledByCurrentPlayer == true)
                {
                    //Victory has been acheived, exit early
                    return true;
                }
            }

            //The Current Player does not control 3 tiles in a row
            return false;
        }

        /// <summary>
        /// Check each column to see if the current player controls all 3 tiles.
        /// </summary>
        /// <returns></returns>
        private bool CheckForVerticalVictory()
        {
            //Switch the order of which dimension is looped over first
            //Since we want to check each tile in a column
            for (int column = gameBoard.GetLowerBound(1); column <= gameBoard.GetUpperBound(1); column++)
            {
                bool columnControledByCurrentPlayer = true;

                for (int row = gameBoard.GetLowerBound(0); row <= gameBoard.GetUpperBound(0); row++)
                {
                    //Save a reference of the current gameTile
                    Button currentTile = gameBoard[row, column];

                    if (currentTile.Text.Equals(currentPlayerMark) == false)
                    {
                        //The Current Player does not control all the tiles in this column.
                        columnControledByCurrentPlayer = false;
                    }
                }

                //Check to see if the Current Player does control all 3 tiles
                if (columnControledByCurrentPlayer == true)
                {
                    //Victory has been acheived, exit early
                    return true;
                }
            }

            //The Current Player does not control 3 tiles in a row
            return false;
        }

        /// <summary>
        /// Check either diagonal (1-5-9 or 3-5-7) to see if the current player controls them.
        /// </summary>
        /// <returns></returns>
        private bool CheckForDiagonalVictory()
        {
            bool diagonal_159_Control = true;
            bool diagonal_357_Control = true;
            /* 1   3
             *   5  
             * 7   9*/

            for (int row = gameBoard.GetLowerBound(0); row <= gameBoard.GetUpperBound(0); row++)
            {
                for (int column = gameBoard.GetLowerBound(1); column <= gameBoard.GetUpperBound(1); column++)
                {
                    //Check Tiles 1, 9
                    if (row == column)
                    {
                        //Save a reference to the Current Tile
                        Button currentTile = gameBoard[row, column];

                        if (currentTile.Text.Equals(currentPlayerMark) == false)
                        {
                            //The Current Player does not control all the tiles in this diagonal.
                            diagonal_159_Control = false;
                        }
                    }
                    //Check Tile 3
                    else if (row == gameBoard.GetLowerBound(0) && column == gameBoard.GetUpperBound(1))
                    {
                        //Save a reference to the Current Tile
                        Button currentTile = gameBoard[row, column];

                        if (currentTile.Text.Equals(currentPlayerMark) == false)
                        {
                            //The Current Player does not control all the tiles in this diagonal.
                            diagonal_357_Control = false;
                        }
                    }
                    //Check Tile 7
                    else if (row == gameBoard.GetUpperBound(0) && column == gameBoard.GetLowerBound(1))
                    {
                        //Save a reference to the Current Tile
                        Button currentTile = gameBoard[row, column];

                        if (currentTile.Text.Equals(currentPlayerMark) == false)
                        {
                            //The Current Player does not control all the tiles in this diagonal.
                            diagonal_357_Control = false;
                        }
                    }
                    //Check Tile 5
                    else if (row == Math.Ceiling(gameBoard.GetUpperBound(0) / 2.0) &&
                            column == Math.Ceiling(gameBoard.GetUpperBound(0) / 2.0))
                    {
                        //Save a reference to the Current Tile   
                        Button currentTile = gameBoard[row, column];

                        if (currentTile.Text.Equals(currentPlayerMark) == false)
                        {
                            //The Current Player does not control all the tiles in this diagonal
                            diagonal_159_Control = false;
                            diagonal_357_Control = false;
                        }
                    }
                }
                
            }

            //Check the results
            if (diagonal_159_Control || diagonal_357_Control)
            {
                //The current player either controls tiles:
                //1,5,9 or 3,5,7
                return true;
            }
            else
            {
                //No victory condition
                return false;
            }
        }

        #endregion

        /// <summary>
        /// Check each gameTile to see if the match is a draw.
        /// </summary>
        /// <returns></returns>
        private bool CheckForDraw()
        {
            //TODO: Improve checking such that, once none of the victory conditions can be met, the game is declared
            //a draw

            for (int row = gameBoard.GetLowerBound(0); row <= gameBoard.GetUpperBound(0); row++)
            {
                for (int column = gameBoard.GetLowerBound(1); column <= gameBoard.GetUpperBound(1); column++)
                {
                    //Save a reference of the current gameTile
                    Button currentTile = gameBoard[row, column];

                    if (currentTile.Text.Equals(" "))
                    {
                        //Not all of the tiles have been claimed yet,
                        //It is not a draw
                        return false;
                    }
                }
            }

            //All tiles have been claimed, but no one has won
            //It is a draw
            return true;
        }
        #endregion

    }
}
