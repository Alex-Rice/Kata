using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    class GildedRose
    {
        private IList<Item> Items;
        private IEnumerable<ItemManager> Managers;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            Managers = Items.Select(ItemManager.Factory);
        }

        public void UpdateQuality()
        {
            foreach (var im in Managers)
            {
                im.Update();
            }
        }
    }
}