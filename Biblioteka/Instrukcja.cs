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
    public partial class Instrukcja : Form
    {
        int i = 0;
        public Instrukcja()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                pictureBox3.Show();
                i++;
            }else if (i == 1)
            {
                pictureBox3.Hide();
                i = 0;
            }
            
        }
    }
}
