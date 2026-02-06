using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("This program will guide you through Breathing, Reflecting, or Listing activities.");
        Console.WriteLine("Take a few minutes to relax and follow the prompts.\n");

        while (true) 
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option (1-4): ");

            string choice = Console.ReadLine();

            if (choice == "4") 
            {
                Console.WriteLine("Thank you for using the Mindfulness Program. Have a peaceful day!");
                break;
            }

            Console.Write("Enter duration in seconds for this activity: ");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.Write("Invalid input. Please enter a positive number for duration: ");
            }

            Activity activity = null; 

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity(
                        "Breathing Activity",
                        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
                        duration);
                    break;

                case "2":
                    activity = new ReflectingActivity(
                        "Reflecting Activity",
                        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
                        duration);
                    break;

                case "3":
                    activity = new ListingActivity(
                        "Listing Activity",
                        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
                        duration);
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please choose 1, 2, 3, or 4.");
                    continue;
            }

            Console.Clear();
            activity.Run(); 

            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
            Console.Clear();
        }
        // I added input validation for duration and clear console screens between activities to improve usability.
    }
}
