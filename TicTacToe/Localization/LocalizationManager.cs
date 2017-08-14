using Localization.SupportedLanguages;
using System.Collections.Generic;

namespace Localization
{
    /// <summary>
    /// Provides access to a language's phrases for use with Tic Tac Toe.
    /// <remark>Exemplifies the Strategy Design Pattern.</remark>
    /// </summary>
    public class LocalizationManager
    {
        //The Current Language
        internal ILocalize Localization;

        /// <summary>
        /// Class constructor.
        /// <remarks>Defaults to English.</remarks>
        /// </summary>
        /// <param name="languageToLocalizeTo">The Language which all messages and Form controls should display. <see cref="Languages"/> contains alls supported languages.</param>
        public LocalizationManager(Languages languageToLocalizeTo)
        {
            switch (languageToLocalizeTo)
            {
                case Languages.German:
                    Localization = new German();
                    break;
                default:
                    Localization = new English();
                    break;
            }

            ((IReadable)Localization).Read("");
        }

        /// <summary>
        /// Returns Player One's Mark for the current language.
        /// </summary>
        /// <returns>Returns Player One's Mark for the current language.</returns>
        public string GetPlayerOneMark()
        {
            return Localization.GetPlayerOneMark();
        }

        /// <summary>
        /// Returns Player Two's Mark for the current language.
        /// </summary>
        /// <returns></returns>
        public string GetPlayerTwoMark()
        {
            return Localization.GetPlayerTwoMark();
        }

        /// <summary>
        /// Returns the Victory message for the current language.
        /// </summary>
        /// <returns></returns>
        public string GetVictoryMessage()
        {
            return Localization.GetVictoryMessage();
        }

        /// <summary>
        /// Returns the Draw message for the current language.
        /// </summary>
        /// <returns></returns>
        public string GetDrawMessage()
        {
            return Localization.GetDrawMessage();
        }

        /// <summary>
        /// Returns Player's turn for the current language.
        /// </summary>
        /// <returns></returns>
        public string GetPlayerTurnMessage()
        {
            return Localization.GetPlayerTurnMessage();
        }

        /// <summary>
        /// Returns the rule set for the current language.
        /// </summary>
        /// <returns></returns>
        public List<string> GetRules()
        {
            return new List<string>();
        }
    }
}
