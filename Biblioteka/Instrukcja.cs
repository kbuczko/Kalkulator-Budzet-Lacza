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
            if (i == -1)
            {
                pictureBox5.Hide(); //0
                i++;
            }
            else if (i == 0)
            {
                pictureBox3.Show(); //1
                i++;
            }else if (i == 1)
            {
                pictureBox3.Hide();
                pictureBox4.Show(); //2
                i++;
            }else if (i == 2)
            {
                pictureBox4.Hide();
                pictureBox5.Show(); //-1
                i = -1;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i == -1)
            {
                pictureBox5.Hide();
                pictureBox4.Show();
                i = 2;
            }
            else if (i == 0)
            {
                pictureBox5.Show();
                i--;
            }
            else if (i == 1)
            {
                pictureBox3.Hide();
                i--;
            }
            else if (i == 2)
            {
                pictureBox4.Hide();
                pictureBox3.Show();
                i--;
            }
        }
    }
}
