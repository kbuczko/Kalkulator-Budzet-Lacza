using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ProjektBudzetLacza
{
    public partial class Form1 : Form
    {
        bool jezyk_pol = true;
        public Form1()
            {
                InitializeComponent();
                Title.BackColor = System.Drawing.Color.Transparent;
                engToolStripMenuItem.Checked = false;    
                polToolStripMenuItem.Checked = true;
            }
        

        private void DataBaseButton_Click(object sender, EventArgs e)
        {
          
            home home = new home();
            if (jezyk_pol == false)
            {
                home.lang = 1;
                home.comboBox1.Items[0] = "Link Budget";
                home.comboBox1.Items[1] = "Materials";
                home.comboBox1.Items[2] = "Antennas";
                home.comboBox1.Items[3] = "Devices";
                home.comboBox1.Items[4] = "Cables";
                home.comboBox1.Items[5] = "Connectors";
                home.comboBox1.SelectedItem = "Antennas";
            }
            else { home.lang = 0; home.comboBox1.SelectedItem = "Anteny"; }
            home.ShowDialog();
            
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            Kalkulator kalk = new Kalkulator();
            if (jezyk_pol == false)
            {
                kalk.lang = 1;
            }
            else
            {
                kalk.lang = 0;
            }
                kalk.ShowDialog();
        }

        private void engToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engToolStripMenuItem.Checked = true;
            polToolStripMenuItem.Checked = false;
            Title.Text = "Link Budget";
            DataBaseButton.Text = "Database";
            CalcButton.Text = "Calculator";
            InstructioinButton.Text = "Instruction";
            językiToolStripMenuItem.Text = "Languages";
            QuitButton.Text = "Quit";

            jezyk_pol = false;


        }

        private void polToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engToolStripMenuItem.Checked = false;
            polToolStripMenuItem.Checked = true;
            Title.Text = "Budżet Łącza";
            DataBaseButton.Text = "Baza danych";
            CalcButton.Text = "Kalkulator";
            InstructioinButton.Text = "Instrukcja";
            QuitButton.Text = "Wyjdź";
            językiToolStripMenuItem.Text = "Języki";

            jezyk_pol = true;


        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InstructioinButton_Click(object sender, EventArgs e)
        {
            Instrukcja inst = new Instrukcja();
            inst.ShowDialog();
        }
    }

      
    }

