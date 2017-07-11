﻿namespace GildedRose.Managers
{
    class ItemManager
    {
        public static ItemManager Factory(Item item)
        {
            ItemManager ret;
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    ret = new Sulfuras {Item = item};
                    break;
                case "Aged Brie":
                    ret = new AgedBrie {Item = item};
                    break;
                default:
                    ret = new ItemManager {Item = item};
                    break;
            }
            return ret;
        }

        public Item Item { get; set; }

        public virtual void Update()
        {
            if (Item.Name != "Aged Brie" && Item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                Item.Quality = Item.Quality - 1;
            }
            else
            {
                Item.Quality = Item.Quality + 1;

                if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Item.SellIn < 11)
                    {
                        Item.Quality = Item.Quality + 1;
                    }

                    if (Item.SellIn < 6)
                    {
                        Item.Quality = Item.Quality + 1;
                    }
                }
            }


            Item.SellIn = Item.SellIn - 1;


            if (Item.SellIn < 0)
            {
                if (Item.Name != "Aged Brie")
                {
                    if (Item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        Item.Quality = Item.Quality - 1;
                    }
                    else
                    {
                        Item.Quality = Item.Quality - Item.Quality;
                    }
                }
                else
                {
                    Item.Quality = Item.Quality + 1;
                }
            }

            if (Item.Quality < 0)
            {
                Item.Quality = 0;
            }
            if (Item.Quality > 50)
            {
                Item.Quality = 50;
            }
        }
    }
}
