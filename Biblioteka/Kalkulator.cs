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
    public partial class Kalkulator : Form
    {
        
        public Kalkulator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculator kalk = new calculator();

            textBox1.Text = kalk.calculate(Convert.ToDouble(SqliteDataAccess.QueryResult("select moc from parametry_anteny where id=1 AND czy_nad=0")), Convert.ToDouble(SqliteDataAccess.QueryResult("select zysk from parametry_anteny where id=1")), Convert.ToDouble(SqliteDataAccess.QueryResult("SELECT (kabel.wartosc+zlacze.tlumiennosc) FROM parametry_anteny, kabel, zlacze WHERE parametry_anteny.id_kabla = kabel.id AND parametry_anteny.id_zlacza = zlacze.id AND parametry_anteny.id=1")), Convert.ToDouble(SqliteDataAccess.QueryResult("select wartosc from fsl where id = 12")), Convert.ToDouble(SqliteDataAccess.QueryResult("select zysk from parametry_anteny where id=1")), Convert.ToDouble(SqliteDataAccess.QueryResult("SELECT (kabel.wartosc+zlacze.tlumiennosc) FROM parametry_anteny, kabel, zlacze WHERE parametry_anteny.id_kabla = kabel.id AND parametry_anteny.id_zlacza = zlacze.id AND parametry_anteny.id=1"))).ToString();

            
        }
    }
}
