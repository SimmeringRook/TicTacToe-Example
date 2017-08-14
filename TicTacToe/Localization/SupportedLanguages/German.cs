namespace Localization.SupportedLanguages
{
    internal class German : Language, IReadable
    {
        public void Read(string fileName)
        {
            //TODO:: replace with reading in from file
            newGame = "Neues Spiel";

            drawMessage = "Der Spiel endet in einem Unentschieden!";
            victoryMessage = " ist siegreich!";

            playerOneMark = "X";
            playerTwoMark = "O";

            playerTurnMessage = "'s dran";
        }
    }
}
