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
            Console.WriteLine(ReverseSentence(sentence));

        }
        public static string ReverseByLetter(string sentence)
        {   
            char[] charArray = sentence.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string ReverseByWord(string sentence) 
        {
            string[] words = sentence.Split(' ');
            Array.Reverse(words);
            sentence = String.Join(" ", words);
            return sentence;
        }
        public static string ReverseEachWordByLetterButKeepWordOrder(string sentence) 
        {
            string reversedLetters = ReverseByLetter(reversedWords)
            string wordsReversedByLetter = ReverseByWord(reversedLetters);
            return wordsReversedByLetter;
        }
    }
}
