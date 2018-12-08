using System;

namespace Aufgabe_7
{
    class Quizelement
    {
        public string question;
        public Answer[] answers;
        public string callToAction;

        public virtual void show(){
            Console.WriteLine(question);
            for (int i = 0; i < this.answers.Length; i++)
            {
                int questionNumber = i + 1;
                Console.WriteLine(questionNumber + ") " + this.answers[i].text);
            }
            Console.WriteLine(callToAction);
        }

        public virtual bool isAnswerCorrect(string choice){
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
