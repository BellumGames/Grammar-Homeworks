using System;
using System.Collections.Generic;
using System.IO;

namespace Tema_Gramatici_1
{
    class Program
    {
        public static List<DataStruct> createProduction(string[] production) 
        {
            List<DataStruct> temp = new List<DataStruct>();
            foreach (string item in production)
            {
                char key = item[0];
                string value = "";
                for (int i = 1; i < item.Length; i++)
                {
                    value = value + item[i];
                }
                DataStruct structura = new DataStruct();
                structura.Add(key, value);
                temp.Add(structura);
            }
            return temp;
        }

        public static bool continua(string returned) 
        {
            string terminals = File.ReadAllText(@"..\..\..\terminals.txt");
            if (returned.Length <= 60)
            {
                for (int i = 0; i < returned.Length; i++)
                {
                    foreach (char item in terminals)
                    {
                        if (returned[i] == item)
                            return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void rules(string text, List<DataStruct> finalProductions)
        {
            Console.WriteLine("caracter(analizat curent) -> sir");
            string returned = text;
            while (continua(returned) == true) 
            {
                int i = 0;
                char[] key = new char[finalProductions.Count];
                string[] value = new string[finalProductions.Count];
                foreach (DataStruct item in finalProductions)
                {
                    key[i] = item.getKey();
                    value[i] = item.getValue();
                    i++;
                }
                for (int j = 0; j < i; j++)
                {
                    foreach (char caracter in returned)
                    {
                        if (j < finalProductions.Count - 1 && key[j + 1] != null)
                        {
                            if (key[j] == key[j + 1])
                            {
                                Random rand = new Random();
                                int rng = rand.Next(0, 3);
                                switch (rng)
                                {
                                    case 0:
                                        if (caracter == key[j])
                                        {
                                            returned = returned.Replace(caracter.ToString(), value[j]);
                                        }
                                        break;
                                    case 1:
                                        if (caracter == key[j + 1])
                                        {
                                            returned = returned.Replace(caracter.ToString(), value[j + 1]);
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                if (caracter == key[j])
                                {
                                    returned = returned.Replace(caracter.ToString(), value[j]);
                                }
                            }
                            //Console.WriteLine($"{caracter} -> {returned}");
                        }
                    }
                }
                //Console.WriteLine("Sir final:");
                Console.WriteLine(returned);
            }
        }

        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"..\..\..\givenstring.txt");
            string neterminals = File.ReadAllText(@"..\..\..\neterminals.txt");
            string[] production = File.ReadAllLines(@"..\..\..\production.txt");

            List<DataStruct> finalProductions = createProduction(production);
            rules(text, finalProductions);

            Console.ReadKey();
        }
    }
}
