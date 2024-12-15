using System;

class Program
{
    static void Main()
    {
        Address lectureAddress = new Address("123 Main St", "Springfield", "IL", "62701");
        Address receptionAddress = new Address("456 Elm St", "Chicago", "IL", "60601");
        Address outdoorAddress = new Address("789 Oak St", "Peoria", "IL", "61602");

        Lecture lectureEvent = new Lecture("Tech Innovations", "A lecture on the latest in technology.", new DateTime(2024, 12, 20), new TimeSpan(14, 0, 0), lectureAddress, "Dr. Smith", 100);
        Reception receptionEvent = new Reception("Holiday Party", "An annual holiday gathering.", new DateTime(2024, 12, 21), new TimeSpan(18, 0, 0), receptionAddress, "rsvp@company.com");
        OutdoorGathering outdoorEvent = new OutdoorGathering("Summer Picnic", "A fun outdoor picnic event.", new DateTime(2024, 6, 15), new TimeSpan(12, 0, 0), outdoorAddress, "Sunny with a chance of clouds");

        Event[] events = new Event[] { lectureEvent, receptionEvent, outdoorEvent };

        foreach (Event e in events)
        {
            Console.WriteLine("\n--- Standard Details ---");
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine("\n--- Full Details ---");
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine("\n--- Short Description ---");
            Console.WriteLine(e.GetShortDescription());
        }
    }
}
