namespace GildedRoseKata.Adapters;

public class AgedItemAdapter : StockItem
{
    private readonly Item _item;
    public AgedItemAdapter(Item item) : base(item)
    {
        _item = item;
    }

    public override void ApplyQualityRules()
    {
        if (_item.Quality < 50)
        {
            _item.Quality += 1;
        }
    }
}
