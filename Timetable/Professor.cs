using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Linq;

namespace Timetable
{
    public class Professor
    {
        public string name { get; set; }
        public int[] blockedAtBlocks { get; set; }
        public string[] courses { get; set;}
        public bool CheckProfessorCourses(Course course)
        {
            if (this.courses.Contains(course.eventName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsProfessorBlocked(Block block)
        {
            if (this.blockedAtBlocks.Contains(block.blockIndex))
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