using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 4)
        {
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listening Activity");
            Console.WriteLine("4. Quit");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("How long in seconds do you want the activty to last?");
                int length = int.Parse(Console.ReadLine());

                BreathingActivity activity = new BreathingActivity(length);
                activity.ActivityStart();
                activity.Breathe();
                activity.ActivityEnd();
            }
            else if (choice == 2)
            {
                Console.WriteLine("How long in seconds do you want the activty to last?");
                int length = int.Parse(Console.ReadLine());

                ReflectionActivity activity = new ReflectionActivity(length);
                activity.ActivityStart();
                activity.PromptUser();
                activity.Reflection();
                activity.ActivityEnd();
            }
            else if (choice == 3)
            {
                Console.WriteLine("How long in seconds do you want the activty to last?");
                int length = int.Parse(Console.ReadLine());

                ListeningActivity activity = new ListeningActivity(length);
                activity.ActivityStart();
                activity.Listen();
                activity.ActivityEnd();

            }
            else if (choice == 4)
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}