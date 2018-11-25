using System;
using System.Collections.Generic;

namespace Aufgabe_6
{
    class Quizelement
    {
        public string question;
        public Answer[] answers;

        public void show(){
            Console.WriteLine();
            Console.WriteLine(question);
             for (int i = 0; i < this.answers.Length; i++)
            {
                int questionNumber = i + 1;
                Console.WriteLine(questionNumber + ") " + this.answers[i].answer);

            }
        }
        public bool IsAnswerChoiceCorrect(int choice)
        {

            if (answers[choice - 1].isTrue == true)
            {
                Console.WriteLine("Richtige Antwort!");
                Console.WriteLine();
                return true;

            } else {
                Console.WriteLine("Die Antwort war leider falsch :(");
                Console.WriteLine();
                return false;
            }
        }
    }    
}
