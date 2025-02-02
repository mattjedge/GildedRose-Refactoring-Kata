namespace GildedRoseKata.Adapters;

public class LegendaryItemAdapter : StockItem
{
    private readonly Item _item;
    public LegendaryItemAdapter(Item item) : base(item)
    {
        _item = item;
    }

    public override void ApplyQualityRules()
    {
        // No degradation for Legendary items
    }

    public override void UpdateSellIn()
    {
        // Always desired
    }
}
