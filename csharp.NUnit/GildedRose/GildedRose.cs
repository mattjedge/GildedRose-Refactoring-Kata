using System.Collections.Generic;

namespace GildedRoseKata;

public interface IItemQualityAdapter
{
    public void ApplyQualityRules();
    public void UpdateSellIn();
}

public class NormalItemAdapter : IItemQualityAdapter
{
    private readonly Item _item;

    public NormalItemAdapter(Item item)
    {
        _item = item;
    }

    public void UpdateSellIn()
    {
        _item.SellIn -= 1;
    }

    public void ApplyQualityRules()
    {
        if (_item.Quality > 0)
        {
            _item.Quality -= 1;
        }
        if (_item.Quality > 0 && _item.SellIn <= 0)
        {
            _item.Quality -= 1;
        }
    }
}

public class LegendaryItemAdapter : IItemQualityAdapter
{
    private readonly Item _item;
    public LegendaryItemAdapter(Item item)
    {
        _item = item;
    }

    public void ApplyQualityRules()
    {
        // No degradation for Legendary items
    }

    public void UpdateSellIn()
    {
        // Always desired
    }
}

public class AgedItemAdapter : IItemQualityAdapter
{
    private readonly Item _item;
    public AgedItemAdapter(Item item)
    {
        _item = item;
    }

    public void ApplyQualityRules()
    {
        if (_item.Quality < 50)
        {
            _item.Quality += 1;
        }
    }

    public void UpdateSellIn()
    {
        _item.SellIn -= 1;
    }
}

public class TimeSensitiveItemAdapter : IItemQualityAdapter
{
    private readonly Item _item;
    public TimeSensitiveItemAdapter(Item item)
    {
        _item = item;
    }

    public void ApplyQualityRules()
    {
        if (_item.Quality < 50)
        {
            _item.Quality += 1;
        }
        if (_item.Quality < 50 && _item.SellIn < 11)
        {
            _item.Quality += 1;
        }
        if (_item.Quality < 50 && _item.SellIn < 6)
        {
            _item.Quality += 1;
        }
        if (    _item.SellIn <= 0)
        {
            _item.Quality = 0;
        }
    }

    public void UpdateSellIn()
    {
        _item.SellIn -= 1;
    }
}


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