using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

using System.Globalization;
using Newtonsoft.Json.Converters;

namespace Aufgabe_8 {
    class QuizBinary : QuizElement 
    {
        [JsonProperty("correct")]
        bool correct { get; set; }  

        public QuizBinary (String question, bool isTrue)
        {
            this.question = question;
            this.correct = isTrue;
            this.callToAction = "Type in yes or no (y/n):";
            this.type = "Binary";

        }
        public override void Show() 
        { 
            Console.WriteLine(question);
            //Console.WriteLine(callToAction);
        }
        public override bool IsAnswerChoiceCorrect(string choice)
        {
            bool theAnswer = (choice == "y");
            if (theAnswer == correct)
            {
                return true;
            } else {
                return false;
            }
        }
    }
}