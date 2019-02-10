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
    class Program
    {
        public static Timetable timetable = new Timetable();
        static void Main(string[] args)
        {
            timetable.TryToGenerateTimetable();
            timetable.DisplayPrintMenu();
        }  
    }  
}
