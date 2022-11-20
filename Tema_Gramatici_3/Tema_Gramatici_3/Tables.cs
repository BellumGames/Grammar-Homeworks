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

        DataTable head = new DataTable();
        internal void loadTables(string n, string t, List<Colection> f, List<List<DataStruct>> c, List<DataStruct> p, Gramatica form)
        {
            this.form = form;
            int i = 1;
            foreach (var item in p)
            {
                P1.Add(new Colection(item.key, item.value, i++));
            }
            Productions = p;
            Neterminals = n;
            string aux = Neterminals;
            Terminals = t;
            F = f;
            i = 0;
            List<DataStruct> I = c[i++];
            t += "$";
            dataGridView1.DataSource = head;

            head.Columns.Add("Status Num", typeof(int));
            dataGridView1.Columns[0].Width = 50;
            DataTable terminals = new DataTable();
            foreach (var item in t + n)
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
            reduceri(c, "table");
        }

        internal void reduceri(List<List<DataStruct>> c, string type, List<Action> list_data = null)
        {
            int status = 0;
            int nr = -1;
            foreach (var item in c)
            {
                foreach (var temp in item)
                {
                    if (temp.value.IndexOf(".") == temp.value.Length - 1)
                    {
                        int poz = temp.value.IndexOf(".");
                        Colection aux = P1.Find(z => z.character.ToString() == temp.value.Substring(0, poz));
                        if (aux != null)
                        {
                            nr = (int)aux.resultList;
                            string where = urmatorul(temp.key);
                            foreach (var item3 in where)
                            {
                                if (type == "table")
                                {
                                    head.Rows[status][item3.ToString()] = "r" + nr;
                                }
                                else
                                {
                                    list_data.Add(new Action(status, item3.ToString(), "r" + nr));
                                }
                            }
                        }
                        else
                        {
                            if (temp.key == "S")
                            {
                                if (type == "table")
                                {
                                    head.Rows[status]["$"] = "acc";
                                }
                                else
                                {
                                    list_data.Add(new Action(status, "$", "accept"));
                                }
                            }
                            else
                            {
                                if (type == "table")
                                {
                                    head.Rows[status]["$"] = "error";
                                }
                                else
                                {

                                }
                            }
                        }

                    }
                }
                status++;
            }
        }

        string urmatorul(string s)
        {
            List<DataStruct> d = Productions.FindAll(z => z.value.Contains(s));
            string aux = "";
            foreach (var item in d)
            {
                int poz = item.value.IndexOf(s);
                if (poz < item.value.Length - 1)
                {
                    aux += item.value.Substring(poz + 1, 1);
                }
                else
                {
                    aux += urmatorul(item.key);
                }
            }
            aux += "$";
            aux = string.Join("", aux.ToCharArray().Distinct());
            return aux;
        }
        private void Tables_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }

        internal List<Action> loadActions(List<Action> action_list)
        {
            action_list.Clear();
            foreach (var item in F)
            {
                if (Terminals.Contains((string)item.character))
                {
                    string d = "d" + item.resultList;
                    action_list.Add(new Action((int)item.listNumber, (string)item.character, d));
                }
            }
            return action_list;
        }

        internal List<Jump> loadJumps(List<Jump> list_salt)
        {
            list_salt.Clear();

            foreach (var item in F)
            {
                if (Neterminals.Contains((string)item.character))
                {
                    list_salt.Add(new Jump((int)item.listNumber, (string)item.character, (int)item.resultList));
                }
            }

            return list_salt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
