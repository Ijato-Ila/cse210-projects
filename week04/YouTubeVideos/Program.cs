using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("How to Code in C#", "Anastasia Dang", 600);
        Video video2 = new Video("Cooking Pasta 101", "Chef Venus", 480);
        Video video3 = new Video("SpaceX Mars Mission", "Elon Musk", 1200);

        // Add comments to video1
        video1.AddComment(new Comment("Olly", "Great explanation!"));
        video1.AddComment(new Comment("Jill", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Ezra", "Nice tutorial."));

        // Add comments to video2
        video2.AddComment(new Comment("Daniel", "Yummy!"));
        video2.AddComment(new Comment("Sabrina", "Easy to follow!"));
        video2.AddComment(new Comment("Jagger", "Tried it, worked perfectly."));

        // Add comments to video3
        video3.AddComment(new Comment("Dexter", "Can't wait for Mars!"));
        video3.AddComment(new Comment("Rowan", "Amazing technology."));
        video3.AddComment(new Comment("Asap", "Very informative."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}
