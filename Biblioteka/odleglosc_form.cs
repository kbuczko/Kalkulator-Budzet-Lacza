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
    public partial class odleglosc_form : Form
    {
        List<odleglosc> lista_odl = new List<odleglosc>();
        public odleglosc_form()
        {
            InitializeComponent();
            loadList();
        }

        private void loadList()
        {
            lista_odl = SqliteDataAccess.listOdl();
            WireUpList();
        }

        private void WireUpList()
        {
            dataGridView1.DataSource = lista_odl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            odleglosc odl = new odleglosc();
            odl.wartosc = Convert.ToInt32(textBox2.Text);
            SqliteDataAccess.saveOdl(odl);
            textBox2.Text = "";
            loadList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
