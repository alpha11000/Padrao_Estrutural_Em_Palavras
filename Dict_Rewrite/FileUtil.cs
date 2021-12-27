using System;
using System.IO;

namespace Dict_Rewrite
{
    internal class FileUtil
    {
        public static string[] openFile(string fileName)
        {

            string[] words;

            try
            {
                words = File.ReadAllLines(fileName);
            }catch(IOException e)
            {
                return new string[0];
            }

            for(int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }
            
            return words;
        }

        public static void writeToFile(string fileName, string[] content)
        {
            File.WriteAllLines(fileName, content);
        }
    }
}
