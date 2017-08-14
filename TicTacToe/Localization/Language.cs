using System.Collections.Generic;

namespace Localization
{
    /// <summary>
    /// The outline that each supported language must follow and offer translations for. 
    /// <para>Note:
    /// All protected strings need to be assigned values via <see cref="IReadable.Read(string)"/>, in
    /// each new Language Sub-Class.</para>
    /// </summary>
    internal class Language : ILocalize
    {
        #region Controls
        //Form Controls
        protected static string newGame = "";

        #endregion

        protected static string drawMessage = "";
        protected static string victoryMessage = "";

        protected static string playerOneMark = "";
        protected static string playerTwoMark = "";

        protected static string playerTurnMessage = "";

        protected static List<string> rules = new List<string>();

        #region ILocalize
        public string GetDrawMessage()
        {
            return drawMessage;
        }

        public string GetPlayerOneMark()
        {
            return playerOneMark;
        }

        public string GetPlayerTwoMark()
        {
            return playerTwoMark;
        }

        public string GetPlayerTurnMessage()
        {
            return playerTurnMessage;
        }

        public List<string> GetRules()
        {
            return rules;
        }

        public string GetVictoryMessage()
        {
            return victoryMessage;
        }
        #endregion
    }
}
