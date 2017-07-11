using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void NameStaysInvariantTest()
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "foo", SellIn = 0, Quality = 0}
            };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual("foo", Items[0].Name);
        }

        [TestCase(10)]
        [TestCase(-10)]
        public void SulfurasQualityStaysInvariant(int sellIn)
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(10,Items[0].Quality);
        }

        [TestCase(10)]
        [TestCase(-10)]
        public void SulfurasSellInStaysInvariant(int sellIn)
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(sellIn, Items[0].SellIn);
        }

        [Test]
        public void CheckQualityDegradesByOne()
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "foo", SellIn = 10, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(9, Items[0].Quality);
        }

        [TestCase("foo")]
        [TestCase("Aged Brie")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert")]
        public void CheckSellInDecreasesByOne(string name)
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = name, SellIn = 10, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(9, Items[0].SellIn);
        }

        [Test]
        public void CheckQualityIsBoundedBelowByZero()
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "foo", SellIn = 10, Quality = 10 }
            };
            GildedRose app = new GildedRose(Items);

            // Act
            for (int ii = 0; ii < 50; ii++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.GreaterOrEqual(Items[0].Quality,0);
        }

        [Test]
        public void CheckQualityIsBoundedAboveByFifty()
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 10 },
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 50, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);

            // Act
            for (int ii = 0; ii < 50; ii++)
            {
                app.UpdateQuality();
            }

            // Assert
            Assert.LessOrEqual(Items[0].Quality, 50);
            Assert.LessOrEqual(Items[1].Quality, 50);
        }

        [Test]
        public void AgedBrieIncreasesQualityByOneOnUpdate()
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 10 },
            };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(11,Items[0].Quality);
        }

        [TestCase(50, 11)]
        [TestCase(10,12)]
        [TestCase(5,13)]
        [TestCase(0,0)]
        public void TicketQualityCorrectlyUpdatesOnValuesGiven(int sellIn, int quality)
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 10},
            };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(quality,Items[0].Quality);
        }

        [Test]
        public void ConjuredSulfurasTestDoesNotModifySellInAndQuality()
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Conjured Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10},
                new Item {Name = "Conjured Sulfuras, Hand of Ragnaros", SellIn = -10, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(10, Items[0].Quality);
            Assert.AreEqual(10, Items[1].Quality);
        }

        [TestCase(10,8)]
        [TestCase(-10,6)]
        public void ConjuredItemsDecreaseQualityByCorrectAmount(int sellIn, int finalQuality)
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Conjured foo", SellIn = sellIn, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(finalQuality,Items[0].Quality);
        }

        [Test]
        public void ConjuredIncreasingItemsIncreaseByCorrectAmmount()
        {
            // Arrange
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10},
                new Item {Name = "Conjured Aged Brie", SellIn = 10, Quality = 10},
            };
            GildedRose app = new GildedRose(Items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.AreEqual(16, Items[0].Quality);
            Assert.AreEqual(12, Items[1].Quality);
        }
    }
}
