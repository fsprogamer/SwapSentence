using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace T9
{
    public class Program
    {
        private static Dictionary<char, string> map;
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
            catch (Exception ex)
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

        private static void BuildMap()
        {
            map = new Dictionary<char,string>();

            map['a'] = "2";
            map['b'] = "22";
            map['c'] = "222";

            map['d'] = "3";
            map['e'] = "33";
            map['f'] = "333";

            map['g'] = "4";
            map['h'] = "44";
            map['i'] = "444";

            map['j'] = "5";
            map['k'] = "55";
            map['l'] = "555";

            map['m'] = "6";
            map['n'] = "66";
            map['o'] = "666";

            map['p'] = "7";
            map['q'] = "77";
            map['r'] = "777";
            map['s'] = "7777";

            map['t'] = "8";
            map['u'] = "88";
            map['v'] = "888";

            map['w'] = "9";
            map['x'] = "99";
            map['y'] = "999";
            map['z'] = "9999";

            map[' '] = "0";
        }
        /// <summary>
        /// Encodes a string to the T9 format.
        /// </summary>
        public static string EncodeString(string clearText)
        {
            BuildMap();
            string result = clearText.ToLower();

            // Remove digits.
            result = Regex.Replace(result, "[2-9]", string.Empty);

            // Translate to SMS.
            StringBuilder sb = new StringBuilder();
            var last = '#';
            if (string.IsNullOrEmpty(clearText))
                sb.Append("0");
            else
                foreach (char c in clearText)
                {
                    var digits = map[c];
                    var next = digits[0];
                    if (last.Equals(next))
                        sb.Append(" ");
                    sb.Append(map[c]);
                    last = digits[digits.Length - 1];
                }           
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            int numberOfCases;
            string stdIn = ProcessFile(Console.OpenStandardInput()).Result;
            string[] sentenceArray = SplitOnSentences(stdIn);
            if (sentenceArray != null)
            {
                bool result = int.TryParse(sentenceArray[0], out numberOfCases);
                for (int i = 1; i <= numberOfCases; i++)
                {
                    Console.WriteLine("Case #{0}: {1}", i, EncodeString(sentenceArray[i]) );
                }
            }
        }
    }
}
