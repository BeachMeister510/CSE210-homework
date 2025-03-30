using System.ComponentModel.DataAnnotations;

public class Player
{
    private string _name;
    private int _health;
    private Inventory _inventory;
    private int _playerLevel;
    private int _experiance;
    private int _levelUpXP;
    private bool _armorEqiuped;
    private bool _firstHandEquipped;
    private bool _secondHandEquiped;
    private bool _ringEquiped;
    private Weapon _equipedWeapon;

    private int _initiative = 2;
    //private double _sellRate; **Might not implement**

    public void DisplayPlayer()
    {
        Console.WriteLine($"{_name} Level: {_playerLevel} XP: {_experiance}");
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine();
        Console.WriteLine($"Armor: {_armorEqiuped}");
        Console.WriteLine($"Ring: {_ringEquiped}");
        if (_firstHandEquipped && _secondHandEquiped)
        {
            Console.WriteLine("Two-handed Weapon: True");
        }
        else if (_firstHandEquipped || _secondHandEquiped)
        {
            Console.WriteLine("One-handed Weapon: True");
        }
        else
        {
            Console.WriteLine("No Weapon Equiped");
        }
    }

    public void DisplayInventory()
    {
        _inventory.Display();
    }

    public int GetInitiative()
    {
        return _initiative;
    }

    public int Attack()
    {
        return _equipedWeapon.Attack();
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
        _firstHandEquipped = true;
        _secondHandEquiped = true;
        _ringEquiped = false;
        _equipedWeapon = new Weapon("Longsword", "A general use longsword that has seen its use in battle", "common", 10, "slashing", 15, 2, true);
        _inventory.AddItem(_equipedWeapon);

    }
}