using ProjektBudzetLacza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class Kalkulator : Form
    {
        List<FSL2> lista_FSL = new List<FSL2>();
        List<parametry_anteny_moc> lista_MOC = new List<parametry_anteny_moc>();
        List<parametry_anteny_zysk> lista_ZYSK = new List<parametry_anteny_zysk>();
        List<Tlumiennosc> lista_TLUM = new List<Tlumiennosc>();
        List<tl_materialow2> lista_MAT = new List<tl_materialow2>();
        List<czestotliwosc> lista_CZ = new List<czestotliwosc>();
        List<odleglosc> lista_ODL = new List<odleglosc>();

        public Kalkulator()
        {
            InitializeComponent();
            loadList();
            textBox2.Hide();
            textBox4.Hide();
            textBox3.Text = "MOC + ZN - TN - FSL + ZO - TO";
        }

        private void loadList()
        {
            lista_FSL = SqliteDataAccess.calc_FSL_Load();
            lista_MOC = SqliteDataAccess.calc_MOC_Load();
            lista_ZYSK = SqliteDataAccess.calc_ZYSK_Load();
            lista_TLUM = SqliteDataAccess.calc_TLUMIENOSC_Load();
            lista_MAT = SqliteDataAccess.calc_MATERIALY_Load();
            lista_CZ = SqliteDataAccess.calc_CZESTOTLIWOSC_Load();
            lista_ODL = SqliteDataAccess.calc_ODLEGLOSC_Load();
            WireUpList();
        }

        private void WireUpList()
        {
            dataGridViewFSL.DataSource = lista_FSL;
            dataGridViewMoc.DataSource = lista_MOC;
            dataGridViewZN.DataSource = lista_ZYSK;
            dataGridViewZO.DataSource = lista_ZYSK;
            dataGridViewTO.DataSource = lista_TLUM;
            dataGridViewTN.DataSource = lista_TLUM;
            dataGridViewM.DataSource = lista_MAT;
            dataGridView1.DataSource = lista_ODL;
            dataGridView2.DataSource = lista_CZ;
        }
        public bool IsEmptyTextBox(TextBox text)
        {
            return text.Text.Length == 0;
        }
        private void textBoxFSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar)) 
            { e.Handled = true; }
        }
        private void textBoxMOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            { e.Handled = true; }
        }
        private void textBoxTN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            { e.Handled = true; }
        }
        private void textBoxZN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            { e.Handled = true; }
        }
        private void textBoxTO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            { e.Handled = true; }
        }
        private void textBoxZO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            { e.Handled = true; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double TN = 0;
            double MOC;
            double TO = 0;
            double ZN;
            double ZO;
            double FSL;
            double MAT = 0;
            if (!IsEmptyTextBox(textBoxTN))
            {
                string[] subs = textBoxTN.Text.Split('+');
                for (int i = 0; i < subs.Length; i++)
                {
                    TN += Convert.ToDouble(subs[i]);
                }
            }
            else
            {
                TN = 0;
            }
            if (!IsEmptyTextBox(textBoxMOC))
            {
                MOC = Convert.ToDouble(textBoxMOC.Text);
            }
            else
            {
                MOC = 0;
            }
            if (!IsEmptyTextBox(textBoxTO))
            {
                string[] subs = textBoxTO.Text.Split('+');
                for (int i = 0; i < subs.Length; i++)
                {
                    TO += Convert.ToDouble(subs[i]);
                }
            }
            else
            {
                TO = 0;
            }
            if (!IsEmptyTextBox(textBoxZN))
            {
                ZN = Convert.ToDouble(textBoxZN.Text);
            }
            else
            {
                ZN = 0;
            }
            if (!IsEmptyTextBox(textBoxZO))
            {
                ZO = Convert.ToDouble(textBoxZO.Text);
            }
            else
            {
                ZO = 0;
            }
            if (!IsEmptyTextBox(textBoxFSL))
            {
                FSL = Convert.ToDouble(textBoxFSL.Text);
            }
            else
            {
                FSL = 0;
            }
            if (checkBox1.Checked)
            {
                if (!IsEmptyTextBox(textBox4))
                {
                    string[] subs = textBox4.Text.Split('+');
                    for (int i = 0; i < subs.Length; i++)
                    {
                        MAT += Convert.ToDouble(subs[i]);
                    }
                }
                else
                {
                    MAT = 0;
                }
                double BL = MOC + ZN - TN - FSL + ZO - TO - MAT;
                textBox1.Text = MOC.ToString() + " + " + ZN.ToString() + " - " + TN.ToString() + " - " + FSL.ToString() + " + " + ZO.ToString() + " - " + TO.ToString() + " - " + MAT.ToString() + " = " + BL.ToString();
            }
            else
            {
                double BL = MOC + ZN - TN - FSL + ZO - TO;
                textBox1.Text = MOC.ToString() + " + " + ZN.ToString() + " - " + TN.ToString() + " - " + FSL.ToString() + " + " + ZO.ToString() + " - " + TO.ToString() +  " = " + BL.ToString();
            }
            

            //calculator kalk = new calculator();
            // textBox1.Text = kalk.calculate(Convert.ToDouble(SqliteDataAccess.QueryResult("select moc from parametry_anteny where id=1 AND czy_nad=0")), Convert.ToDouble(SqliteDataAccess.QueryResult("select zysk from parametry_anteny where id=1")), Convert.ToDouble(SqliteDataAccess.QueryResult("SELECT (kabel.wartosc+zlacze.tlumiennosc) FROM parametry_anteny, kabel, zlacze WHERE parametry_anteny.id_kabla = kabel.id AND parametry_anteny.id_zlacza = zlacze.id AND parametry_anteny.id=1")), Convert.ToDouble(SqliteDataAccess.QueryResult("select wartosc from fsl where id = 12")), Convert.ToDouble(SqliteDataAccess.QueryResult("select zysk from parametry_anteny where id=1")), Convert.ToDouble(SqliteDataAccess.QueryResult("SELECT (kabel.wartosc+zlacze.tlumiennosc) FROM parametry_anteny, kabel, zlacze WHERE parametry_anteny.id_kabla = kabel.id AND parametry_anteny.id_zlacza = zlacze.id AND parametry_anteny.id=1"))).ToString();
        }
        private void dataGridViewFSL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridViewFSL.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            textBoxFSL.Text = cellValue;
        }
        private void dataGridViewMoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridViewMoc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            textBoxMOC.Text = cellValue;
        }
        private void dataGridViewZN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridViewZN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            textBoxZN.Text = cellValue;
        }
        private void dataGridViewZO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridViewZO.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            textBoxZO.Text = cellValue;
        }
        private void dataGridViewTN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridViewTN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (textBoxTN.Text.Length == 0)
            {
                textBoxTN.Text = cellValue;
            }
            else
            {
                textBoxTN.Text += " + " + cellValue;
            }

        }
        private void dataGridViewTO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridViewTO.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (textBoxTO.Text.Length == 0)
            {
                textBoxTO.Text = cellValue;
            }
            else
            {
                textBoxTO.Text += " + " + cellValue;
            }
        }
        private void dataGridViewM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridViewM.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (textBox4.Text.Length == 0)
            {
                textBox4.Text = cellValue;
            }
            else
            {
                textBox4.Text += " + " + cellValue;
            }
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBoxFSL.Clear();
            textBoxMOC.Clear();
            textBoxTN.Clear();
            textBoxTO.Clear();
            textBoxZN.Clear();
            textBoxZO.Clear();
            textBox4.Clear();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.Text = "MOC + ZN - TN - FSL + ZO - TO - TP";
                textBox4.Show();
            }
            else
            {
                textBox3.Text = "MOC + ZN - TN - FSL + ZO - TO";
                textBox4.Hide();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                    using (StreamWriter objWriter = new StreamWriter(saveFileDialog1.FileName))
                    {
                        objWriter.Write("FSL: " + textBoxFSL.Text + ", ");
                        objWriter.Write("Moc: " + textBoxMOC.Text + ", ");
                        objWriter.Write("Nadajnik: " + textBoxTN.Text + ", ");
                        objWriter.Write("Odbiornik: " + textBoxTO.Text + ", ");
                        objWriter.Write("Zlacze- nadajnik: " + textBoxZN.Text + ", ");
                        objWriter.Write("Zlacze- odbiornik: " + textBoxZO.Text + ", ");
                        objWriter.Write("\n");
                        objWriter.Write("Wynik: " + textBox1.Text);
                    }
            }
           /* using (StreamWriter objWriter = new StreamWriter("test1.txt"))
            {
                objWriter.Write(textBox1.Text);

                MessageBox.Show("Details have been saved");
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Show();
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var line in File.ReadAllLines(openFileDialog1.FileName))
                {
                    textBox2.Text += line;
                }
                    
            }

        }
    }
}
