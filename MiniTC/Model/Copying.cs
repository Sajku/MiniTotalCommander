using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Model
{
    static class Copying
    {
        public static void CopyFile(string s, string d)
        {
            Console.WriteLine("COPYYYYYY!");
            File.Copy(@s, @d);
        }
    }
}
