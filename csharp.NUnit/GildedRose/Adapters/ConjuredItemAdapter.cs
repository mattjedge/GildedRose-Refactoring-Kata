﻿namespace GildedRoseKata.Adapters
{
    public class ConjuredItemAdapter(Item item) : StockItem(item)
    {
        private readonly Item _item = item;

        public override void ApplyQualityRules()
        {
            if (_item.SellIn > 0)
            {
                _item.DecreaseQualityBy(2);
            }

            if (_item.SellIn <= 0)
            {
                _item.DecreaseQualityBy(4);
            }
        }
    }
}
