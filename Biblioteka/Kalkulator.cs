using Dapper;
using Microsoft.Data.Sqlite;
using ProjektBudzetLacza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class Kalkulator : Form
    {
        public int lang;
        int licznik = 0;
        //nadajnik
        List<Urzadzenie> lista_urz = new List<Urzadzenie>();
        List<parametry_anteny> lista_ant = new List<parametry_anteny>();
        List<kabel> lista_kab = new List<kabel>();
        List<zlacze> lista_zla = new List<zlacze>();
        //odbiornik
        List<parametry_anteny> lista_ant2 = new List<parametry_anteny>();
        List<kabel> lista_kab2 = new List<kabel>();
        List<zlacze> lista_zla2 = new List<zlacze>();

        List<tl_materialow> lista_mat = new List<tl_materialow>();
        List<Budzet_lacza> lista_bud = new List<Budzet_lacza>();
        private int licznik7;
        private static string czestotliwosc_global;
        private static int ant_wbyd_licz = 0;
        public Kalkulator()
        {
            InitializeComponent();

            //nadajnik
            lista_urz = SqliteDataAccess.ListUrzadzenie();
            lista_mat = SqliteDataAccess.listMaterials();
            Load_list();
            textBox4.Hide();
            textBox7.Hide();
            comboBox1.Hide();
            label24.Hide();
            label25.Hide();
            addButton.Hide();
            label26.Hide();
            label27.Hide();
            label13.Hide();
            label19.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox11.Hide();
            textBox10.Hide();
            label29.Text = "";

        }
        //load
        private void Load_list() //ładowanie wszystkich zmiennych
        {
            if (lang == 1)
            {
                lista_urz.Insert(0, new Urzadzenie() { nazwa = "Choose" });
            }
            else
            {
                lista_urz.Insert(0, new Urzadzenie() { nazwa = "Wybierz" });
            }
            comboBox5.DataSource = lista_urz;
            comboBox5.DisplayMember = "nazwa";
        }
        //load nadajnik
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
        //przyciski
        private void CountButton1_Click(object sender, EventArgs e)
        {
            string mozna = "Można zestawić połączenia";
            string can = "Can establish a connection";
            string niemozna = "Nie można zestawić połączenie";
            string cant = "Can't establish a connection";

            double TN = 0;
            double MOC;
            double TO = 0;
            double ZN;
            double ZO;
            double FSL;
            double MAT = 0;
            if (!IsEmptyTextBox(textBoxTN))
            {
                string[] subs = textBoxTN.Text.Split('+');
                for (int i = 0; i < subs.Length; i++)
                {
                    TN += Convert.ToDouble(subs[i]);
                }
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
                string[] subs = textBoxTO.Text.Split('+');
                for (int i = 0; i < subs.Length; i++)
                {
                    TO += Convert.ToDouble(subs[i]);
                }
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
                FSL = Math.Round(Convert.ToDouble(textBoxFSL.Text),2);
            }
            else
            {
                FSL = 0;
            }
            if (checkBox1.Checked)
            {
                if (!IsEmptyTextBox(textBox4))
                {
                    string[] subs = textBox4.Text.Split('+');
                    for (int i = 0; i < subs.Length; i++)
                    {
                        MAT += Convert.ToDouble(subs[i]);
                    }
                }
                else
                {
                    MAT = 0;
                }
                double BL = Math.Round(MOC + ZN - TN - FSL + ZO - TO - MAT, 2);
                string query_czulosc = "SELECT Urzadzenie.czulosc FROM  Urzadzenie WHERE Urzadzenie.nazwa = '" + comboBox5.Text + "'";
                int id_czulosc = 0;
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    var a = cnn.ExecuteScalar<int>(query_czulosc);
                    id_czulosc = a;
                }
                if(lang == 1)
                {
                    if (BL + id_czulosc + 10 >= 0)
                    {
                        label29.Text = can;
                        label31.Text = "✓";
                        label31.ForeColor = Color.Green;
                    }
                    else
                    {
                        label29.Text = cant;
                        label31.Text = "X";
                        label31.ForeColor = Color.Red;
                    }
                }
                else
                {
                    if (BL + id_czulosc + 10 >= 0)
                    {
                        label29.Text = mozna;
                        label31.Text = "✓";
                        label31.ForeColor = Color.Green;

                    }
                    else
                    {
                        label29.Text = niemozna;
                        label31.Text = "X";
                        label31.ForeColor = Color.Red;
                    }
                }
                
                string czestotliwosc_txt = comboBox6.GetItemText(comboBox6.SelectedItem);
                string[] subs2 = czestotliwosc_txt.Split('.');
                Int32 czestotliwosc = Convert.ToInt32(subs2[0]);
                Budzet_lacza budzet = new Budzet_lacza
                {
                    fsl_db = FSL,
                    odleglosc_km = Convert.ToDouble(textBox8.Text),
                    czestotliwosc_MHz = czestotliwosc,
                    wartosc = BL
                };
                SqliteDataAccess.saveBudget(budzet);
                textBox1.Text = MOC.ToString() + " + " + ZN.ToString() + " - " + TN.ToString() + " - " + FSL.ToString() + " + " + ZO.ToString() + " - " + TO.ToString() + " - " + MAT.ToString() + " = " + BL.ToString();
            }
            else
            {
                double BL = Math.Round(MOC + ZN - TN - FSL + ZO - TO, 2);


                string query_czulosc = "SELECT Urzadzenie.czulosc FROM  Urzadzenie WHERE Urzadzenie.nazwa = '" + comboBox5.Text + "'";
                int id_czulosc = 0;
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    var a = cnn.ExecuteScalar<int>(query_czulosc);
                    id_czulosc = a;
                }

                if (lang == 1)
                {
                    if (BL + id_czulosc + 10 >= 0)
                    {
                        label29.Text = can;
                        label29.ForeColor = Color.Green;
                        label31.Text = "✓";
                        label31.ForeColor = Color.Green;
                    }
                    else
                    {
                        label29.Text = cant;
                        label31.Text = "X";
                        label31.ForeColor = Color.Red;
                    }
                }
                else
                {
                    if (BL + id_czulosc + 10 >= 0)
                    {
                        label29.Text = mozna;
                        label29.ForeColor = Color.Green;
                        label31.Text = "✓";
                        label31.ForeColor = Color.Green;
                    }
                    else
                    {
                        label29.Text = niemozna;
                        label31.Text = "X";
                        label31.ForeColor = Color.Red;
                    }
                }
                string czestotliwosc_txt = comboBox6.GetItemText(comboBox6.SelectedItem);
                string[] subs3 = czestotliwosc_txt.Split('.');
                Int32 czestotliwosc = Convert.ToInt32(subs3[0]);
                Budzet_lacza budzet = new Budzet_lacza
                {
                    
                fsl_db = FSL,
                    odleglosc_km = Convert.ToDouble(textBox8.Text),
                    czestotliwosc_MHz = czestotliwosc,
                    wartosc = BL
                };
                SqliteDataAccess.saveBudget(budzet);
                textBox1.Text = MOC.ToString() + " + " + ZN.ToString() + " - " + TN.ToString() + " - " + FSL.ToString() + " + " + ZO.ToString() + " - " + TO.ToString() +  " = " + BL.ToString();
            }
            
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
            textBox8.Clear();
            textBoxZN.Clear();
            textBoxZO.Clear();
            textBox4.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox7.Clear();
            textBoxTN.Clear();
            textBoxTO.Clear();
            comboBox5.ResetText();
            comboBox6.ResetText();
            comboBox4.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox7.ResetText();
            comboBox8.ResetText();
            comboBox9.ResetText();
            textBox5.Clear();
            textBox6.Clear();
            if (lang == 1)
            {
                comboBox5.Text = "Choose";
            }
            else
            {
                comboBox5.Text = "Wybierz";
            }
            if(lang == 1)
            {
                comboBox6.Text = "Choose";
            }
            else
            {
                comboBox6.Text = "Wybierz";
            }
            comboBox10.ResetText();
            licznik = 1;
        }
        //chackeBox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                
                if (lang == 1)
                {
                    WzorBox.Text = "TRANSMITTER POWER + TRANSMITTER GAIN - TRANSMITTER ATTENUATION - FSL + RECEIVER GAIN - RECEIVER ATTENUATION - OBSTACLES ATTENUATION";
                    if (checkBox2.Checked)
                    {
                        textBox12.Text = "Computational model without optical optics. Autocomplete is running. Select the elements of your layout to calculate budgets.";
                    }
                    else
                    {
                        textBox12.Text = "Calculation model without optical visibility. Autocomplete disabled. Enter the values ​​for the calculated link budget manually.";
                    }
                }
                else
                {
                    WzorBox.Text = "MOC NADAJNIKA + ZYSK NADAJNIKA - TŁUMIENNOŚĆ NADAJNIKA - FSL + ZYSK ODBIORNIKA - TŁUMIENNOŚĆ ODBIRONIKA - TŁUMIENNOŚĆ PRZESZKÓD";
                    if (checkBox2.Checked)
                    {
                        textBox12.Text = "Model obliczeniowy bez widoczności optycznej. Autouzupełniaie uruchomione. Wybierz elementy swojego układu by wyliczyć budżet łącza.";
                    }
                    else
                    {
                        textBox12.Text = "Model obliczeniowy bez widoczności optycznej. Autouzupełnianie wyłączone. Wprowadź ręcznie wartości dla liczonego budżetu łącza.";
                    }
                }
               
                textBox4.Show();
                label9.Show();
                label24.Show();
                label25.Show();
                textBox7.Show();
                comboBox1.Show();
                addButton.Show();
                comboBox1.DataSource = lista_mat;
                comboBox1.DisplayMember = "nazwa";
            }
            else
            {
               
                if (lang == 1)
                {
                    WzorBox.Text = "TRANSMITTER POWER + TRANSMITTER GAIN - TRANSMITTER ATTENUATION - FSL + RECEIVER GAIN - RECEIVER ATTENUATION";
                    if (checkBox2.Checked)
                    {
                        textBox12.Text = "Calculation model with optical visibility. Autocomplete is running. Select your layout elements to calculate your link budget.";
                    }
                    else
                    {
                        textBox12.Text = "Calculation model with optical visibility. Autocomplete disabled. Enter the values ​​for the calculated link budget manually.";
                    }
                }
                else
                {
                    WzorBox.Text = "MOC NADAJNIKA + ZYSK NADAJNIKA - TŁUMIENNOŚĆ NADAJNIKA - FSL + ZYSK ODBIORNIKA - TŁUMIENNOŚĆ ODBIRONIKA";
                    if (checkBox2.Checked)
                    {
                        textBox12.Text = "Model obliczeniowy z widocznością optyczną. Autouzupełniaie uruchomione. Wybierz elementy swojego układu by wyliczyć budżet łącza.";
                    }
                    else
                    {
                        textBox12.Text = "Model obliczeniowy z widocznością optyczną. Autouzupełnianie wyłączone. Wprowadź ręcznie wartości dla liczonego budżetu łącza.";
                    }
                }

                textBox4.Hide();
                label9.Hide();
                label24.Hide();
                label25.Hide();
                textBox7.Hide();
                comboBox1.Hide();
                addButton.Hide();
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if (lang == 1)
                {
                    if (checkBox1.Checked)
                    {
                        textBox12.Text = "Calculation model without optical visibility. Autocomplete is running. Select your layout elements to calculate your link budget.";
                    }
                    else
                    {
                        textBox12.Text = "Calculation model with optical visibility. Autocomplete is running. Select your layout elements to calculate your link budget.";
                    }
                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        textBox12.Text = "Model obliczeniowy bez widoczności optycznej. Autouzupełniaie uruchomione. Wybierz elementy swojego układu by wyliczyć budżet łącza.";
                    }
                    else
                    {
                        textBox12.Text = "Model obliczeniowy z widocznością optyczną. Autouzupełniaie uruchomione. Wybierz elementy swojego układu by wyliczyć budżet łącza.";
                    }
                }

                label26.Show();
                label27.Show();
                label13.Show();
                label19.Show();
                textBox2.Show();
                textBox3.Show();
                textBox11.Show();
                textBox10.Show();
            }
            else
            {
                if (lang == 1)
                {
                    if (checkBox1.Checked)
                    {
                        textBox12.Text = "Calculation model without optical visibility. Autocomplete disabled. Enter the values ​​for the calculated link budget manually.";
                    }
                    else
                    {
                        textBox12.Text = "Calculation model with optical visibility. Autocomplete disabled. Enter the values ​​for the calculated link budget manually.";
                    }
                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        textBox12.Text = "Model obliczeniowy bez widoczności optycznej. Autouzupełnianie wyłączone. Wprowadź ręcznie wartości dla liczonego budżetu łącza.";
                    }
                    else
                    {
                        textBox12.Text = "Model obliczeniowy z widocznością optyczną. Autouzupełnianie wyłączone. Wprowadź ręcznie wartości dla liczonego budżetu łącza.";
                    }
                }
               
                label26.Hide();
                label27.Hide();
                label13.Hide();
                label19.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox11.Hide();
                textBox10.Hide();
            }
        }
        private static string loadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //combobox nadajnik
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (licznik7 == 0)
            {
                licznik7++;
            }
            else
            {
                comboBox6.ResetText();
                comboBox4.ResetText();
                comboBox2.ResetText();
                comboBox3.ResetText();
                comboBox7.ResetText();
                comboBox8.ResetText();
                comboBox9.ResetText();
                textBox5.Clear();
                textBox6.Clear();
                if (lang == 1)
                {
                    comboBox6.Text = "Choose";
                }
                else
                {
                    comboBox6.Text = "Wybierz";
                }
                comboBox10.ResetText();
                //wybraliśmy nadajnik
                string nazwa = comboBox5.GetItemText(comboBox5.SelectedItem);
                string query = "SELECT moc FROM Urzadzenie WHERE nazwa='"+nazwa+"'";
                string query1 = "SELECT ant_wbud FROM Urzadzenie WHERE nazwa='"+nazwa+"'";
                string query2 = "SELECT id_anteny FROM Urzadzenie WHERE nazwa='" + nazwa + "'";
                using(var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    try
                    {
                        if (checkBox2.Checked) //sprawdzanie autouzupełniania moc
                        {
                            string output = cnn.ExecuteScalar(query).ToString();
                            textBoxMOC.Text = output;
                        }
                        string ant_wbud = cnn.ExecuteScalar(query1).ToString(); //sprawdzanie czy jest antena wbudowana
                        if (ant_wbud == "1") //jest
                        {
                            ant_wbyd_licz = 1;
                            comboBox4.Text = "Antena wbudowana";
                            comboBox3.Text = "Antena wbudowana";
                            textBox3.Text = "0";
                            textBox5.Text = "Antena wbudowana";
                            string id_anteny = cnn.ExecuteScalar(query2).ToString();
                            string query3 = "SELECT nazwa FROM Antena WHERE id='" + id_anteny + "'";
                            var anteny = cnn.Query<parametry_anteny>(query3, new DynamicParameters()); //uzupełnienie pasujących anten

                            comboBox2.DataSource = anteny.ToList();
                            comboBox2.DisplayMember = "nazwa";
                            
                            string nazwa_anteny = comboBox2.GetItemText(comboBox2.SelectedItem);
                            if (checkBox2.Checked)//sprawdzanie autouzupełniania zysk
                            {
                                string query4 = "SELECT zysk_dBi FROM Antena WHERE nazwa='" + nazwa_anteny + "'";
                                string zysk = cnn.ExecuteScalar(query4).ToString();
                                textBoxZN.Text = zysk;
                            }
                            string query7 = "SELECT czestotliwosc_MHz FROM Antena WHERE nazwa='" + nazwa_anteny + "'";
                            string czestotliwosc_antena = cnn.ExecuteScalar(query7).ToString();
                            czestotliwosc_global = czestotliwosc_antena;
                            comboBox6.Text = czestotliwosc_antena;
                            string query5 = "SELECT nazwa FROM Antena WHERE czestotliwosc_MHz='" + czestotliwosc_antena + "'";
                            var output3 = cnn.Query<parametry_anteny>(query5, new DynamicParameters());
                            lista_ant2 = output3.ToList();
                            if (lang == 1)
                            {
                                lista_ant2.Insert(0, new parametry_anteny() { nazwa = "Choose" });
                            }
                            else
                            {
                                lista_ant2.Insert(0, new parametry_anteny() { nazwa = "Wybierz" });
                            }
                            comboBox7.DataSource = lista_ant2;
                            comboBox7.DisplayMember = "nazwa";
                        }
                        else//nie ma wbudowanej anteny
                        {
                            string query5 = "SELECT id_zlacza FROM Urzadzenie WHERE nazwa='" + nazwa + "'";
                            string id_zlacza = cnn.ExecuteScalar(query5).ToString();
                            string query6 = "SELECT symbol FROM Zlacze WHERE id='" + id_zlacza + "'"; //uzupełnienie listy dostępnych złącz
                            var zlacza = cnn.Query<zlacze>(query6, new DynamicParameters());
                            lista_zla = zlacza.ToList();
                            if (lang == 1)
                            {
                                lista_zla.Insert(0, new zlacze() { symbol = "Choose" });
                            }
                            else
                            {
                                lista_zla.Insert(0, new zlacze() { symbol = "Wybierz" });
                            }
                            comboBox4.DataSource = lista_zla;
                            comboBox4.DisplayMember = "symbol";
                        }
                    }
                    catch (NullReferenceException ex) { }
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //combobox rodzaj anteny nadajnik
        {
            string nazwa = comboBox2.GetItemText(comboBox2.SelectedItem);
            using(var cnn = new SQLiteConnection(loadConnectionString()))
            {
                try
                {
                    {
                        if (checkBox2.Checked)
                        {
                            string query1 = "SELECT zysk_dBi FROM Antena WHERE nazwa='" + nazwa + "'";
                            textBoxZN.Text = cnn.ExecuteScalar(query1).ToString();
                        }
                    }
                }catch(NullReferenceException ex)
                {

                }


            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) //combobox rodzaj kabla nadajnik
        {
            string nazwa = comboBox3.GetItemText(comboBox3.SelectedItem);
            string czestotliwosc = comboBox6.GetItemText(comboBox6.SelectedItem);
            if (checkBox2.Checked)
            {
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    try
                    {
                        string query = "SELECT tlumiennosc_db1m FROM Kabel WHERE symbol='" + nazwa + "' AND czestotliwosc_MHz='" + czestotliwosc + "'";
                        if (textBox5.Text == "")
                        {

                            textBox2.Text = cnn.ExecuteScalar(query).ToString();
                        }
                        else
                        {
                            string dl = textBox5.Text;
                            string tl = cnn.ExecuteScalar(query).ToString();
                            double wynik = Convert.ToDouble(dl) * Convert.ToDouble(tl);
                            textBox2.Text = wynik.ToString();
                        }
                    }
                    catch (NullReferenceException ex) { }
                }
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) //combobx rodzaj zlacze nadajnik
        {
                string nazwa = comboBox4.GetItemText(comboBox4.SelectedItem);
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                string query2 = "SELECT id FROM Zlacze WHERE symbol='" + nazwa + "'";
                try
                {
                    string id = cnn.ExecuteScalar(query2).ToString();
                    string czestotliwosc_txt = comboBox6.GetItemText(comboBox6.SelectedItem);
                    string query1 = "SELECT nazwa FROM Antena WHERE czestotliwosc_MHz='" + czestotliwosc_txt + "' AND id_zlacza='" + id + "'";
                    var output = cnn.Query<parametry_anteny>(query1, new DynamicParameters());
                    lista_ant = output.ToList();
                    if (lang == 1)
                    {
                        lista_ant.Insert(0, new parametry_anteny() { nazwa = "Choose" });
                    }
                    else
                    {
                        lista_ant.Insert(0, new parametry_anteny() { nazwa = "Wybierz" });
                    }
                    
                    comboBox2.DataSource = lista_ant.ToList();
                    comboBox2.DisplayMember = "nazwa";
                    if (checkBox2.Checked)//autouzupełnianie
                    {
                        string query = "SELECT tlumiennosc_db FROM Zlacze WHERE symbol='" + nazwa + "'"; //pobranie tlumieności na podstawie nazwy
                        string tlum = cnn.ExecuteScalar(query).ToString();
                        double tluml = Convert.ToDouble(tlum);
                        double czestotliwosc = 0;
                        if (czestotliwosc_txt != "" && tlum != "")
                        {
                            string[] subs = czestotliwosc_txt.Split('.');
                            czestotliwosc = Double.Parse(subs[0]);
                        }
                        double wynik = tluml * Math.Sqrt(czestotliwosc / 1000); //wyliczanie ze wzoru
                        textBox3.Text = Math.Round(wynik,2).ToString();
                    }
                    string query3 = "SELECT symbol FROM Kabel WHERE czestotliwosc_MHz='" + czestotliwosc_txt + "' AND id_zlacza='" + id + "'";
                    var output2 = cnn.Query<kabel>(query3, new DynamicParameters());
                    lista_kab = output2.ToList();
                    if (lang == 1)
                    {
                        lista_kab.Insert(0, new kabel() { symbol = "Choose" });
                    }
                    else
                    {
                        lista_kab.Insert(0, new kabel() { symbol = "Wybierz" });
                    }
                   
                    comboBox3.DataSource = lista_kab;
                    comboBox3.DisplayMember = "symbol";
                }
                catch (NullReferenceException ex) { }
            }
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string czestotliwosc_txt = comboBox6.GetItemText(comboBox6.SelectedItem);
            
            string query1 = "SELECT nazwa FROM Antena WHERE czestotliwosc_MHz='" + czestotliwosc_txt + "'";
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<parametry_anteny>(query1, new DynamicParameters());
                lista_ant2 = output.ToList();
                if (lang == 1)
                {
                    lista_ant2.Insert(0, new parametry_anteny() { nazwa = "Choose" });
                }
                else
                {
                    lista_ant2.Insert(0, new parametry_anteny() { nazwa = "Wybierz" });
                }
                
                comboBox7.DataSource = lista_ant2;
                comboBox7.DisplayMember = "nazwa";
            }
            double f;
            double d;
            if (czestotliwosc_txt != "" || !IsEmptyTextBox(textBox8))
            {
                if (czestotliwosc_txt != ""|| czestotliwosc_txt != "Wybierz" || czestotliwosc_txt != "Choose")
                {
                    string[] subs = czestotliwosc_txt.Split('.');
                    double czestotliwosc = Double.Parse(subs[0]);
                    f = czestotliwosc;
                }
                else
                {
                    f = 1;
                }
                if (!IsEmptyTextBox(textBox8))
                {
                    d = Convert.ToDouble(textBox8.Text);
                }
                else
                {
                    d = 1;
                }
                double FSL = Math.Round(20 * Math.Log10(d) + 20 * Math.Log10(f) + 32.44, 2);
                textBoxFSL.Text = FSL.ToString();
            }
            else
            {
                textBoxFSL.Text = "0";
            }

        }
        //combobox odbiornik
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string czestotliwosc_txt = comboBox6.GetItemText(comboBox6.SelectedItem);
            
            if (czestotliwosc_txt == "")
            {
                czestotliwosc_txt = czestotliwosc_global;
            }
            string query1 = "SELECT nazwa FROM Antena WHERE czestotliwosc_MHz='" + czestotliwosc_txt + "'";
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                try
                {
                    string nazwa = cnn.ExecuteScalar(query1).ToString();
                    if (checkBox2.Checked)
                    {
                        string query2 = "SELECT zysk_dBi FROM Antena WHERE nazwa='" + nazwa + "'";
                        textBoxZO.Text = cnn.ExecuteScalar(query2).ToString();
                    }
                    string query3 = "SELECT id_zlacza FROM Antena WHERE nazwa='" + nazwa + "'";
                    string id_zlacza = cnn.ExecuteScalar(query3).ToString();
                    string query4 = "SELECT symbol FROM Zlacze WHERE id='" + id_zlacza + "'";
                    var output = cnn.Query<zlacze>(query4, new DynamicParameters());
                    lista_zla2 = output.ToList();
                    if (lang == 1)
                    {
                        lista_zla2.Insert(0, new zlacze() { symbol = "Choose" });
                    }
                    else
                    {
                        lista_zla2.Insert(0, new zlacze() { symbol = "Wybierz" });
                    }
                    
                    comboBox9.DataSource = lista_zla2;
                    comboBox9.DisplayMember = "symbol";
                }
                catch (NullReferenceException ex) { }
            }
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nazwa = comboBox8.GetItemText(comboBox8.SelectedItem);
            string czestotliwosc = comboBox6.GetItemText(comboBox6.SelectedItem);
            if (checkBox2.Checked)
            {
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    try {
                        if (czestotliwosc == "")
                        {
                            czestotliwosc = czestotliwosc_global;
                        }
                        string query = "SELECT tlumiennosc_db1m FROM Kabel WHERE symbol='" + nazwa + "' AND czestotliwosc_MHz='" + czestotliwosc + "'";
                    if (textBox6.Text == "")
                    {

                        textBox11.Text = cnn.ExecuteScalar(query).ToString();
                    }
                    else
                    {
                        string dl = textBox6.Text;
                        string tl = cnn.ExecuteScalar(query).ToString();
                        double wynik = Convert.ToDouble(dl) * Convert.ToDouble(tl);
                        textBox11.Text = wynik.ToString();
                    }
                    }
                    catch (NullReferenceException ex) { }
                }
            }
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nazwa = comboBox9.GetItemText(comboBox9.SelectedItem);
            string query = "SELECT id FROM Zlacze WHERE symbol='" + nazwa + "'";
            string czestotliwosc_txt = comboBox6.GetItemText(comboBox6.SelectedItem);
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                try
                {
                    if (checkBox2.Checked)
                {
                    if (checkBox2.Checked)//autouzupełnianie
                    {
                        string query1 = "SELECT tlumiennosc_db FROM Zlacze WHERE symbol='" + nazwa + "'"; //pobranie tlumieności na podstawie nazwy
                        string tlum = cnn.ExecuteScalar(query).ToString();
                        double tluml = Convert.ToDouble(tlum);
                        double czestotliwosc = 0;
                        if (czestotliwosc_txt != "" || czestotliwosc_txt != "Wybierz" || czestotliwosc_txt != "Choose")
                        {
                            string[] subs = czestotliwosc_txt.Split('.');
                            czestotliwosc = Double.Parse(subs[0]);
                        }
                        double wynik = tluml * Math.Sqrt(czestotliwosc / 1000); //wyliczanie ze wzoru
                        textBox10.Text = Math.Round(wynik,2).ToString();
                    }
                }
                
                    string id = cnn.ExecuteScalar(query).ToString();
                    string query2 = "SELECT nazwa FROM Urzadzenie WHERE id_zlacza ='" + id + "'";
                    var output = cnn.Query<parametry_anteny>(query2, new DynamicParameters());
                    lista_ant2 = output.ToList();
                    if (lang == 1)
                    {
                        lista_ant2.Insert(0, new parametry_anteny() { nazwa = "Choose" });
                    }
                    else
                    {
                        lista_ant2.Insert(0, new parametry_anteny() { nazwa = "Wybierz" });
                    }
                    
                    comboBox10.DataSource = lista_ant2;
                    comboBox10.DisplayMember = "nazwa";
                    string query3 = "SELECT symbol FROM Kabel WHERE id_zlacza='" + id + "' AND czestotliwosc_MHz='" + czestotliwosc_txt + "'";
                    var output2 = cnn.Query<kabel>(query3, new DynamicParameters());
                    lista_kab2 = output2.ToList();
                    if (lang == 1)
                    {
                        lista_kab2.Insert(0, new kabel() { symbol = "Choose" });
                    }
                    else
                    {
                        lista_kab2.Insert(0, new kabel() { symbol = "Wybierz" });
                    }
                    
                    comboBox8.DataSource = lista_kab2;
                    comboBox8.DisplayMember = "symbol";
                }
                catch (NullReferenceException ex) { }

            }
        }
        //obsługa pliku
        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                    using (StreamWriter objWriter = new StreamWriter(saveFileDialog1.FileName))
                    {
                        objWriter.Write("FSL: " + textBoxFSL.Text + ", ");
                        objWriter.Write("Moc: " + textBoxMOC.Text + ", ");
                        objWriter.Write("Nadajnik: " + textBoxTN.Text + ", ");
                        objWriter.Write("Odbiornik: " + textBoxTO.Text + ", ");
                        objWriter.Write("Zlacze- nadajnik: " + textBoxZN.Text + ", ");
                        objWriter.Write("Zlacze- odbiornik: " + textBoxZO.Text + ", ");
                        objWriter.Write("\n");
                        objWriter.Write("Wynik: " + textBox1.Text);
                    }
            }
           /* using (StreamWriter objWriter = new StreamWriter("test1.txt"))
            {
                objWriter.Write(textBox1.Text);

                MessageBox.Show("Details have been saved");
            }*/
        }
        private void button2_Click(object sender, EventArgs e)
        {
            WzorBox.Clear();
            WzorBox.Show();
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var line in File.ReadAllLines(openFileDialog1.FileName))
                {
                    WzorBox.Text += line;
                }
                    
            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string tlk = textBox2.Text;
            string tlz = textBox3.Text;
            double tlk_l = 0;
            double tlz_l = 0;
            if(textBox2.Text != "")
            {
                tlk_l = Convert.ToDouble(tlk);
            }
            if(textBox3.Text != "")
            {
                tlz_l = Convert.ToDouble(tlz);
            }
            double wynik = tlk_l + tlz_l;
            textBoxTN.Text = wynik.ToString();
            

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string tlk = textBox2.Text;
            string tlz = textBox3.Text;
            double tlk_l = 0;
            double tlz_l = 0;
            if (textBox2.Text != "")
            {
                tlk_l = Convert.ToDouble(tlk);
            }
            if (textBox3.Text != "")
            {
                tlz_l = Convert.ToDouble(tlz);
            }
            double wynik = tlk_l + tlz_l;
            textBoxTN.Text = wynik.ToString();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (licznik == 1)
            {
                licznik--;
            }
            else
            {
                string nazwa = comboBox3.GetItemText(comboBox3.SelectedItem);
                string czestotliwosc = comboBox6.GetItemText(comboBox6.SelectedItem);
                if (checkBox2.Checked)
                {
                    using (var cnn = new SQLiteConnection(loadConnectionString()))
                    {
                        string query = "SELECT tlumiennosc_db1m FROM Kabel WHERE symbol='" + nazwa + "' AND czestotliwosc_MHz='" + czestotliwosc + "'";
                        if (textBox5.Text == "Antena wbudowana")
                        {
                            textBox2.Text = "0";
                        }
                        else
                        {
                            try
                            {
                                if (textBox5.Text == "")
                                {

                                    textBox2.Text = cnn.ExecuteScalar(query).ToString();
                                }
                                else
                                {
                                    string dl = textBox5.Text;
                                    string tl = cnn.ExecuteScalar(query).ToString();
                                    double wynik = Convert.ToDouble(dl) * Convert.ToDouble(tl);
                                    textBox2.Text = wynik.ToString();
                                }
                            }
                            catch (NullReferenceException ex) { }
                        }
                    }
                }
            }
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            string tlk = textBox11.Text;
            string tlz = textBox10.Text;
            double tlk_l = 0;
            double tlz_l = 0;
            if (textBox11.Text != "")
            {
                tlk_l = Convert.ToDouble(tlk);
            }
            if (textBox10.Text != "")
            {
                tlz_l = Convert.ToDouble(tlz);
            }
            double wynik = tlk_l + tlz_l;
            textBoxTO.Text = wynik.ToString();
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string tlk = textBox11.Text;
            string tlz = textBox10.Text;
            double tlk_l = 0;
            double tlz_l = 0;
            if (textBox11.Text != "")
            {
                tlk_l = Double.Parse(tlk);
            }
            if (textBox10.Text != "")
            {
                tlz_l = Double.Parse(tlz);
            }
            double wynik = tlk_l + tlz_l;
            textBoxTO.Text = wynik.ToString();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string nazwa = comboBox8.GetItemText(comboBox8.SelectedItem);
            string czestotliwosc = comboBox6.GetItemText(comboBox6.SelectedItem);
            if (checkBox2.Checked)
            {
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    string query = "SELECT tlumiennosc_db1m FROM Kabel WHERE symbol='" + nazwa + "' AND czestotliwosc_MHz='" + czestotliwosc + "'";
                    if (textBox6.Text == "")
                    {

                        textBox11.Text = cnn.ExecuteScalar(query).ToString();
                    }
                    else
                    {
                        string dl = textBox6.Text;
                        string tl = cnn.ExecuteScalar(query).ToString();
                        double wynik = Convert.ToDouble(dl) * Convert.ToDouble(tl);
                        textBox11.Text = wynik.ToString();
                    }
                }
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            double f;
            double d;
            string czestotliwosc_txt = comboBox6.GetItemText(comboBox6.SelectedIndex);
            if (ant_wbyd_licz == 1)
            {
                ant_wbyd_licz = 0;
                czestotliwosc_txt = czestotliwosc_global;
            }
            if(czestotliwosc_txt !="" || !IsEmptyTextBox(textBox8)){
                if (czestotliwosc_txt != "" || czestotliwosc_txt != "Wybierz" || czestotliwosc_txt != "Choose")
                {
                    string[] subs = czestotliwosc_txt.Split('.');
                    double czestotliwosc = Double.Parse(subs[0]);
                    f = czestotliwosc;
                }
                else
                {
                    f = 1;
                }
                if (!IsEmptyTextBox(textBox8))
                {
                    d = Convert.ToDouble(textBox8.Text);
                }
                else
                {
                    d = 1;
                }
                double FSL = Math.Round(20 * Math.Log10(d) + 20 * Math.Log10(f) + 32.44, 2);
                textBoxFSL.Text = FSL.ToString();
            }else
            {
                textBoxFSL.Text = "0";
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            string nazwa = comboBox1.GetItemText(comboBox1.SelectedItem);
            string query = "SELECT tlumiennosc_db FROM Material WHERE nazwa= '" + nazwa + "'";
            string query2 = "SELECT grubosc_cm FROM Material WHERE nazwa= '" + nazwa + "'";
            string output = "";
            double tl;
            double grubosc;
            double gruWpisana;
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                output = cnn.ExecuteScalar(query).ToString();
                tl = Convert.ToDouble(output);
                output = cnn.ExecuteScalar(query2).ToString();
                grubosc = Convert.ToDouble(output);
            }
            string text = textBox7.Text;
            if (!IsEmptyTextBox(textBox7) && text != "Grubość automatyczna")
            {
                gruWpisana = Convert.ToDouble(textBox7.Text);
                double x;
                double y;
                if (grubosc == 0)
                {
                    x = tl;
                    y = tl * gruWpisana;
                }
                else
                {
                    x = tl / grubosc;
                    y = x * gruWpisana;

                }

                if (IsEmptyTextBox(textBox4))
                {
                    textBox4.Text = y.ToString();
                }
                else
                {
                    textBox4.Text += "+" + y.ToString();
                }
            }
            else
            {
                textBox7.Text = "Grubość automatyczna";
                if (IsEmptyTextBox(textBox4))
                {
                    textBox4.Text = tl.ToString();
                }
                else
                {
                    textBox4.Text += "+" + tl.ToString();
                }
            }
        }


    }
}
