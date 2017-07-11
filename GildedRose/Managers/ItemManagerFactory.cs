namespace GildedRose.Managers
{
    class ItemManagerFactory
    {
        public static ItemManager Factory(Item item)
        {
            ItemManager ret;
            bool conjured;
            string baseName;
            if (item.Name.StartsWith("Conjured "))
            {
                conjured = true;
                baseName = item.Name.Substring("Conjured ".Length);
            }
            else
            {
                conjured = false;
                baseName = item.Name;
            }
            switch (baseName)
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
            if (conjured)
            {
                return new ConjuredItem(ret);
            }
            else
            {
                return ret;
            }
        }
    }
}