using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void GildedRose_has_list_of_items()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("foo"));
    }

    [Test]
    public void UpdateQuality_degrades_standard_item_quality()
    {
        var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(19));
    }

    [Test]
    public void UpdateQuality_double_degrades_standard_item_quality_after_SellIn_reached()
    {
        var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(18));
    }

    [Test]
    public void UpdateQuality_cannot_reduce_item_quality_below_zero()
    {
        var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void AgedBrie_increases_item_quality_over_time()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(1));
    }

    [Test]
    public void UpdateQuality_cannot_increase_item_quality_above_50()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void UpdateQuality_does_not_increase_Sulfuras_quality()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    [TestCase(11, 8)]
    [TestCase(10, 9)]
    [TestCase(5, 10)]
    [TestCase(0, 0)]
    public void Backstage_pass_increases_in_value_as_concert_approaches(int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 7 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(quality));
    }

    [Test]
    public void UpdateQuality_reduces_SellIn()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 7 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(4));
    }

    [Test]
    public void UpdateQuality_does_not_reduce_Sulfuras_SellIn()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    [TestCase(2, 8)]
    [TestCase(-2, 6)]
    public void Update_quality_degrades_conjured_items_twice_as_fast(int sellIn, int expectedQuality)
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(expectedQuality));

    }
}