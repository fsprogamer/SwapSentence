using System;

namespace SwapSentence
{
    public class Program
    {
        public static string ReverseWords(string sentence)
        {
            string[] words = sentence.Split(' ');
            Array.Reverse(words);
            return string.Join(" ", words);
        }
        public static void ProcessFile()
        {
            string s;
            int numberOfCases;

            s = Console.ReadLine();
            bool result = int.TryParse(s, out numberOfCases);
            for (int i = 0; i <= numberOfCases; i++)
            {
                if ((s = Console.ReadLine()) != null)
                {
                    Console.WriteLine("Case #{0}: {1}", i + 1, ReverseWords(s));
                }
            }
        }
        static void Main(string[] args)
        {
            ProcessFile();
        }
    }
}
