using System;
using System.Collections.Generic;

namespace HenrisQuiz
{
    class QuizElement
    {
        public string question;
        public string callToAction;

        
        public virtual void Show() { }
        public virtual bool IsAnswerChoiceCorrect() { 
            return false;
        }
    }
}
