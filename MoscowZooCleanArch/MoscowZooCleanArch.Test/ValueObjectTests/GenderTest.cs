using MoscowZooCleanArch.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooCleanArch.Test.ValueObjectTests
{
    public class GenderTest
    {
        [Fact]
        public void Gender_FromString_ShouldReturnCorrectGender()
        {
            // Act
            var maleGender = Gender.FromString("Male");
            var femaleGender = Gender.FromString("Female");

            // Assert
            Assert.Equal(Gender.Male, maleGender);
            Assert.Equal(Gender.Female, femaleGender);
        }

        [Fact]
        public void Gender_FromString_ShouldThrowArgumentExceptionForInvalidValue()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => Gender.FromString("Invalid"));
        }
    }
}
