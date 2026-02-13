
class ScriptureWord
{
    private string _word = "Cheese";
    private int _wordLength = 6;
    private bool _hidden = false;

    // Constructor
    public ScriptureWord(string word = "Cheese")
    {
        _word = word;
        _wordLength = word.Length;
    }

    // Toggles word to be hidden or revealed
    public void Toggle()
    {
        _hidden = !_hidden;
    }

    // Gets word
    public string GetWord()
    {
        return _word;
    }

    // Returns word if not hidden or string of underscores the size of the word if hidden
    public string GetToggledWord()
    {
        if (!_hidden)
        {
            return _word;
        }
        else
        {
            string hiddenWord = "";
            for (int i= 0; i < _wordLength; i++)
            {
                hiddenWord += "_";
            }
            return hiddenWord;
        }
    }
}