using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Tests
{
    public class IInventoryTests
    {
        [Fact]
        public void Number_Read_ShouldReturnExpectedValue()
        {
            // Arrange
            IInventory item = new Computer();

            // Act & Assert
            Assert.Equal(1, item.Number);
        }
    }
}
