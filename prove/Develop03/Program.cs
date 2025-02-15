using System;
using System.Net.Quic;

class Program
{
    static void Main(string[] args)
    {
        Scripture _scripture = new Scripture();
        ConsoleManager _CM = new ConsoleManager();
        string input = "";
        bool done = false;

        Console.WriteLine("Welcome to the scripture memorizer program!");

        do
        {
            Console.WriteLine("1. Load");
            Console.WriteLine("2. Memorize Loaded Scripture");
            Console.WriteLine("3. Continue to Default Scripture");
            Console.WriteLine("4. Save Progress");
            Console.WriteLine("5. Quit Program");
            input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("What is the name of the file you want to load?");
                string file = Console.ReadLine();
                _scripture = _CM.Load(file);
                Console.WriteLine("File Loaded Succesfully!");
            }
            else if (input == "2")
            {
                _CM.ClearScreen();

                while (input != "quit" && input != "Quit" && done == false)
                {
                    _scripture.Display();
                    input = Console.ReadLine();
                    done = _scripture.HideWord();
                    _CM.ClearScreen();
                }
                if (input != "quit" && input != "Quit")
                {
                    Console.WriteLine("You finished the scripture!");
                }
            }
            else if (input == "4")
            {
                Console.WriteLine("What is the name of the file you want to save to?");
                string file = Console.ReadLine();
                _CM.Save(file, _scripture);

            }
            else if (input == "3")
            {
                _scripture = new Scripture("John 3:16", "16 For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
                _CM.ClearScreen();

                while (input != "quit" && input != "Quit" && done == false)
                {
                    _scripture.Display();
                    input = Console.ReadLine();
                    done = _scripture.HideWord();
                    _CM.ClearScreen();
                }
                if (input != "quit" && input != "Quit")
                {
                    Console.WriteLine("You have finished the scripture!");
                }
            }
            else if (input == "5")
            {
                input = "done";
            }
            else
            {
                Console.WriteLine("Please enter a menu options number.");
            }
        } while (input != "done");
    }
}