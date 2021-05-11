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

namespace ProjektBudzetLacza
{
    public partial class Form1 : Form
    {
        ResourceManager res_man;
        CultureInfo cul;
        void switch_language() //nie wiem czemu nie działa
        {
            if (polToolStripMenuItem.Checked == true)    
            {
                cul = CultureInfo.CreateSpecificCulture("pl-PL");    
            }
            else                                                
            {
                cul = CultureInfo.CreateSpecificCulture("en-EN");    
            }
        }
            public Form1()
            {
                InitializeComponent();
                label1.BackColor = System.Drawing.Color.Transparent;
                engToolStripMenuItem.Checked = false;    
                polToolStripMenuItem.Checked = true;
                res_man = new ResourceManager("MultiLanguageApp.Resource.Res", typeof(Form1).Assembly);
                switch_language();

        }
        

        private void DataBaseButton_Click(object sender, EventArgs e)
        {
          
            home home = new home();
            home.ShowDialog();
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            Kalkulator kalk = new Kalkulator();
            kalk.ShowDialog();
        }

        private void engToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engToolStripMenuItem.Checked = true;
            polToolStripMenuItem.Checked = false;
            switch_language();
        }

        private void polToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engToolStripMenuItem.Checked = false;
            polToolStripMenuItem.Checked = true;
            switch_language();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }

      
    }

