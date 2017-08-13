using System;
using System.Windows.Forms;

namespace TicTacToe
{
    internal class TicTacToeEngine
    {
        #region GameBoard Management
        private Button[,] gameBoard;

        /// <summary>
        /// Assign the GameBoard to the Engine.
        /// </summary>
        /// <param name="gameBoard"></param>
        internal void Initialize(Button[,] gameBoard)
        {
            this.gameBoard = gameBoard;
        }


        /// <summary>
        /// Ensure all tiles are reset and enabled for a new match
        /// </summary>
        internal void InitializeNewGame()
        {
            CurrentPlayerMark = player1Mark;
            ToggleGameBoard(isEnabled: true);
            ResetGameBoard();
        }

        /// <summary>
        /// Sets the "Enabled" property on each gameTile to the value of "isEnabled".
        /// </summary>
        /// <param name="isEnabled"></param>
        internal void ToggleGameBoard(bool isEnabled)
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
                    gameBoard[row, column].Enabled = isEnabled;
                }
            }
        }

        /// <summary>
        /// Reset each gameTile to an empty state.
        /// </summary>
        internal void ResetGameBoard()
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

        #region String Helper Functions/Variables
        private string player1Mark = "X";
        private string player2Mark = "O";

        internal string CurrentPlayerMark
        {
            get;

            private set;
            /* While it is not used at this time, I want to restrict
             * the setting of CurrentPlayerMark to be something that
             * can only be done by the Engine. The form should never
             * have the chance to override what the Engine will do.
             */
        }

        /// <summary>
        /// Returns the Victory message.
        /// </summary>
        /// <returns></returns>
        internal string GetVictoryMessage()
        {
            return CurrentPlayerMark + " is victorious!";
        }

        /// <summary>
        /// Returns the Draw message.
        /// </summary>
        /// <returns></returns>
        internal string GetDrawMessage()
        {
            return "The match ends in a draw!";
        }

        /// <summary>
        /// Returns whose turn it currently is.
        /// </summary>
        /// <returns></returns>
        internal string GetPlayerTurnMessage()
        {
            return CurrentPlayerMark + "'s turn";
        }
        #endregion

        /// <summary>
        /// Change Marks between player 1 and player 2
        /// </summary>
        private void ChangePlayers()
        {
            //If it is currently player 1's turn; switch to player 2
            if (CurrentPlayerMark.Equals(player1Mark))
            {
                CurrentPlayerMark = player2Mark;
            }
            else
            {
                //switch to player 1
                CurrentPlayerMark = player1Mark;
            }

        }

        /// <summary>
        /// Check to see if Victory or Draw conditions have been met,
        /// otherwise, let the other player make a move.
        /// </summary>
        internal void NextTurn()
        {
            //Check to see if the current player has won
            if (HasCurrentPlayerWon())
            {
                //The current player has won

                //Disable the game board
                ToggleGameBoard(false);

                //Inform the players that the current player has won
                MessageBox.Show(GetVictoryMessage());
            }
            else if (CheckForDraw())
            {
                //There are no moves remaining

                //Disable the game board
                ToggleGameBoard(false);

                //Inform the players the match is over
                MessageBox.Show(GetDrawMessage());
            }
            else
            {
                //No one has won yet, change players
                ChangePlayers();
            }
        }

        #region Victory Condition
        /// <summary>
        /// Combines all Victory condition checking into one function.
        /// </summary>
        /// <returns></returns>
        private bool HasCurrentPlayerWon()
        {
            //While somewhat redundant, the language is more clear and
            //explicit in regards to what exactly is being checked in 
            //NextTurn() 
            if (CheckForHorizontalVictory())
                return true;

            if (CheckForVerticalVictory())
                return true;

            if (CheckForDiagonalVictory())
                return true;

            return false;
        }

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

                    if (currentTile.Text.Equals(CurrentPlayerMark) == false)
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

                    if (currentTile.Text.Equals(CurrentPlayerMark) == false)
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

                        if (currentTile.Text.Equals(CurrentPlayerMark) == false)
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

                        if (currentTile.Text.Equals(CurrentPlayerMark) == false)
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

                        if (currentTile.Text.Equals(CurrentPlayerMark) == false)
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

                        if (currentTile.Text.Equals(CurrentPlayerMark) == false)
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

        #region Defeat Condition
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
