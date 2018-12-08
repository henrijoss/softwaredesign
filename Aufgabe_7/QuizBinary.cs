using System;

namespace Aufgabe_7
{
    class QuizBinary : Quizelement
    {
        public bool isTrue;
        public QuizBinary (String question, bool isTrue)
        {
            this.question = question;
            this.isTrue = isTrue;
            this.callToAction = "Type in yes or no (y/n):";

        }
        public override void show()
        {
            Console.WriteLine(question);
            Console.WriteLine(callToAction);
        }
        public override bool isAnswerCorrect(string choice)
        {
            bool theAnswer = (choice == "y");
            if (theAnswer == isTrue)
            {
                return true;
            } else {
                return false;
            }
        }
    }
}