class Entry
{
    public string _prompt = "";
    public string _responce = "";
    public string _dateStr = "";
    
    //constructor for Entry (manual)
    public Entry(string newPrompt, string newResponce, string newDateStr)
    {
        _prompt = newPrompt;
        _responce = newResponce;
        _dateStr = newDateStr;
    }

    //constructor for Entry (auto date)
    public Entry(string newPrompt, string newResponce)
    {
        _prompt = newPrompt;
        _responce = newResponce;

        DateTime dateTime = DateTime.Now;
        _dateStr = $"{dateTime.Month}/{dateTime.Day}/{dateTime.Year}";
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_dateStr} - Prompt: {_prompt}\n{_responce}");
    }
}