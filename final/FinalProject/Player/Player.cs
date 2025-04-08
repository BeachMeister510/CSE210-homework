using System.ComponentModel.DataAnnotations;
using System.Dynamic;

public class Player
{
    private string _name;
    private int _health;
    private Inventory _inventory;
    private int _playerLevel;
    private int _experiance;
    private int _levelUpXP;
    private bool _armorEqiuped;
    private bool _firstHandEquiped;
    private bool _secondHandEquiped;
    private Weapon _equipedWeapon;
    private Armor _equipedArmor;

    private int _initiative = 2;
    //private double _sellRate; **Might not implement**

    public void DisplayPlayer()
    {
        Console.WriteLine($"{_name} Level: {_playerLevel} XP: {_experiance}");
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine();
        Console.WriteLine($"Armor: {_armorEqiuped}");
        if (_firstHandEquiped && _secondHandEquiped)
        {
            Console.WriteLine("Two-handed Weapon: True");
        }
        else if (_firstHandEquiped || _secondHandEquiped)
        {
            Console.WriteLine("One-handed Weapon: True");
        }
        else
        {
            Console.WriteLine("No Weapon Equiped");
        }
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Health: {_health} XP: {_experiance}");
    }

    public void DisplayInventory()
    {
        _inventory.Display();
    }

    public bool CheckInventoryFull()
    {
        return _inventory.CheckInventoryFull();
    }

    public void AddToInventory(Item item)
    {
        _inventory.AddItem(item);
    }

    public void RemoveFromInventory(int index)
    {
        _inventory.RemoveItem(index);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public int GetInitiative()
    {
        return _initiative;
    }

    public Item GetItemFromInventory(int index)
    {
        return _inventory.GetItem(index);
    }

    public void GainXP(int XP)
    {
        _experiance += XP;
    }

    public int Attack()
    {
        return _equipedWeapon.Attack();
    }

    public void LevelUp()
    {
        if (_experiance >= _levelUpXP)
        {
            _playerLevel++;
            _experiance = 0;
            _levelUpXP = (_levelUpXP * 2) + (_levelUpXP / 2);
        }
    }

    public void EquipItem(Item item)
    {
        if (item is Weapon weapon)
        {
            _equipedWeapon.Unequip();
            _equipedWeapon = weapon;
            weapon.Equip();

        }
        else if (item is Armor armor)
        {
            _equipedArmor.Unequip();
            _equipedArmor = armor;
            armor.Equip();
        }
    }

    public Player()
    {
        _name = "John";
        _health = 100;
        _inventory = new Inventory();
        _playerLevel = 1;
        _experiance = 0;
        _levelUpXP = 100;
        _armorEqiuped = false;
        _firstHandEquiped = true;
        _secondHandEquiped = true;
        _equipedWeapon = new Weapon("Longsword", "A general use longsword that has seen its use in battle", "common", 10, "slashing", 15, 2, true);
        _equipedArmor = new Armor();
        _inventory.AddItem(_equipedWeapon);

    }

    public Player(string name, int health, Inventory inventory, int level, int XP, int LevelUpXP, bool equipedArmor, bool equipedHand1, bool equipedHand2, Weapon weapon, Armor armor)
    {
        _name = name;
        _health = health;
        _inventory = inventory;
        _playerLevel = level;
        _experiance = XP;
        _levelUpXP = LevelUpXP;
        _armorEqiuped = equipedArmor;
        _firstHandEquiped = equipedHand1;
        _secondHandEquiped = equipedHand2;
        _equipedWeapon = weapon;
        _equipedArmor = armor;

    }
}