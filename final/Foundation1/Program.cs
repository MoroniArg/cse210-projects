using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video #1
        Video video1 = new Video("C# Tutorial for Beginners", "John Doe", 600);
        video1.Comments.Add(new Comment("Alice", "Great tutorial!"));
        video1.Comments.Add(new Comment("Bob", "Very helpful, thanks!"));
        video1.Comments.Add(new Comment("Charlie", "I learned a lot."));      

        // Video #2
        Video video2 = new Video("Advanced C# Programming", "Jane Smith", 1200);
        video2.Comments.Add(new Comment("Dave", "This is exactly what I needed."));
        video2.Comments.Add(new Comment("Eve", "Could you make a part 2?"));
        video2.Comments.Add(new Comment("Frank", "Nice explanation."));

        // Video #3
        Video video3 = new Video("C# Design Patterns", "Chris Johnson", 900);
        video3.Comments.Add(new Comment("Grace", "Well done!"));
        video3.Comments.Add(new Comment("Hank", "Awesome examples."));
        video3.Comments.Add(new Comment("Ivy", "Clear and concise."));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display the info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(); 
        }
    }
}
