using System.Reflection.Metadata.Ecma335;

public class Weapon : Item
{
    private string _dmgType;
    private int _damage;
    // private int _durabiltiy;
    private int _hands;
    private bool _equipped;

    public override void Display()
    {
        base.Display();
        if (_hands == 1)
        {
            Console.WriteLine("One-handed");
        }
        else if (_hands == 2)
        {
            Console.WriteLine("Two-handed");
        }
        Console.WriteLine();
        Console.WriteLine($"Damage: {_damage}   Type: {_dmgType}");
        Console.WriteLine($"Equiped: {_equipped}");
    }

    public int Equip()
    {
        _equipped = true;
        return (_hands);
    }

    public int Attack()
    {
        return _damage;
    }
    public string GetDmgType()
    {
        return _dmgType;
    }

    public Weapon(string name, string desc, string rarity, int value, string dmgType, int damage, int hands, bool equiped) : base(name, desc, rarity, value)
    {
        _dmgType = dmgType;
        _damage = damage;
        _hands = hands;
        _equipped = equiped;
    }

    public Weapon(Weapon other)
    {
        _itemName = other._itemName;
        _itemDesc = other._itemDesc;
        _itemRarity = other._itemRarity;
        _itemValue = other._itemValue;
        _dmgType = other._dmgType;
        _damage = other._damage;
        _hands = other._hands;
        _equipped = other._equipped;
    }

    public Weapon() : base()
    {
        _dmgType = "none";
        _damage = 0;
        _hands = 1;
        _equipped = false;
    }
}