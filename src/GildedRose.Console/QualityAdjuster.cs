using System.Runtime.Serialization.Formatters;

namespace GildedRose.Console
{
    internal static class QualityAdjuster
    {
        public static void UpdateItemQuality(Item item)
        {
            if (IsDegradeableItemType(item))
            {
                if (CanBeDegradable(item))
                {
                    DegradeItem(item);
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (IsDegradeableItemType(item))
                        {
                            if (CanBeDegradable(item))
                            {
                                DegradeItem(item);
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        private static void DegradeItem(Item item)
        {
            item.Quality = item.Quality - 1;
            if (item.Name.Contains("Conjured"))
            {
                item.Quality = item.Quality - 1;
            }

        }

        private static bool CanBeDegradable(Item item)
        {
            return item.Quality > 0;
        }

        private static bool IsDegradeableItemType(Item item)
        {
            return item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros";
        }
    }
}