using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        ShowDailyReminder(); // Enhancement #8

        string userChoice = "";

        while (userChoice != "4")
        {
            Console.WriteLine("\nWelcome to the Mindfulness Program\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = Console.ReadLine();

            DateTime startTime = DateTime.Now;

            if (userChoice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                DateTime endTime = DateTime.Now;
                int duration = (int)(endTime - startTime).TotalSeconds;
                ActivityLog.LogActivity("Breathing Activity", duration);
            }
            else if (userChoice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                DateTime endTime = DateTime.Now;
                int duration = (int)(endTime - startTime).TotalSeconds;
                ActivityLog.LogActivity("Reflecting Activity", duration);
            }
            else if (userChoice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                DateTime endTime = DateTime.Now;
                int duration = (int)(endTime - startTime).TotalSeconds;
                ActivityLog.LogActivity("Listing Activity", duration);
            }
            else if (userChoice != "4")
            {
                Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
            }
        }

        SaveLastActivityDate(); // Enhancement #8
        ActivityLog.ShowSummary(); // Show activity log summary
        Console.WriteLine("\nThank you for using the Mindfulness Program. Have a peaceful day! 🌿");
    }

    // Enhancement #8 - Daily Reminder
    static void ShowDailyReminder()
    {
        string filePath = "last_activity.txt";

        if (File.Exists(filePath))
        {
            string lastDate = File.ReadAllText(filePath);
            if (DateTime.TryParse(lastDate, out DateTime lastActiveDate))
            {
                if (lastActiveDate.Date < DateTime.Now.Date)
                {
                    Console.WriteLine("🌞 Welcome back! Don’t forget to take time for yourself today.\n");
                }
            }
        }
        else
        {
            Console.WriteLine("🌞 Welcome! Start your mindfulness journey today!\n");
        }
    }

    static void SaveLastActivityDate()
    {
        File.WriteAllText("last_activity.txt", DateTime.Now.ToString());
    }
}
