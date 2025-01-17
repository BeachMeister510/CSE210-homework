using System;
using System.Net.NetworkInformation;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcomeMessage(){
            Console.WriteLine("Welcome to the Program!");
        }
        
        static string PromptUserName(){
            Console.WriteLine("Waht is your full name?");
            string UsersName = Console.ReadLine();
            return UsersName;
        }

        static int PromptUserNumber(){
            Console.WriteLine("What is your favorite number?");
            int UserNumber = int.Parse(Console.ReadLine());
            return UserNumber;
        }

        static int SquareNumber (int Number){
            int SquaredNum = Number * Number;
            return SquaredNum;
        }

        static void DisplayResult (string Name, int SquaredNumber){
            Console.WriteLine($"{Name}, the square of your number is {SquaredNumber}");
        }

        DisplayWelcomeMessage();
        string Name = PromptUserName();
        int Number = PromptUserNumber();
        int SquaredNumber = SquareNumber(Number);
        DisplayResult(Name, SquaredNumber);
    }
}