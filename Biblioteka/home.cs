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
    public partial class home : Form
    {

        List<FSL> lista_FSL = new List<FSL>();
        List<tl_materialow> lista_mat = new List<tl_materialow>();
        List<parametry_anteny> lista_ant = new List<parametry_anteny>();
        List<kabel> lista_kab = new List<kabel>();
        List<zlacze> lista_zla = new List<zlacze>();
        List<czestotliwosc> lista_czest = new List<czestotliwosc>();
        List<odleglosc> lista_odl = new List<odleglosc>();


        public home()
        {
            InitializeComponent();
            lista_mat = SqliteDataAccess.listMaterials();
            lista_FSL = SqliteDataAccess.load();
            lista_ant = SqliteDataAccess.ListParameters();
            lista_kab = SqliteDataAccess.ListCables();
            lista_zla = SqliteDataAccess.ListZlacza();
            lista_czest = SqliteDataAccess.ListCzest();
            lista_odl = SqliteDataAccess.listOdl();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem.ToString())
            {
                case "FSL":
                    dataGridView1.DataSource = lista_FSL;
                    break;
                case "Materiały":
                    dataGridView1.DataSource = lista_mat;
                    break;
                case "Parametry anten":
                    dataGridView1.DataSource = lista_ant;
                    break;
                case "Kable":
                    dataGridView1.DataSource = lista_kab;
                    break;
                case "Złącza":
                    dataGridView1.DataSource = lista_zla;
                    break;
                case "Częstotliwość":
                    dataGridView1.DataSource = lista_czest;
                    break;
                case "Odległość":
                    dataGridView1.DataSource = lista_odl;
                    break;

            }
        }
           
            /*else
            {
                dataGridView1.DataSource = "";
            }*/
            
        }
    }
