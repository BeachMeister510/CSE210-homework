using System.Net;
using System.Reflection.Metadata.Ecma335;

class Verse
{
    private List<Word> _verseText = new List<Word>();
    private string _verseNumber;

    public void Display()
    {
        Console.Write($"{_verseNumber} ");
        foreach (Word word in _verseText)
        {
            word.Display();
        }
    }

    public string VerseTextString()
    {
        string stringtext = "";
        foreach (Word word in _verseText)
        {
            stringtext += word.WordString();
        }
        return stringtext;
    }

    public string FormatSave()
    {
        return $"{_verseNumber} {VerseTextString()}";
    }

    public bool HideVerseParts()
    {
        Random random = new Random();
        int wordCount = _verseText.Count();
        int hideNum = 3;
        int hideCount = 0;

        if (hideNum == 0)
        {
            hideNum = 1;
        }

        do
        {
            int randomIndex = random.Next(0, wordCount);
            Word word = _verseText[randomIndex];

            if (word.IsHidden() == false)
            {
                hideCount++;
                word.HideWord();
                if (IsFinished() == true)
                {
                    return true;
                }
            }

        } while (hideCount != hideNum);

        return false;
    }

    public bool IsFinished()
    {
        int trueCount = 0;
        foreach (Word word in _verseText)
        {
            if (word.IsHidden() == true)
            {
                trueCount++;
            }
        }

        if (trueCount == _verseText.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeVerseNum(string verseNum)
    {
        _verseNumber = verseNum;
    }

    public Verse()
    {
        _verseNumber = "";
    }

    public Verse(string verseNum, string verseText)
    {
        _verseNumber = verseNum;
        List<string> words = new List<string>(verseText.Split(" "));
        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _verseText.Add(newWord);
        }
    }

}