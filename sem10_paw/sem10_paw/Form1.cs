using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;

namespace sem10_paw
{
    public partial class Form1 : Form
    {
        string connString;

        public Form1()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = student.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                //MessageBox.Show("merge");
                //OleDbCommand comanda = new OleDbCommand("SELECT * FROM student", conexiune);
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT * FROM student";
                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["cod"].ToString());
                    itm.SubItems.Add(reader["nume"].ToString());
                    itm.SubItems.Add(reader["varsta"].ToString());
                    itm.SubItems.Add(reader["sex"].ToString());
                    itm.SubItems.Add(reader["adresa"].ToString());
                    listView1.Items.Add(itm);
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             OleDbConnection conexiune = new OleDbConnection(connString);
             try
             {
                 conexiune.Open();
                 OleDbCommand comanda = new OleDbCommand();
                 comanda.Connection = conexiune;

                 foreach(ListViewItem itm in listView1.Items)
                     if (itm.Checked)
                     {
                         int cod = Convert.ToInt32(itm.SubItems[0].Text);
                         comanda.CommandText = "UPDATE student SET adresa='Bucuresti' WHERE cod=" + cod;
                         comanda.ExecuteNonQuery();
                     }
             }
             catch (OleDbException ex)
             {
                 MessageBox.Show(ex.Message);
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 conexiune.Close();
             }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
