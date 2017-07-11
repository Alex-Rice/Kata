using System.Runtime.Serialization.Formatters;

namespace GildedRose.Managers
{
    class AgedBrie : ItemManager
    {
        protected override void Update()
        {
            Item.Quality += 1;
            Item.SellIn -= 1;
            if (Item.SellIn < 0)
            {
                Item.Quality += 1;
            }
        }
    }
}
