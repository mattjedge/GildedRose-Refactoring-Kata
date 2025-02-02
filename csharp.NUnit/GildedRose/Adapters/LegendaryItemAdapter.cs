namespace GildedRoseKata.Adapters;

public class LegendaryItemAdapter(Item item) : StockItem(item)
{
    public override void ApplyQualityRules()
    {
        // No degradation for Legendary items
    }

    public override void UpdateSellIn()
    {
        // Always desired
    }
}
