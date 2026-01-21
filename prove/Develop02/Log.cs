// using System.IO;

class Log
{
    List<Entry> _entries = new List<Entry>();

    // appends entry
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // displays all entries
    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // saves all entries to chosen file
    public void Save(string filePath)
    {
        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._dateStr}`{entry._prompt}`{entry._responce}");
            }
        }
    }

    // appends all entries from chosen file
    public void Load(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split("`");

            string dateStr = parts[0];
            string prompt = parts[1];
            string responce = parts[2];
            Entry newEntry = new Entry(prompt,responce,dateStr);
            AddEntry(newEntry);
        }
    }

    // erases all entries from log and file
    public void Erase(string filePath)
    {
        _entries.Clear();
        new StreamWriter(filePath);
    }
}