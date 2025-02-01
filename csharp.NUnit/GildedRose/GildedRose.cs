using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }
            else if (item.Name == "Aged Brie")
            {
                IncreaseQualityToMaxOf50(item);
                DecreaseSellIn(item);
                continue;
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpcomingEventQualityApplier(item);
                continue;
            }
            else
            {
                DecreaseQualityToMinOf0(item);                
                DecreaseSellIn(item);
            }
        }
    }

    private void UpcomingEventQualityApplier(Item item)
    {
        IncreaseQualityToMaxOf50(item);
        if (item.SellIn < 11)
        {
            IncreaseQualityToMaxOf50(item);
        }
        if (item.SellIn < 6)
        {
            IncreaseQualityToMaxOf50(item);
        }
        if (item.SellIn <= 0)
        {
            item.Quality = 0;
        }
        DecreaseSellIn(item);
    }

    private void DecreaseSellIn(Item item)
    {
        item.SellIn -= 1;
    }

    private void DecreaseQualityToMinOf0(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }
        if (item.SellIn <= 0)
        {
            item.Quality -= 1;
        }
    }

    private void IncreaseQualityToMaxOf50(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }
    }
}