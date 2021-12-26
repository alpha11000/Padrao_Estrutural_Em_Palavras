using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dict_Rewrite
{
    internal class FileUtil
    {
        public static string[] openFile(string fileName)
        {
            string[] words = File.ReadAllLines(fileName);

            for(int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }
            
            return words;
        }

        public static void writeToFile(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
        }
    }
}
