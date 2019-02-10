using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace Timetable
{
    public class Block
    {
        public string day { get; set; }
        public int blockIndex { get; set; }
        public int blockNumber { get; set; }
        public string blockTime { get; set; }
        public List<Course> courses = new List<Course>();
        public List<ElectiveCourse> electiveCourses = new List<ElectiveCourse>();
        private readonly IWritableReadable readerWriter = new ConsoleWriterReader();
        public bool CheckIfBlocked(Course course)
        {
            string eventProfessor = course.professor.name;

            for (int i = 0; i < course.students.Count; i++)
            {
                string eventCourseOfStudies = course.students[i].courseOfStudies;
                int eventSemester = course.students[i].semester;
                
                for (int j = 0; j < this.courses.Count; j++)
                {
                    for (int k = 0; k < this.courses[j].students.Count; k++)
                    {
                        string courseOfStudies = this.courses[j].students[k].courseOfStudies;
                        int semester = this.courses[j].students[k].semester;
                        string professor = this.courses[j].professor.name;

                        if (courseOfStudies == eventCourseOfStudies && semester == eventSemester || professor == eventProfessor)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool CheckIfRoomIsBlocked(Room room)
        {
            foreach (Course currentCourse in this.courses)
            {
                if (currentCourse.room.name == room.name)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckIfRoomIsBlockedGeneraly(Room room)
        {
            foreach (ElectiveCourse electiveCourse in this.electiveCourses)
            {
                if (electiveCourse.roomUsed == room.name)
                {
                    return true;
                }
            }
            return false;
        }
        public void PrintSpecificCourses(string info)
        {
            readerWriter.Write("****************** " + this.day + " " + this.blockNumber + ". Block " + this.blockTime + " ******************");
            foreach (Course course in this.courses)
            {
                if (CheckIfCourseContainsInformation(info, course))
                {
                    PrintCourse(course);
                }
            }
        }
        public bool CheckIfCourseContainsInformation(string info, Course course)
        {
                for (int i = 0; i < course.students.Count; i++)
                {
                    string students = course.students[i].courseOfStudies + course.students[i].semester;
                    if (info == students || info == course.professor.name || info == course.room.name)
                    {   
                        return true;
                    }
                }
            return false;
        }
        public void PrintAllCourses()
        {
            readerWriter.Write("****************** " + this.day + " " + this.blockNumber + ". Block " + this.blockTime + " ******************");
            foreach (Course course in courses)
            {
                PrintCourse(course);
            }
        }
        public void PrintCourse(Course course)
        {
            readerWriter.Write(course.eventName);
            for (int i = 0; i < course.students.Count; i++)
            {
                readerWriter.Write(course.students[i].courseOfStudies + " " + course.students[i].semester);
            }
            readerWriter.Write(course.professor.name);
            readerWriter.Write(course.room.name + "\n");
        }
        public bool PrintElectiveCoursesTimetable(string info)
        {
            bool studentsHaveTime = false;
            foreach (Course course in courses)
            {
                for (int i = 0; i < course.students.Count; i++)
                {
                    string students = course.students[i].courseOfStudies + course.students[i].semester;
                    if (info != students)
                    {
                        studentsHaveTime = true;
                    }
                    else
                    {
                        studentsHaveTime = false;
                        return studentsHaveTime;
                    }
                }
            }
            return studentsHaveTime;
        }
        public void PrintElectiveCourseInformation(string info)
        {
            readerWriter.Write("****************** " + this.day + " " + this.blockNumber + ". Block " + this.blockTime + " ******************");
            if (PrintElectiveCoursesTimetable(info))
            {
                foreach (ElectiveCourse electiveCourse in electiveCourses)
                {
                    readerWriter.Write(electiveCourse.electiveCourseName);
                    readerWriter.Write(electiveCourse.professorName);
                    readerWriter.Write(electiveCourse.roomUsed + "\n");
                }
            }
        }
    }
}