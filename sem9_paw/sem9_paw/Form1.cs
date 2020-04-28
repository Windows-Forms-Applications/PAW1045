using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sem9_paw
{
    public partial class Form1 : Form
    {
        int y = 10;

        Student[] vectStud = { new Student(21,"Gigel",9.5f),
                                  new Student(22, "Dorel", 9.7f),
                                  new Student(23,"Ionel", 10)};

        List<Student> lista = new List<Student>();

        public Form1()
        {
            InitializeComponent();

            lista.Add(new Student(24, "Maricica", 10));
            for (int i = 0; i < vectStud.Length; i++)
                lista.Add(vectStud[i]);

            //for (int i = 0; i < vectStud.Length; i++)
            //    listBox1.Items.Add(vectStud[i].ToString());
            foreach (Student s in lista)
                listBox1.Items.Add(s.ToString());
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if((e.KeyState & 8)==8 && (e.AllowedEffect & DragDropEffects.Copy)==DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else
                if ((e.AllowedEffect & DragDropEffects.Move)==DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string text = e.Data.GetData(typeof(string)).ToString();
            Graphics g = Graphics.FromHwnd(panel1.Handle);
            g.DrawString(text, this.Font, new SolidBrush(Color.Red), 10, y);
            y += 20;
            if (y > panel1.Height)
            {
                MessageBox.Show("Cos plin!");
                panel1.Invalidate();
                y = 10;
            }
            if (e.Effect == DragDropEffects.Move)
            {
                textBox1.Clear();
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(listBox1.Items.Count >0)
                listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if ((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else
                if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                    e.Effect = DragDropEffects.Move;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string text = e.Data.GetData(typeof(string)).ToString();
            try
            {
                int varsta = Convert.ToInt32(text.Split(',')[0]);
                string nume = text.Split(',')[1];
                float medie = (float)Convert.ToDouble(text.Split(',')[2]);
                Student s = new Student(varsta, nume, medie);
                lista.Add(s);
                listBox1.Items.Add(s.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (e.Effect == DragDropEffects.Move)
                textBox1.Clear();
        }
    }
}
