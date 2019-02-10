using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Linq;

namespace Timetable
{
    public class Room
    {
        public string name { get; set; }
        public int capacity { get; set; }
        public string[] equipment { get; set; }
        public bool CheckRoomEquipment(Course course)
        {
            bool roomIsFitting = true;
            for (int i = 0; i < course.equipment.Length; i++)
            {
                if (Array.IndexOf(this.equipment, course.equipment[i]) >= 0)
                {
                    roomIsFitting = true;
                }
                else
                {
                    roomIsFitting = false;
                    return roomIsFitting;
                }
            }
            return roomIsFitting;
        }
        public bool CheckRoomCapacity(Course course)
        {
            int completeNumberOfStudents = 0;
            for (int i = 0; i < course.students.Count; i++)
            {
                completeNumberOfStudents += course.students[i].numberOfStudents;
            }
            if (this.capacity >= completeNumberOfStudents)
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