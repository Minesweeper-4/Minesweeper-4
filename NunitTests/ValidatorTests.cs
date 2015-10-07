using Minesweeper.Helpers;
using NUnit.Framework;
using System;

namespace NunitTests
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void ValidateNonEmptyStringsThrowsArgumentExceptionWhenPassingNull()
        {
            string parameter = null;
            Assert.Throws(typeof(ArgumentNullException), () => Validator.ValidateNonEmptyString(parameter, "something"));
        }

        [Test]
        public void ValidateNonEmptyStringsThrowsArgumentExceptionWhenPassingEmptyString()
        {
            string parameter = String.Empty;
            Assert.Throws(typeof(ArgumentNullException), () => Validator.ValidateNonEmptyString(parameter, "something"));
        }

        [TestCase("a", 3, 10)]
        [TestCase("aa", 3, 10)]
        [TestCase("a1a2a3a4a5", 3, 9)]
        public void ValidateStringLengthThrowsExceptionWhenPassingTooLongOrTooShortString(string value, int minLength, int maxLength)
        {
            string parameterName = "ParameterName";
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Validator.ValidateStringLength(value, minLength, maxLength, parameterName));
        }
                
        [TestCase("", 0, 4)] //Doesn't work with String.Empty
        [TestCase(null, 0, 4)]
        public void ValidateStringLengthThrowsProperExceptionWhenPassingEmptyOrNullString(string value, int minLength, int maxLength)
        {
            string parameterName = "ParameterName";
            Assert.Throws(typeof(ArgumentNullException), () => Validator.ValidateStringLength(value, minLength, maxLength, parameterName));
        }
    
        [TestCase(2, 1, 4)]
        [TestCase(-1, -2, 0)]
        public void ValidateIntInRangeThrowsProperExceptionWhenPassingTooLowOrTooHighNumber(int value, int minValue, int maxValue)
        {
            string parameterName = "ParameterName";
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Validator.ValidateIntInRange(value, minValue, minValue, parameterName));
        }

        [Test]
        public void ValidateIntInRangeShouldNotThrowWhenPassingValidData()
        {
            string parameterName = "ParameterName";
            int value = 5;
            int minValue = 2;
            int maxValue = 10;
            Assert.DoesNotThrow(() => Validator.ValidateIntInRange(value, minValue, maxValue, parameterName));
        }

        [TestCase(-1)]
        public void ValidateNonNegativeThrowsProperExceptionWhennegativeNumber(int value)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => Validator.ValidateNonNegativeInt(value));
        }
    }
}