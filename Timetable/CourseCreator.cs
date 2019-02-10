using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Timetable
{
    public class CourseCreator
    {
        public static JsonPersistence jsonPersistence = new JsonPersistence();
        public List<Course> courses = jsonPersistence.deserializeCourses();
        public List<Students> students = jsonPersistence.deserializeStudents();
        public List<Professor> professors = jsonPersistence.deserializeProfessors();
        public List<Room> rooms = jsonPersistence.deserializeRooms();
        private readonly IWritableReadable readerWriter = new ConsoleWriterReader();
        public List<Course> GenerateCourses()
        {
            foreach (Course course in courses)
            {
                AddStudentsToCourses(course);
                AddProfessorsToCourses(course);
                if (course.CheckIfAllInformationIsAssigned() == false)
                {
                    Console.WriteLine(course.errorReport);
                    Environment.Exit(0);
                }
            }
            readerWriter.Write("Daten konnten erflogreich geladen werden!");
            return courses;
        }
        public void AddStudentsToCourses(Course course)
        {
            foreach (Students studentClass in students)
            {
                course.AddStudentsToCourse(studentClass);
            }
        }
        public void AddProfessorsToCourses(Course course)
        {
            foreach (Professor professor in professors)
            {
                course.AddProfessorsToCourse(professor);
            }
        }
        
    }
}