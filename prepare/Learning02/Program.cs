using System;

class Program
{
    //Gets only an integer from a user following a prompt.
    static int input_int(string prompt = "")
    {
        Console.WriteLine(prompt);
        string str = Console.ReadLine();

        int value = 0;

        if (int.TryParse(str, out value))
        {
            return value;
        }
        else
        {
            Console.WriteLine("Entry has to be an integer, try again.");
            return input_int(prompt);
        }
    }

    //Returns a "y" or "n" boolean from a user following a prompt.
    static bool input_yn(string prompt = "")
    {
        Console.WriteLine(prompt);
        string str = Console.ReadLine();

        switch (str)
        {
            case "y":
                return true;
            case "n":
                return false;
            default:
                Console.WriteLine("Entry has to be a y or n.");
                return input_yn(prompt);
        }
    }

    //Gets job description from user.
    static Job input_job()
    {
        Job job = new Job();

        Console.WriteLine("Please enter your job title: ");
        job.job_title = Console.ReadLine();
        

        Console.WriteLine("Please enter your company: ");
        job.company = Console.ReadLine();
        

        job.start_year = input_int("Please enter your start year: ");
        job.end_year = input_int("Please enter your end year: ");

        return job;
    }
    static void Main(string[] args)
    {
        // prompts user's name
        Console.WriteLine("Please enter your name: ");
        String name = Console.ReadLine();

        // following code allows user to add several jobs to the job list until user enters "n" when prompted to continue.
        List<Job> jobs = new List<Job>();

        bool adding_job= false;
        do
        {
            adding_job = input_yn("Please enter 'y' if you would add a job to your resume, enter 'n' otherwise.");
            if (adding_job) {jobs.Add(input_job());}
        } while (adding_job);
    
        //Creates resume object using data collected above. Then displays resume.
        Resume resume = new Resume(name,jobs);
        resume.display();

    }
}