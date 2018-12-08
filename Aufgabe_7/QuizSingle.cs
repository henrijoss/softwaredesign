using System;

namespace Aufgabe_7
{
    class QuizSingle : Quizelement
    {
        public QuizSingle (String question, Answer[] answers)
        {
            this.question = question;
            this.answers = answers;
            this.callToAction = "Type in the number of the correct answer:";
        }
        public override void show(){
            Console.WriteLine(question);
            for (int i = 0; i < this.answers.Length; i++)
            {
                int questionNumber = i + 1;
                Console.WriteLine(questionNumber + ") " + this.answers[i].text);
            }
            Console.WriteLine(callToAction);
        }
        public override bool isAnswerCorrect(string choice){
            int currentChoice = Int32.Parse(choice);
            if (answers[currentChoice - 1].isCorrect == true)
            {
                return true;
            } else {
                return false;
            }
        }
    }
}