using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class UpdateQualityDegradableItemTests
    {
        private const int HighPositiveQuality = 4;
        private const int HighPositiveSellIn = 5;
        private const string StandardObjectType = "new object";
        private const int NegativeSellIn = -1;

        [TestCase(HighPositiveQuality, HighPositiveSellIn, ExpectedResult = HighPositiveQuality - 1)]
        [TestCase(0, HighPositiveSellIn, ExpectedResult = 0)]
        [TestCase(HighPositiveQuality, NegativeSellIn, ExpectedResult = HighPositiveQuality - 2)]
        [TestCase(0, NegativeSellIn, ExpectedResult = 0)]
        public int StandardItemQualityChangedTo(int quality, int sellIn)
        {
            return GetUpdatedItemQuality(StandardObjectType, quality, sellIn);
        }

        [TestCase(HighPositiveQuality, HighPositiveSellIn, ExpectedResult = HighPositiveQuality - 2)]
        [TestCase(HighPositiveQuality, NegativeSellIn, ExpectedResult = HighPositiveQuality - 4)]
        [TestCase(1, HighPositiveSellIn, ExpectedResult = 0, Description = "Quality should never drop below zero")]
        public int ConjuredItemQualityChangedTo(int quality, int sellIn)
        {
            return GetUpdatedItemQuality("Conjured " + StandardObjectType, quality, sellIn);
        }

        private static int GetUpdatedItemQuality(string name, int quality, int sellIn)
        {
            var item = new Item {Name = name, Quality = quality, SellIn = sellIn};
            QualityAdjuster.UpdateItemQuality(item);
            return item.Quality;
        }
    }
}