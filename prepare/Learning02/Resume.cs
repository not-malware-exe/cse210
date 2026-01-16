public class Resume
{

    public string name = "";
    public List<Job> jobs = new List<Job>();
    
    // constructor for resume
    public Resume(string set_name, List<Job> set_jobs)
    {
        name = set_name;
        jobs = set_jobs;
    }

    // displays the name on the resume and then each job description
    public void display()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Jobs: ");
        foreach (Job job in jobs)
        {
            job.display();
        }
    }
}