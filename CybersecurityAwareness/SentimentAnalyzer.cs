using System;

namespace CybersecurityAwareness
{
    /// <summary>
    /// Represents possible user emotional states.
    /// </summary>
    public enum UserSentiment
    {
        Neutral,
        Curious,
        Frustrated,
        Worried,
        Confused
    }

    /// <summary>
    /// Detects sentiment from user input and generates tone-appropriate responses.
    /// </summary>
    public static class SentimentAnalyzer
    {
        /// <summary>
        /// Analyzes the input text and classifies the user's emotional tone.
        /// </summary>
        public static UserSentiment DetectSentiment(string input)
        {
            string lowerInput = input.ToLower();

            // Check for words related to "worried"
            if (lowerInput.Contains("worried") || lowerInput.Contains("concerned") ||
                lowerInput.Contains("anxious") || lowerInput.Contains("scared") ||
                lowerInput.Contains("nervous") || lowerInput.Contains("afraid") ||
                lowerInput.Contains("stressed") || lowerInput.Contains("uneasy"))
            {
                return UserSentiment.Worried;
            }

            // Check for words related to "curious"
            if (lowerInput.Contains("curious") || lowerInput.Contains("interested") ||
                lowerInput.Contains("what") || lowerInput.Contains("how") ||
                lowerInput.Contains("why") || lowerInput.Contains("?") ||
                lowerInput.Contains("wonder") || lowerInput.Contains("learn"))
            {
                return UserSentiment.Curious;
            }

            // Check for words related to "frustrated"
            if (lowerInput.Contains("frustrated") || lowerInput.Contains("annoyed") ||
                lowerInput.Contains("angry") || lowerInput.Contains("mad") ||
                lowerInput.Contains("upset") || lowerInput.Contains("irritated") ||
                lowerInput.Contains("fed up"))
            {
                return UserSentiment.Frustrated;
            }

            // Check for words related to "confused"
            if (lowerInput.Contains("confused") || lowerInput.Contains("don't understand") ||
                lowerInput.Contains("not sure") || lowerInput.Contains("unclear") ||
                lowerInput.Contains("lost") || lowerInput.Contains("stuck") ||
                lowerInput.Contains("puzzled"))
            {
                return UserSentiment.Confused;
            }

            return UserSentiment.Neutral;
        }

        /// <summary>
        /// Returns a tone-adjusted response based on the user's sentiment.
        /// Randomizes supportive messages to feel more human and less repetitive.
        /// </summary>
        public static string GetSentimentResponse(UserSentiment sentiment, string originalResponse)
        {
            var rng = new Random();

            switch (sentiment)
            {
                case UserSentiment.Worried:
                    var worriedResponses = new[]
                    {
                        "I understand this can be worrying.",
                        "You're not alone in feeling concerned.",
                        "It's okay to feel unsure when it comes to cybersecurity.",
                        "Taking steps to learn is already a strong move."
                    };
                    return $"{worriedResponses[rng.Next(worriedResponses.Length)]} {originalResponse}";

                case UserSentiment.Curious:
                    var curiousResponses = new[]
                    {
                        "That's a great question!",
                        "I'm glad you're curious — it's the key to learning.",
                        "Curiosity is how we grow knowledge.",
                        "Awesome! Let’s explore that together."
                    };
                    return $"{curiousResponses[rng.Next(curiousResponses.Length)]} {originalResponse}";

                case UserSentiment.Frustrated:
                    var frustratedResponses = new[]
                    {
                        "I hear your frustration — cybersecurity can be confusing.",
                        "Let’s try to make this simpler.",
                        "You're not alone — these topics can be tricky.",
                        "No worries, I'm here to help you through it."
                    };
                    return $"{frustratedResponses[rng.Next(frustratedResponses.Length)]} {originalResponse}";

                case UserSentiment.Confused:
                    var confusedResponses = new[]
                    {
                        "Let me try to explain it more clearly.",
                        "Sounds like this needs some clarification.",
                        "Let’s take it step by step.",
                        "No problem — we can go over this together."
                    };
                    return $"{confusedResponses[rng.Next(confusedResponses.Length)]} {originalResponse}";

                default:
                    return originalResponse;
            }
        }
    }
}
