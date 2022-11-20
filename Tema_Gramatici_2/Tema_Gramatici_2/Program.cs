using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Tema_Gramatici_1
{
    class Program
    {
        public static List<DataStruct> createProduction(string[] production)
        {
            int j = 0;
            List<DataStruct> temp = new List<DataStruct>();
            foreach (string item in production)
            {
                int index = j;
                char key = item[0];
                string value = "";
                for (int i = 1; i < item.Length; i++)
                {
                    value = value + item[i];
                }
                DataStruct structura = new DataStruct();
                structura.Add(index, key, value);
                temp.Add(structura);
                j++;
            }
            return temp;
        }
        public static string[][] initTable()
        {
            string[] row0 = { "d5", "x", "x", "d4", "x", "x", "1", "2", "3" };
            string[] row1 = { "x", "d6", "x", "x", "x", "acc", "x", "x", "x" };
            string[] row2 = { "x", "r2", "d7", "x", "r2", "r2", "x", "x", "x" };
            string[] row3 = { "x", "r4", "r4", "x", "r4", "r4", "x", "x", "x" };
            string[] row4 = { "d5", "x", "x", "d4", "x", "x", "8", "2", "3" };
            string[] row5 = { "x", "r6", "r6", "x", "r6", "r6", "x", "x", "x" };
            string[] row6 = { "d5", "x", "x", "d4", "x", "x", "x", "9", "3" };
            string[] row7 = { "d5", "x", "x", "d4", "x", "x", "x", "x", "10" };
            string[] row8 = { "x", "d6", "x", "x", "d11", "x", "x", "x", "x" };
            string[] row9 = { "x", "r1", "d7", "x", "r1", "r1", "x", "x", "x" };
            string[] row10 = { "x", "r3", "r3", "x", "r3", "r3", "x", "x", "x" };
            string[] row11 = { "x", "r5", "r5", "x", "r5", "r5", "x", "x", "x" };
            string[][] table = { row0, row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, };
            Console.Write("Numar stare: id + * ( ) $ E T F");
            Console.WriteLine();
            for (int i = 0; i < 12; i++)
            {
                if (i < 10)
                    Console.Write("Row " + i + ":       ");
                if (i >= 10)
                    Console.Write("Row " + i + ":      ");
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(table[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            return table;
        }

        public static void rules(string givenString, string[] neterminals, string[] terminals, List<DataStruct> finalProductions, Stack<StackData> stack, string[][] tabel)
        {
            Console.Out.WriteLine();
            Console.Out.WriteLine("Garamatica este:");
            int i = 0;
            int[] index = new int[finalProductions.Count];
            char[] key = new char[finalProductions.Count];
            string[] value = new string[finalProductions.Count];
            foreach (DataStruct item in finalProductions)
            {
                index[i] = item.getIndex();
                key[i] = item.getKey();
                value[i] = item.getValue();
                Console.Out.WriteLine(index[i] + ": " + key[i] + "->" + value[i]);
                i++;
            }
            Console.WriteLine();
            string returned = givenString;
            string currData;
            afisare_prima(returned);
            while (!string.IsNullOrEmpty(returned))
            {
                string linie = returned.Split(" ")[0];
                StackData currStack = stack.Peek();
                int nr = currStack.getValue();
                if (linie == "id")
                {
                    currData = tabel[nr][0];
                    if (currData == "x")
                    {
                        Console.WriteLine("Sirul nu apartine gramaticii.");
                        returned = string.Empty;
                    }
                    if (currData[0] == 'd')
                    {
                        deplasari(currData);
                        returned = d(stack, returned, linie, currData);
                    }
                    if (currData[0] == 'r')
                    {
                        reduceri(currData);
                        returned = r(stack, tabel, key, currData, returned, linie, value);
                    }
                }
                if (linie == "+")
                {
                    currData = tabel[nr][1];
                    if (currData == "x")
                    {
                        Console.WriteLine("Sirul nu apartine gramaticii.");
                        returned = string.Empty;
                    }
                    if (currData[0] == 'd')
                    {
                        deplasari(currData);
                        returned = d(stack, returned, linie, currData);
                    }
                    if (currData[0] == 'r')
                    {
                        reduceri(currData);
                        returned = r(stack, tabel, key, currData, returned, linie, value);
                    }
                }
                if (linie == "*")
                {
                    currData = tabel[nr][2];
                    if (currData == "x")
                    {
                        Console.WriteLine("Sirul nu apartine gramaticii.");
                        returned = string.Empty;
                    }
                    if (currData[0] == 'd')
                    {
                        deplasari(currData);
                        returned = d(stack, returned, linie, currData);
                    }
                    if (currData[0] == 'r')
                    {
                        reduceri(currData);
                        returned = r(stack, tabel, key, currData, returned, linie, value);
                    }
                }
                if (linie == "(")
                {
                    currData = tabel[nr][3];
                    if (currData == "x")
                    {
                        Console.WriteLine("Sirul nu apartine gramaticii.");
                        returned = string.Empty;
                    }
                    if (currData[0] == 'd')
                    {
                        deplasari(currData);
                        returned = d(stack, returned, linie, currData);
                    }
                    if (currData[0] == 'r')
                    {
                        reduceri(currData);
                        returned = r(stack, tabel, key, currData, returned, linie, value);
                    }
                }
                if (linie == ")")
                {
                    currData = tabel[nr][4];
                    if (currData == "x")
                    {
                        Console.WriteLine("Sirul nu apartine gramaticii.");
                        returned = string.Empty;
                    }
                    if (currData[0] == 'd')
                    {
                        deplasari(currData);
                        returned = d(stack, returned, linie, currData);
                    }
                    if (currData[0] == 'r')
                    {
                        reduceri(currData);
                        returned = r(stack, tabel, key, currData, returned, linie, value);
                    }
                }
                if (linie == "$")
                {
                    currData = tabel[nr][5];
                    if (currData == "acc")
                    {
                        Console.WriteLine("Sirul apartine gramaticii.");
                        returned = string.Empty;
                    }
                    else
                    {
                        if (currData[0] == 'd')
                        {
                            deplasari(currData);
                            returned = d(stack, returned, linie, currData);
                        }
                        if (currData[0] == 'r')
                        {
                            reduceri(currData);
                            returned = r(stack, tabel, key, currData, returned, linie, value);
                        }
                    }
                }
            }
        }

        private static void afisare_prima(string returned)
        {
            Console.WriteLine("Sirul prelucrat in momentul asta arata astfel: \"" + returned + "\"");
            Console.WriteLine("Stiva: $ 0 id");
        }

        private static void reduceri(string currData)
        {
            Console.WriteLine("Reducere cu productia " + currData[1]);
            Console.WriteLine();
        }

        private static void deplasari(string currData)
        {
            Console.WriteLine("Deplasare cu " + currData[1]);
            Console.WriteLine();
        }

        private static void afisare(Stack<StackData> stack, string returned)
        {
            Console.WriteLine("Sirul prelucrat in momentul asta arata astfel: \"" + returned + "\"");
            StackData[] temp_3 = stack.ToArray();
            Console.Write("Stiva: ");
            for (int i = temp_3.Length; i-- > 0;)
            {
                Console.Write(temp_3[i].getKey() + " " + temp_3[i].getValue() + " ");
            }
            Console.WriteLine();
        }

        private static string r(Stack<StackData> stack, string[][] tabel, char[] key, string currData, string returned, string linie, string[] value)
        {
            //returned = returned.Remove(0, linie.Length + 1);
            int reducere = int.Parse(currData.Substring(1));
            int nr_elem_prod;
            if (value[reducere] != "id")
            {
                nr_elem_prod = value[reducere].Length;
            }
            else
            {
                nr_elem_prod = 1;
            }
            for (int i = 0; i < nr_elem_prod; i++)
            {
                stack.Pop();
            }

            StackData temp_1 = new StackData();
            temp_1.setKey(key[reducere].ToString());

            int pop_anterior_nr = stack.Peek().getValue();
            string inlocuire = "";
            if (temp_1.getKey() == "E")
            {
                inlocuire = tabel[pop_anterior_nr][6];
            }
            if (temp_1.getKey() == "T")
            {
                inlocuire = tabel[pop_anterior_nr][7];

            }
            if (temp_1.getKey() == "F")
            {
                inlocuire = tabel[pop_anterior_nr][8];
            }
            int push_back = int.Parse(inlocuire);
            temp_1.setValue(push_back);
            stack.Push(temp_1);
            afisare(stack, returned);
            return returned;
        }

        private static string d(Stack<StackData> stack, string returned, string linie, string currData)
        {
            returned = returned.Remove(0, linie.Length + 1);
            StackData temp_1 = new StackData();
            temp_1.setKey(linie);
            temp_1.setValue(int.Parse(currData.Substring(1)));
            stack.Push(temp_1);
            afisare(stack, returned);
            return returned;
        }

        static void Main(string[] args)
        {
            string givenString = File.ReadAllText(@"..\..\..\givenstring.txt");
            string[] neterminals = File.ReadAllLines(@"..\..\..\neterminals.txt");
            string[] terminals = File.ReadAllLines(@"..\..\..\terminals.txt");
            string[] production = File.ReadAllLines(@"..\..\..\production.txt");

            List<DataStruct> productionIgnition = createProduction(production);
            string[][] tabel = initTable();

            Stack<StackData> stack = new Stack<StackData>();
            StackData initialValue = new StackData();
            initialValue.setKey("$");
            initialValue.setValue(0);
            stack.Push(initialValue);

            rules(givenString, neterminals, terminals, productionIgnition, stack, tabel);

            Console.ReadKey();
        }
    }
}
