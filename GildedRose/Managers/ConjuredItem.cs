using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Managers
{
    class ConjuredItem : ItemManager
    {
        public ConjuredItem(ItemManager baseManager)
        {
            Item = baseManager.Item;
            Bounded = baseManager.Bounded;
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
