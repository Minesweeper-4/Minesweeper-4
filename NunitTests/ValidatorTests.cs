namespace NunitTests
{
    using System;
    using Minesweeper.Helpers;
    using NUnit.Framework;

    /// <summary>
    /// Validator Tests
    /// </summary>
    [TestFixture]
    public class ValidatorTests
    {
        /// <summary>
        /// Validate whether an empty string passes NULL and throws an Exception
        /// </summary>
        [Test]
        public void ValidateNonEmptyStringsThrowsArgumentExceptionWhenPassingNull()
        {
            string parameter = null;
            Assert.Throws(typeof(ArgumentNullException), () => Validator.ValidateNonEmptyString(parameter, "something"));
        }

        /// <summary>
        /// Validate whether an empty string passes empty string and throws an Exception
        /// </summary>
        [Test]
        public void ValidateNonEmptyStringsThrowsArgumentExceptionWhenPassingEmptyString()
        {
            string parameter = string.Empty;
            Assert.Throws(typeof(ArgumentNullException), () => Validator.ValidateNonEmptyString(parameter, "something"));
        }

        /// <summary>
        /// Passes the dimensions of the passed parameter
        /// </summary>
        /// <param name="value">pass the input</param>
        /// <param name="minLength">pass the minimal size for the input</param>
        /// <param name="maxLength">pass the maximum size for the input</param>
        [TestCase("a", 3, 10)]
        [TestCase("aa", 3, 10)]
        [TestCase("a1a2a3a4a5", 3, 9)]
        public void ValidateStringLengthThrowsExceptionWhenPassingTooLongOrTooShortString(string value, int minLength, int maxLength)
        {
            string parameterName = "ParameterName";
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Validator.ValidateStringLength(value, minLength, maxLength, parameterName));
        }

        /// <summary>
        /// Passes the dimensions of the passed parameter, and throws if empty or NULL
        /// </summary>
        /// <param name="value">pass the input</param>
        /// <param name="minLength">pass the minimal size for the input</param>
        /// <param name="maxLength">pass the maximum size for the input</param>        
        [TestCase("", 0, 4)] // Doesn't work with String.Empty
        [TestCase(null, 0, 4)]
        public void ValidateStringLengthThrowsProperExceptionWhenPassingEmptyOrNullString(string value, int minLength, int maxLength)
        {
            string parameterName = "ParameterName";
            Assert.Throws(typeof(ArgumentNullException), () => Validator.ValidateStringLength(value, minLength, maxLength, parameterName));
        }

        /// <summary>
        /// Passes the dimensions of the passed parameter, and throws if too low or too high
        /// </summary>
        /// <param name="value">pass the input</param>
        /// <param name="minValue">pass the minimal size for the input</param>
        /// <param name="maxValue">pass the maximum size for the input</param>   
        [TestCase(2, 1, 4)]
        [TestCase(-1, -2, 0)]
        public void ValidateIntInRangeThrowsProperExceptionWhenPassingTooLowOrTooHighNumber(int value, int minValue, int maxValue)
        {
            string parameterName = "ParameterName";
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Validator.ValidateIntInRange(value, minValue, minValue, parameterName));
        }

        /// <summary>
        /// Validate if the input is the right range, acts normally 
        /// </summary>
        [Test]
        public void ValidateIntInRangeShouldNotThrowWhenPassingValidData()
        {
            string parameterName = "ParameterName";
            int value = 5;
            int minValue = 2;
            int maxValue = 10;
            Assert.DoesNotThrow(() => Validator.ValidateIntInRange(value, minValue, maxValue, parameterName));
        }

        /// <summary>
        /// Validates if negative numbers is passed, throws
        /// </summary>
        /// <param name="value">passed negative number check</param>
        [TestCase(-1)]
        public void ValidateNonNegativeThrowsProperExceptionWhennegativeNumber(int value)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Validator.ValidateNonNegativeInt(value));
        }
    }
}