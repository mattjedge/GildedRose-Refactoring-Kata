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
            _itemDictionary[item] = AdapterFactory.AdapterFor(item);
        }
    }

    public void UpdateQuality()
    {
        foreach (var item in _itemDictionary.Values)
        {
            item.ApplyQualityRules();
            item.UpdateSellIn();
        };
    }
}