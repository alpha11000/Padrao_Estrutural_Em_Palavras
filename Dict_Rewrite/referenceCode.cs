using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
