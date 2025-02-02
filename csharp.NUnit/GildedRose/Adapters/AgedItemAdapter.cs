namespace GildedRoseKata.Adapters;

public class AgedItemAdapter(Item item) : StockItem(item)
{
    private readonly Item _item = item;

    public override void ApplyQualityRules()
    {
        if (_item.Quality < 50)
        {
            _item.Quality += 1;
        }
    }
}
