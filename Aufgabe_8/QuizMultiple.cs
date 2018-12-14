using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

using System.Globalization;
using Newtonsoft.Json.Converters;

namespace Aufgabe_8 {
    class QuizMultiple : QuizElement 
    {
        [JsonProperty("answers")]
        public Answer[] answers { get; set; }  
        public QuizMultiple (String question, Answer[] answers)
        {
            this.question = question;
            this.answers = answers;
            this.callToAction = "Type in the numbers of the correct answers seperated by \",\" ";
            this.type = "Multiple";
        }
        public override void Show() 
        { 
             Console.WriteLine(question);
            for (int i = 0; i < this.answers.Length; i++)
            {
                int questionNumber = i + 1;
                Console.WriteLine(questionNumber + ") " + this.answers[i].text);
            }
            Console.WriteLine(callToAction);
        }
        public override bool IsAnswerChoiceCorrect(string choice)
        {
            string[] parts = Array.ConvertAll(choice.Split(','), p => p.Trim());
            int[] pickedAnswers = Array.ConvertAll(parts, int.Parse);

            int numberOfCorrectAnswers = 0;
            for (int i = 0; i < answers.Length; i++) 
            {
                if (answers[i].isTrue == true) 
                {
                    numberOfCorrectAnswers++;
                }
            }

            if (numberOfCorrectAnswers != pickedAnswers.Length)
            {
                Console.WriteLine("You either picked too less or too much correct answers");
                return false;
            } 
            else 
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    try {
                        if (answers[pickedAnswers[i] - 1].isTrue == false) 
                        {
                            Console.WriteLine("At least one of the answers was wrong");
                            return false;
                        } 
                    } 
                    catch 
                    {
                        Console.WriteLine("At least one of the answers you selected does not exist");
                    }
                }
            }
            return true;
        }
    }
}