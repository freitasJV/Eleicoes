using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Eleicoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> contagem = new Dictionary<string, int>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int count = int.Parse(line[1]);

                        if (contagem.ContainsKey(name))
                            contagem[name] += count;
                        else
                            contagem[name] = count;
                    }

                    foreach (var item in contagem)
                    {
                        Console.WriteLine($"{item.Key} : {item.Value}");
                    }

                    var totalCountWin = contagem.Max(x => x.Value);
                    var win = contagem.First(x => x.Value == totalCountWin);

                    if (contagem.Keys.Count > 0)
                        Console.WriteLine($"The win was {win.Key}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
