public class Entry
{
    int test = 0;
    public string _prompt;
    public string _date;
    public string _response;

    public string FormatToString()
    {
        string entry = $"({_date}) \"{_prompt}\" \n{_response}";
        return entry;
    }
}