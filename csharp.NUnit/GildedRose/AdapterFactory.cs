using GildedRoseKata.Adapters;

namespace GildedRoseKata;

public static class AdapterFactory
{  
    public static IItemQualityAdapter AdapterFor(Item item)
    {
        switch (item.Name)
        {
            case "Sulfuras, Hand of Ragnaros":
                return new LegendaryItemAdapter(item);
            case "Aged Brie":
                return new AgedItemAdapter(item);
            case "Backstage passes to a TAFKAL80ETC concert":
                return new TimeSensitiveItemAdapter(item);
            case "Conjured teapot":
                return new ConjuredItemAdapter(item);
            default:
                return new NormalItemAdapter(item);
        }
    }
}
