public class Job
{
    public string company = "";
    public string job_title = "";
    public int start_year = 0;
    public int end_year = 0;

    // constructor for job that was not necessary for the assignment.
    // public Job(string set_company, string set_job_title, int set_start_year, int set_end_year)
    // {
    //     company = set_company;
    //     job_title = set_job_title;
    //     start_year = set_start_year;
    //     end_year = set_end_year;
    // }

    // displays description of job.
    public void display()
    {
        Console.WriteLine($"{job_title} ({company}) {start_year}-{end_year}");
    }
}