using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Burger King";
        job1._jobTitle = "Team Member";
        job1._startYear = 2023;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._company = "Melaleuca";
        job2._jobTitle = "Customer Service Rep";
        job2._startYear = 2024;
        job2._endYear = 2025;

        Resume resume = new Resume();
        resume._name = "Jacob Beacham";

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.DisplayResume();
    }
}