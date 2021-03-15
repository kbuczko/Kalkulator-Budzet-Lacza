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
    public partial class FreeSpaceLoss : Form
    {
        List<FSL> lista_FSL = new List<FSL>();
       
        public FreeSpaceLoss()
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
            dataGridView1.DataSource = lista_FSL;


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
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            loadList();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            materialy mat = new materialy();
            mat.ShowDialog(this);
        }
        private int rowIndex = 0;
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqliteDataAccess.QueryResult("Delete from FSL WHERE id=17");
        }
    }
}
