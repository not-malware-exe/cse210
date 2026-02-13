
class Reference
{
    private string _chapter = "Genesis 1";
    private int _firstVerse = 1;
    private int _lastVerse = 5;

    // Constructors
    public Reference(string chapter = "Genesis 1", int verse = 1)
    {
        _chapter = chapter;
        _firstVerse = verse;
        _lastVerse = verse;
    }

    public Reference(string chapter = "Genesis 1", int firstVerse = 1, int lastVerse = 5)
    {
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
    }

    // Returns reference as string
    public string GetReference()
    {
        string referenceString = $"{_chapter}: {_firstVerse}";
        if (_lastVerse != _firstVerse)
        {
            referenceString += $"-{_lastVerse}";
        }
        return referenceString;
    }
}