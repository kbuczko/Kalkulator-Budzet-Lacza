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
    public partial class czest_form : Form
    {
        List<czestotliwosc> lista_czest = new List<czestotliwosc>();
        public czest_form()
        {
            InitializeComponent();
            loadList();
        }

        private void loadList()
        {
            lista_czest = SqliteDataAccess.ListCzest();
            WireUpList();
        }

        private void WireUpList()
        {
            dataGridView1.DataSource = lista_czest;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            czestotliwosc czest = new czestotliwosc();
            czest.wartosc = Convert.ToInt32(textBox2.Text);
            SqliteDataAccess.saveCzest(czest);
            textBox2.Text = "";
            loadList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            odleglosc_form odl = new odleglosc_form();
            odl.ShowDialog();
        }
    }
}
