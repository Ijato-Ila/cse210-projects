using System;
using System.Collections.Generic;

public static class ActivityLog
{
    private static List<string> _logs = new List<string>();
    private static int _totalTime = 0;

    public static void LogActivity(string activityName, int duration)
    {
        _logs.Add($"{activityName} - {duration} seconds");
        _totalTime += duration;
    }

    public static void ShowSummary()
    {
        Console.WriteLine("\nMindfulness Session Summary:");
        Console.WriteLine("----------------------------");

        if (_logs.Count == 0)
        {
            Console.WriteLine("No activities recorded.");
        }
        else
        {
            foreach (string log in _logs)
            {
                Console.WriteLine($"✔️ {log}");
            }
            Console.WriteLine($"\n🕒 Total Time Spent: {_totalTime} seconds");
        }
    }
}

