using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

using System.Globalization;
using Newtonsoft.Json.Converters;


namespace Aufgabe_8 {
    class QuizFree : QuizElement 
    {

        [JsonProperty("correct")]
        public string correct { get; set; }  



        public QuizFree (String question, String correct)
        {
            this.question = question;
            this.correct = correct;
            this.callToAction = "Type in the correct answer:";
            this.type = "Free";
        }
        public override void Show() 
        { 
            Console.WriteLine(question);
            Console.WriteLine(callToAction);
        }
       public override bool IsAnswerChoiceCorrect(string choice)
        {
            if (choice == correct)
            {
                return true;
            } else {
                return false;
            }
        }
    }
}