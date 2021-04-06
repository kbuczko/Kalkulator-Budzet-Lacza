﻿using ProjektBudzetLacza;
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
    public partial class Kalkulator : Form
    {
        List<FSL2> lista_FSL = new List<FSL2>();
        List<parametry_anteny_moc> lista_MOC = new List<parametry_anteny_moc>();
        List<parametry_anteny_zysk> lista_ZYSK = new List<parametry_anteny_zysk>();
        List<Tlumiennosc> lista_TLUM = new List<Tlumiennosc>();

        public Kalkulator()
        {
            InitializeComponent();
            loadList();
        }

        private void loadList()
        {
            lista_FSL = SqliteDataAccess.calc_FSL_Load();
            lista_MOC = SqliteDataAccess.calc_MOC_Load();
            lista_ZYSK = SqliteDataAccess.calc_ZYSK_Load();
            lista_TLUM = SqliteDataAccess.calc_TLUMIENOSC_Load();

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
            double TN;
            double MOC;
            double TO;
            double ZN;
            double ZO;
            double FSL;
            if (!IsEmptyTextBox(textBoxTN))
            {
                TN = Convert.ToDouble(textBoxTN.Text);
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
                TO = Convert.ToDouble(textBoxTO.Text);
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
            double BL = MOC + ZN - TN - FSL + ZO - TO;
            textBox1.Text = BL.ToString();

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
        }
    }
}
