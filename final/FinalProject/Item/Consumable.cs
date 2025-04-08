public class Consumable : Item
{
    private int _boostValue;
    private bool _used;

    public int UseConsumable()
    {
        _used = true;
        return _boostValue;
    }

    public bool CheckUsed()
    {
        return _used;
    }

    public override string CheckItemName()
    {
        return _itemName;
    }

    public override string CheckItemRarity()
    {
        return _itemRarity;
    }

    public Consumable(string name, string desc, string rarity, int value, int boostValue) : base(name, desc, rarity, value)
    {
        _boostValue = boostValue;
        _used = false;
    }
}