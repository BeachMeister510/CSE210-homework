class Reference
{
    private string _book;
    private string _chapterNumber;
    private string _verseNumbers;

    public void Display()
    {
        Console.WriteLine($"{_book} {_chapterNumber}:{_verseNumbers}");
    }
    public string FormatSave()
    {
        return $"{_book} {_chapterNumber}:{_verseNumbers}";
    }

    public void changeBook(string bookName)
    {
        _book = bookName;
    }
    public void changeChapNum(string chapNum)
    {
        _chapterNumber = chapNum;
    }
    public void changeVerseNum(string verseNums)
    {
        _verseNumbers = verseNums;
    }

    public Reference()
    {
        _book = "none";
        _chapterNumber = " ";
        _verseNumbers = " ";
    }

    public Reference(string book, string chapNum, string verseNums)
    {
        _book = book;
        _chapterNumber = chapNum;
        _verseNumbers = verseNums;
    }
}