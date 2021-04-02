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
    public partial class zlacze_form : Form
    {
        List<zlacze> lista = new List<zlacze>();
        public zlacze_form()
        {
            InitializeComponent();
            loadMaterialy();
        }
        private void loadMaterialy()
        {
            lista = SqliteDataAccess.ListZlacza();
            WireUpList();
        }

        private void WireUpList()
        {
            dataGridView1.DataSource = lista;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            zlacze zl = new zlacze();
            zl.symbol = textBox1.Text;
            zl.tlumiennosc= Convert.ToDouble(textBox2.Text);
            SqliteDataAccess.saveZlacza(zl);


            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
