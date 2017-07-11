using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace GildedRose.Managers
{
    class Ticket : ItemManager
    {
        public override void Update()
        {
            Item.SellIn -= 1;
            if (Item.SellIn < 0)
            {
                Item.Quality = 0;
            }
            else if (Item.SellIn < 5)
            {
                Item.Quality += 3;
            }
            else if (Item.SellIn < 10)
            {
                Item.Quality += 2;
            }
            else
            {
                Item.Quality += 1;
            }
        }
    }
}
