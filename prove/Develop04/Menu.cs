using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

public class Menu()
{
    public void Display()
    {
        Console.WriteLine("1. New Entry");
        Console.WriteLine("2. Load");
        Console.WriteLine("3. Save");
        Console.WriteLine("4. Display Journal");
        Console.WriteLine("5. Edit Entry");
        Console.WriteLine("6. Quit");
        Console.WriteLine();
    }
}

