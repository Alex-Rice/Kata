namespace GildedRose.Managers
{
    class ItemManager
    {
        public Item Item { get; set; }
        public bool Bounded { get; set; } = true;

        public virtual void Update()
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
            if (Bounded)
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
