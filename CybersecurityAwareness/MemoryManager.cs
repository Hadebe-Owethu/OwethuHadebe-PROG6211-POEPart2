using System;
using System.Collections.Generic;

namespace CybersecurityAwareness
{
    /// <summary>
    /// Stores user-specific data (e.g., name and interests) and generates personalized responses.
    /// </summary>
    internal class MemoryManager
    {
        // ✅ Dictionary to store all user data (case-insensitive keys)
        private Dictionary<string, string> userData = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Stores or retrieves the user's name.
        /// </summary>
        public string Name
        {
            get => userData.TryGetValue("name", out var name) ? name : null;
            set => userData["name"] = value;
        }

        /// <summary>
        /// Stores or retrieves the user's interest.
        /// </summary>
        public string Interest
        {
            get => userData.TryGetValue("interest", out var interest) ? interest : null;
            set => userData["interest"] = value;
        }

        /// <summary>
        /// Save any custom key-value pair to memory.
        /// </summary>
        public void Remember(string key, string value)
        {
            userData[key.ToLower()] = value;
        }

        /// <summary>
        /// Retrieve a previously saved value using a key.
        /// </summary>
        public string Recall(string key)
        {
            return userData.TryGetValue(key.ToLower(), out var value) ? value : null;
        }

        /// <summary>
        /// Adds personalized context to a message if name and/or interest are available.
        /// </summary>
        public string PersonalizeResponse(string message)
        {
            // If both name and interest are known
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Interest))
            {
                return $"{Name}, since you're interested in {Interest}, {message}";
            }

            // If only name is known
            if (!string.IsNullOrEmpty(Name))
            {
                return $"{Name}, {message}";
            }

            // If only interest is known
            if (!string.IsNullOrEmpty(Interest))
            {
                return $"Since you're interested in {Interest}, {message}";
            }

            // If neither is known, return plain message
            return message;
        }
    }
}
