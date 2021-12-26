using System;
using System.Collections.Generic;

namespace Dict_Rewrite
{
    internal class Rewriter
    {
        List<referenceCode> references = new List<referenceCode>();

        public void addVariousReferences(string[] words)
        {
            int i = 0;
            int s = words.Length;
            int percent = 0;
            int lastPercent = -1;

            foreach (string word in words)
            {
                addToReference(word);
                i++;

                percent = (100 * i) / s;

                if(percent != lastPercent)
                {
                    Console.WriteLine(percent.ToString()+ " %");
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    lastPercent = percent;
                }
            }
        }

        public string getStructuredString()
        {
            string structuredString = "";

            Console.WriteLine();

            foreach(referenceCode r in references)
            {
                structuredString += "#" + r.getRefCode() + "\n";

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("gerando codigo: " + r.getRefCode());

                foreach(string s in r.getElements())
                {
                    structuredString += s + "\n";
                }

            }

            Console.WriteLine("Pronto");

            return structuredString;
        }

        public void addToReference(string word)
        {

            string wordCode = toStructWord(word);

            foreach (var reference in references)
            {
                if(reference.getRefCode() == wordCode)
                {
                    reference.addElement(word);
                    return;
                }
            }

            var newReference = new referenceCode(wordCode);
            newReference.addElement(word);

            references.Add(newReference);

        }

        public static string toStructWord(string word)
        {

            Dictionary<char, int> lettersCode = new Dictionary<char, int>();

            char[] lettersArray = word.ToCharArray();
            string lettersCodeString = "";

            int a = 0;


            for(int i = 0; i < lettersArray.Length; i++)
            {
                if (lettersCode.ContainsKey(lettersArray[i]))
                {
                    lettersCodeString += lettersCode[lettersArray[i]] + " ";
                    continue;
                }

                lettersCode.Add(lettersArray[i], a);
                lettersCodeString += a++ + " ";
            }


            Console.WriteLine(word + " --> " + lettersCodeString);

            return lettersCodeString;
        }

        public List<string> getSimiliarStructWords(string word)
        {
            referenceCode refCode = findReferenceByCode(toStructWord(word));
            List<string> words = new List<string>();

            if(refCode != null)
            {
                words = refCode.getElements();

            }
            
            return words;
        }

        public referenceCode findReferenceByCode(string code)
        {
            foreach (var reference in references)
            {
                if (reference.getRefCode() == code)
                {
                    return reference;
                }
            }

            //throw new 
            return null;
        }
    }
}
