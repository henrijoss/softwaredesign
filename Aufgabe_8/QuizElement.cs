using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

using System.Globalization;
using Newtonsoft.Json.Converters;

namespace Aufgabe_8
{
    public class QuizElement  
    {  
        [JsonProperty("type")]
        public string type { get; set; }  

        [JsonProperty("question")]
        public string question { get; set; }  

        public string callToAction;


        public virtual void Show()
        {

        }
        public virtual bool IsAnswerChoiceCorrect(string choice) 
        {
            return true;
        } 
    }  
}