using System;
using System.Threading;

public abstract class Activity
{
    
    private string _name;
    private string _description;
    private int _duration; 

  
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

  
    protected string Name { get { return _name; } }
    protected string Description { get { return _description; } }
    protected int Duration { get { return _duration; } }

 
    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name}!");
        Console.WriteLine(_description);
        Console.WriteLine($"Duration: {_duration} seconds");
        Console.WriteLine("Get ready...");
        ShowSpinner(3); 
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nGreat job!");
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    
    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b"); 
            i++;
        }
    }

    public abstract void Run();
}
