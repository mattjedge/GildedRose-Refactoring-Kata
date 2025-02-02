namespace GildedRoseKata;

public static class ItemHelperExtensions
{
    public static void DecreaseQualityBy(this Item item, int valueDecrease)
    {
        for (int i = 0; i < valueDecrease; i++)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }

    public static void IncreaseQualityBy(this Item item, int valueIncrease)
    {
        for (int i = 0; i < valueIncrease; i++)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }            
    }
}
