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
{//ctrl+m,+o
    public partial class Parser : Form
    {
        public Parser()
        {
            InitializeComponent();
        }
        Dictionary<int, string> atribute = new Dictionary<int, string>();
        Dictionary<int, string> Turi = new Dictionary<int, string>();
        string tempStack = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            tBrowse.Text = InternalDefines.initial_path;
            file.InitialDirectory = InternalDefines.initial_path;
            file.FileName = InternalDefines.initial_path;
            loadGrammar();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            formClear();
            input = tInput.Text + "$";
            tStack.AppendText("$ " + stiva + "\r\n");
            tInput_Word.AppendText(input + "\r\n");
            string actiune = "";
            while (input != "accept")
            {
                if (actiune == "")
                {
                    actiune = searchInActions();
                    tThing.AppendText("\r\n");
                }
                else
                {
                    if (actiune.Substring(0, 1).Equals("d"))
                    {
                        displacement();
                    }
                    if (actiune.Substring(0, 1).Equals("r"))
                    {
                        reduction();
                    }
                    actiune = searchInActions();
                }
                tAction.AppendText(result);
                if (result == "false")
                {
                    tStack.AppendText("Nu a fost gasit");
                    tInput_Word.AppendText("Nu a fost gasit");
                    break;
                }
                if (result == "accept")
                {
                    break;
                }
            }
        }

        private string searchInActions()
        {
            foreach (Actions act in list_actiuni)
            {
                result = "false";
                if ((act.intStatusNumber.ToString() == stiva.Substring(stiva.Length - nr, nr) || act.intStatusNumber.ToString() == stiva.Substring(stiva.Length - nr - 1, nr))
                    && act.strTerminal == input.Substring(0, 1))
                {
                    result = act.strData;
                    return result;
                }
            }
            return result;
        }

        private void displacement()
        {
            stiva += input.Substring(0, 1) + result.Substring(1);
            tempStack = input.Substring(0, 1);
            input = input.Remove(0, 1);
            tInput_Word.AppendText(input + "\r\n");
            nr = result.Substring(1).Length;
            tStack.AppendText("$ " + stiva + "\r\n");
            tAction.AppendText("\r\n");
            stiva += " ";

            var ceva = searchInActions();
            if (ceva.Substring(0, 1) != "d")
            {
                var tempT = Terminals.Remove(0, 1);
                if (!tempT.Contains(tempStack.Substring(0, 1)))
                {
                    atribute.Add(atribute.Count + 1, tempStack.Substring(0, 1));
                }
                foreach (var item in atribute)
                {
                    tThing.AppendText(item.Value + item.Key);
                }
                tThing.AppendText("\r\n");
                //tThing.AppendText("deplasare");
            }
        }

        private void reduction()
        {
            int index = int.Parse(result.Substring(1, 1)) - 1;
            string key = list[index].strKey;
            string productie = list[index].strProduction;
            count = stiva.Count(f => f == ' ');
            tAction.AppendText(" => " + key + "+TS(");
            if (atribute.Count > 0)
            {

                if (productie.Length < 2)
                {
                    foreach (var item in atribute)
                    {
                        tThing.AppendText(item.Value + item.Key);
                    }
                    string[] deLucru = stiva.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    string altceva = deLucru.Last().Substring(0, 1);
                    altceva = altceva == "a" ? altceva + atribute.Count().ToString() : altceva + ".p";
                    string stivaActiune = "";
                    if (altceva == "a")
                    {
                        stivaActiune = $"[push({key}.p)]";
                    }
                    else
                    {
                        stivaActiune = $"[{key}.p=pop(), push({key}.p)]";
                    }
                    tThing.AppendText($"    {key}.p={altceva}  {stivaActiune} \r\n");
                }
                else
                {
                    string[] deLucru = stiva.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    Turi.Add(Turi.Count + 1, "t");
                    string ulitmul = $"{ atribute.Last().Value }{ atribute.Last().Key}";
                    atribute.Remove(atribute.Last().Key);
                    string penultim = $"{ atribute.Last().Value }{ atribute.Last().Key}";
                    atribute.Remove(atribute.Last().Key);
                    atribute.Add(atribute.Count + 1, "t");
                    foreach (var item in atribute)
                    {
                        tThing.AppendText(item.Value + item.Key);
                    }
                    string operatie = deLucru[deLucru.Length - 2].First().ToString();

                    string ultimStiva = deLucru.Last().First().ToString();
                    string penultimStiva = deLucru[deLucru.Length - 3].First().ToString();
                    string stivaActiune = $"[{ultimStiva}.p=pop(), {penultimStiva}.p=pop(), push({key}.p)]";
                    tThing.AppendText($"     emit({Turi.Values.Last()}{Turi.Keys.Last()}={penultim}{operatie}{ulitmul})  {stivaActiune} \r\n");

                }
                //tThing.AppendText("reducere");
            }
            stiva = stiva.Remove(stiva.LastIndexOf(productie.Substring(0, 1)));
            stiva = stiva.Insert(stiva.Length, key);
            findInJump(key);
        }

        private void findInJump(string key)
        {
            foreach (Jump salt in list_salt)
            {
                if (salt.intStatusNumber.ToString() == stiva.Substring(stiva.Length - 2 - key.Length, 1) &&
                    salt.strData == stiva.Substring(stiva.Length - 1, 1))
                {
                    nr = salt.intData.ToString().Length;
                    stiva += salt.intData.ToString();
                    tStack.AppendText("$ " + stiva + "\r\n");
                    stiva += " ";
                    tAction.AppendText(salt.intStatusNumber.ToString() + salt.strData + ") \r\n");
                    break;
                }
            }
            tInput_Word.AppendText(input + "\r\n");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            formClear();
        }

        private void formClear()
        {
            tAction.Clear();
            tStack.Clear();
            tInput_Word.Clear();
            tThing.Clear();
            stiva = "0 ";
            input = " $";
            counter = 0;
            nr = 1;
            text = "";
            r = false;
            result = "";
        }

        private void loadGrammar()
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)
                {
                    counter++;
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
                text = sr.ReadToEnd().Replace(Environment.NewLine, "");
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
                        list.Add(new DataStruct(aux1, aux2));
                        par++;

                    }
                }
                sr.Close();
            }
            foreach (DataStruct s in list)
            {
                tProduction.AppendText(String.Join("\r\n", s.strKey));
                tProduction.AppendText(" -> ");
                tProduction.AppendText(String.Join("\r\n", s.strProduction));
                tProduction.AppendText("\r\n");
            }
            Production.Clear();
            c = colectie();
            loadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Production.Clear();
            Process start = Process.Start(file.FileName);
            start.WaitForExit();
            tProduction.Clear();
            text = "";
            list.Clear();
            loadGrammar();
            formClear();
        }

        private List<DataStruct> inc(List<DataStruct> list_inc)
        {
            List<DataStruct> M = new List<DataStruct>();
            List<DataStruct> M0 = new List<DataStruct>();
            List<DataStruct> M1 = new List<DataStruct>();
            List<DataStruct> L = new List<DataStruct>(list);

            M = new List<DataStruct>(list_inc);
            M0 = new List<DataStruct>(list_inc);
            bool firstStep = true;
            DataStruct aux;
            do
            {
                aux = M0[0];
                M0.RemoveAt(0);
                int poz = aux.strProduction.IndexOf(".");
                if (poz < aux.strProduction.Length - 1 && !Terminals.Contains(aux.strProduction.Substring(aux.strProduction.IndexOf(".") + 1, 1)))
                {
                    if (!firstStep)
                    {
                        L.RemoveAll(x => x.strProduction == (poz != -1 ? (aux.strProduction.Substring(0, poz) + aux.strProduction.Substring(poz + 1)) : aux.strProduction));
                    }
                    DataStruct S = L.Find(x => x.strKey == aux.strProduction.Substring(aux.strProduction.LastIndexOf(".") + 1, 1));
                    M0.Add(new DataStruct(S.strKey, "." + S.strProduction));
                    M1.Add(aux);
                    firstStep = false;
                }
                else
                {
                    if (!firstStep)
                    {
                        List<DataStruct> ceva = new List<DataStruct>(L.FindAll(x => x.strKey == aux.strKey));
                        List<DataStruct> insertPoint = new List<DataStruct>();
                        foreach (var item in ceva)
                        {
                            insertPoint.Add(new DataStruct(item.strKey, item.strProduction));
                        }

                        foreach (DataStruct aux3 in insertPoint)
                        {
                            aux3.strProduction = "." + aux3.strProduction;
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
                I1.Add(new DataStruct(item.strKey, item.strProduction));
            }
            List<DataStruct> M = new List<DataStruct>();
            foreach (var item in I1)
            {
                int poz = item.strProduction.IndexOf('.');
                if (poz < item.strProduction.Length - 1)
                {
                    if (item.strProduction.Substring(poz + 1, 1) == x)
                    {
                        item.strProduction = item.strProduction.Remove(poz, 1);
                        item.strProduction = item.strProduction.Insert(++poz, ".");
                        M.Add(item);
                    }
                }
            }
            M = inc(M);
            return (M);
        }

        private List<List<DataStruct>> colectie()
        {
            int j = 0;//indice de stare I
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
                        if (item.strProduction.IndexOf('.') < item.strProduction.Length - 1)
                        {
                            ctX++;
                        }
                    }
                    Array.Clear(x, 0, x.Length);
                    x = new string[ctX];
                    ctX = 0;
                    foreach (var item in temp)
                    {
                        if (item.strProduction.IndexOf('.') < item.strProduction.Length - 1)
                        {
                            x[ctX++] = item.strProduction.Substring(item.strProduction.IndexOf('.') + 1, 1);
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
                        Production.Add(new Colection(j, x[0], i++));
                        x = x.Where(z => z != x[0]).ToArray();
                    }
                    else
                    {
                        InternalDefines.contor = 0;
                        int ctI = 0;
                        while (I.Any(z => z.SequenceEqual(M)))
                        {
                            ctI = InternalDefines.contor;
                            break;
                        }
                        Production.Add(new Colection(j, x[0], ctI));
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
            t.loadTables(Neterminals, Terminals, Production, c, list, this);
            list_actiuni.Clear();
            list_actiuni = t.loadActions(list_actiuni);
            list_salt.Clear();
            list_salt = t.LoadJumps(list_salt);
            t.reduction(c, "list", list_actiuni);
        }

        private void stackText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lStack_Click(object sender, EventArgs e)
        {

        }

        private void tInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void tProduction_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
