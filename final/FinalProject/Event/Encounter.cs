public class Encounter : Event
{
    // private Chest _chestOfItems;
    private int _numOfEnemies;
    List<Enemy> _gameEnemies = new List<Enemy>{
        new Enemy("Goblin",  25, 1, 3, new Weapon("Short sword", "your average short sword", "common", 5, "slashing", 5, 2, true), 10, "peircing")
    };
    List<Enemy> _combatEnemies = new List<Enemy>();

    private Random rand = new Random();

    public void GenerateEnemyList()
    {
        int counter = 0;
        while (counter != _numOfEnemies)
        {
            counter++;
            _combatEnemies.Add(new Enemy(_gameEnemies[0]));
        }
    }

    public override bool CheckEventFinished()
    {
        int deathCount = 0;
        foreach (Enemy enemy in _combatEnemies)
        {
            if (enemy.CheckDead() == true)
            {
                deathCount++;
            }
        }

        if (deathCount == _combatEnemies.Count())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Enemy GetEnemy(int playerChoice)
    {
        return _combatEnemies[playerChoice - 1];
    }

    public int EnemyCombat()
    {
        int playerDamage = 0;
        foreach (Enemy enemy in _combatEnemies)
        {
            if (enemy.CheckDead() == false)
            {
                playerDamage += enemy.Attack();
            }
        }
        return playerDamage;
    }

    public void PlayerCombat(Player player)
    {
        int damage = player.Attack();
        Console.WriteLine("Enter the number of the enemy you want to attack");
        int choice = int.Parse(Console.ReadLine());
        Enemy enemy = GetEnemy(choice);
        enemy.TakeDamage(damage);
    }

    public int Combat(Player player)
    {
        PlayerCombat(player);
        int dmg = EnemyCombat();
        return dmg;
    }

    public override void Display()
    {
        int counter = 0;
        base.Display();
        Console.WriteLine($"There are {_numOfEnemies} enimies");
        Console.WriteLine();
        foreach (Enemy enemy in _combatEnemies)
        {
            counter++;
            Console.WriteLine($"{counter}:");
            enemy.Display();
        }
    }

    public Encounter(string name, string desc, int numEnemy, List<Enemy> enemies) : base(name, desc)
    {
        _numOfEnemies = numEnemy;
        _gameEnemies = enemies;
    }

    public Encounter(string name, string desc, int numEnemy) : base(name, desc)
    {
        _numOfEnemies = numEnemy;
    }

    public Encounter() : base()
    {
        _numOfEnemies = 0;
    }
}