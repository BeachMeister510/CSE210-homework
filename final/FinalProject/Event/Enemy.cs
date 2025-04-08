public class Enemy
{
    private string _name;
    private int _health;
    private int _level;
    private int _initiative;
    private Weapon _weapon;
    private int _XPValue;
    private string _weakness;
    private Inventory _inventory = new Inventory();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}  Level: {_level}");
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine();
    }

    public int Attack()
    {
        return _weapon.Attack();
    }

    public bool CheckDead()
    {
        if (_health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetExperiance()
    {
        return _XPValue;
    }

    public int CheckInitiative()
    {
        return _initiative;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public Enemy(string name, int health, int level, int initiative, Weapon weapon, int XP, string weakness)
    {
        _name = name;
        _health = health;
        _level = level;
        _initiative = initiative;
        _weapon = weapon;
        _XPValue = XP;
        _weakness = weakness;
    }

    public Enemy(Enemy other)
    {
        _name = other._name;
        _health = other._health;
        _level = other._level;
        _initiative = other._initiative;
        _weapon = new Weapon(other._weapon);
        _XPValue = other._XPValue;
        _weakness = other._weakness;
        _inventory = other._inventory;
    }

    public Enemy()
    {
        _name = "Unknown Enemy";
        _health = 10;
        _level = 1;
        _initiative = 1;
        _weapon = new Weapon("Short sword", "your average short sword", "common", 5, "slashing", 5, 2, true);
    }

}