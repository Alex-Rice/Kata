using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture()]
    public class GildedRoseTest
    {
        [Test()]
        public void NameTest()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "foo", SellIn = 0, Quality = 0}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test()]
        public void SulfurasQuality()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -10, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(10,Items[0].Quality);
            Assert.AreEqual(10,Items[1].Quality);
        }

        [Test()]
        public void SulfurasSellIn()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -10, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(10, Items[0].SellIn);
            Assert.AreEqual(-10, Items[1].SellIn);
        }

        [Test()]
        public void QualityDegrade()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "foo", SellIn = 10, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].Quality);
        }

        [Test()]
        public void SellInReduce()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "foo", SellIn = 10, Quality = 10 },
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 10 },
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }

        [Test()]
        public void QualityNegativeCheck()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "foo", SellIn = 10, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);
            for (int ii = 0; ii < 50; ii++)
            {
                app.UpdateQuality();
            }
            Assert.GreaterOrEqual(Items[0].Quality,0);
        }

        [Test()]
        public void QualityCapCheck()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 10 },
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 50, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);
            for (int ii = 0; ii < 50; ii++)
            {
                app.UpdateQuality();
            }
            Assert.LessOrEqual(Items[0].Quality, 50);
            Assert.LessOrEqual(Items[1].Quality, 50);
        }

        [Test()]
        public void AgedBrie()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 10 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11,Items[0].Quality);
        }

        [Test()]
        public void TicketQuality()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 50, Quality = 10},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10},
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11,Items[0].Quality);
            Assert.AreEqual(12,Items[1].Quality);
            Assert.AreEqual(13,Items[2].Quality);
            Assert.AreEqual(0,Items[3].Quality);
        }
    }
}
