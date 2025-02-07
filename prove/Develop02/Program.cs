using System;

class Program
{
    int test = 0;
    static void Main(string[] args)
    {
        Menu _menu = new Menu();
        Prompt _prompt = new Prompt();
        Journal _journal = new Journal();
        _prompt.CreatePromptList();

        string Choice = "-1";
        do
        {
            _menu.Display();
            Choice = Console.ReadLine();
            if (Choice == "1")
            {
                DateTime date = DateTime.Now;
                string dateText = date.ToShortDateString();
                string prompt = _prompt.GetRandPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                _journal.AddEntry(dateText, prompt, response);
            }
            else if (Choice == "2")
            {
                Console.WriteLine("Please enter the name of the file you would like to load from? ");
                string file = Console.ReadLine();
                _journal.Load(file);
                Console.WriteLine("File Loaded");
            }
            else if (Choice == "3")
            {
                Console.WriteLine("What is the name of the file that you want to save to? ");
                string file = Console.ReadLine();
                _journal.Save(file);
                Console.WriteLine("File Saved");
            }
            else if (Choice == "4")
            {
                _journal.DisplayJournal();
            }
            else if (Choice == "5")
            {
                _journal.EditEntry();
            }
            else if (Choice == "6")
            {
                Console.WriteLine("You have successfuly quited the Program");
            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
            }

        } while (Choice != "6");
    }
}