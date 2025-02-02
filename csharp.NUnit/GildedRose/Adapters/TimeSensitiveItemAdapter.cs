namespace GildedRoseKata.Adapters;

public class TimeSensitiveItemAdapter : StockItem
{
    private readonly Item _item;
    public TimeSensitiveItemAdapter(Item item) : base(item)
    {
        _item = item;
    }

    public override void ApplyQualityRules()
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
}
