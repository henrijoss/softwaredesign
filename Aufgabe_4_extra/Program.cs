using System;
using System.Text;

namespace Aufgabe_4_extra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geben Sie einen Satz ein:");
            string sentence = Console.ReadLine();
            Console.WriteLine(ReverseWords(sentence));

        }
        public static string ReverseChar(string sentence)
        {   
            char[] charArray = sentence.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string ReverseSentence(string sentence) 
        {
            string[] words = sentence.Split(' ');
            Array.Reverse(words);
            sentence = String.Join(" ", words);
            return sentence;
        }
        public static string ReverseWords(string sentence) 
        {
            string[] words = sentence.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words.Length; i++) 
            {
                sb.Append(ReverseChar(words[i]));
                sb.Append(" ");            
            }
            return sb.ToString();
        }
    }
}
