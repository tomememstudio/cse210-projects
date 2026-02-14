// Creativity Feature:
// A leveling system has been added based on the user's total score.
// The user advances one level for every 1000 points earned,
// and the current level is displayed alongside the score.

using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            int level = (_score / 1000) + 1;
            Console.WriteLine($"\nScore: {_score} | Level: {level}");

            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoals();
            else if (choice == "3") RecordEvent();
            else if (choice == "4") Save();
            else if (choice == "5") Load();
            else if (choice == "6") break;
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    private void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");

        if (int.TryParse(Console.ReadLine(), out int index))
        {
            index--;

            if (index >= 0 && index < _goals.Count)
            {
                int earned = _goals[index].RecordEvent();
                _score += earned;

                Console.WriteLine($"You earned {earned} points!");
            }
        }
    }

    private void Save()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }
    }

    private void Load()
    {
        if (!File.Exists("goals.txt"))
            return;

        _goals.Clear();

        string[] lines = File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            if (type == "Simple")
            {
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
            }
            else if (type == "Eternal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "Checklist")
            {
                _goals.Add(new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6])
                ));
            }
        }
    }
}
