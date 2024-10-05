using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Driver";
        job1._company = "Desseret News Paper Delivery - BYU-Idaho";
        job1._startYear = 2022;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Coordinator";
        job2._company = "Grounds Crew 8 - BYU-Idaho";
        job2._startYear = 2023;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Moroni Argueta";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}