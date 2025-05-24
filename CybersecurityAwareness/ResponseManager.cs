using System;
using System.Collections.Generic;
using AwarenessBot;

namespace CybersecurityAwareness
{
    /// <summary>
    /// Manages topic-specific cybersecurity responses and personalizes them.
    /// </summary>
    internal static class ResponseManager
    {
        private static Random rnd = new Random(); // For selecting random tips
        private static Random rng = new Random(); // For controlling 40% personalization

        /// <summary>
        /// Handles phishing-related responses.
        /// </summary>
        public static void HandlePhishingResponse()
        {
            var phishingTips = new List<string>
            {
                "Phishing is the fraudulent communications that may appear legitimate and come from a reputable source, usually through emails or text messages.",
                "Avoid clicking on any links in unsolicited emails or messages! Always verify the source first.",
                "Enable two-factor authentication wherever possible to add an extra layer of security.",
                "Be careful of emails that ask for personal information. Scammers often disguise themselves as trusted organizations."
            };

            string message = phishingTips[rnd.Next(phishingTips.Count)];

            if (rng.NextDouble() < 0.4)
            {
                message = Program.Memory.PersonalizeResponse(message);
            }

            Console.WriteLine(message);
        }

        /// <summary>
        /// Handles password-related responses.
        /// </summary>
        public static void HandlePasswordResponse()
        {
            var passwordSafety = new List<string>
            {
                "Use a strong password to prevent unauthorized access to your accounts and sensitive data.",
                "Enable two-factor authentication whenever possible. It adds another layer of security using your phone or device.",
                "Update your passwords regularly! Change them at least once a year, especially after any data breach."
            };

            string message = passwordSafety[rnd.Next(passwordSafety.Count)];

            if (rng.NextDouble() < 0.4)
            {
                message = Program.Memory.PersonalizeResponse(message);
            }

            Console.WriteLine(message);
        }

        /// <summary>
        /// Handles safe browsing-related responses.
        /// </summary>
        public static void HandleSafeBrowsingResponse()
        {
            var saferBrowsing = new List<string>
            {
                "Use HTTPS websites to ensure your data is encrypted and secure.",
                "Be cautious with links and attachments — especially from unknown senders.",
                "Keep your browser and software updated to stay protected from vulnerabilities.",
                "Install and maintain trusted antivirus or anti-malware software, and consider using a VPN for added privacy."
            };

            string message = saferBrowsing[rnd.Next(saferBrowsing.Count)];

            if (rng.NextDouble() < 0.4)
            {
                message = Program.Memory.PersonalizeResponse(message);
            }

            Console.WriteLine(message);
        }

        /// <summary>
        /// Handles ransomware-related responses.
        /// </summary>
        public static void HandleRansomwareResponse()
        {
            var ransomwareTips = new List<string>
            {
                "Ransomware is malware that locks your files and demands payment to unlock them.",
                "Keep secure backups of important data — preferably offline or in the cloud.",
                "Use up-to-date antivirus software and make sure your systems receive regular security updates.",
                "Restrict administrative privileges to reduce the risk of ransomware damage."
            };

            string message = ransomwareTips[rnd.Next(ransomwareTips.Count)];

            if (rng.NextDouble() < 0.4)
            {
                message = Program.Memory.PersonalizeResponse(message);
            }

            Console.WriteLine(message);
        }

        /// <summary>
        /// Handles spyware-related responses.
        /// </summary>
        public static void HandleSpywareResponse()
        {
            var spywareTips = new List<string>
            {
                "Spyware is software installed without your knowledge that secretly gathers data about your activity.",
                "Use reputable anti-spyware and anti-malware tools to detect and remove spyware threats.",
                "Be cautious when downloading free software, apps, or browser extensions — they may contain hidden spyware.",
                "Review and limit app permissions, especially access to your microphone, camera, and location."
            };

            string message = spywareTips[rnd.Next(spywareTips.Count)];

            if (rng.NextDouble() < 0.4)
            {
                message = Program.Memory.PersonalizeResponse(message);
            }

            Console.WriteLine(message);
        }

        /// <summary>
        /// Handles MITM (Man-in-the-Middle) attack-related responses.
        /// </summary>
        public static void HandleMITMResponse()
        {
            var mitmTips = new List<string>
            {
                "A man-in-the-middle (MITM) attack occurs when an attacker intercepts communication between two parties.",
                "Avoid using public Wi-Fi for sensitive transactions — use a VPN to protect your data.",
                "Enable multi-factor authentication (MFA) to make unauthorized access more difficult.",
                "Always ensure you're using encrypted connections like HTTPS and secure messaging apps."
            };

            string message = mitmTips[rnd.Next(mitmTips.Count)];

            if (rng.NextDouble() < 0.4)
            {
                message = Program.Memory.PersonalizeResponse(message);
            }

            Console.WriteLine(message);
        }
    }
}
