using System;
using System.Collections.Generic;
using System.Linq;

namespace Dict_Rewrite
{
    internal class Rewriter
    {
        List<referenceCode> references = new List<referenceCode>();

        public void setReferences(string[] _dict)
        {
            int i = -1;

            foreach(string _ref in _dict)
            {
                if (_ref.Contains("#"))
                {
                    string value = _ref.Substring(1);

                    referenceCode refCode = new referenceCode(value);
                    references.Add(refCode);
                    i++;
                    continue;
                }

                references[i].addElement(_ref);
            }
        }

        public void addVariousReferences(string[] words)
        {
            int i = 0;
            int s = words.Length;
            int percent = 0;
            int lastPercent = -1;

            Console.WriteLine();

            foreach (string word in words)
            {
                addToReference(word);
                i++;

                percent = (100 * i) / s;

                if(percent != lastPercent)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine(percent.ToString() + " %");
                    lastPercent = percent;
                }
            }
        }

        public string getStructuredString()
        {
            string structuredString = "";

            Console.WriteLine("gerando codigo: ");

            foreach(referenceCode r in references)
            {
                structuredString += "#" + r.getRefCode() + "\n";

                Console.SetCursorPosition(16, Console.CursorTop - 1);
                Console.WriteLine(r.getRefCode() + "\t\t");

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

            referenceCode rC = findReferenceByCode(wordCode);

            if (rC != null)
            {
                rC.addElement(word);
                return;
            }

            var newReference = new referenceCode(wordCode);
            newReference.addElement(word);

            references.Add(newReference);

        }

        public static string toStructWord(string word)
        {

            Dictionary<char, char> lettersCode = new Dictionary<char, char>();

            char[] lettersArray = word.ToCharArray();
            string lettersCodeString = "";

            char a = 'a';

            for(int i = 0; i < lettersArray.Length; i++)
            {
                if (lettersCode.ContainsKey(lettersArray[i]))
                {
                    lettersCodeString += lettersCode[lettersArray[i]];
                    continue;
                }

                lettersCode.Add(lettersArray[i], a);
                lettersCodeString += a++;
            }

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

            referenceCode refC;

            try
            {
                refC = references.Find(i => i.getRefCode() == code);
            }catch(Exception e)
            {
                refC = null;
            }
            
            return refC;
        }

    }
}
