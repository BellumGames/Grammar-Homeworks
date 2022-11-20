using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Gramatica : Form
    {
        public Gramatica()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            file.InitialDirectory = InternalDefinitions.path;
            file.FileName = InternalDefinitions.path;
            loadGrammar();
        }

        private void loadGrammar()
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)
                {
                    ct++;
                }
                sr.Close();
            }
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                text = sr.ReadLine();
                Neterminals = text;
                text = sr.ReadLine();
                Terminals = text;
                text = sr.ReadLine();
                S = text;
                text = sr.ReadToEnd().Replace(Environment.NewLine, ""); //elimina \r\n
                string[] lines = text.Split(',');
                int par = 0;
                string aux1 = "", aux2;
                foreach (string s in lines)
                {
                    if (par % 2 == 0)
                    {
                        aux1 = s;
                        par++;
                    }
                    else
                    {
                        aux2 = s;
                        Productions.Add(new DataStruct(aux1, aux2));
                        par++;

                    }
                }
                sr.Close();
            }
            foreach (DataStruct s in Productions)
            {
                tProd.AppendText(String.Join("\r\n", s.key));
                tProd.AppendText(" -> ");
                tProd.AppendText(String.Join("\r\n", s.value));
                tProd.AppendText("\r\n");
            }
            f.Clear();
            Collections = colectie();
            loadData();
        }

        private List<DataStruct> inc(List<DataStruct> list_inc)
        {
            List<DataStruct> M = new List<DataStruct>();
            List<DataStruct> M0 = new List<DataStruct>();
            List<DataStruct> M1 = new List<DataStruct>();
            List<DataStruct> L = new List<DataStruct>(Productions);

            M = new List<DataStruct>(list_inc);
            M0 = new List<DataStruct>(list_inc);
            bool firstStep = true;
            DataStruct aux;
            do
            {
                aux = M0[0];
                M0.RemoveAt(0);
                int poz = aux.value.IndexOf(".");
                if (poz < aux.value.Length - 1 && !Terminals.Contains(aux.value.Substring(aux.value.IndexOf(".") + 1, 1)))
                {
                    if (!firstStep)
                    {
                        L.RemoveAll(x => x.value == (poz != -1 ? (aux.value.Substring(0, poz) + aux.value.Substring(poz + 1)) : aux.value));
                    }
                    DataStruct S = L.Find(x => x.key == aux.value.Substring(aux.value.LastIndexOf(".") + 1, 1));
                    M0.Add(new DataStruct(S.key, "." + S.value));
                    M1.Add(aux);
                    firstStep = false;
                }
                else
                {
                    if (!firstStep)
                    {
                        List<DataStruct> ceva = new List<DataStruct>(L.FindAll(x => x.key == aux.key));
                        List<DataStruct> insertPoint = new List<DataStruct>();
                        foreach (var item in ceva)
                        {
                            insertPoint.Add(new DataStruct(item.key, item.value));
                        }

                        foreach (DataStruct aux3 in insertPoint)
                        {
                            aux3.value = "." + aux3.value;
                            M1.Add(aux3);
                        }
                    }
                    else
                    {
                        foreach (DataStruct aux3 in list_inc)
                        {
                            M1.Add(aux3);
                        }
                    }
                    M0.Clear();
                    firstStep = false;
                }

            }
            while (M0.Count > 0);
            M1 = M1.Distinct().ToList();
            return M1;
        }

        private List<DataStruct> jump(List<DataStruct> I, string x)
        {
            List<DataStruct> I1 = new List<DataStruct>();
            foreach (var item in I)
            {
                I1.Add(new DataStruct(item.key, item.value));
            }
            List<DataStruct> M = new List<DataStruct>();
            foreach (var item in I1)
            {
                int poz = item.value.IndexOf('.');
                if (poz < item.value.Length - 1)
                {
                    if (item.value.Substring(poz + 1, 1) == x)
                    {
                        item.value = item.value.Remove(poz, 1);
                        item.value = item.value.Insert(++poz, ".");
                        M.Add(item);
                    }
                }
            }
            M = inc(M);
            return (M);
        }

        private List<List<DataStruct>> colectie()
        {
            int j = 0;
            int i = 1;
            int ctX = 0;
            string[] x = new string[10];
            bool one = true;

            List<List<DataStruct>> C = new List<List<DataStruct>>();
            List<DataStruct> M = new List<DataStruct>();
            List<List<DataStruct>> I = new List<List<DataStruct>>();

            C.Add(inc(new List<DataStruct> { new DataStruct("S", ".E") }));
            I.Add(C[0]);
            ctX = 0;
            while (j < I.Count)
            {
                if (one)
                {
                    List<DataStruct> temp = new List<DataStruct>(C[j]);
                    foreach (var item in C[j])
                    {
                        if (item.value.IndexOf('.') < item.value.Length - 1)
                        {
                            ctX++;
                        }
                    }
                    Array.Clear(x, 0, x.Length);
                    x = new string[ctX];
                    ctX = 0;
                    foreach (var item in temp)
                    {
                        if (item.value.IndexOf('.') < item.value.Length - 1)
                        {
                            x[ctX++] = item.value.Substring(item.value.IndexOf('.') + 1, 1);
                        }
                    }
                    x = x.Where(z => z != null).ToArray();
                    one = false;
                }
                if (x.Count() > 0)
                {
                    M = jump(I[j], x[0]);
                    if (!I.Any(z => z.SequenceEqual(M)))
                    {
                        I.Add(M);
                        C.Add(M);
                        f.Add(new Colection(j, x[0], i++));
                        x = x.Where(z => z != x[0]).ToArray();
                    }
                    else
                    {
                        InternalDefinitions.cx_register = 0;
                        int ctI = 0;
                        while (I.Any(z => z.SequenceEqual(M)))
                        {
                            ctI = InternalDefinitions.cx_register;
                            break;
                        }
                        f.Add(new Colection(j, x[0], ctI));
                        x = x.Where(z => z != x[0]).ToArray();
                    }
                }
                else
                {
                    ctX = 0;
                    one = true;
                    j++;
                }

            }
            return C;
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            loadData("show");
        }

        private void loadData(string s = null)
        {
            Tables t = new Tables();
            if (s == "show")
            {
                Hide();
                t.Show();
            }
            t.loadTables(Neterminals, Terminals, f, Collections, Productions, this);
            action_list.Clear();
            action_list = t.loadActions(action_list);
            jump_list.Clear();
            jump_list = t.loadJumps(jump_list);
            t.reduceri(Collections, "list", action_list);
        }

        private void tProd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
