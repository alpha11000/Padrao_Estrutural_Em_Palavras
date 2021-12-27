//projeto feito para testes, visando ser usado principalmente em um próximo, o qual terá como principal objetivo a
//quebra de cifras de substituição.

using System;
using System.Collections.Generic;
using System.IO;

namespace Dict_Rewrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rewriter rw = new Rewriter();

            Console.WriteLine("Importando palavras...");

            string name = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            name += "/_dict/pt-br/br-com-acentos.txt";

            string saveName = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            saveName += "/_dict/pt-br/br-sem-acentos-RW.txt";

            string[] _dict = FileUtil.openFile(saveName);

            if(_dict.Length == 0) 
            {
                Console.WriteLine("Não foi encontrado um dicionário com as referencias, gerando um novo...");
                string[] content = FileUtil.openFile(name);

                Console.WriteLine("Gerando e armazenando referencias...");
                rw.addVariousReferences(content);

                Console.WriteLine("Gerando a estrutura do novo dicionário...");
                string[] structuredString = rw.getStructuredString();
                Console.WriteLine("Salvando no arquivo...");
                FileUtil.writeToFile(saveName, structuredString);
            }
            else
            {
                rw.setReferences(_dict);
            }

            while (true)
            {
                Console.WriteLine("Entre com uma palavra:");

                List<string> similiarWords = rw.getSimiliarStructWords(Console.ReadLine());

                Console.WriteLine("Palaras com estruturas semelhantes à palavra inserida:\n");

                foreach (string s in similiarWords)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
