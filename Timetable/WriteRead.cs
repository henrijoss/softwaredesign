using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace Timetable
{
    public interface IWritableReadable
    {
        void Write(string text);
        string Read();
    }
    public class ConsoleWriterReader : IWritableReadable
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}