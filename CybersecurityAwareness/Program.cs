using System;
using CybersecurityAwareness;


namespace AwarenessBot
{
    internal class Program
    {
        // Shared memory manager to store user data across the program
        public static MemoryManager Memory = new MemoryManager();
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear(); //Background colour must cover the whole page

            BorderDrawer.DrawBorder();

            Console.ForegroundColor = ConsoleColor.Cyan;

            //The voice greeting
            VoiceGreeting.Play();

            //Image display
            ASCIIArt.Display();

            //User interaction 
            Console.WriteLine("\nHello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online");
            Console.Write("What's your name? ");
            string name = Console.ReadLine();
            Memory.Name = name;
            Console.WriteLine($"It is nice to meet you, {name}!\n");

            UserInteraction.ProvideResponses();

            Console.ForegroundColor = ConsoleColor.Red;
            BorderDrawer.DrawBorder();

            ConsoleEnhancer.EnhanceConsoleUI();

            Console.ResetColor();
        }
       

    }
}
