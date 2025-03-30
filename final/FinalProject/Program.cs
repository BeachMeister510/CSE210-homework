using System;
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
            menu.DisplayMenu();

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Not yet implemented");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Not yet implemented");
            }

            else if (choice == 3)
            {
                int usergoal = 0;

                do
                {
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
                        Event myevent = game.GetEvent();
                        if (myevent is Encounter encounter)
                        {
                            bool finished = false;
                            encounter.GenerateEnemyList();
                            while (!finished)
                            {
                                encounter.Display();
                                encounter.Combat(game.GetPlayer());
                                finished = encounter.CheckEventFinished();
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
            //     if (choice == 1)
            //     {
            //         Console.Clear();
            //         Console.WriteLine("Please enter the name of the file you want to load: ");
            //         string filename = Console.ReadLine();

            //         goals = LoadGoals(filename, totpoints, goals);

            //         Thread.Sleep(1000);
            //         Console.Clear();
            //     }
            //     else if (choice == 2)
            //     {
            //         Console.Clear();
            //         Console.WriteLine("Please enter the name of the file you want to save to:");
            //         string filename = Console.ReadLine();

            //         SaveGoals(filename, totpoints, goals);

            //         Thread.Sleep(1000);
            //         Console.Clear();
            //     }
            //     else if (choice == 8)
            //     {
            //         Console.WriteLine("Have a nice day!");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Please enter a valid input");
            //     }
            // } while (choice != 8);
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