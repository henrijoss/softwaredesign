using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace Timetable
{
    public class Course
    {
        public string eventName { get; set; }
        public string[] equipment { get; set; }
        public List<Students> students = new List<Students>();
        public Professor professor;
        public Room room;
        public string errorReport;
        public bool CheckIfAllInformationIsAssigned()
        {
            if (this.students == null)
            {
                errorReport = "Keine Studenten für den Kurs " + this.eventName + " gefunden!";
                return false;
            }
            else if (this.professor == null)
            {
                errorReport = "Kein professor für den Kurs " + this.eventName + " gefunden!";
                return false;
            }
            return true;
        }
        public void AddStudentsToCourse(Students students)
        {
            if (students.CheckStudentsObligatoryEvents(this) == true)
            {
                this.students.Add(students);
            }
        }
        public void AddProfessorsToCourse(Professor professor)
        {
            if (professor.CheckProfessorCourses(this) == true)
            {
                this.professor = professor;
            } 
        }
    }
    public class ElectiveCourse
    {   
        public string electiveCourseName { get; set; }
        public int takesPlaceAtBlock { get; set; }
        public string roomUsed { get; set; }
        public string professorName { get; set; }
    }
}