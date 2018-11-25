using System;
using System.Collections.Generic;

namespace Aufgabe_6
{
    class Program
    {
        static List<Quizelement> listOfQuestions = new List<Quizelement>();
        static int score = 0;
        static int answeredQuestions = 0;
        static void Main(string[] args)
        {
            DisplayMenu();

        }
        static public void DisplayMenu()
        {   
            Console.WriteLine("Bisher beantwortete Fragen " + answeredQuestions);
            Console.WriteLine("Score: " + score);
            Console.WriteLine();
            Console.WriteLine("Was möchten Sie tun ?");
            Console.WriteLine();
            Console.WriteLine("1. Neues Quizelement anlegen");
            Console.WriteLine("2. Quizfrage beantworten");
            Console.WriteLine("3. Exit");
            string userInput = Console.ReadLine();
            if (userInput == "1"){
                newQuizQuestion();
            } else if (userInput == "2") {
                ShowQuizQuestion();
            } else if (userInput == "3") {
                System.Environment.Exit(1);
            }
        }
        public static void CreateQuestions()
        {
            Quizelement quiz1 = new Quizelement();
            quiz1.question = "Wer war der 1.Bundeskanzler der BRD ?";
            quiz1.answers = new Answer[4];
            quiz1.answers[0] = new Answer { answer = "Barack Obama", isTrue = false };
            quiz1.answers[1] = new Answer { answer = "Helmut Kohl", isTrue = false };
            quiz1.answers[2] = new Answer { answer = "Konrad Adenauer", isTrue = true };
            quiz1.answers[3] = new Answer { answer = "Angela Merkel", isTrue = false };

            Quizelement quiz2 = new Quizelement();
            quiz2.question = "Super Mario gilt als bekannteste Videospielfigur der Welt. Was ist sein Markenzeichen?";
            quiz2.answers = new Answer[3];
            quiz2.answers[0] = new Answer { answer = "grüne Mütze", isTrue = false };
            quiz2.answers[1] = new Answer { answer = "blaue Latzhose", isTrue = true };
            quiz2.answers[2] = new Answer { answer = "gelbes Hemd", isTrue = false };

            Quizelement quiz3 = new Quizelement();
            quiz3.question = "In welchem Land wurde das Computerspiel Tetris erfunden?";
            quiz3.answers = new Answer[5];
            quiz3.answers[0] = new Answer { answer = "Deutschland", isTrue = false };
            quiz3.answers[1] = new Answer { answer = "Japan", isTrue = false };
            quiz3.answers[2] = new Answer { answer = "Russland", isTrue = true };
            quiz3.answers[3] = new Answer { answer = "Amerika", isTrue = false };
            quiz3.answers[4] = new Answer { answer = "Frankreich", isTrue = false };

            Quizelement quiz4 = new Quizelement();
            quiz4.question = "Was bedeuten die Silben Nin-ten-do?";
            quiz4.answers = new Answer[3];
            quiz4.answers[0] = new Answer { answer = "Aufgabe-Himmel-Tempel", isTrue = true };
            quiz4.answers[1] = new Answer { answer = "Spiel-Lösung-Haus", isTrue = false };
            quiz4.answers[2] = new Answer { answer = "Mut-Geschick-Vertrauen", isTrue = false };


            listOfQuestions.Add(quiz1);
            listOfQuestions.Add(quiz2);
            listOfQuestions.Add(quiz3);
            listOfQuestions.Add(quiz4);
        }

        public static int random(){
            Random rnd = new Random();
            int rInt = rnd.Next(listOfQuestions.Count);
            return rInt;
        }

        public static void ShowQuizQuestion() {
                CreateQuestions();
                Quizelement currentQuiz = listOfQuestions[random()];
                currentQuiz.show();
                Console.WriteLine();
                Console.WriteLine("Antwort eingeben:");
                int eingabe = Int32.Parse(Console.ReadLine());
                if (currentQuiz.IsAnswerChoiceCorrect(eingabe) == true) 
                {
                    score++;
                } else {
                    score--;
                }
                answeredQuestions++;
                DisplayMenu();
        }
        public static void newQuizQuestion() {
            Quizelement newQuizQuestion = new Quizelement();
            Console.WriteLine("Wie lautet die Quizfrage?");
            newQuizQuestion.question = Console.ReadLine();
            Console.WriteLine("Wie viele Antwortmöglichkeiten soll es geben?");
            int numberOfAnswers = Int32.Parse(Console.ReadLine());
            newQuizQuestion.answers = new Answer[numberOfAnswers];
            for (int i = 0; i < numberOfAnswers; i++) {
                int zeahler = i + 1;
                Console.WriteLine("Wie lautet die " + zeahler + ". Antwortmöglichkeit");
                string currentAnswer = Console.ReadLine();
                Console.WriteLine("Ist diese Antwort die richtige ? (ja/nein)");
                string isAnswerCorrect = Console.ReadLine();
                bool correctOrNot = true;
                if (isAnswerCorrect == "ja") {
                    correctOrNot = true;
                } else if (isAnswerCorrect == "nein") {
                    correctOrNot = false;
                }
                newQuizQuestion.answers[i] = new Answer { answer = currentAnswer, isTrue = correctOrNot };
            }
            listOfQuestions.Add(newQuizQuestion);
            Console.WriteLine("Ihre Quizfrage wurde erfolgreich eingespeichert");
            Console.WriteLine();
            DisplayMenu();
        }
    }
}
