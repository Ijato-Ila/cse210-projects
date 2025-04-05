using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Display a daily reminder message when the program starts.
        ShowDailyReminder();

        string userChoice = ""; // Variable to store user's menu choice.

        // Run the program until the user chooses to quit (option 4).
        while (userChoice != "4")
        {
            // Display the program menu and prompt user to make a choice.
            Console.WriteLine("\nWelcome to the Mindfulness Program\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = Console.ReadLine(); // Read the user's choice.

            DateTime startTime = DateTime.Now; // Record the start time for the activity.

            // Start Breathing Activity when user selects option 1.
            if (userChoice == "1")
            {
                BreathingActivity breathing = new BreathingActivity(); // Create an instance of BreathingActivity.
                breathing.Run(); // Call the Run method to start the activity.
                DateTime endTime = DateTime.Now; // Record the end time for the activity.
                int duration = (int)(endTime - startTime).TotalSeconds; // Calculate the duration.
                ActivityLog.LogActivity("Breathing Activity", duration); // Log the activity with its duration.
            }
            // Start Reflecting Activity when user selects option 2.
            else if (userChoice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity(); // Create an instance of ReflectingActivity.
                reflecting.Run(); // Call the Run method to start the activity.
                DateTime endTime = DateTime.Now; // Record the end time for the activity.
                int duration = (int)(endTime - startTime).TotalSeconds; // Calculate the duration in seconds.
                ActivityLog.LogActivity("Reflecting Activity", duration); // Log the activity with its duration.
            }
            // Start Listing Activity when user selects option 3.
            else if (userChoice == "3")
            {
                ListingActivity listing = new ListingActivity(); // Create an instance of ListingActivity.
                listing.Run(); // Call the Run method to start the activity.
                DateTime endTime = DateTime.Now; // Record the end time for the activity.
                int duration = (int)(endTime - startTime).TotalSeconds; // Calculate the duration in seconds.
                ActivityLog.LogActivity("Listing Activity", duration); // Log the activity with its duration.
            }
            // If the user enters an invalid choice, display an error message.
            else if (userChoice != "4")
            {
                Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
            }
        }

        // Save the date of the last activity after quitting.
        SaveLastActivityDate();

        // Display the activity log summary (e.g., list of all completed activities).
        ActivityLog.ShowSummary();

        // Display a final thank you message before the program ends.
        Console.WriteLine("\nThank you for using the Mindfulness Program. Have a peaceful day! 🌿");
    }

    //Show a daily reminder to encourage users to take time for mindfulness.
    static void ShowDailyReminder()
    {
        string filePath = "last_activity.txt"; // File to store the date of the last activity.

        // Check if the file exists (i.e., if the user has used the program before).
        if (File.Exists(filePath))
        {
            string lastDate = File.ReadAllText(filePath); // Read the last activity date from the file.
            if (DateTime.TryParse(lastDate, out DateTime lastActiveDate)) // Try to parse the date.
            {
                // If the last activity date is earlier than today, display a reminder.
                if (lastActiveDate.Date < DateTime.Now.Date)
                {
                    Console.WriteLine("🌞 Welcome back! Don’t forget to take time for yourself today.\n");
                }
            }
        }
        else
        {
            // If the file doesn't exist (first time using the program), display a welcome message.
            Console.WriteLine("🌞 Welcome! Start your mindfulness journey today!\n");
        }
    }

    // Save the current date to track the last time the user used the program.
    static void SaveLastActivityDate()
    {
        File.WriteAllText("last_activity.txt", DateTime.Now.ToString()); // Write the current date to the file.
    }
}
