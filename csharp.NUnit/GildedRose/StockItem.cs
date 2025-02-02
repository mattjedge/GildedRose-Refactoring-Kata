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
        _item.DecreaseQualityBy(1);

        if (_item.SellIn <= 0)
        {
            _item.DecreaseQualityBy(1);
        }
    }

    public virtual void UpdateSellIn()
    {
        _item.SellIn -= 1;
    }
}
