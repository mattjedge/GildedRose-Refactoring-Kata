using GildedRoseKata.Adapters;

namespace GildedRoseKata;

public abstract class StockItem : IItemQualityAdapter
{
    private readonly Item _item;

    public StockItem(Item item)
    {
        _item = item;
    }
    public virtual void ApplyQualityRules()
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

    public virtual void UpdateSellIn()
    {
        _item.SellIn -= 1;
    }
}
