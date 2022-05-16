using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Model
{
    class PanelModel
    {
        private string currentPath;
        private string errorDescription;

        public List<string> UpdateFiles()
        {
            List<string> list = new List<string>();
            if (currentPath != null)
            {
                try
                {
                    string[] directories = Directory.GetDirectories(currentPath);
                    string[] files = Directory.GetFiles(currentPath);
                    if (currentPath.Count(f => f == '\\') != 1)
                    {
                        list.Add("..");
                    }

                    foreach (string d in directories)
                    {
                        list.Add("<D>" + Path.GetFileName(d));
                    }
                    foreach (string f in files)
                    {
                        list.Add(Path.GetFileName(f));
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access error");
                    currentPath = Path.GetDirectoryName(currentPath);
                    currentPath = currentPath.Remove(currentPath.Length - 1, 1);
                    errorDescription = "Error - Odmowa dostępu!";
                }

            }
            return list;
        }

        public List<string> getDrives()
        {
            List<string> list = new List<string>();
            Console.WriteLine("CLICK!!!");
            string[] x = Directory.GetLogicalDrives();

            foreach (string str in x)
            {
                //Console.WriteLine(str);
                list.Add(str);
            }

            return list;
        }

        public string changePath(string s)
        {
            // RETURN TO PREVIOUS DIRECTORY
            if (s == "..")
            {
                currentPath = Path.GetDirectoryName(Path.GetDirectoryName(currentPath));
                if (currentPath.Last() != '\\')
                {
                    currentPath += "\\";
                }
            }
            else
            {
                s = s.Remove(0, 3);
                currentPath += s;
                currentPath += "\\";
            }

            return currentPath;
        }

        public void setPath(string s)
        {
            currentPath = s;
        }
    }
}
