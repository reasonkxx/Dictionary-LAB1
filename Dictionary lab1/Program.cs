using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace Dictionary_lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<int, string> names = new Dictionary<int, string>()
            {
                {1, "Bob" },
                {2, "Bob" },
                {3, "Max" },
                {4, "Den" },
                {5, "Lari" },
                {6, "Bob" },
                {7, "Tim" },
            };
            string jsonData = JsonConvert.SerializeObject(names);
            string path = @"C:\Users\chubk\Desktop\Json.txt";
            File.WriteAllText(path, jsonData);
            Console.WriteLine(jsonData);
            Console.WriteLine("Поиск одинаковых значений");
                var result = from p in names
                             group p by p.Value into g
                             where g.Count() > 1
                             select g;
                foreach (var item in result)
                {
                    var sameValue = from p in item
                                    select p.Key;

                    Console.WriteLine("{0} Имеют одинаковые значения", string.Join(",", sameValue));
                }
                Console.ReadKey();
        }
    }
}
