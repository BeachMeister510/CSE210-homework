using System;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int choice = 0;
        int totpoints = 0;
        Menu menu = new Menu();
        Game game = new Game();
        Random rand = new Random();

        do
        {
            Console.WriteLine($"Goal Points");
            menu.DisplayMenu();

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                LoadGoals("goals.txt", totpoints, goals);
            }
            else if (choice == 2)
            {
                SaveGoals("goals.txt", totpoints, goals);
            }

            else if (choice == 3)
            {
                int usergoal = 0;

                do
                {
                    Console.WriteLine($"Goal Points: {totpoints}");
                    menu.DisplayGoalMenu();

                    usergoal = int.Parse(Console.ReadLine());

                    if (usergoal == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter your goal name: ");
                        string goal_name = Console.ReadLine();

                        Console.WriteLine("Please enter a description of your goal: ");
                        string description = Console.ReadLine();

                        Console.WriteLine("Please enter the points this goal is worth: ");
                        int points = int.Parse(Console.ReadLine());

                        SimpleGoal simple = new SimpleGoal(goal_name, description, points);
                        goals.Add(simple);

                        Console.Clear();
                        Console.WriteLine("Your goal has been added!");

                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else if (usergoal == 2)
                    {
                        Console.Clear();

                        Console.WriteLine("Please enter your goal name: ");
                        string goal_name = Console.ReadLine();

                        Console.WriteLine("Please enter a description of your goal: ");
                        string description = Console.ReadLine();

                        Console.WriteLine("Please enter the points this goal is worth: ");
                        int points = int.Parse(Console.ReadLine());

                        EternalGoal eternal = new EternalGoal(goal_name, description, points);
                        goals.Add(eternal);
                        Console.Clear();
                        Console.WriteLine("Your goal has been added!");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else if (usergoal == 3)
                    {
                        Console.Clear();

                        Console.WriteLine("Please enter your goal name: ");
                        string goal_name = Console.ReadLine();

                        Console.WriteLine("Please enter a description of your goal: ");
                        string description = Console.ReadLine();

                        Console.WriteLine("Please enter the points this goal is worth: ");
                        int points = int.Parse(Console.ReadLine());

                        Console.WriteLine("Please enter the bonus points for this goal on completion: ");
                        int bonus = int.Parse(Console.ReadLine());

                        Console.WriteLine("Please enter the number of time you want to complete this: ");
                        int completed_at = int.Parse(Console.ReadLine());

                        ChecklistGoal eternal = new ChecklistGoal(goal_name, description, points, completed_at, bonus);
                        goals.Add(eternal);
                        Console.Clear();
                        Console.WriteLine("Your goal has been added!");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else if (usergoal == 4)
                    {
                        Console.Clear();
                        foreach (Goal goal in goals)
                        {
                            goal.Display();
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (usergoal == 5)
                    {
                        Console.Clear();
                        int count = 1;
                        foreach (Goal goal in goals)
                        {
                            Console.WriteLine($"{count}. " + goal.ReturnGoal());
                            count++;
                        }
                        Console.WriteLine("Enter the number for the goal you want to complete: ");
                        int goal_complete_index = int.Parse(Console.ReadLine()) - 1;
                        totpoints += goals[goal_complete_index].FinishGoal();
                        Console.Clear();
                    }
                } while (usergoal != 6);
            }

            else if (choice == 4)
            {
                int usergame = 0;

                do
                {
                    menu.DisplayGameMenu();

                    usergame = int.Parse(Console.ReadLine());

                    if (usergame == 1)
                    {
                        bool finished = false;
                        Event myevent = game.GetEvent();

                        if (myevent is Encounter encounter)
                        {
                            encounter.GenerateEnemyList();
                            while (!finished)
                            {
                                encounter.Display();
                                encounter.Combat(game.GetPlayer());
                                game.GetPlayer().LevelUp();


                                finished = encounter.CheckEventFinished();
                                if (finished == true)
                                {

                                    bool looting = true;
                                    encounter.GenerateChest();

                                    while (looting)
                                    {
                                        Console.WriteLine("The Chest Contains:");
                                        encounter.DisplayChestItems();
                                        Console.WriteLine("Enter 0 to exit or take all items");

                                        int itemChoice = int.Parse(Console.ReadLine());
                                        Item item = encounter.TakeRewardItem(itemChoice);
                                        game.GetPlayer().AddToInventory(item);

                                        if (encounter.CheckChestEmpty() == true || itemChoice == 0)
                                        {
                                            looting = false;
                                        }
                                    }
                                }
                            }
                        }
                        else if (myevent is TownEvent townEvent)
                        {

                            int itemsPruchased = 0;
                            townEvent.GenerateStore();

                            while (!finished)
                            {
                                menu.DisplayShop();
                                int usershop = int.Parse(Console.ReadLine());

                                if (usershop == 1)
                                {
                                    if (game.GetPlayer().CheckInventoryFull() == false && townEvent.CheckStoreEmpty() == false)
                                    {
                                        itemsPruchased++;
                                        townEvent.DisplayStore();
                                        int itemChoice = int.Parse(Console.ReadLine());
                                        Item item = townEvent.GetItem(itemChoice);
                                        if (totpoints - item.GetItemValue() >= 0)
                                        {
                                            townEvent.Buyitem(itemChoice);
                                            totpoints -= item.GetItemValue();
                                            game.GetPlayer().AddToInventory(item);
                                            Console.Clear();
                                            Console.WriteLine($"Item: {item.CheckItemName()} has been purchased and added to inventory press enter to continue");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You dont have enough points to buy this");
                                        }

                                    }
                                    else if (game.GetPlayer().CheckInventoryFull() == true)
                                    {
                                        Console.WriteLine("Your inventory is full please sell some items before buying from the shop");
                                    }
                                    else if (townEvent.CheckStoreEmpty() == true)
                                    {
                                        Console.WriteLine("The store doesn't have any items left for sale.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error");
                                    }
                                }
                                else if (usershop == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine();
                                    game.GetPlayer().DisplayInventory();
                                    int itemChoice = int.Parse(Console.ReadLine());
                                    Item item = game.GetPlayer().GetItemFromInventory(itemChoice);

                                    if (item is Weapon weapon)
                                    {
                                        if (weapon.CheckEquiped() == false)
                                        {
                                            totpoints += item.GetItemValue();
                                            game.GetPlayer().RemoveFromInventory(itemChoice);
                                            Console.Clear();
                                            Console.WriteLine($"Item {item.CheckItemName()} has been sold. Press enter to continue.");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You must unequip an item before you can sell it.");
                                        }
                                    }
                                    else if (item is Armor armor)
                                    {
                                        if (armor.CheckEquiped() == false)
                                        {
                                            totpoints += item.GetItemValue();
                                            game.GetPlayer().RemoveFromInventory(itemChoice);
                                            Console.Clear();
                                            Console.WriteLine($"Item {item.CheckItemName()} has been sold. Press enter to continue.");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("You must unequip an item before you can sell it.");
                                        }
                                    }
                                }
                                else if (usershop == 3)
                                {
                                    finished = true;
                                }
                            }
                        }
                    }
                    else if (usergame == 2)
                    {
                        game.DisplayInventory();
                    }
                    else if (usergame == 3)
                    {
                        game.DisplayPlayer();
                    }
                } while (usergame != 4);
            }
            else if (choice == 5)
            {
                Console.WriteLine("Thanks for playing!");
            }
        } while (choice != 5);
    }

    public static List<Goal> LoadGoals(string filename, int totpoints, List<Goal> goals)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            string[] lines = reader.ReadToEnd().Split("\n");
            totpoints = int.Parse(lines[0]);

            foreach (string goal in lines)
            {
                if (goal != lines[0] && !string.IsNullOrWhiteSpace(goal))
                {
                    string[] stringsplit = goal.Split(":");
                    string goaltype = stringsplit[0].ToString();
                    string goalparts = stringsplit[1].ToString();
                    string[] splitparts = goalparts.Split(",");
                    if (goaltype == "SimpleGoal")
                    {
                        string goalname = splitparts[0];
                        string goaldesc = splitparts[1];
                        int points = int.Parse(splitparts[2]);
                        bool done = bool.Parse(splitparts[3]);
                        SimpleGoal newgoal = new SimpleGoal(goalname, goaldesc, points, done);
                        goals.Add(newgoal);
                    }
                    else if (goaltype == "EternalGoal")
                    {
                        string goalname = splitparts[0];
                        string goaldesc = splitparts[1];
                        int points = int.Parse(splitparts[2]);
                        EternalGoal newgoal = new EternalGoal(goalname, goaldesc, points);
                        goals.Add(newgoal);
                    }
                    else if (goaltype == "ChecklistGoal")
                    {
                        string goalname = splitparts[0];
                        string goaldesc = splitparts[1];
                        int points = int.Parse(splitparts[2]);
                        bool done = bool.Parse(splitparts[3]);
                        int completiongoal = int.Parse(splitparts[4]);
                        int currentcompletion = int.Parse(splitparts[5]);
                        int bonuspoints = int.Parse(splitparts[6]);
                        ChecklistGoal newgoal = new ChecklistGoal(goalname, goaldesc, points, done, completiongoal, currentcompletion, bonuspoints);
                        goals.Add(newgoal);
                    }
                    else
                    {
                        Console.WriteLine("File corrupted");
                        return goals;
                    }
                }
            }
        }
        Console.WriteLine("File Loaded");
        return goals;
    }
    public static void SaveGoals(string filename, int totpoints, List<Goal> goals)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totpoints);
            foreach (Goal goal in goals)
            {
                foreach (string item in goal.SaveGoal())
                {
                    writer.Write(item);
                }
                writer.Write("\n");
            }

        }
        Console.WriteLine("File Saved!");
    }

    public static Type GetDataType(object value)
    {
        return value.GetType();
    }
}