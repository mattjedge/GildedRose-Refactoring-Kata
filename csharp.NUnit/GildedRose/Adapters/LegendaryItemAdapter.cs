namespace GildedRoseKata.Adapters;

public class LegendaryItemAdapter(Item item) : StockItem(item)
{
    private readonly Item _item = item;

    public override void ApplyQualityRules()
    {
        _item.DecreaseQualityBy(0);        
    }

    public override void UpdateSellIn()
    {
        // Always desired
    }
}
