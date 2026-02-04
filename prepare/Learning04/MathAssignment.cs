class MathAssignment : Assignment
{
    protected string _textbookSection;
    protected string _problems;

    public MathAssignment(string student_name, string topic, string textbookSection, string problems) : base(student_name,topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}