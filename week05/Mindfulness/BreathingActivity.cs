using System;
using System.Threading;

public class BreathingActivity : Activity
{
    private string _inhaleMessage = "Breathe in...";
    private string _exhaleMessage = "Breathe out...";

    public BreathingActivity(string name, string description, int duration)
        : base(name, description, duration)
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(_inhaleMessage);
            ShowSpinner(4); 
            Console.WriteLine(_exhaleMessage);
            ShowSpinner(6); 
        }

        DisplayEndingMessage();
    }
}
