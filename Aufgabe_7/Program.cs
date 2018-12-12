using System;
using System.Collections.Generic;

namespace Aufgabe_7
{
    
    class Program
    {
        static List<Quizelement> listOfQuestions = new List<Quizelement>();
        static int score = 0;
        static int answeredQuestions = 0;
        static void Main(string[] args)
        {
            int userInput = 0;
            do 
            {
                Console.WriteLine("Score: " + score + "\nAnswered qestions: " + answeredQuestions + "\nWhat do you want to do ? \n 1) Play Quiz \n 2) Add Quizelement \n 3) Quit");
                userInput = Int32.Parse(Console.ReadLine());
                switch(userInput)
                {
                    case 1:
                        StartQuiz();
                        break;
                    case 2:
                        AddQuestion();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please choose one of the options (1/2/3) \n");
                        break;
                }
            } while (userInput != 3);
        }

        static public void StartQuiz()
        {
            listOfQuestions.Add(new QuizSingle("The C# keyword \"int\" maps to which .NET type?", new Answer[] {
                new Answer("System.Int16", false),
                new Answer("System.Int32", true),
                new Answer("System.Int64", false),
                new Answer("System.Int128", false)
            }));
            listOfQuestions.Add( new QuizMultiple("Which of the following is correct about C#", new Answer[] {
                new Answer("It is component oriented.", true),
                new Answer("It can be compiled on a variety of computer platforms.", true),
                new Answer("It was developed by Apple", false),
                new Answer("It is a part of .Net Framework.", true)
            }) );
            listOfQuestions.Add( new QuizBinary("Does C# support multiple inheritance?", false));
            listOfQuestions.Add( new QuizGuess("When was C# developed? (year)", 2000));
            listOfQuestions.Add( new QuizFree("Which datatype in C# should be more preferred for storing a simple number like 35 to improve execution speed of a program ?", "sbyte"));

            int randomQuizElement = Random();
            listOfQuestions[randomQuizElement].show();
            string choice = Console.ReadLine();
            if (listOfQuestions[randomQuizElement].isAnswerCorrect(choice)) 
            {
                Console.WriteLine("Correct Answer! \n");
                score ++;
                answeredQuestions++;
            } 
            else 
            {
                Console.WriteLine("Wrong Answer! \n");
                score --;
            }
        }

        public static int Random() 
        {
            Random rnd = new Random();
            int rInt = rnd.Next(listOfQuestions.Count);
            return rInt;
        }

        static public void AddQuestion()
        {
            Console.WriteLine("What type of question do you want to add ? \n 1. QuizSingle \n 2. QuizMultiple \n 3. QuizBinary \n 4. QuizGuess \n 5. QuizFree");
            string questionType = Console.ReadLine();
            Console.WriteLine("Whats the question ?");
            string question = Console.ReadLine();
            switch(questionType)
            {
                case "1":
                    listOfQuestions.Add(NewQuizSingle(question));
                    break;
                case "2":
                    listOfQuestions.Add(NewQuizMultiple(question));
                    break;
                case "3":
                    listOfQuestions.Add(NewQuizBinary(question));
                    break;
                case "4":
                    listOfQuestions.Add(NewQuizFree(question));
                    break;
                case "5":
                    listOfQuestions.Add(NewQuizFree(question));
                    break;
            }
            Console.WriteLine("Your quizelement has been added successfully");
        }

        public static Quizelement NewQuizSingle(string question) 
        {
            Console.WriteLine("How many possible answers should the question have?");
            int numberOfAnswers = Int32.Parse(Console.ReadLine());
            Answer[] arrayOfAnswers = new Answer[numberOfAnswers];
            Console.WriteLine("Type in the correct answer:");
            arrayOfAnswers[0] = new Answer(Console.ReadLine(), true);
            for (int i = 1; i < numberOfAnswers; i++) 
            {
                Console.WriteLine("Type in a wrong answer:");
                arrayOfAnswers[i] = new Answer(Console.ReadLine(), false);
            }
            return new QuizSingle(question, arrayOfAnswers);
        }

        public static Quizelement NewQuizMultiple(string question) 
        {
            Console.WriteLine("How many possible answers should the question have?");
            int numberOfAnswers = Int32.Parse(Console.ReadLine());
            Answer[] arrayOfAnswers = new Answer[numberOfAnswers];
            for (int i = 1; i < numberOfAnswers; i++) 
            {
                Console.WriteLine("Type in an answer:");
                string answer = Console.ReadLine();
                Console.WriteLine("Is the answer correct ? (y/n)");
                bool isTrue = Console.ReadLine() == "y";
                arrayOfAnswers[i] = new Answer(answer, isTrue);
            }
            return new QuizSingle(question, arrayOfAnswers);
        }

        public static Quizelement NewQuizBinary(string question) 
        {
            Console.WriteLine("Is the answer correct? (y/n)");
            bool theAnswer = Console.ReadLine() == "y";
            return new QuizBinary(question, theAnswer);
        }

        public static Quizelement NewQuizGuess(string question) 
        {
            Console.WriteLine("What is the correct number?");
            return new QuizGuess(question, Int32.Parse(Console.ReadLine()));
        }

        public static Quizelement NewQuizFree(string question) 
        {
            Console.WriteLine("What is the correct answer?");
            return new QuizFree(question, Console.ReadLine());
        }
    }
}
