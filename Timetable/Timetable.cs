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
    public class Timetable
    {
        public static JsonPersistence jsonPersistence = new JsonPersistence();
        public List<ElectiveCourse> electiveCourse = jsonPersistence.deserializeElectiveCourses();
        public List<Block> blocks = jsonPersistence.deserializeBlocks();
        public List<Students> students = jsonPersistence.deserializeStudents();
        public List<Professor> professors = jsonPersistence.deserializeProfessors();
        public List<Room> rooms = jsonPersistence.deserializeRooms();
        public CourseCreator courseCreator = new CourseCreator();
        public List<Course> courses;
        public Random random = new Random();
        public int triedTimetables;
        private readonly IWritableReadable readerWriter = new ConsoleWriterReader();
        public Timetable()
        {
            this.courses = courseCreator.GenerateCourses();
            triedTimetables = 0;
            foreach (ElectiveCourse electiveCourse in electiveCourse)
            {
                blocks[electiveCourse.takesPlaceAtBlock-1].electiveCourses.Add(electiveCourse);
            }
        }
        public void TryToGenerateTimetable()
        {
            readerWriter.Write("Stundenplan wird generiert...");
            this.GenerateTimetable(0, 0);
            if (courses.Count != 0)
            {
                readerWriter.Write("Die generierung des Stundenplans hat mehr Zeit in Anspruch genommen als erwartet. \nBitte überprüfen Sie die Daten!");
                Environment.Exit(0);
            }
            else
            {
                readerWriter.Write("Der Stundenplan wurde erfolgreich erstellt! \n");
            }
        }
        public void GenerateTimetable(int currentBlock, int currentCourse)
        {
            if (courses.Count != 0) // Wenn noch nicht alle Kurse zugeordnet werden konnten
            {
                if (currentBlock < blocks.Count) // Nur wenn noch nicht alle Blöcke versucht worden sind
                {
                    if (currentCourse < courses.Count) // Wenn noch nicht alle Events versucht worden sind
                    {
                        if (blocks[currentBlock].CheckIfBlocked(courses[currentCourse]) == false && courses[currentCourse].professor.IsProfessorBlocked(blocks[currentBlock]) == false)
                        {
                            AddCourseToBlockOrTryNextCourse(currentBlock, currentCourse);
                        }
                        else // Wenn aktueller Kurs aufgrund anderem Kurs oder Professor nicht geht -> nächster Kurs
                        {
                            GenerateTimetable(currentBlock, currentCourse+1);
                        }    
                    }
                    else // Wenn alle bei aktuellem Block versucht worden sind -> nächster Block
                    {
                        GenerateTimetable(currentBlock+1, 0);
                    }
                }
                else
                {
                    TryNextTimetable();
                }
            }
        }
        public void AddCourseToBlockOrTryNextCourse(int currentBlock, int currentCourse)
        {
            if (TryToAddRoomToCourse(currentBlock, currentCourse))
            {
                blocks[currentBlock].courses.Add(courses[currentCourse]);
                courses.Remove(courses[currentCourse]);
            }
            GenerateTimetable(currentBlock, currentCourse+1);
        }
        public bool TryToAddRoomToCourse(int currentBlock, int currentCourse)
        {
            foreach (Room room in rooms)
            {
                    if (CheckIfRoomIsFitting(room, courses[currentCourse], blocks[currentBlock]))
                    {
                        courses[currentCourse].room = room;
                        return true;
                    }
            }
            return false;
        }
        public bool CheckIfRoomIsFitting(Room room, Course course, Block block)
        {
            if (room.CheckRoomEquipment(course) == true && room.CheckRoomCapacity(course) == true && block.CheckIfRoomIsBlocked(room) == false && block.CheckIfRoomIsBlockedGeneraly(room) == false)
            {
                return true;
            }
            return false;
        }
        public void ResetTimetable()
        {
            foreach (Block block in blocks)
            {
                for (int i = 0; i < block.courses.Count; i++)
                {
                    courses.Add(block.courses[i]);
                }
                block.courses.Clear();
            }
        }
        public void TryNextTimetable()
        {
            triedTimetables++;
            if (triedTimetables < 10000)
            {
                ResetTimetable();
                ShuffleCourses(courses);
                GenerateTimetable(0, 0);
            }
        }
        public void ShuffleCourses<Course>(List<Course> courses)
        {
            int listLength = courses.Count;  
            while (listLength > 1) {  
                listLength--;  
                int k = random.Next(listLength + 1);  
                Course value = courses[k];  
                courses[k] = courses[listLength];  
                courses[listLength] = value;  
            }  
        }
        public void DisplayPrintMenu()
        {
            while (true)
            {
                readerWriter.Write("Wessen Stundenplan möchten Sie sehen?");
                readerWriter.Write("1) Gesamtstundenplan anzeigen");
                readerWriter.Write("2) Stundenplan für eine Kohorte anzeigen");
                readerWriter.Write("3) Studenplan für ein Dozenti anzeigen");
                readerWriter.Write("4) Studenplan für einen Raum anzeigen");
                readerWriter.Write("5) Mögliche WPM's für eine Kohorte anzeigen");
                readerWriter.Write("6) Beenden \n");

                string input = readerWriter.Read();
                switch (input)
                {
                    case "1":
                        // this.ShowAvailabelOptions("all");
                        this.PrintCompleteTimetable();
                        break;
                    case "2":
                        this.ShowAvailabelStudentOptions("students");
                        break;
                    case "3":
                        this.ShowAvailabelOptions("professor");
                        break;
                    case "4":
                        this.ShowAvailabelOptions("room");
                        break;
                    case "5":
                        this.ShowAvailabelStudentOptions("electiveCourse");
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        readerWriter.Write("Bitte wählen Sie eine der Möglichkeiten \n");
                        break;
                }
            }
        }
        public void ShowAvailabelOptions(string info)
        {
            switch (info)
            {
                case "professor":
                    readerWriter.Write("Bitte wählen Sie einen Professor aus: \n");
                    for (int i = 0; i < professors.Count; i++)
                    {
                        readerWriter.Write(i + ") " + professors[i].name);
                    }
                    int professorChoice = Convert.ToInt32(readerWriter.Read());
                    this.PrintSpecificTimetable(professors[professorChoice].name);
                    break;
                case "room":
                    readerWriter.Write("Bitte wählen Sie einen Raum aus: \n");
                    for (int i = 0; i < rooms.Count; i++)
                    {
                        readerWriter.Write(i + ") " + rooms[i].name);
                    }
                    int roomChoice = Convert.ToInt32(readerWriter.Read());
                    this.PrintSpecificTimetable(rooms[roomChoice].name);
                    break;
            }
        }
        public void ShowAvailabelStudentOptions(string option)
        {
            readerWriter.Write("Bitte wählen Sie einen Studiengang und ein Semester aus: \n");
            for (int i = 0; i < students.Count; i++)
            {
                readerWriter.Write(i + ") " + students[i].courseOfStudies + students[i].semester);
            }
            int input = Convert.ToInt32(readerWriter.Read());
            string info = students[input].courseOfStudies + students[input].semester;
            if (option == "students")
            {
                this.PrintSpecificTimetable(info);
            }
            else if (option == "electiveCourse")
            {
                this.PrintElectiveCourseTimetable(info);
            }
        }
        public void PrintSpecificTimetable(string info)
        {
            foreach(Block block in blocks)
            {
                block.PrintSpecificCourses(info);
            }
        }
        public void PrintElectiveCourseTimetable(string info)
        {
            foreach (Block block in blocks)
            {
                block.PrintElectiveCourseInformation(info);
            }
        }
        public void PrintCompleteTimetable()
        {
            foreach(Block block in blocks)
            {
                block.PrintAllCourses();
            }
        }
    }
}