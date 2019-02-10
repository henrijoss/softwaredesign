using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Linq;

namespace Timetable
{
    public class Students
    {
        public string courseOfStudies { get; set; }
        public int semester { get; set; }
        public string[] obligatoryEvents { get; set; }
        public int numberOfStudents { get; set; }
        public bool CheckStudentsObligatoryEvents(Course course)
        {
            if (this.obligatoryEvents.Contains(course.eventName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}