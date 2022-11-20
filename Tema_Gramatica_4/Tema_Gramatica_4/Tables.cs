using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Tables : Form
    {
        public Tables()
        {
            InitializeComponent();
        }
        string aux;
        DataTable head = new DataTable();
        internal void loadTables(string n, string t, List<Colection> f, List<List<DataStruct>> c, List<DataStruct> p, Parser form)
        {
            
            this.form = form;
            int i = 1;
            foreach (var item in p)
            {
                P1.Add(new Colection(item.strKey, item.strProduction, i++));
            }
            P = p;
            N = n;
            aux = N;
            T = t;
            F = f;
            i = 0;
            List<DataStruct> I = c[i++];
            t += "$";
            dataGridView1.DataSource = head;

            head.Columns.Add("NrStare", typeof(int));
            dataGridView1.Columns[0].Width = 50;
            DataTable terminals = new DataTable();
            foreach (var item in t+n)
            {
                head.Columns.Add(item.ToString(), typeof(string));
                dataGridView1.Columns[i++].Width = 50;
            }
            i = 0;
            int nr_rows = (int)f.Max(z => z.resultList);
            while (nr_rows >= 0)
            {
                head.Rows.Add(i++);
                nr_rows--;
            }
            foreach (var item in f)
            {
                if (t.Contains((string)item.character))
                {
                    head.Rows[(int)item.listNumber][(string)item.character] = "d" + item.resultList;
                }
                if (n.Contains((string)item.character))
                {
                    head.Rows[(int)item.listNumber][(string)item.character] = item.resultList;
                }
            }
            reduction(c, "table");
        }

        internal void reduction(List<List<DataStruct>> c, string type, List<Actions> list_data = null)
        {
            int stare = 0;
            int nr = -1;
            foreach (var item in c)
            {
                foreach (var item1 in item)
                {
                    if (item1.strProduction.IndexOf(".") == item1.strProduction.Length - 1)
                    {
                        int poz = item1.strProduction.IndexOf(".");
                        Colection aux = P1.Find(z => z.character.ToString() == item1.strProduction.Substring(0, poz));
                        if (aux != null)
                        {
                            nr = (int)aux.resultList;
                            string where = urm(item1.strKey);
                            foreach (var item3 in where)
                            {
                                if (type == "table")
                                {
                                    head.Rows[stare][item3.ToString()] = "r" + nr;
                                }else
                                {
                                    list_data.Add(new Actions(stare, item3.ToString(), "r"+nr));
                                }
                            }
                        }
                        else
                        {
                            if (item1.strKey == "S")
                            {
                                if (type == "table")
                                {
                                    head.Rows[stare]["$"] = "acc";
                                }
                                else
                                {
                                    list_data.Add(new Actions(stare, "$", "accept"));
                                }
                            }
                            else
                            {
                                if (type == "table")
                                {
                                    head.Rows[stare]["$"] = "error";
                                }else
                                {

                                }
                            }
                        }

                    }
                }
                stare++;
            }
        }

        string urm(string s)
        {
            List<DataStruct> d = P.FindAll(z => z.strProduction.Contains(s));
            string aux = "";
            foreach (var item in d)
            {
                int poz = item.strProduction.IndexOf(s);
                if (poz < item.strProduction.Length-1)
                {
                    aux += item.strProduction.Substring(poz + 1, 1);
                }
                else
                {
                    aux += urm(item.strKey);
                }
            }
            aux += "$";
            aux = string.Join("", aux.ToCharArray().Distinct());
            return aux;
        }
        private void Tables_FormClosing(object sender, FormClosingEventArgs e)
        {;
            form.Show();
        }

        internal List<Actions> loadActions(List<Actions> list_actiuni)
        {
            list_actiuni.Clear();
            foreach (var item in F)
            {
                if (T.Contains((string)item.character))
                {
                    string d = "d" + item.resultList;
                    list_actiuni.Add(new Actions((int)item.listNumber, (string)item.character, d));
                }
            }
            return list_actiuni;
        }

        internal List<Jump> LoadJumps(List<Jump> list_salt)
        {
            list_salt.Clear();

            foreach (var item in F)
            {
                if (N.Contains((string)item.character))
                {
                    list_salt.Add(new Jump((int)item.listNumber, (string)item.character, (int)item.resultList));
                }
            }

            return list_salt;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
