using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace Timetable
{
    public class JsonPersistence 
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented
        };
        public List<Room> deserializeRooms()
        {
            List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(File.ReadAllText(@"room.json"), settings);
            return rooms;
        }
        public List<Students> deserializeStudents()
        {
            List<Students> students = JsonConvert.DeserializeObject<List<Students>>(File.ReadAllText(@"students.json"), settings);
            return students;
        }
        public List<Professor> deserializeProfessors()
        {
            List<Professor> professors = JsonConvert.DeserializeObject<List<Professor>>(File.ReadAllText(@"professor.json"), settings);
            return professors;
        }
        public List<Course> deserializeCourses()
        {
            List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(File.ReadAllText(@"course.json"), settings);
            return courses;
        }
        public List<ElectiveCourse> deserializeElectiveCourses()
        {
            List<ElectiveCourse> electiveCourse = JsonConvert.DeserializeObject<List<ElectiveCourse>>(File.ReadAllText(@"electiveCourse.json"), settings);
            return electiveCourse;
        }
        public List<Block> deserializeBlocks()
        {
            List<Block> blocks = JsonConvert.DeserializeObject<List<Block>>(File.ReadAllText(@"block.json"), settings);
            return blocks;
        }
    }
}