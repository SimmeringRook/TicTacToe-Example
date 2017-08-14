namespace Localization.SupportedLanguages
{
    internal class English : Language, IReadable
    {
        public void Read(string fileName)
        {
            //TODO:: replace with reading in from file
            newGame = "New Game";

            drawMessage = "The match ends in a draw!";
            victoryMessage = " is victorious!";

            playerOneMark = "X";
            playerTwoMark = "O";

            playerTurnMessage = "'s turn";

        }
    }
}
