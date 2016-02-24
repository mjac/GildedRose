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

            var item = new Item { Name = "Test Name", SellIn = sellIn, Quality = quality };
            var items = new List<Item>{item};

            var target = new InventoryManager(items);
            target.UpdateInventory();

            Assert.AreEqual(sellIn-1, item.SellIn);
            Assert.AreEqual(quality-1, item.Quality);
        }

        [Test]
        public void WhenConjuredItemThenUpdateShouldReduceQualityTwiceAsFast()
        {
            int sellIn = 10;
            int quality = 20;

            var item = new Item { Name = "Conjured Thing", SellIn = sellIn, Quality = quality };
            var items = new List<Item>{item};

            var target = new InventoryManager(items);
            target.UpdateInventory();

            Assert.AreEqual(sellIn-1, item.SellIn);
            Assert.AreEqual(quality-2, item.Quality);
        }
    }
}