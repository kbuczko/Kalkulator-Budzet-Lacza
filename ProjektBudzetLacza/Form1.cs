using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektBudzetLacza
{
    public partial class Form1 : Form
    {
        List<FSL> lista_FSL = new List<FSL>();
        public Form1()
        {
            InitializeComponent();
            loadList();
        }

        private void loadList()
        {
            lista_FSL = SqliteDataAccess.load();
            WireUpList();
        }

        private void WireUpList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = lista_FSL;
            listBox1.DisplayMember = "Wartosci";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FSL fsl = new FSL();
            fsl.odleglosc = Convert.ToDouble(textBox2.Text);
            fsl.czestotliwosc = Convert.ToInt32(textBox3.Text);
            fsl.wartosc = Convert.ToDouble(textBox4.Text);
            SqliteDataAccess.SaveFsl(fsl);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            materialy mat = new materialy();
            mat.ShowDialog(this);

        }
    }
}
