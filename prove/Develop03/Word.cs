using System.Dynamic;
using System.Net;

class Word
{
    private string _word;
    private bool _hidden;

    public void Display()
    {
        Console.Write($"{_word} ");
    }

    public string WordString(){
        return $"{_word} ";
    }

    public void HideWord()
    {
        string hiddenWord = "";
        if (_hidden == false)
        {
            foreach (char letter in _word)
            {
                if ("QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm".Contains(letter))
                {
                    hiddenWord += "_";
                }
                else
                {
                    hiddenWord += letter;
                }
            }
            _word = hiddenWord;
            _hidden = true;
        }
    }

    public bool IsHidden()
    {
        if (_hidden == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetWord(string word)
    {
        _word = word;
    }

    public Word()
    {
        _word = "";
        _hidden = false;
    }

    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }
}