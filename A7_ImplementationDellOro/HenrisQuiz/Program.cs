using System;
using System.Collections.Generic;

namespace HenrisQuiz
{
    class Program
    {
        static public List<QuizElement> listOfQuestions = new List<QuizElement>();
        static int score = 0;
        static int answeredQuestions = 0;
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Henri's Quiz");
            CreateQuizElements();
            DisplayMenu();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Some Info. Type 'p' to play, 'c' to create quiz element or 'q' to quit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "p":
                    AnswerQuizElement();
                    break;
                case "c":
                    AddNewQuizElement();
                    break;
                case "q":
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        static void CreateQuizElements()
        {
            listOfQuestions.Add(new QuizSingle());
            listOfQuestions.Add(new QuizMultiple());
            listOfQuestions.Add(new QuizBinary());
            listOfQuestions.Add(new QuizGuess());
            listOfQuestions.Add(new QuizFree());
        }
        static void AnswerQuizElement()
        {
            QuizElement current = listOfQuestions[PickRandomQuizElement()];
            current.Show();
            Console.WriteLine(@"What's the correct answer? Type it...");
            string answer = Console.ReadLine();
            if (current.IsAnswerChoiceCorrect())
                score += 1;
            else
                score -= 1;

            answeredQuestions++;

            DisplayMenu();
        }
        static void AddNewQuizElement()
        {
            Console.WriteLine(@"Which type of Quiz? Type 
            's' for single choice,
            'm' for multiple choice,
            'b' for binary (true/false),
            'g' for guess,
            'f' for free");
            string type = Console.ReadLine();
            Console.WriteLine(@"What's the question? Type it...");
            string question = Console.ReadLine();

            string correctAnswer;
            switch (type)
            {
                /* disabled, design lacking 
                TODO: implement when designed
                case "s":
                    break;
                case "m":
                    break;
                */
                case "b":
                    Console.WriteLine(@"Type 't' for true and 'f' for false as correct answer");
                    correctAnswer = Console.ReadLine();
                    break;
                case "g":
                    Console.WriteLine(@"Type the correct number");
                    correctAnswer = Console.ReadLine();
                    break;
                case "f":
                    Console.WriteLine(@"Type the correct answer");
                    correctAnswer = Console.ReadLine();
                    break;
            }

            listOfQuestions.Add(new QuizElement());

            DisplayMenu();
        }
        static int PickRandomQuizElement()
        {
            int randomQuestionIndex = random.Next(0, listOfQuestions.Count);
            return randomQuestionIndex;
        }
    }
}
