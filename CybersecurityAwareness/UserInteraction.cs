using System;
using AwarenessBot;
using CybersecurityAwareness;

namespace CybersecurityAwareness
{
    internal static class UserInteraction
    {
        public static void ProvideResponses()
        {
            // Greet the user and ask about their interest
            Console.WriteLine("You can ask me anything about cybersecurity.");
            Console.WriteLine("Your questions may involve phishing, password safety, my purpose in assisting, mitm, safe browsing, ransomware or spyware.");
            Console.WriteLine("You can type 'exit' at any time to end the session.\n");

            Console.WriteLine("What cybersecurity topics are you most interested in?");
            Console.Write("You: ");
            string interestInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(interestInput))
            {
                Program.Memory.Interest = interestInput.ToLower();
                Console.WriteLine($"That is great! I will remember that you're interested in {interestInput}.");
            }
            
            // Create random generator for occasional personalization
            Random rng = new Random();

            while (true)
            {
                Console.Write("You: ");
                string input = Console.ReadLine()?.ToLower()?.Trim();
                string response = null;

                //Exit check first — only exact match
                if (input == "exit")
                {
                    response = Program.Memory.PersonalizeResponse("Goodbye! Stay safe online.");
                    Console.WriteLine(response);
                    break;
                }

                // Sentiment detection comes next
                var sentiment = SentimentAnalyzer.DetectSentiment(input);
                if (sentiment != UserSentiment.Neutral)
                {
                    response = SentimentAnalyzer.GetSentimentResponse(sentiment, "Can you tell me more so I can assist better?");
                    Console.WriteLine(response);
                    continue;
                }

                // Error check (after sentiment)
                if (ErrorHandler.IsInvalidInput(input))
                {
                    Console.WriteLine(ErrorHandler.GetDefaultResponse());
                    continue;
                }

                // Recall memory
                if (input.Contains("remember") || input.Contains("recall"))
                {
                    if (input.Contains("name"))
                        response = $"I remember, your name is {Program.Memory.Name}";
                    else if (input.Contains("interest"))
                        response = $"You told me that you're interested in {Program.Memory.Interest}";
                }

                // Greeting or identity check
                else if (input.Contains("how are you"))
                {
                    response = "I am just a bot, but I'm functioning well. Thanks for asking!";
                }
                else if (input.Contains("your purpose"))
                {
                    response = "My purpose is to assist and educate users about cybersecurity.";
                }

                // Topic-specific responses
                else if (input.Contains("phishing"))
                {
                    ResponseManager.HandlePhishingResponse();
                    continue;
                }
                else if (input.Contains("password"))
                {
                    ResponseManager.HandlePasswordResponse();
                    continue;
                }
                else if (input.Contains("safe browsing"))
                {
                    ResponseManager.HandleSafeBrowsingResponse();
                    continue;
                }
                else if (input.Contains("ransomware"))
                {
                    ResponseManager.HandleRansomwareResponse();
                    continue;
                }
                else if (input.Contains("spyware"))
                {
                    ResponseManager.HandleSpywareResponse();
                    continue;
                }
                else if (input.Contains("mitm"))
                {
                    ResponseManager.HandleMITMResponse();
                    continue;
                }

                //  Fallback: unknown input, no sentiment
                else
                {
                    response = ErrorHandler.GetDefaultResponse();
                }

                
                if (!string.IsNullOrEmpty(response))
                {
                    Console.WriteLine(response);
                }
            }
        }
    }
}
