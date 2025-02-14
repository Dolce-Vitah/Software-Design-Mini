using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Animals;
using MoscowZooAccounting.Items;
using MoscowZooAccounting.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZooAccounting.Tests
{
    public class InventoryCountInformerTests
    {
        [Fact]
        public void GetInfo_ShouldReturnExpectedString()
        {
            // Arrange
            var inventoryStorage = Substitute.For<IInventoryStorageProvider>();
            var inventories = new List<IInventory>();
            inventoryStorage.GetInventories.Returns(inventories);
            string expectedResult = "The list of the zoo's invetories:\n";

            var inventoryCountInformer = new InventoryCountInformer(inventoryStorage);

            // Act
            string result = inventoryCountInformer.GetInfo();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
