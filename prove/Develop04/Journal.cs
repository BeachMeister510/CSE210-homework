using System.Net;
using System.Runtime.CompilerServices;

public class Journal
{
    List<Entry> entries = new List<Entry>();

    public void AddEntry(string date, string prompt, string response)
    {
        Entry new_entry = new Entry();
        new_entry._date = date;
        new_entry._prompt = prompt;
        new_entry._response = response;
        entries.Add(new_entry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in entries)
        {
            string formatedEntry = entry.FormatToString();
            Console.WriteLine(formatedEntry);
        }
    }
    public void Load(string filename)
    {
        using (StreamReader inputFile = new StreamReader(filename))
        {
            string[] fileEntries = System.IO.File.ReadAllLines(filename);
            int count = 0;
            foreach (string entry in fileEntries)
            {
                count++;
                if (count == 1)
                    continue;
                string[] entryparts = entry.Split(",");
                string date = entryparts[0];
                string prompt = entryparts[1];
                string response = entryparts[2];
                AddEntry(date, prompt, response);


            }
        }
    }

    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("DATE", "PROMPT", "RESPONSE");
            foreach (Entry entry in entries)
            {
                string date = entry._date;
                string prompt = entry._prompt;
                string response = entry._response;
                string format = $"{date},{prompt},{response}";
                outputFile.WriteLine(format);
            }
        }
    }
    public void EditEntry()
    {
        Console.WriteLine("Enter the date for the entry you want to change.");
        string date = Console.ReadLine();
        foreach (Entry entry in entries)
        {
            if (entry._date == date)
            {
                Console.WriteLine(entry.FormatToString());
                Console.WriteLine();
                Console.WriteLine("Please enter the changed response to your prompt.");
                entry._response = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("That date could not be found in the journal.");
            }
        }
    }
}