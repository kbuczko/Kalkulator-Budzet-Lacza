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
        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FreeSpaceLoss fsl = new FreeSpaceLoss();
            fsl.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            materialy mat = new materialy();
            mat.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            par_anteny par = new par_anteny();
            par.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            kabel_form kab = new kabel_form();
            kab.ShowDialog();
=======
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
                case "Anteny":
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
>>>>>>> Stashed changes
        }

        private void button5_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            zlacze_form zl = new zlacze_form();
            zl.ShowDialog();
=======
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
                case "Anteny":
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
>>>>>>> Stashed changes
        }

        private void button6_Click(object sender, EventArgs e)
        {
            czest_form czest = new czest_form();
            czest.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            odleglosc_form odl = new odleglosc_form();
            odl.ShowDialog();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
