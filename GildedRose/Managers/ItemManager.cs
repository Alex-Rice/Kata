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
                case "Backstage passes to a TAFKAL80ETC concert":
                    ret = new Ticket {Item = item};
                    break;
                default:
                    ret = new ItemManager {Item = item};
                    break;
            }
            return ret;
        }

        public Item Item { get; set; }
        protected bool bounded = true;

        protected virtual void Update()
        {
            Item.Quality = Item.Quality - 1;


            Item.SellIn = Item.SellIn - 1;


            if (Item.SellIn < 0)
            {
                Item.Quality = Item.Quality - 1;
            }
        }

        private void CheckBounds()
        {
            if (bounded)
            {
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

        public void UpdateAndCheckBounds()
        {
            Update();
            CheckBounds();
        }
    }
}
