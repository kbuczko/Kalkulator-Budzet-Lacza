using ProjektBudzetLacza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class par_anteny : Form
    {
        List<parametry_anteny> lista = new List<parametry_anteny>();
        public par_anteny()
        {
            InitializeComponent();
            loadMaterialy();
        }

        private void loadMaterialy()
        {
            lista = SqliteDataAccess.ListParameters();
            WireUpList();
        }

        private void WireUpList()
        {
            dataGridView1.DataSource = lista;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            parametry_anteny par = new parametry_anteny();
            par.id_kabla = Convert.ToInt32(textBox1.Text);
            par.id_zlacza= Convert.ToInt32(textBox2.Text);
            par.moc = Convert.ToDouble(textBox3.Text);
            par.zysk= Convert.ToDouble(textBox4.Text);
            par.rodzaj = textBox5.Text;
            SqliteDataAccess.saveParameters(par);


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kabel_form kab = new kabel_form();
            kab.ShowDialog();
        }
    }
}
