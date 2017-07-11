using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    class ItemManager
    {
        public static ItemManager Factory(Item item)
        {
            return new ItemManager {Item = item};
        }
        public Item Item { get; set; }

        public void Update()
        {
            if (Item.Name != "Aged Brie" && Item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Item.Quality > 0)
                {
                    if (Item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Item.Quality = Item.Quality - 1;
                    }
                }
            }
            else
            {
                if (Item.Quality < 50)
                {
                    Item.Quality = Item.Quality + 1;

                    if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Item.SellIn < 11)
                        {
                            if (Item.Quality < 50)
                            {
                                Item.Quality = Item.Quality + 1;
                            }
                        }

                        if (Item.SellIn < 6)
                        {
                            if (Item.Quality < 50)
                            {
                                Item.Quality = Item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (Item.Name != "Sulfuras, Hand of Ragnaros")
            {
                Item.SellIn = Item.SellIn - 1;
            }

            if (Item.SellIn < 0)
            {
                if (Item.Name != "Aged Brie")
                {
                    if (Item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Item.Quality > 0)
                        {
                            if (Item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Item.Quality = Item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        Item.Quality = Item.Quality - Item.Quality;
                    }
                }
                else
                {
                    if (Item.Quality < 50)
                    {
                        Item.Quality = Item.Quality + 1;
                    }
                }
            }
        }
    }
}
