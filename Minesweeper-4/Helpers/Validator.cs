namespace Minesweeper.Helpers
{
    using System;

    /// <summary>
    /// Class used for validating all user inputs
    /// </summary>
    public static class Validator
    {
        public static void ValidateNonEmptyString(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(string.Format("{0} must be a non-empty string", parameterName));
            }
        }

        public static void ValidateStringLength(string value, int minLength, int maxLength, string parameterName)
        {
            Validator.ValidateNonEmptyString(value, parameterName);

            if (value.Length < minLength || maxLength < value.Length)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} length must be between {1} and {2}", parameterName, minLength, maxLength));
            }
        }

        public static void ValidateIntInRange(int value, int minValue, int maxValue, string parameterName)
        {
            if (value < minValue || maxValue < value)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} must be between {1} nad {2}", parameterName, minValue, maxValue));
            }
        }

        public static void ValidateNonNegativeInt(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} cannot be negative", number));
            }
        }
    }
}