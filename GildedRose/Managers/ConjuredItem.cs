using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Managers
{
    class ConjuredItem : ItemManager
    {
        private ItemManager BaseManager;
        public ConjuredItem(ItemManager baseManager)
        {
            Item = baseManager.Item;
            Bounded = baseManager.Bounded;
            BaseManager = baseManager;
        }

        public override void Update()
        {
            var qualityBefore = Item.Quality;
            BaseManager.Update();
            var qualityAfter = Item.Quality;
            Item.Quality = qualityBefore + (qualityAfter - qualityBefore) * 2;
        }
    }
}
