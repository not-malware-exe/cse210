using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignmentExample = new Assignment("Samuel Bennett","Multiplication");
        Console.WriteLine(assignmentExample.GetSummary());

        MathAssignment mathAssignmentExample = new MathAssignment("Roberto Rodriguez","Fractions","7.3","8-19");
        Console.WriteLine(mathAssignmentExample.GetSummary());
        Console.WriteLine(mathAssignmentExample.GetHomeworkList());

        WritingAssignment writingAssignmentExample = new WritingAssignment("Mary Waters","European History","The Causes of World War II");
        Console.WriteLine(writingAssignmentExample.GetSummary());
        Console.WriteLine(writingAssignmentExample.GetWritingInformation());
    }
}