using System;
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
            Assert.Equal("Custom Name can't be empty", result);
        }

        [Fact]
        public void ValidateValueCanNotBeOutsideMinimumOrMaximum()
        {
            var validator = new WindowSettingsValidator();
            var result = validator.ValidateInput("Start", string.Empty, "1", "2", string.Empty, "3", true);
            Assert.Equal("Value can't be outside minimum or maximum.", result);
        }

        [Fact]
        public void ValidateMiniumCanNotExceedMaximum()
        {
            var validator = new WindowSettingsValidator();
            var result = validator.ValidateInput("Minimum", string.Empty, "5", "4", string.Empty, string.Empty, true);
            Assert.Equal("Minium value can't exceed Maximum value.", result);
        }

        [Fact]
        public void ValidateMaximumCanNotSmallerThanMinimum()
        {
            var validator = new WindowSettingsValidator();
            var result = validator.ValidateInput("Maximum", string.Empty, "2.15", "0.4", string.Empty, string.Empty, true);
            Assert.Equal("Maximum value can't be smaller than Minimum value.", result);
        }
    }
}
