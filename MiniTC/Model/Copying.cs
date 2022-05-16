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
        public static string CopyFile(string s, string d)
        {
            Console.WriteLine("COPYYYYYY!");
            string x = "";
            try
            {
                File.Copy(@s, @d);
            }
            catch (IOException)
            {
                Console.WriteLine("Plik już istnieje!");
                x = "Error - Plik o takiej nazwie juz istnieje!";
            }

            return x;
        }
    }
}
