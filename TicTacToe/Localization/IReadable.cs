namespace Localization
{

    /// <summary>
    /// Interface for reading information in from a textfile.
    /// </summary>
    internal interface IReadable
    {
        /// <summary>
        /// Parses strings from <paramref name="fileName"/> for use with <see cref="Language"/>.
        /// </summary>
        /// <param name="fileName">Name of the Language File.</param>
        void Read(string fileName);
    }
}
