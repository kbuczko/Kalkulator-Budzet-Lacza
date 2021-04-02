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
            kabel_form kab = new kabel_form();
            kab.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            zlacze_form zl = new zlacze_form();
            zl.ShowDialog();
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
    }
}
