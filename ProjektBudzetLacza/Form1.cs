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
                kalk.WzorBox.Text = "TRANSMITTER POWER + TRANSMITTER GAIN - TRANSMITTER ATTENUATION - FSL + RECEIVER GAIN - RECEIVER ATTENUATION";
                kalk.textBox12.Text = "Calculation model with optical visibility. Autocomplete disabled.Enter the values ​​for the calculated link budget manually.";
                kalk.label8.Text = "Link budget";
                kalk.label7.Text = "Obstacles model";
                kalk.label10.Text = "Distance [km]";
                kalk.label11.Text = "Frequency [MHz]";
                kalk.label12.Text = "Transmitter model";
                kalk.label18.Text = "Receiver model";
                kalk.label14.Text = "Antenna model";
                kalk.label15.Text = "Cable name (transmitter)";
                kalk.label16.Text = "Connector name (transmitter)";
                kalk.label20.Text = "Antenna model";
                kalk.label21.Text = "Cable name (reciver)";
                kalk.label22.Text = "Connector name (reciver)";
                kalk.label17.Text = "Cable length (transmitter) [m]";
                kalk.label23.Text = "Cable length (receiver) [m]";
                kalk.label1.Text = "Transmitter power";
                kalk.label2.Text = "Transmitter gain [dBi]";
                kalk.label3.Text = "Transmitter attenuation [db]";
                kalk.label13.Text = "Cable attenuation [db]";
                kalk.label19.Text = "Connector attenuation [db]";
                kalk.label5.Text = "Receiver gain [db]";
                kalk.label6.Text = "Receiver attenuation [db]";
                kalk.label27.Text = "Cable attenuation [db]";
                kalk.label26.Text = "Connector attenuation [db]";
                kalk.label9.Text = "Obstacle attenuation [db]";
                kalk.label24.Text = "Material name";
                kalk.label25.Text = "Thickness [cm]";
                kalk.addButton.Text = "Add an obstacle";
                kalk.button1.Text = "Save data";
                kalk.button2.Text = "Read data";
                kalk.CountButton.Text = "Count";
                kalk.ClearButton.Text = "Clear";
                kalk.QuitButton.Text = "Quit";
                kalk.label28.Text = "Autocomplete";
                kalk.comboBox6.Text = "Choose";
            }
            else
            {
                kalk.lang = 0;
                kalk.WzorBox.Text = "MOC NADAJNIKA + ZYSK NADAJNIKA - TŁUMIENNOŚĆ NADAJNIKA - FSL + ZYSK ODBIORNIKA - TŁUMIENNOŚĆ ODBIRONIKA";
                kalk.textBox12.Text = "Model obliczeniowy z widocznością optyczną. Autouzupełnianie wyłączone. Wprowadź ręcznie wartości dla liczonego budżetu łącza.";
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

