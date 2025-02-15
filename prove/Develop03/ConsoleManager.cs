using System.IO.Enumeration;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.VisualBasic;

class ConsoleManager
{
    public void Save(string filename, Scripture scripture)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("REFERANCE", "VERSE1", "VERSE2", "ETC..");
            Reference reference = scripture.GetReference();
            string StrRef = reference.FormatSave();
            string finalOutput = StrRef;
            foreach (Verse verse in scripture.GetVerses())
            {
                string FVerse = verse.FormatSave();
                finalOutput += $",{FVerse}";
            }
            outputFile.WriteLine(finalOutput);
        }
    }

    public Scripture Load(string filename)
    {
        using (StreamReader inputFile = new StreamReader(filename))
        {
            string[] fileEntries = System.IO.File.ReadAllLines(filename);

            if (fileEntries.Length < 2)
            {
                return null;
            }

            string scripture = fileEntries[1];
            string versestext = "";
            string[] scriptureParts = scripture.Split(",");

            string[] reference = scriptureParts[0].Split(" ");
            string book = reference[0];
            string[] ChapterVerses = reference[1].Split(":");
            string chapter = ChapterVerses[0];
            string verses = ChapterVerses[1];
            Reference NewReference = new Reference(book, chapter, verses);

            versestext += string.Join("", scriptureParts.Skip(1));
            Scripture NewScripture = new Scripture(NewReference, versestext);
            return NewScripture;
        }
    }

    public void ClearScreen()
    {
        Console.Clear();
    }
}
