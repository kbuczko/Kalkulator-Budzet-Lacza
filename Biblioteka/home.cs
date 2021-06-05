using ProjektBudzetLacza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class home : Form
    {
        
        List<tl_materialow> lista_mat = new List<tl_materialow>();
        List<parametry_anteny> lista_ant = new List<parametry_anteny>();
        List<kabel> lista_kab = new List<kabel>();
        List<zlacze> lista_zla = new List<zlacze>();
        List<Budzet_lacza> lista_bud = new List<Budzet_lacza>();
        List<Urzadzenie> lista_urz = new List<Urzadzenie>();

       
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
                if (c is Label && ((Label)c) != label2)
                {
                    ((Label)c).Text = "";
                }
            }
        }

        public home()
        {
            InitializeComponent();
            lista_bud = SqliteDataAccess.ListBudzet();
            lista_mat = SqliteDataAccess.listMaterials();
            lista_ant = SqliteDataAccess.ListParameters();
            lista_kab = SqliteDataAccess.ListCables();
            lista_zla = SqliteDataAccess.ListZlacza();
            lista_urz = SqliteDataAccess.ListUrzadzenie();


            // MessageBox.Show(rm.GetString("QuitButton.Text"));
            
            label7.Text = "lista_fsl";
            dataGridView1.DataSource = lista_bud;
            dataGridView1.Columns[0].Visible = false;
            clearTextBoxes();
            clearLabels();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem.ToString())
            {
               
                case "Urządzenie":
                case "Devices":
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_urz;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    textBox4.Show(); 
                    textBox5.Show();
                    label7.Text = dataGridView1.Columns[1].HeaderText;
                    label1.Text = dataGridView1.Columns[2].HeaderText;
                    label3.Text = dataGridView1.Columns[3].HeaderText; 
                    label4.Text = dataGridView1.Columns[4].HeaderText;
                    label5.Text = dataGridView1.Columns[5].HeaderText;
                    break;
                case "Budżet łącza":
                case "Link budget":
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_bud;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    label7.Text = dataGridView1.Columns[1].HeaderText;
                    label1.Text = dataGridView1.Columns[2].HeaderText;
                    label3.Text = dataGridView1.Columns[3].HeaderText;
                    break;
                case "Materiały":
                case "Materials":
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_mat;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    label7.Text = dataGridView1.Columns[1].HeaderText;
                    label1.Text = dataGridView1.Columns[2].HeaderText;
                    break;
                case "Anteny":
                case "Antennas":
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_ant;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    label7.Text = dataGridView1.Columns[1].HeaderText;
                    label1.Text = dataGridView1.Columns[2].HeaderText;
                    label3.Text = dataGridView1.Columns[3].HeaderText;
                    break;
                case "Kable":
                case "Cables":
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_kab;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    label7.Text = dataGridView1.Columns[1].HeaderText;
                    label1.Text = dataGridView1.Columns[2].HeaderText;
                    label3.Text = dataGridView1.Columns[3].HeaderText;
                    break;
                case "Złącza":
                case "Connectors":
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_zla;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    label7.Text = dataGridView1.Columns[1].HeaderText;
                    label1.Text = dataGridView1.Columns[2].HeaderText;
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Urządzenie":
                case "Devices":
                    Urzadzenie urz = new Urzadzenie
                    {

                        moc = Convert.ToInt32(textBox1.Text),
                        dl_kabla = Convert.ToInt32(textBox2.Text),
                        nazwa_kabla = textBox3.Text,
                        nazwa_zlacza = textBox4.Text,
                        nazwa_anteny = textBox5.Text

                    };
                    SqliteDataAccess.saveDevices(urz);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    break;
                case "Materiały":
                case "Materials":
                    tl_materialow mat = new tl_materialow
                    {
                        nazwa = textBox1.Text,
                        tlumiennosc_db = Convert.ToDouble(textBox2.Text)
                    };
                    SqliteDataAccess.saveMaterials(mat);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    break;
                case "Anteny":
                case "Antennas":
                    parametry_anteny par = new parametry_anteny
                    {
                        zysk_dBi = Convert.ToDouble(textBox4.Text),
                        nazwa = textBox5.Text
                    };
                    SqliteDataAccess.saveParameters(par);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    break;
                case "Kable":
                case "Cables":
                    kabel kab = new kabel
                    {
                        czestotliwosc_MHz = Convert.ToInt32(textBox1.Text),
                        symbol = textBox2.Text,
                        tlumiennosc_db1m = Convert.ToInt32(textBox3.Text)
                    };
                    SqliteDataAccess.saveCables(kab);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    break;
                case "Złącza":
                case "Connectors":
                    zlacze zl = new zlacze
                    {
                        symbol = textBox1.Text,
                        tlumiennosc_db = Convert.ToDouble(textBox2.Text)
                    };
                    SqliteDataAccess.saveZlacza(zl);

                    textBox1.Text = "";
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
