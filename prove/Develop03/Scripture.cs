using System.Security.Cryptography.X509Certificates;

class Scripture
{
    private Reference _reference = new Reference("Genesis 1",1,5);
    private List<ScriptureWord> _words = [];

    // word index lists
    private List<int> _hiddenWordIndices = [];
    private List<int> _revealedWordIndices = [];

    // word counts
    private int _totalWords = 0;
    private int _totalHiddenWords = 0;

    // Constructors
    public Scripture(string chapter = "Genesis 1", int verse = 1, string text = "")
    {
        _reference = new Reference(chapter,verse);
        SetWordsFromText(text);
    }
    
    public Scripture(string chapter = "Genesis 1", int firstVerse = 1, int lastVerse = 5, string text = "")
    {
        _reference = new Reference(chapter,firstVerse,lastVerse);
        SetWordsFromText(text);
    }
    
    public Scripture(Reference reference, string text = "")
    {
        _reference = reference;
        SetWordsFromText(text);
    }

    // divides string by word (character sequence prior to space or string end) and then stores words as ScriptureWord object
    private void SetWordsFromText(string text = "")
    {
        string word = "";
        foreach (char character in text)
        {
            if (character != ' ')
            {
                word += character;
            }
            else
            {
                AddWord(word);
                word = "";
            }
        }
        AddWord(word);
    }

    // Stores word as ScriptureWord in _words list and adds index to _revealedWordIndices and increments totalWords
    private void AddWord(string word)
    {
        _words.Add(new ScriptureWord(word));
        _revealedWordIndices.Add(_totalWords++);
    }

    // Returns string with scripture reference and scripture text
    public string GetFullScripture()
    {
        string text = "";

        foreach (ScriptureWord scriptureWord in _words)
        {
            text += $"{scriptureWord.GetWord()} ";
        }

        return $"{_reference.GetReference()}\n{text}";
    }

    
    // Returns string with scripture reference and scripture text with toggled words
    public string GetFullToggledScripture()
    {
        string text = "";

        foreach (ScriptureWord scriptureWord in _words)
        {
            text += $"{scriptureWord.GetToggledWord()} ";
        }

        return $"{_reference.GetReference()}\n{text}";
    }

    // Toggles random words that are stored in the _revealedWordIndices and moves index int to _hiddenWordIndices
    public void HideRandomWords(int numOfWords = 1)
    {
        int totalRevealedWords = _totalWords - _totalHiddenWords;
        int revisedNumOfWords = Math.Min(numOfWords,totalRevealedWords);

        var rnd = new Random();
        for (int i = 0; i < revisedNumOfWords; i++)
        {
            int randomNum = rnd.Next(0,totalRevealedWords - i);
            int wordIndexToHide = _revealedWordIndices[randomNum];

            _revealedWordIndices.RemoveAt(randomNum);
            _hiddenWordIndices.Add(wordIndexToHide);

            _words[wordIndexToHide].Toggle();
        }

        _totalHiddenWords += revisedNumOfWords;
    }

    // Toggles all words that are stored in the _revealedWordIndices and moves index int to _hiddenWordIndices
    public void HideAllWords()
    {
        int totalRevealedWords = _totalWords - _totalHiddenWords;
        for (int i = 0; i < totalRevealedWords; i++)
        {
            int wordIndexToHide = _revealedWordIndices[totalRevealedWords-i-1];

            _revealedWordIndices.RemoveAt(totalRevealedWords-i-1);
            _hiddenWordIndices.Add(wordIndexToHide);

            _words[wordIndexToHide].Toggle();
        }
        
        _totalHiddenWords = _totalWords;
    }

    // Toggles all that are stored in the _hiddenWordIndices and moves index int to _revealedWordIndices
    public void RevealAllWords()
    {
        for (int i = 0; i < _totalHiddenWords; i++)
        {
            int wordIndexToHide = _hiddenWordIndices[_totalHiddenWords-i-1];

            _hiddenWordIndices.RemoveAt(_totalHiddenWords-i-1);
            _revealedWordIndices.Add(wordIndexToHide);

            _words[wordIndexToHide].Toggle();
        }
        
        _totalHiddenWords = 0;
    }
    
}