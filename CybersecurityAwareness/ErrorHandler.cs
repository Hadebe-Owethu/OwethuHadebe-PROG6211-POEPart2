using System;
using System.Collections.Generic;

namespace CybersecurityAwareness
{
    /// <summary>
    /// Handles fallback responses and input validation for the chatbot.
    /// </summary>
    public static class ErrorHandler
    {
        // ✅ List of varied fallback responses
        private static readonly List<string> DefaultResponses = new List<string>
        {
            "I'm not sure that I understand properly, can you please rephrase your question?",
            "Can you please clarify again what you would like to know?",
            "I want to make sure I address your concern correctly. Could you please rephrase?",
            "That didn’t quite make sense to me. Could you try asking in another way?",
            "Hmm, I didn't catch that. Want to try rephrasing?"
        };

        /// <summary>
        /// Returns a randomly selected fallback response.
        /// </summary>
        public static string GetDefaultResponse()
        {
            Random rnd = new Random();
            return DefaultResponses[rnd.Next(DefaultResponses.Count)];
        }

        /// <summary>
        /// Determines if the user's input is too short or vague to process.
        /// Allows known sentiment words to pass through even if short.
        /// </summary>
        public static bool IsInvalidInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return true;

            string trimmed = input.Trim().ToLower();

            // ✅ Let known sentiment keywords through even if short
            string[] knownSentimentKeywords =
            {
                "confused", "worried", "frustrated", "curious", "scared",
                "angry", "anxious", "nervous", "lost", "upset"
            };

            foreach (var word in knownSentimentKeywords)
            {
                if (trimmed.Contains(word))
                    return false; // ✅ Consider this valid input
            }

            // ✅ Default invalid criteria: input is short or one word
            return trimmed.Length < 2 || trimmed.Split(' ').Length < 2;
        }
    }
}
