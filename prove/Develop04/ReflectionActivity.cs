using System.Diagnostics.Contracts;

class ReflectionActivity : Activity
{

    Random rand = new Random();
    List<int> indexesChosenGen = new List<int>();
    List<int> indexesChosenChur = new List<int>();
    List<string> generalPrompts = new List<string>
        {
            "What did you learn today that surprised you?",
            "How did you challenge yourself today?",
            "What is one thing you did well?",
            "What is one thing you could improve on?",
            "How did you help someone today?",
            "What is a mistake you made, and what did you learn from it?",
            "What emotions did you experience today, and why?",
            "How did today's experience connect to your goals?",
            "What inspired you today?",
            "If you could redo one moment from today, what would it be and why?",
            "How did today's events shape your perspective?",
            "What is one thing you are grateful for today?",
            "What did you learn about yourself today?",
            "How did you step outside of your comfort zone?",
            "What is one action you can take tomorrow to grow?"
        };



    List<string> churchPrompts = new List<string>
        {
            "How did you see the Lord's hand in your life today?",
            "What scripture stood out to you recently, and why?",
            "How did you follow the promptings of the Spirit today?",
            "In what ways did you strive to be more like Christ today?",
            "What is one gospel principle you better understood this week?",
            "How did you serve someone today as Christ would?",
            "What did you learn from your prayers today?",
            "How did you strengthen your testimony today?",
            "What is one way you can improve your Sabbath day observance?",
            "How did you apply a recent General Conference talk to your life?",
            "What experience this week reminded you of Heavenly Father's love?",
            "How has the temple or temple work influenced your spiritual growth?",
            "What did you learn from your ministering efforts?",
            "How can you be a better disciple of Jesus Christ tomorrow?",
            "What blessing have you noticed from keeping your covenants?"
        };
    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _activityLength = 30;
        _description = "Durring this activity you will be given the chance to refect on things that have happened throughout the day based on the prompts given";
    }
    public ReflectionActivity(int length)
    {
        _name = "Reflection Activity";
        _activityLength = length;
        _description = "Durring this activity you will be given the chance to refect on things that have happened throughout the day based on the prompts given";
    }
    public ReflectionActivity(int length, int delay)
    {
        _name = "Reflection Activity";
        _activityLength = length;
        _delay = delay;
        _description = "Durring this activity you will be given the chance to refect on things that have happened throughout the day based on the prompts given";
    }

    public void PromptUser()
    {
        int pick = rand.Next(1, 3);
        int Index = rand.Next(0, generalPrompts.Count());
        bool enter = false;

        Console.WriteLine("Consider the following prompt:");
        if (pick == 1 && (!indexesChosenGen.Contains(Index)))
        {
            Console.WriteLine($"-- {generalPrompts[Index]} --");

        }
        else if (pick == 2 && (!indexesChosenChur.Contains(Index)))
        {
            Console.WriteLine(churchPrompts[Index]);
        }

        Console.WriteLine();
        Console.WriteLine("Press enter when you have something in mind.");

        Console.Write("-");
        while (!enter)
        {

            Thread.Sleep(325);
            Console.Write("\r" + "~");
            Thread.Sleep(325);
            Console.Write("\r" + "-");

            if (Console.KeyAvailable)
            {
                Console.Write("\r");
                Console.ReadKey(true);
                enter = true;
            }
        }
    }
    public void Reflection()
    {
        DateTime start = DateTime.Now;
        DateTime future = start.AddSeconds(_activityLength);

        List<string> ReflectionQs = new List<string>
        {
            "How did this experience impact your perspective on life or your goals?",
            "What did you learn about yourself from this experience?",
            "How can you apply what you learned today to future situations?",
            "What emotions did you experience during this moment, and how did they affect your actions or decisions?",
            "What is one thing you would do differently if you had the chance to redo this experience?",
            "In what ways did this experience challenge your beliefs or assumptions?",
            "How did this experience influence your relationships with others?",
            "What is one thing you can take away from this experience that will help you grow?",
            "How did this situation align with your values or principles?",
            "What role did your mindset play in how you approached or handled this experience?"
        };
        Console.WriteLine("Take some time to ponder on the following questions:");
        int Countdown = 5;
        while (Countdown > 0)
        {
            Console.Write(Countdown);
            Thread.Sleep(1000);
            Console.Write("\r");
            Countdown--;
        }
        foreach (string question in ReflectionQs)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(question);
            Thread.Sleep(5000);
            if (now >= future)
            {
                break;
            }
            else if (question == ReflectionQs[ReflectionQs.Count() - 1])
            {
                Console.WriteLine("You have finished all the questions");
            }
        }


    }
}