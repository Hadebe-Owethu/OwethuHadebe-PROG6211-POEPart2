using System;


namespace CybersecurityAwareness
{
    internal static class BorderDrawer
    {
        public static void DrawBorder()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string border = new string('*', Console.WindowWidth);

            Console.WriteLine(border);

            for (int i = 0; i < Console.WindowHeight - 3; i++)
            {
                Console.WriteLine("*" + new string(' ', Console.WindowWidth - 2) + "*");
            }
            Console.WriteLine(border);
            Console.WriteLine(border); Console.SetCursorPosition(1, 1);
        }
    
}
}
