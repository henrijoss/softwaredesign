using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

using System.Globalization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;


namespace Aufgabe_8
{
    class Program
    {
        static List<QuizElement> listOfQuestions = new List<QuizElement>();
        static int score;
        static int answeredQuestions;
        static Random rnd = new Random();
        
        static void Main(string[] args)
        {
            //LoadJson();
            DisplayMenu();
        }

        static void DisplayMenu()
        {
            do {
                Console.WriteLine("Score: " + score + "\nAnswered Questions: " + answeredQuestions);
                Console.WriteLine("Some Info. Type 'p' to play, 'c' to create quiz element or 'q' to quit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "p":
                        LoadJson();
                        PlayQuiz();
                        break;
                    case "c":
                        AddQuizelementToJSON();
                        break;
                    case "q":
                    default:
                        Environment.Exit(0);
                        break;
                }
            } while(true);
        }

        public static JArray LoadJson()
        {
            using (StreamReader r = new StreamReader("listOfQuizelements.json"))
            {
                var json = r.ReadToEnd();
                JArray obj = (JArray)JsonConvert.DeserializeObject(json);
                CreateQuestions(obj);
                return obj;
            }
        }

        public static void CreateQuestions(JArray obj)
        {
            for (int i = 0; i < obj.Count; i ++)
                {
                    dynamic item = obj[i];
                    //dynamic item = obj[rnd.Next(0, obj.Count)];
                    String type = item.type;

                    switch (type)
                    {
                        case "Single":
                            QuizSingle quizSingle = item.ToObject<QuizSingle>();
                            listOfQuestions.Add(quizSingle);
                            break;
                        case "Multiple":
                            QuizMultiple quizMultiple = item.ToObject<QuizMultiple>();
                            listOfQuestions.Add(quizMultiple);
                            break;
                        case "Guess":
                            QuizGuess quizGuess = item.ToObject<QuizGuess>();
                            listOfQuestions.Add(quizGuess);
                            break;
                        case "Binary":
                            QuizBinary quizBinary = item.ToObject<QuizBinary>();
                            listOfQuestions.Add(quizBinary);
                            break;
                        case "Free":
                            QuizFree quizFree = item.ToObject<QuizFree>();
                            listOfQuestions.Add(quizFree);
                            break;
                    }
                }
        }

        public static void PlayQuiz() 
        {
            QuizElement currentQuiz = listOfQuestions[rnd.Next(listOfQuestions.Count)];
            currentQuiz.Show();
            string choice = Console.ReadLine();
            if (currentQuiz.IsAnswerChoiceCorrect(choice)) 
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
        public static JObject AddNewQuizElement() {
            Console.WriteLine("What type of question do you want to add ? \n 1. QuizSingle \n 2. QuizMultiple \n 3. QuizBinary \n 4. QuizGuess \n 5. QuizFree");
            string questionType = Console.ReadLine();
            Console.WriteLine("Whats the question ?");
            string question = Console.ReadLine();
                        switch(questionType)
            {
                case "1":
                    var single = NewQuizSingle(question);
                    JObject jSingle = JObject.FromObject(single);
                    return jSingle;
                case "2":
                    var multiple = NewQuizMultiple(question);
                    JObject jMultiple = JObject.FromObject(multiple);
                    return jMultiple;
                case "3":
                    var binary = NewQuizBinary(question);
                    JObject jBinary = JObject.FromObject(binary);
                    return jBinary;
                case "4":
                    var guess = NewQuizGuess(question);
                    JObject jGuess = JObject.FromObject(guess);
                    return jGuess;
                case "5":
                    var free = NewQuizFree(question);
                    JObject jFree = JObject.FromObject(free);
                    return jFree;
            }
            Console.WriteLine("Something went wrong");
            return null;
        }

        public static QuizElement NewQuizSingle(string question) 
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

        public static QuizElement NewQuizMultiple(string question) 
        {
            Console.WriteLine("How many possible answers should the question have?");
            int numberOfAnswers = Int32.Parse(Console.ReadLine());
            Answer[] arrayOfAnswers = new Answer[numberOfAnswers];
            for (int i = 0; i < numberOfAnswers; i++) 
            {
                Console.WriteLine("Type in an answer:");
                string answer = Console.ReadLine();
                Console.WriteLine("Is the answer correct ? (y/n)");
                bool isTrue = Console.ReadLine() == "y";
                arrayOfAnswers[i] = new Answer(answer, isTrue);
            }
            return new QuizMultiple(question, arrayOfAnswers);
        }

        public static QuizElement NewQuizBinary(string question) 
        {
            Console.WriteLine("Is the answer correct? (y/n)");
            bool theAnswer = false;
            if (Console.ReadLine() == "y")
            {
                theAnswer = true;   
            }
            return new QuizBinary(question, theAnswer);
        }

        public static QuizElement NewQuizGuess(string question) 
        {
            Console.WriteLine("What is the correct number?");
            return new QuizGuess(question, Int32.Parse(Console.ReadLine()));
        }

        public static QuizElement NewQuizFree(string newQuestion) 
        {
            Console.WriteLine("What is the correct answer?");
            // return new QuizFree(question, Console.ReadLine());
            string correctAnswer = Console.ReadLine();
            return new QuizFree(newQuestion, correctAnswer);
        }

        public static void AddQuizelementToJSON()
        {
            JObject newElem = AddNewQuizElement();

            using (FileStream fs = new FileStream("listOfQuizelements.json", FileMode.Append, FileAccess.Write)) {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    JArray array = LoadJson();
                    //JObject jsonObject = JObject.FromObject(obj);
                    array.Add(newElem);
                    string json = JsonConvert.SerializeObject(array, Formatting.Indented);
                    File.WriteAllText("listOfQuizelements.json", json);
                }
            }
        }
    }
}

