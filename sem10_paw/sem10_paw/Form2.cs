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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = student.accdb");
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;

                comanda.CommandText = "SELECT MAX(cod) FROM student";
                int cod = Convert.ToInt32(comanda.ExecuteScalar());

                comanda.CommandText = "INSERT INTO student VALUES(?,?,?,?,?)";
                comanda.Parameters.Add("cod", OleDbType.Integer).Value = cod + 1;
                comanda.Parameters.Add("nume", OleDbType.Char, 20).Value = tbNume.Text;
                comanda.Parameters.Add("varsta", OleDbType.Integer).Value = Convert.ToInt32(tbVarsta.Text);
                comanda.Parameters.Add("sex", OleDbType.Char, 2).Value = cbSex.Text;
                comanda.Parameters.Add("adresa", OleDbType.Char, 30).Value = tbAdresa.Text;
                comanda.ExecuteNonQuery();
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
                tbNume.Clear();
                tbVarsta.Clear();
                tbAdresa.Clear();
                cbSex.Text = "";
            }
        }
    }
}
