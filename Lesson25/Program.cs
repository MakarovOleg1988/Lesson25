using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Lesson25
{
    class Program
    {
        static void Main(string[] args)
        {
            var _path = Environment.CurrentDirectory + "//Lesson25.exe";
            var _file = Environment.CurrentDirectory + "//newFile.txt";

            if (args.Length > 0)
            {
                using (var _stream = File.Create(_file))
                {
                    using (var _writer = new StreamWriter(_stream))
                    {
                        _writer.WriteLine("Hello Man!");
                    }
                }
            }
            else
            {
                var _process = Process.Start(_path, "args < 0");

                while (!File.Exists(_file))
                {
                    Thread.Sleep(200);
                }

                var _stream = File.OpenRead(_file);
                var _reader = new StreamReader(_stream);
                Console.WriteLine(_reader.ReadToEnd());

                _reader.Close();
                _stream.Close();
            }
        }
    }
}
