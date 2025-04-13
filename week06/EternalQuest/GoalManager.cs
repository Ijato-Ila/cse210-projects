using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // LEVELING SYSTEM
    private int _level = 1;
    private int _nextLevelThreshold = 500;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points. [Level {_level}]"); // LEVEL DISPLAY
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Types of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int count = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, count, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level); // LEVELING SYSTEM
            writer.WriteLine(_nextLevelThreshold); // LEVELING SYSTEM

            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved!");
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]); // LEVELING SYSTEM
        _nextLevelThreshold = int.Parse(lines[2]); // LEVELING SYSTEM

        for (int i = 3; i < lines.Length; i++) // Adjusted index
        {
            string[] parts = lines[i].Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    _goals.Add(SimpleGoal.Deserialize(parts));
                    break;
                case "EternalGoal":
                    _goals.Add(EternalGoal.Deserialize(parts));
                    break;
                case "ChecklistGoal":
                    _goals.Add(ChecklistGoal.Deserialize(parts));
                    break;
            }
        }

        Console.WriteLine("Goals loaded!");
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points! Total score: {_score}");

            CheckLevelUp(); // LEVELING SYSTEM
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    // LEVELING SYSTEM: Check for level ups
    private void CheckLevelUp()
    {
        while (_score >= _nextLevelThreshold)
        {
            _level++;
            _nextLevelThreshold += 500;
            Console.WriteLine($"\n🎉 Congrats! You leveled up to Level {_level}!");
        }
    }
}
