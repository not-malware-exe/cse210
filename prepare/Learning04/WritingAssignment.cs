class WritingAssignment : Assignment
{
    protected string _title;

    public WritingAssignment(string student_name, string topic, string title) : base(student_name,topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"{_title} by {_student_name}";
    }
}