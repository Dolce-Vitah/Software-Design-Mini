using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Tests
{
    public class IAliveTests
    {
        [Fact]
        public void Food_Read_ShouldReturnExpectedValue()
        {
            // Arrange
            IAlive animal = new Tiger(10, 6);

            // Act & Assert
            Assert.Equal(10, animal.Food);
        }
    }
}
