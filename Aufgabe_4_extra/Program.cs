using System;
using System.Text;

namespace Aufgabe_4_extra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(reverseSentence("Hallo dies ist ein test"));
        }
        public static string Reverse(string sentence)
        {   
            char[] charArray = sentence.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
        }
        public static string ReverseWords(string sentence) 
        {
            string[] words = sentence.Split(' ');
            Array.Reverse(words);
            sentence = String.Join(" ", words);
            return sentence;
        }
        public static string reverseSentence(string sentence) 
        {
            string[] words = sentence.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words.Length; i++) 
            {
                sb.Append(Reverse(words[i]));
                sb.Append(" ");            
            }
            return sb.ToString();
        }
    }
}
