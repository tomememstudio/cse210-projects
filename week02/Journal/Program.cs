// Exceeded requirements by ensuring journal prompts never repeat and reserving the final prompt to encourage free writing.
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");
            Console.WriteLine("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");

                string response = Console.ReadLine();
                Entry entry = new Entry(prompt, response);

                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayEntries();
            }
            else if (choice == "3")
            {
                Console.Write("Filename: ");
                journal.SaveToFile(Console.ReadLine());
            }
            else if (choice == "4")
            {
                Console.Write("Filename: ");
                journal.LoadFromFile(Console.ReadLine());
            }
            else if (choice == "5")
            {
                running = false;
            }
        }
    }
}