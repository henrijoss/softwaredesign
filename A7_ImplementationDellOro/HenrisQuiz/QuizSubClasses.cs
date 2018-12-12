namespace HenrisQuiz {
    class QuizSingle:QuizElement {
        public Answer[] answers;
        public override void Show() { }
        public override bool IsAnswerChoiceCorrect() { 
            return false;
        }
    }
    class QuizMultiple:QuizElement {
        public Answer[] answers;
        public override void Show() { }
        public override bool IsAnswerChoiceCorrect() { 
            return false;
        }
    }
    class QuizGuess:QuizElement {
        public int correct;
        public override void Show() { }
        public override bool IsAnswerChoiceCorrect() { 
            return false;
        }
    }
    class QuizBinary:QuizElement {
        bool correct;
        public override void Show() { }
        public override bool IsAnswerChoiceCorrect() { 
            return false;
        }
    }
    class QuizFree:QuizElement {
        public string correct;
        public override void Show() { }
        public override bool IsAnswerChoiceCorrect() { 
            return false;
        }
    }
}