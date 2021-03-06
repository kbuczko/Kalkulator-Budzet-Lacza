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
    public partial class materialy : Form
    {
        List<tl_materialow> lista = new List<tl_materialow>();
       
        public materialy()
        {
            InitializeComponent();
            loadMaterialy();
        }

        private void loadMaterialy()
        {
            lista = SqliteDataAccess.listMaterials();
            WireUpList();
        }

        private void WireUpList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = lista;
            listBox1.DisplayMember = "material";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tl_materialow mat = new tl_materialow();
            mat.nazwa = textBox1.Text;
            mat.wartosc = Convert.ToInt32(textBox2.Text);
            SqliteDataAccess.saveMaterials(mat);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadMaterialy();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kalkulator kalk = new Kalkulator();
            kalk.ShowDialog();
        }
    }
}
