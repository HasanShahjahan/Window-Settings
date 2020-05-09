using System;
using WindowSettings.Utilities;
using WindowSettings.Validation;
using Xunit;

namespace WindowSettings.UnitTest
{
    public class ValidatorUnitTest
    {
        [Fact]
        public void ValidateFieldInput()
        {
            var validator = new WindowSettingsValidator();
            var result = validator.ValidateInput("Name", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);
            Assert.Equal(string.Format(ResourceFile.CanNotBeEmpty,"Custom Name"), result);
        }

        [Fact]
        public void ValidateValueCanNotBeOutsideMinimumOrMaximum()
        {
            var validator = new WindowSettingsValidator();
            var result = validator.ValidateInput("Start", string.Empty, "1", "2", string.Empty, "3", true);
            Assert.Equal(string.Format(ResourceFile.ValueCanNotBeOutside, "Minimum", "Maximum"), result);
        }

        [Fact]
        public void ValidateMiniumCanNotExceedMaximum()
        {
            var validator = new WindowSettingsValidator();
            var result = validator.ValidateInput("Minimum", string.Empty, "5", "4", string.Empty, string.Empty, true);
            Assert.Equal(string.Format(ResourceFile.CanNotExceed, "Minimum", "Maximum"), result);
        }

        [Fact]
        public void ValidateMaximumCanNotSmallerThanMinimum()
        {
            var validator = new WindowSettingsValidator();
            var result = validator.ValidateInput("Maximum", string.Empty, "2.15", "0.4", string.Empty, string.Empty, true);
            Assert.Equal(string.Format(ResourceFile.ValueCanNotBeSmallerThan, "Maximum", "Minimum"), result);
        }

        [Fact]
        public void ValidateDigitCanNotFraction()
        {
            var validator = new WindowSettingsValidator();
            var result = validator.ValidateInput("Digits", string.Empty, string.Empty, string.Empty, "2.15", string.Empty, true);
            Assert.Equal(string.Format(ResourceFile.IsNotAllowed, "Fraction"), result);
        }
    }
}
