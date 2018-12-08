using System;

namespace Aufgabe_7
{
    class QuizGuess : Quizelement
    {
        public int correct;
        public QuizGuess (String question, int correct)
        {
            this.question = question;
            this.correct = correct;
            this.callToAction = "Guess the correct Number:";

        }
        public override void show(){
            Console.WriteLine(question);
            Console.WriteLine(callToAction);
        }
        public override bool isAnswerCorrect(string choice){
            int currentChoice = Int32.Parse(choice);
            if (currentChoice == correct)
            {
                return true;
            } else {
                return false;
            }
        }
    }
}