using System;
using System.IO;
using System.Threading.Tasks;

namespace SwapSentence
{
    public class Program
    {
        public static string[] ReverseWords(string[] words)
        {            
            Array.Reverse(words);
            return words;
        }
       
        public async static Task<string> ProcessFile(Stream stream)
        {
            string stdin = null;
            try
            {
                if (Console.IsInputRedirected)
                {
                    using (StreamReader reader = new StreamReader(stream, Console.InputEncoding))
                    {
                        stdin = await reader.ReadToEndAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return stdin;
        }
        public static string[] SplitOnSentences(string stdin)
        {            
            return stdin?.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);            
        }
        public static string[] SplitOnWords(string stdin)
        {            
            return stdin?.Split(' ');
        }
        public static string JoinWords(string[] words)
        {
            return string.Join(" ", words);
        }

        static void Main(string[] args)
        {
            int numberOfCases;
            string stdIn = ProcessFile(Console.OpenStandardInput()).Result;
            string[] sentenceArray = SplitOnSentences(stdIn);
            if (sentenceArray != null) { 
                bool result = int.TryParse(sentenceArray[0], out numberOfCases);
                for (int i = 1; i <= numberOfCases; i++)
                {
                    Console.WriteLine("Case #{0}: {1}", i, JoinWords(ReverseWords(SplitOnWords(sentenceArray[i]))));
                }
            }
        }      
    }
}
