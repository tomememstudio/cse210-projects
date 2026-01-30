using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("Learning C#", "CodeSchool", 600);
        v1.AddComment(new Comment("Anna", "Very helpful video"));
        v1.AddComment(new Comment("James", "I finally understand classes"));
        v1.AddComment(new Comment("Ruth", "Please upload more"));
        videos.Add(v1);

        Video v2 = new Video("Faith and Discipline", "Daily Devotion", 420);
        v2.AddComment(new Comment("Paul", "This blessed me"));
        v2.AddComment(new Comment("Sarah", "Simple and powerful"));
        v2.AddComment(new Comment("Mark", "Thank you for this"));
        videos.Add(v2);

        Video v3 = new Video("Life in Lagos", "Naija Vlogs", 780);
        v3.AddComment(new Comment("Sola", "Naija vibes 🔥"));
        v3.AddComment(new Comment("Tunde", "Miss home"));
        v3.AddComment(new Comment("Amaka", "Nice editing"));
        videos.Add(v3);

        foreach (Video video in videos)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.Name}: {comment.Text}");
            }
        }
    }
}
