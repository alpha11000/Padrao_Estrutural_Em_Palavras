using System;
using System.Collections.Generic;

namespace Dict_Rewrite
{
    internal class referenceCode
    {

        private string refCode;
        private List<string> wordList = new List<string>();

        public referenceCode(string code)
        {
            refCode = code;
        }

        public int getSize()
        {
            return refCode.Length;
        }

        public List<string> getElements()
        {
            return wordList; 
        }

        public string getRefCode()
        {
            return refCode; ;
        }

        public void addElement(string element)
        {
            wordList.Add(element);
        }
    }
}
