//projeto feito para testes, visando ser usado principalmente em um próximo, o qual terá como principal objetivo a
//quebra de cifras de substituição.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dict_Rewrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Importando palavras...");

            string name = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            name += "/_dict/pt-br/br-sem-acentos.txt";

            string saveName = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            saveName += "/_dict/pt-br/br-sem-acentos-RW.txt";

            string [] content = FileUtil.openFile(name);

            Rewriter rw = new Rewriter();

            Console.WriteLine("Armazenando referencias...");
            rw.addVariousReferences(content);

            Console.WriteLine("Salvando no arquivo...");
            string structuredString = rw.getStructuredString();
            FileUtil.writeToFile(saveName, structuredString);

            Console.WriteLine("Entre com uma palavra:");
            List<string> similiarWords = rw.getSimiliarStructWords(Console.ReadLine());

            foreach (string s in similiarWords)
            {
                Console.WriteLine(s);
            }
        }
    }
}
