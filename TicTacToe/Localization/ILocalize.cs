using System.Collections.Generic;

namespace Localization
{
    /// <summary>
    /// Standardized functions for retreiving the different phrases for each supported language.
    /// </summary>
    internal interface ILocalize
    {
        string GetPlayerOneMark();
        string GetPlayerTwoMark();
        string GetVictoryMessage();

        string GetDrawMessage();

        string GetPlayerTurnMessage();

        List<string> GetRules();
    }
}
