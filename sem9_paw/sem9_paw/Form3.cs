using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;

namespace sem9_paw
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            comboBox1.Items.Add("English");
            comboBox1.Items.Add("Spanish");
            comboBox1.Items.Add("French");
            comboBox1.Items.Add("Romanian");
            comboBox1.Items.Add("Italian");
            comboBox1.SelectedIndex = 0;
        }

        private void ChangeLanguage(string lang)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager res = new ComponentResourceManager(typeof(Form3));
                res.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "English")
                ChangeLanguage("en");
            else
                if (comboBox1.SelectedItem.ToString() == "Spanish")
                    ChangeLanguage("es-ES");
                else
                    if (comboBox1.SelectedItem.ToString() == "French")
                        ChangeLanguage("fr-FR");
                    else
                        if (comboBox1.SelectedItem.ToString() == "Romanian")
                            ChangeLanguage("ro-RO");
                        else
                            if (comboBox1.SelectedItem.ToString() == "Italian")
                                ChangeLanguage("it-IT");
        }
    }
}
