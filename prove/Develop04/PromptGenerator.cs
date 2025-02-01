using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

public class Prompt
{

    public List<string> _prompts = new List<string>();

    public void CreatePromptList()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What progress have I made towards my goals?");
        _prompts.Add("What is one thing I could have improved on today?");
        _prompts.Add("How did I share the light of the Savior today?");
    }
    public string GetRandPrompt()
    {
        Random rnd = new Random();
        int RandomIndex = rnd.Next(0, _prompts.Count());

        string prompt = _prompts[RandomIndex];
        return prompt;
    }

    public void Display()
    {
        foreach (string prompt in _prompts)
        {
            Console.WriteLine(prompt);
        }
    }
}
