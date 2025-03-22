using System;

class Program
{
    static void Main()
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his only begotten Son");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine().Trim().ToLower();
            if (input == "quit" || scripture.IsFullyHidden())
                break;

            scripture.HideRandomWords();
        }

        Console.WriteLine("Program ended.");
    }
}
