using System.IO;

namespace Plor_V4
{
    class FileManager
    {
        //File Exists:
        public bool fileExists(string path)
        {
            return File.Exists(path);
        }

        //Dir Exists:
        public bool dirExists(string path)
        {
            return Directory.Exists(path);
        }

        //Get Files:
        public string[] getFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        //Get Dirs:
        public string[] getDirs(string path)
        {
            return Directory.GetDirectories(path);
        }

        //Read:
        public string[] read(string path)
        {
            StreamReader sr = new StreamReader(path);
            int lineNumber = File.ReadAllLines(path).Length;
            int line = 0;
            string[] lines = new string[lineNumber];

            while (!sr.EndOfStream)
            {
                lines[line] = sr.ReadLine();
                line++;
            }

            sr.Dispose();
            return lines;
        }
    }
}