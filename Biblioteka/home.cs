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
        
        private void clearTextBoxes()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Hide();
                }
            }
        }

        private void clearLabels()
        {
            foreach (var c in this.Controls)
            {
                if (c is Label && ((Label)c).Text != "Select table")
                {
                    ((Label)c).Text = "";
                }
            }
        }

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
            dataGridView1.DataSource = lista_FSL;
            clearTextBoxes();
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
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    label1.Text = "Odległość";
                    label3.Text = "Częstotliwość";
                    label4.Text = "Wartość";
                    break;
                case "Materiały":
                    dataGridView1.DataSource = lista_mat;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    label1.Text = "Nazwa";
                    label3.Text = "Wartość";
                    break;
                case "Parametry anten":
                    dataGridView1.DataSource = lista_ant;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    textBox4.Show();
                    textBox5.Show();
                    label1.Text = "Id kabla";
                    label3.Text = "Id złącza";
                    label4.Text = "Moc";
                    label5.Text = "Zysk";
                    label6.Text = "Rodzaj";
                    break;
                case "Kable":
                    dataGridView1.DataSource = lista_kab;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    label1.Text = "Częstotliwosć";
                    label3.Text = "Symbol";
                    label4.Text = "Wartość";
                    break;
                case "Złącza":
                    dataGridView1.DataSource = lista_zla;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    label1.Text = "Symbol";
                    label3.Text = "Tłumienność";
                    break;
                case "Częstotliwość":
                    dataGridView1.DataSource = lista_czest;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    label1.Text = "Wartość";
                    break;
                case "Odległość":
                    dataGridView1.DataSource = lista_odl;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    label1.Text = "Wartość";
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "FSL":
                    FSL fsl = new FSL
                    {
                        id_odl = Convert.ToDouble(textBox2.Text),
                        id_czest = Convert.ToInt32(textBox3.Text),
                        wartosc = Convert.ToDouble(textBox4.Text)
                    };
                    SqliteDataAccess.SaveFsl(fsl);

                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    break;
                case "Materiały":
                    tl_materialow mat = new tl_materialow
                    {
                        nazwa = textBox1.Text,
                        wartosc = Convert.ToDouble(textBox2.Text)
                    };
                    SqliteDataAccess.saveMaterials(mat);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    break;
                case "Parametry anten":
                    parametry_anteny par = new parametry_anteny
                    {
                        id_kabla = Convert.ToInt32(textBox1.Text),
                        id_zlacza = Convert.ToInt32(textBox2.Text),
                        moc = Convert.ToDouble(textBox3.Text),
                        zysk = Convert.ToDouble(textBox4.Text),
                        rodzaj = textBox5.Text
                    };
                    SqliteDataAccess.saveParameters(par);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    break;
                case "Kable":
                    kabel kab = new kabel
                    {
                        id_czest = Convert.ToInt32(textBox1.Text),
                        symbol = textBox2.Text,
                        wartosc = Convert.ToInt32(textBox3.Text)
                    };
                    SqliteDataAccess.saveCables(kab);


                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    break;
                case "Złącza":
                    zlacze zl = new zlacze
                    {
                        symbol = textBox1.Text,
                        tlumiennosc = Convert.ToDouble(textBox2.Text)
                    };
                    SqliteDataAccess.saveZlacza(zl);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    break;
                case "Częstotliwość":
                    czestotliwosc czest = new czestotliwosc
                    {
                        wartosc = Convert.ToInt32(textBox2.Text)
                    };
                    SqliteDataAccess.saveCzest(czest);

                    textBox2.Text = "";
                    break;
                case "Odległość":
                    odleglosc odl = new odleglosc
                    {
                        wartosc = Convert.ToInt32(textBox2.Text)
                    };
                    SqliteDataAccess.saveOdl(odl);

                    textBox2.Text = "";
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            int id = 0;
            
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Materiały":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    SqliteDataAccess.QueryResult("Delete FROM tl_materialow WHERE id= '"+id+"'");
                    dataGridView1.DataSource = lista_mat;
                    break;
            }
            

        }

        /*else
        {
            dataGridView1.DataSource = "";
        }*/

    }
    }
