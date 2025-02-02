namespace GildedRoseKata.Adapters;

public class AgedItemAdapter(Item item) : StockItem(item)
{
    private readonly Item _item = item;

    public override void ApplyQualityRules()
    {
        _item.IncreaseQualityBy(1);
        if (_item.SellIn < 0)
        {
            _item.IncreaseQualityBy(1);
        }
    }
}
