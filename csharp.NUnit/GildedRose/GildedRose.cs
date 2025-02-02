using GildedRoseKata.Adapters;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    IDictionary<Item, IItemQualityAdapter> _itemDictionary;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
        _itemDictionary = new Dictionary<Item, IItemQualityAdapter>();
        foreach (var item in Items)
        {
            _itemDictionary[item] = AdapterFor(item);
        }
    }

    public IItemQualityAdapter AdapterFor(Item item)
    {
        if (item.Name == "Sulfuras, Hand of Ragnaros")
        {
            return new LegendaryItemAdapter(item);
        }
        else if (item.Name == "Aged Brie")
        {
            return new AgedItemAdapter(item);
        }
        else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            return new TimeSensitiveItemAdapter(item);
        }
        else
        {
            return new NormalItemAdapter(item);
        }
    }

    public void UpdateQuality()
    {
        foreach (var item in _itemDictionary)
        {
            item.Value.ApplyQualityRules();
            item.Value.UpdateSellIn();
        };
    }
}