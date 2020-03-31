using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace sem7_paw
{
    public partial class Form1 : Form
    {
        List<Student> listaStud = new List<Student>();

        public Form1()
        {
            InitializeComponent();
            listaStud.Add(new Student(123, "Gigel", 9));
            listaStud.Add(new Student(456, "Dorel", 10));
            incarcaDate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (Student s in listaStud)
            {
                ListViewItem itm = new ListViewItem(s.cod.ToString());
                itm.SubItems.Add(s.nume);
                itm.SubItems.Add(s.nota.ToString());

                if (s.nota >= 5)
                    itm.SubItems.Add("promovat");
                else
                    itm.SubItems.Add("nepromovat");

                listView1.Items.Add(itm);
            }
        }

        private void incarcaDate()
        {
            StreamReader sr = new StreamReader("fisier.txt");
            string linie = null;
            while ((linie = sr.ReadLine()) != null)
            {
                try
                {
                    int cod = Convert.ToInt32(linie.Split(',')[0]);
                    string nume = linie.Split(',')[1];
                    int nota = Convert.ToInt32(linie.Split(',')[2]);
                    Student s = new Student(cod, nume, nota);
                    listaStud.Add(s);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            sr.Close();
            MessageBox.Show("Date incarcate!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView1.Items)
                if (itm.Checked)
                    itm.Remove();
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView1.Items)
                if (itm.Selected)
                    itm.Remove();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TreeNode parinte = new TreeNode("Studenti");
            treeView1.Nodes.Add(parinte);

            foreach (Student s in listaStud)
            {
                TreeNode copil = new TreeNode(s.cod + "-" + s.nume + "-" + s.nota);
                parinte.Nodes.Add(copil);

                TreeNode nepot = new TreeNode();
                if (s.nota >= 5)
                    nepot.Text = "promovat";
                else
                    nepot.Text = "nepromovat";

                copil.Nodes.Add(nepot);
            }

            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode nodSelectat = treeView1.SelectedNode;
            int cod;
            try
            {
                cod = Convert.ToInt32(nodSelectat.Text.Split('-')[0]);
            }
            catch
            {
                cod = 0;
            }
            foreach (Student s in listaStud)
                if (s.cod == cod)
                    textBox1.Text += s.ToString() + Environment.NewLine;
        }

        private void stergeNodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode nodSelectat = treeView1.SelectedNode;
            if (nodSelectat.NextNode != null)
                nodSelectat = treeView1.SelectedNode.NextNode;
            else
                if (nodSelectat.PrevNode != null)
                    nodSelectat = treeView1.SelectedNode.PrevNode;

            treeView1.SelectedNode.Remove();
            treeView1.SelectedNode = nodSelectat;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemoryStream memStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(memStream, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();

            foreach (TreeNode nod in treeView1.Nodes)
            {
                writer.WriteStartElement(nod.Text);
                foreach (TreeNode copil in nod.Nodes)
                {
                    writer.WriteStartElement(copil.Text);
                    foreach (TreeNode nepot in copil.Nodes)
                    {
                        writer.WriteStartElement(nepot.Text);

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            writer.WriteEndDocument();

            writer.Close();

            string str = Encoding.UTF8.GetString(memStream.ToArray());
            memStream.Close();

            StreamWriter sw = new StreamWriter("fisier.xml");
            sw.WriteLine(str);
            sw.Close();
            MessageBox.Show("Exportat");
        }
    }
}
