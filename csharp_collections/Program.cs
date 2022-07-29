using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_collections
{
    public class Post
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
    }

    public class Element
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int AtomicNumber { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var salmons = new List<string>();
            salmons.Add("chinook");
            salmons.Add("coho");
            salmons.Add("pink");
            salmons.Add("sockeye");

            salmons.Remove("sockeye");

            foreach(var salmon in salmons)
            {
                Console.WriteLine($"{salmon}  ");
            }

            var numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // remove odd numbers
            for (int i = 0; i < numeros.Count; i++)
            {
                if (numeros[i] % 2 == 1)
                {
                    Console.WriteLine($"number removed {numeros[i]}");
                    numeros.RemoveAt(i);
                }
            }

            foreach (var numero in numeros)
            {
                Console.WriteLine($"{numero}");
            }

            for (int i = 0; i < numeros.Count; i++)
            {
                Console.WriteLine($"Usando for {numeros[i]}");
            }

            // A collection may be a class
            var Posts = new List<Post>()
            {
               new Post(){Title="buenas nuevas", Content="jaja", UserName ="pepito" },
               new Post(){Title="aniversario", Content="mi content", UserName = "jaimito"}
            };

            foreach (Post post in Posts)
            {
                Console.WriteLine($"user: {post.UserName} > post : {post.Title}");
            }

            Dictionary<string, Element> elements = BuildDictionary();
            foreach (KeyValuePair<string, Element> kvp in elements)
            {
                Element theElement = kvp.Value;
                Console.WriteLine($"Key > {kvp.Key}");
            }

            List<Element> elements1 = BuildList();
            // Linq Query
            var subset = from theElement in elements1
                         where theElement.AtomicNumber < 22
                         orderby theElement.Name
                         select theElement;

            foreach (Element theElement in subset)
            {
                Console.WriteLine($"{theElement.Name}   {theElement.AtomicNumber}");
            }
        }

        private static List<Element> BuildList()
        {
            return new List<Element>
            {
                new Element(){Symbol="K", Name="potasium", AtomicNumber=19},
                new Element(){Symbol="Ca", Name="calcium", AtomicNumber=20},
                new Element(){Symbol="Sc", Name="scandium", AtomicNumber=21},
                new Element(){Symbol="Ti", Name="titanium", AtomicNumber=22}
            };
        }
        private static Dictionary<string, Element> BuildDictionary()
        {
            var elements = new Dictionary<string, Element>();
            AddToDictionary(elements, "K", "Potassium", 19);
            AddToDictionary(elements, "Ca", "Calcium", 20);
            AddToDictionary(elements, "Ti", "Titanium", 22);
            return elements;
        }
        private static void AddToDictionary(Dictionary<string, Element> elements, string symbol, string name, int atomicNumber)
        {
            Element theElement = new Element();
            theElement.Symbol = symbol;
            theElement.Name = name;
            theElement.AtomicNumber = atomicNumber;
            elements.Add(key: theElement.Symbol, value: theElement);
        }
    }
}
