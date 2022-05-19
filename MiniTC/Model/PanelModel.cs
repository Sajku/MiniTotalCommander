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
        public string CurrentPath { get; set; }

        public List<string> UpdateFiles()
        {
            List<string> list = new List<string>();
            if (CurrentPath != null)
            {
                string[] directories = Directory.GetDirectories(CurrentPath);
                string[] files = Directory.GetFiles(CurrentPath);
                if (CurrentPath.Count(f => f == '\\') != 1)
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
                CurrentPath = Path.GetDirectoryName(Path.GetDirectoryName(CurrentPath));
                if (CurrentPath.Last() != '\\')
                {
                    CurrentPath += "\\";
                }
            }
            else if (s.StartsWith("<D>"))
            {
                s = s.Remove(0, 3);
                CurrentPath += s;
                CurrentPath += "\\";
            }

            return CurrentPath;
        }

    }
}
