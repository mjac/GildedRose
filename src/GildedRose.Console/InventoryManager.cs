using System.Collections.Generic;

namespace GildedRose.Console
{
    public class InventoryManager
    {
        private const string _agedBrie = "Aged Brie";
        private const string _backstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string _sulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        private IList<Item> Items;

        public InventoryManager(IList<Item> items)
        {
            Items = items;
        }

        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = _agedBrie, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = _sulfurasHandOfRagnaros, SellIn = 0, Quality = 80},
                new Item
                {
                    Name = _backstagePass,
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new InventoryManager(items);

            app.UpdateInventory();

            System.Console.ReadKey();
        }

        public void UpdateInventory()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                bool isLessThanMaxQuality = item.Quality < 50;
                bool isGreaterThanMinQauality = item.Quality > 0;
                
                if (item.Name != _agedBrie && item.Name != _backstagePass)
                {
                    if (isGreaterThanMinQauality)
                    {
                        if (item.Name != _sulfurasHandOfRagnaros)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (isLessThanMaxQuality)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == _backstagePass)
                        {
                            if (item.SellIn < 11)
                            {
                                if (isLessThanMaxQuality)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (isLessThanMaxQuality)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != _sulfurasHandOfRagnaros)
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != _agedBrie)
                    {
                        if (item.Name != _backstagePass)
                        {
                            if (isGreaterThanMinQauality)
                            {
                                if (item.Name != _sulfurasHandOfRagnaros)
                                {
                                    item.Quality = item.Quality - 1;
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
                        if (isLessThanMaxQuality)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}