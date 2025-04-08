public class Armor : Item
{
    private int _damageReduction;
    private bool _equiped;

    public int ReduceDamage()
    {
        return _damageReduction;
    }

    public void Equip()
    {
        _equiped = true;
    }

    public void Unequip()
    {
        _equiped = false;
    }

    public bool ReturnEquiped()
    {
        return _equiped;
    }

    public override string CheckItemName()
    {
        return _itemName;
    }

    public override string CheckItemRarity()
    {
        return _itemRarity;
    }

    public bool CheckEquiped()
    {
        return _equiped;
    }

    public Armor()
    {
        _itemName = "Regular Clothes";
        _itemDesc = "Normal everyday wear";
        _itemRarity = "N/A";
        _itemValue = 0;
        _damageReduction = 0;
        _equiped = false;
    }

    public Armor(string name, string desc, string rarity, int value, int damageReduction, bool equiped) : base(name, desc, rarity, value)
    {
        _damageReduction = damageReduction;
        _equiped = equiped;
    }
}