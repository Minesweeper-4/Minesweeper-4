namespace Minesweeper.Helpers
{
    using System;

    /// <summary>
    /// Class used for validating all user inputs
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validate if a given string has an empty value. If the string is empty throws an ArgumentNullException.
        /// </summary>
        /// <param name="value">Input string to be validated.</param>
        /// <param name="parameterName">The name of the validating parameter for the error message.</param>
        public static void ValidateNonEmptyString(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(string.Format("{0} must be a non-empty string", parameterName));
            }
        }

        /// <summary>
        /// Validate if a given string has length between two values. 
        /// </summary>
        /// <param name="value">Input string to be validated.</param>
        /// <param name="minLength">Minimum length value.</param>
        /// <param name="maxLength">Maximum length value.</param>
        /// <param name="parameterName">The name of the validating parameter for the error message.</param>
        public static void ValidateStringLength(string value, int minLength, int maxLength, string parameterName)
        {
            Validator.ValidateNonEmptyString(value, parameterName);

            if (value.Length < minLength || maxLength < value.Length)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} length must be between {1} and {2}", parameterName, minLength, maxLength));
            }
        }

        /// <summary>
        /// Validate if given integeer is between two values.
        /// </summary>
        /// <param name="value">Input integeer to be validated.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Maximum value.</param>
        /// <param name="parameterName">The name of the validating parameter for the error message.</param>
        public static void ValidateIntInRange(int value, int minValue, int maxValue, string parameterName)
        {
            if (value < minValue || maxValue < value)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} must be between {1} nad {2}", parameterName, minValue, maxValue));
            }
        }

        /// <summary>
        /// Validate if given integeer has a negative value.
        /// </summary>
        /// <param name="number">The name of the validating parameter for the error message.</param>
        public static void ValidateNonNegativeInt(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} cannot be negative", number));
            }
        }
    }
}