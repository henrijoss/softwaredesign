using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

using System.Globalization;
using Newtonsoft.Json.Converters;

namespace Aufgabe_8 {
    class QuizGuess : QuizElement 
    {

        [JsonProperty("correct")]
        public int correct { get; set; }  

        public QuizGuess (String question, int correct)
        {
            this.question = question;
            this.correct = correct;
            this.callToAction = "Guess the correct Number:";
            this.type = "Guess";

        }
        public override void Show() 
        { 
            Console.WriteLine(question);
            Console.WriteLine(callToAction);
        }
        public override bool IsAnswerChoiceCorrect(string choice)
        {
            try {
                int currentChoice = Int32.Parse(choice);
                if (currentChoice == correct)
                {
                    return true;
                } 
                else 
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Your Input was not valid");
                return false;
            }
        }
    }
}