namespace Minesweeper.Helpers
{
    /// <summary>
    /// Class that sets the error messages and saving the state and records of the game
    /// </summary>
    internal class GlobalErrorMessages
    {
        public const string NonEmptyString = "{0} must be a non-empty string";
        public const string StringLength = "{0} length must be between {1} and {2}";
        public const string SaveMatrixFileName = "save.dat";
        public const string SaveRecordstFileName = "records.dat";
    }
}
