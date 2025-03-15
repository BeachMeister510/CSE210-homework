using System;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int choice = 0;
        int totpoints = 0;

        do
        {
            Console.WriteLine($"Total Points: {totpoints}");
            Console.WriteLine();
            Console.WriteLine("Welcome to the _________ Program!");
            Console.WriteLine("Please enter the number of your selection");
            Console.WriteLine("1. Load Goals");
            Console.WriteLine("2. Save Goals");
            Console.WriteLine("3. New Simple Goal");
            Console.WriteLine("4. New Eternal Goal");
            Console.WriteLine("5. New Checklist Goal");
            Console.WriteLine("6. List Goals");
            Console.WriteLine("7. Record Goal Progress");
            Console.WriteLine("8. Quit Program");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Clear();
                Console.WriteLine("Please enter the name of the file you want to load: ");
                string filename = Console.ReadLine();

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
                                return;
                            }
                        }
                    }
                }
                Console.WriteLine("File Loaded");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else if (choice == 2)
            {
                Console.Clear();
                Console.WriteLine("Please enter the name of the file you want to save to:");
                string filename = Console.ReadLine();

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
                Thread.Sleep(1000);
                Console.Clear();
            }
            else if (choice == 3)
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
            else if (choice == 4)
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
            else if (choice == 5)
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
            else if (choice == 6)
            {
                Console.Clear();
                foreach (Goal goal in goals)
                {
                    goal.Display();
                }
                Thread.Sleep(5000);
                Console.Clear();
            }
            else if (choice == 7)
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
            else if (choice == 8)
            {
                Console.WriteLine("Have a nice day!");
            }
            else
            {
                Console.WriteLine("Please enter a valid input");
            }
        } while (choice != 8);
    }
}