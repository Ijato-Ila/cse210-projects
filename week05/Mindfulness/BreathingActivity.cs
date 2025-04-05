using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", 
        "This activity will help you relax by guiding you through slow breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);
            Console.WriteLine();

            Console.Write("Now breathe out... ");
            ShowCountdown(4);
            Console.WriteLine("\n");
        }

        DisplayEndingMessage();
    }
}
