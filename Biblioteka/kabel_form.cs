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
    public partial class kabel_form : Form
    {
        List<kabel> lista = new List<kabel>();
        public kabel_form()
        {
            InitializeComponent();
            loadMaterialy();
        }

        private void loadMaterialy()
        {
            lista = SqliteDataAccess.ListCables();
            WireUpList();
        }

        private void WireUpList()
        {
            dataGridView1.DataSource = lista;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kabel kab = new kabel();
            kab.id_czest = Convert.ToInt32(textBox1.Text);
            kab.symbol = textBox2.Text;
            kab.wartosc= Convert.ToInt32(textBox3.Text);
            SqliteDataAccess.saveCables(kab);


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zlacze_form zl = new zlacze_form();
            zl.ShowDialog();
        }
    }
}
