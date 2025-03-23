using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<string> entries = new List<string>(); // List to store journal entries

    // Add a new entry
    public void AddEntry(string prompt, string response)
    {
        string date = DateTime.Now.ToShortDateString();
        string entry = $"{date} | {prompt} | {response}";
        entries.Add(entry);
    }

    // Display all entries
    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (string entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Save journal entries to a file
    public void SaveToFile(string filename)
    {
        File.WriteAllLines(filename, entries);
        Console.WriteLine($"Journal saved to {filename}.");
    }

    // Load journal entries from a file
    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            entries.Clear(); // Clear existing entries before loading new ones
            entries.AddRange(File.ReadAllLines(filename)); // Read all lines and store them

            Console.WriteLine($"Journal loaded from {filename}.\n");

            // Automatically display the loaded entries
            DisplayJournal();
        }
        else
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
        }
    }
}
