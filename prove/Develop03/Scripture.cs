using System.Net;
using System.Security;

class Scripture
{
    private List<Verse> _verses = new List<Verse>();
    private Reference _reference;

    public void Display()
    {
        _reference.Display();
        foreach (Verse verse in _verses)
        {
            verse.Display();
        }
    }

    public bool HideWord()
    {
        int numOfVerses = _verses.Count;
        int hiddenVerses = 0;
        foreach (Verse verse in _verses)
        {
            bool finished = verse.HideVerseParts();
            if (finished == true)
            {
                hiddenVerses++;
            }
        }
        if (hiddenVerses == numOfVerses)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void SetReferance(string reference)
    {

        string[] unparsedReference = reference.Split(" ");
        string book = unparsedReference[0];
        string chapterVerseRef = unparsedReference[1];
        string[] unparsedChapterVerse = chapterVerseRef.Split(":");
        string chapter = unparsedChapterVerse[0];
        string verseRef = unparsedChapterVerse[1];
        _reference = new Reference(book, chapter, verseRef);
    }

    public void SetVerses(string verses)
    {
        string[] spiltVerses = verses.Split(".");
        foreach (string verse in spiltVerses)
        {
            List<string> wholeVerse = new List<string>(verse.Split(" "));
            string verseNum = wholeVerse[0];
            wholeVerse.RemoveAt(0);
            string verseText = string.Join(" ", wholeVerse);
            verseText += ".";
            Verse newVerse = new Verse(verseNum, verseText);
            _verses.Add(newVerse);
        }
    }

    public void SetVerses(List<Verse> verses)
    {
        foreach (Verse verse in verses)
        {
            _verses.Add(verse);
        }
    }

    public List<Verse> GetVerses()
    {
        return _verses;
    }

    public Reference GetReference()
    {
        return _reference;
    }

    public Scripture()
    {
        _reference = new Reference();
        _verses = new List<Verse>();
    }

    public Scripture(string reference, string verses)
    {
        string[] unparsedReference = reference.Split(" ");
        string book = unparsedReference[0];
        string chapterVerseRef = unparsedReference[1];
        string[] unparsedChapterVerse = chapterVerseRef.Split(":");
        string chapter = unparsedChapterVerse[0];
        string verseRef = unparsedChapterVerse[1];
        _reference = new Reference(book, chapter, verseRef);

        string[] spiltVerses = verses.Split(".");
        foreach (string verse in spiltVerses)
        {
            if (string.IsNullOrWhiteSpace(verse)) continue;

            List<string> wholeVerse = new List<string>(verse.Split(" "));
            string verseNum = wholeVerse[0];
            wholeVerse.RemoveAt(0);
            string verseText = string.Join(" ", wholeVerse);
            verseText += ".";
            Verse newVerse = new Verse(verseNum, verseText);
            _verses.Add(newVerse);
        }
    }

    public Scripture(Reference reference, string verses)
    {
        _reference = reference;

        foreach (string verse in verses.Split("."))
        {
            if (string.IsNullOrWhiteSpace(verse)) continue;

            List<string> wholeVerse = new List<string>(verse.Split(" "));
            string verseNum = wholeVerse[0];
            wholeVerse.RemoveAt(0);
            string verseText = string.Join(" ", wholeVerse);
            verseText += ".";
            Verse newVerse = new Verse(verseNum, verseText);
            _verses.Add(newVerse);
        }
    }
}