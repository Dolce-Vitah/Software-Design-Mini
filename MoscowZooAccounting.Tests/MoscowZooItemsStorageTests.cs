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
    public class MoscowZooItemsStorageTests
    {
        [Theory]
        [MemberData(nameof(GetThingsForAddItemsTest))]
        public void AddItem_CheckAddsThings(List<Thing> items, int count)
        {
            // Arrange
            var itemsStorage = Substitute.For<MoscowZooItemsStorage>();            

            // Act
            items.ForEach(item => itemsStorage.AddItem(item));

            // Assert
            Assert.Equal(count, itemsStorage.GetItems.Count);
        }

        public static IEnumerable<object[]> GetThingsForAddItemsTest()
        {
            yield return new object[]
            {
                new List<Thing>()
                {
                    new Computer(),
                    new Table()
                },
                2
            };
        }
    }
}
