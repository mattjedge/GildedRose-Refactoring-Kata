namespace GildedRoseKata.Adapters;

public class TimeSensitiveItemAdapter(Item item) : StockItem(item)
{
    private readonly Item _item = item;

    public override void ApplyQualityRules()
    {
        _item.IncreaseQualityBy(1);
        if (_item.SellIn < 11)
        {
            _item.IncreaseQualityBy(1);
        }
        if ( _item.SellIn < 6)
        {
            _item.IncreaseQualityBy(1);
        }
        if (_item.SellIn <= 0)
        {
            _item.Quality = 0;
        }
    }
}
