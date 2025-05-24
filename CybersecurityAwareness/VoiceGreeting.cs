using System.Media;


namespace CybersecurityAwareness
{
    internal static class VoiceGreeting
    {
        public static void Play()
        {
            string filepath = "C:\\Users\\lab_services_student\\Desktop\\Prog6211-POEPart2-Hadebe-Owethu\\PROG6211-POEPART2\\CybersecurityAwareness\\voiceRecording.wav";


            using (SoundPlayer player = new SoundPlayer(filepath))
            {
                player.PlaySync();
            }
        }
    }
}
