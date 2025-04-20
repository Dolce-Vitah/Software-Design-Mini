using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Animals;
using MoscowZooAccounting.Items;
using MoscowZooAccounting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Tests
{
    public class InventoryStorageTests
    {
        [Fact]
        public void AddInventory_ShouldReturnExpectedValue()
        {
            // Arrange
            var inventoryStorage = new InventoryStorage();
            var inventories = new List<IInventory>() { new Computer(), new Table(), new Tiger(8, 8) };
            int expectedResult = 3;

            // Act
            inventories.ForEach(inventory => inventoryStorage.AddInventory(inventory));
            int result = inventoryStorage.GetInventories.Count;

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
