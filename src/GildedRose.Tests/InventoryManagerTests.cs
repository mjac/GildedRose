using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class InventoryManagerTests
    {
        [Test]
        public void WhenNormalItemsEndOfDayThenUpdateShouldReduceSellInAndQuality()
        {
            int sellIn = 10;
            int quality = 20;

            var item = new Item {Name = "Test Name", SellIn = sellIn, Quality = quality};
            var items = new List<Item>
            {
                item
            };

            var app = new InventoryManager(items);

            app.UpdateInventory();
            Assert.AreEqual(--sellIn, item.SellIn);
            Assert.AreEqual(--quality, item.Quality);
        }
    }
}