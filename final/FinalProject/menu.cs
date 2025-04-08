public class Menu
{
    private List<string> _menu = new List<string>{
        "1. Load Files ",
        "2. Save Files",
        "3. Goal Menu",
        "4. Game Menu",
        "5. Quit Program"
    };

    private List<string> _goalMenu = new List<string>{
        "1. New Simple Goal",
        "2. New Eternal Goal",
        "3. New Checklist Goal",
        "4. List Goals",
        "5. Record Goal Progress",
        "6. Exit Goals"
    };

    private List<string> _gameMenu = new List<string>{
        "1. Next Event",
        "2. Check Inventory",
        "3. Show Player Status",
        "4. Exit Game"
    };

    private List<string> _townShop = new List<string>{
        "1. Buy item",
        "2. Sell item",
        "3. Leave"
    };

    public void DisplayMenu()
    {
        Console.WriteLine("Please enter your selection");
        Console.WriteLine();
        foreach (string option in _menu)
        {
            Console.WriteLine(option);
        }
    }

    public void DisplayGoalMenu()
    {
        Console.WriteLine("Please enter your selection");
        Console.WriteLine();
        foreach (string option in _goalMenu)
        {
            Console.WriteLine(option);
        }
    }

    public void DisplayGameMenu()
    {
        Console.WriteLine("Please enter your selection");
        Console.WriteLine();
        foreach (string opiton in _gameMenu)
        {
            Console.WriteLine(opiton);
        }
    }

    public void DisplayShop()
    {
        Console.WriteLine("Please enter your selection");
        Console.WriteLine();
        foreach (string opiton in _townShop)
        {
            Console.WriteLine(opiton);
        }
    }
}