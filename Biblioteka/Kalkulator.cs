using Dapper;
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
        int licznik2 = 0;
        //nadajnik
        List<parametry_anteny> lista_ant = new List<parametry_anteny>();
        List<kabel> lista_kab = new List<kabel>();
        List<zlacze> lista_zla = new List<zlacze>();
        //odbiornik
        List<parametry_anteny> lista_ant2 = new List<parametry_anteny>();
        List<kabel> lista_kab2 = new List<kabel>();
        List<zlacze> lista_zla2 = new List<zlacze>();

        List<tl_materialow> lista_mat = new List<tl_materialow>();
        List<Budzet_lacza> lista_bud = new List<Budzet_lacza>();
        List<Urzadzenie> lista_urz = new List<Urzadzenie>();
        ResourceManager res_man;
        CultureInfo cul;
        private int licznik3;
        private int licznik4;
        private int licznik5;
        private int licznik6;

        public Kalkulator()
        {
            InitializeComponent();

            //nadajnik
            lista_ant = SqliteDataAccess.ListParameters();
            lista_kab = SqliteDataAccess.ListCables();
            lista_zla = SqliteDataAccess.ListZlacza();
            //odbiornik
            lista_ant2 = SqliteDataAccess.ListParameters();
            lista_kab2 = SqliteDataAccess.ListCables();
            lista_zla2 = SqliteDataAccess.ListZlacza();

            lista_bud = SqliteDataAccess.ListBudzet();
            lista_mat = SqliteDataAccess.listMaterials();
            lista_urz = SqliteDataAccess.ListUrzadzenie();
            Load_list();
            //WzorBox.Hide();
            textBox4.Hide();
            textBox7.Hide();
            comboBox1.Hide();
            label24.Hide();
            label25.Hide();
            addButton.Hide();
            if(lang == 1)
            {
                WzorBox.Text = "TRANSMITTER POWER + TRANSMITTER GAIN - TRANSMITTER ATTENUATION - FSL + RECEIVER GAIN - RECEIVER ATTENUATION";
            }
            else { WzorBox.Text = "MOC NADAJNIKA + ZYSK NADAJNIKA - TŁUMIENNOŚĆ NADAJNIKA - FSL + ZYSK ODBIORNIKA - TŁUMIENNOŚĆ ODBIRONIKA"; }
           
        }
        //load
        private void Load_list() //ładowanie wszystkich zmiennych
        {
            
            //nadajnik
            comboBox2.DataSource = lista_ant;
            comboBox2.DisplayMember = "nazwa";
            comboBox3.DataSource = lista_kab;
            comboBox3.DisplayMember = "symbol";
            comboBox4.DataSource = lista_zla;
            comboBox4.DisplayMember = "symbol";
            //odbiornik
            comboBox7.DataSource = lista_ant2;
            comboBox7.DisplayMember = "nazwa";
            comboBox8.DataSource = lista_kab2;
            comboBox8.DisplayMember = "symbol";
            comboBox9.DataSource = lista_zla2;
            comboBox9.DisplayMember = "symbol";
            /*comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox4.ResetText();
            comboBox7.ResetText();
            comboBox8.ResetText();
            comboBox9.ResetText();*/
        }
        //load nadajnik
        private void Load_antena() //ładowanie combobox antena na podstawie czestotliwosci
        {
            string query5 = "SELECT nazwa FROM Antena WHERE czestotliwosc_MHz='" + textBox9.Text + "'";
            List<parametry_anteny> output6 = new List<parametry_anteny>();
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output5 = cnn.Query<parametry_anteny>(query5);
                output6 = output5.ToList();
                comboBox2.DataSource = output6;
                comboBox2.DisplayMember = "nazwa";
            }
        }
        private void Load_antena2() //ładowanie combobox antena na podstawie czestotliwosci
        {
            string query5 = "SELECT nazwa FROM Antena WHERE czestotliwosc_MHz='" + textBox9.Text + "'";
            List<parametry_anteny> output6 = new List<parametry_anteny>();
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output5 = cnn.Query<parametry_anteny>(query5);
                output6 = output5.ToList();
                comboBox7.DataSource = output6;
                comboBox7.DisplayMember = "nazwa";
            }
        }
        private void Load_material()
        {
            string query = "SELECT nazwa FROM Material WHERE czestotliwosc_MHz='" + textBox9.Text + "'";
            List<tl_materialow> output2 = new List<tl_materialow>();
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output3 = cnn.Query<tl_materialow>(query);
                output2 = output3.ToList();
                comboBox1.DataSource = output2;
                comboBox1.DisplayMember = "nazwa";
            }
        }
        private void Load_kabel() //ładowanie combobox kabel na podstawie czestotliwosc
        {
            string query2 = "SELECT symbol FROM Kabel WHERE czestotliwosc_MHz='" + textBox9.Text + "'";
            List<kabel> output2 = new List<kabel>();
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output3 = cnn.Query<kabel>(query2);
                output2 = output3.ToList();
                comboBox3.DataSource = output2;
                comboBox3.DisplayMember = "symbol";
            }
        }
        private void Load_kabel2() //ładowanie combobox kabel na podstawie czestotliwosc
        {
            string query2 = "SELECT symbol FROM Kabel WHERE czestotliwosc_MHz='" + textBox9.Text + "'";
            List<kabel> output2 = new List<kabel>();
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output3 = cnn.Query<kabel>(query2);
                output2 = output3.ToList();
                comboBox8.DataSource = output2;
                comboBox8.DisplayMember = "symbol";
            }
        }
        private void Load_kabel(string nazwa) 
        {
            string query3 = "SELECT nazwa_kabla FROM Urzadzenie JOIN Antena ON Urzadzenie.id_anteny=Antena.id WHERE Antena.nazwa= '" + nazwa + "'";
            List<Urzadzenie> output2 = new List<Urzadzenie>();
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output3 = cnn.Query<Urzadzenie>(query3);
                output2 = output3.ToList();
                comboBox3.DataSource = output2;
                comboBox3.DisplayMember = "nazwa_kabla";
            }
        }
        private void Load_kabel2(string nazwa)
        {
            string query3 = "SELECT nazwa_kabla FROM Urzadzenie JOIN Antena ON Urzadzenie.id_anteny=Antena.id WHERE Antena.nazwa= '" + nazwa + "'";
            List<Urzadzenie> output2 = new List<Urzadzenie>();
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output3 = cnn.Query<Urzadzenie>(query3);
                output2 = output3.ToList();
                comboBox8.DataSource = output2;
                comboBox8.DisplayMember = "nazwa_kabla";
            }
        }
        private void Load_zlacze() // ladowanie combobox zlacze na podstawie wybranego kabla
        {
                string symbol = comboBox3.GetItemText(comboBox3.SelectedItem);
                string query2 = "SELECT Zlacze.symbol FROM Zlacze JOIN Kabel ON Zlacze.id_kab=Kabel.id WHERE Kabel.symbol= '" + symbol + "'";
                List<zlacze> output2 = new List<zlacze>();
            if (symbol != "")
            {
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    var output3 = cnn.Query<zlacze>(query2);
                    output2 = output3.ToList();
                    comboBox4.DataSource = output2;
                    comboBox4.DisplayMember = "symbol";
                }
            }
        }
        private void Load_zlacze2() // ladowanie combobox zlacze na podstawie wybranego kabla
        {
            string symbol = comboBox3.GetItemText(comboBox3.SelectedItem);
            string query2 = "SELECT Zlacze.symbol FROM Zlacze JOIN Kabel ON Zlacze.id_kab=Kabel.id WHERE Kabel.symbol= '" + symbol + "'";
            List<zlacze> output2 = new List<zlacze>();
            if (symbol != "")
            {
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    var output3 = cnn.Query<zlacze>(query2);
                    output2 = output3.ToList();
                    comboBox9.DataSource = output2;
                    comboBox9.DisplayMember = "symbol";
                }
            }
        }
        private void Load_zlacze(string nazwa) 
        {
            string query4 = "SELECT nazwa_zlacza FROM Urzadzenie JOIN Antena ON Urzadzenie.id_anteny=Antena.id WHERE Antena.nazwa= '" + nazwa + "'";
            List<Urzadzenie> output2 = new List<Urzadzenie>();
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output3 = cnn.Query<Urzadzenie>(query4);
                output2 = output3.ToList();
                comboBox4.DataSource = output2;
                comboBox4.DisplayMember = "nazwa_zlacza";
            }
        }
        private void Load_zlacze2(string nazwa)
        {
            string query4 = "SELECT nazwa_zlacza FROM Urzadzenie JOIN Antena ON Urzadzenie.id_anteny=Antena.id WHERE Antena.nazwa= '" + nazwa + "'";
            List<Urzadzenie> output2 = new List<Urzadzenie>();
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output3 = cnn.Query<Urzadzenie>(query4);
                output2 = output3.ToList();
                comboBox9.DataSource = output2;
                comboBox9.DisplayMember = "nazwa_zlacza";
            }
        }

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
                FSL = Math.Round(Convert.ToDouble(textBoxFSL.Text));
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
                double BL = MOC + ZN - TN - FSL + ZO - TO - MAT;
                Budzet_lacza budzet = new Budzet_lacza
                {
                    fsl_db = FSL,
                    odleglosc_km = Convert.ToDouble(textBox8.Text),
                    czestotliwosc_MHz = Convert.ToInt32(textBox9.Text),
                    wartosc = BL
                };
                SqliteDataAccess.saveBudget(budzet);
                textBox1.Text = MOC.ToString() + " + " + ZN.ToString() + " - " + TN.ToString() + " - " + FSL.ToString() + " + " + ZO.ToString() + " - " + TO.ToString() + " - " + MAT.ToString() + " = " + BL.ToString();
            }
            else
            {
                double BL = MOC + ZN - TN - FSL + ZO - TO;
                Budzet_lacza budzet = new Budzet_lacza
                {
                    fsl_db = FSL,
                    odleglosc_km = Convert.ToDouble(textBox8.Text),
                    czestotliwosc_MHz = Convert.ToInt32(textBox9.Text),
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
        }
        //chackeBox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if(lang == 1)
                {
                    WzorBox.Text = "TRANSMITTER POWER + TRANSMITTER GAIN - TRANSMITTER ATTENUATION - FSL + RECEIVER GAIN - RECEIVER ATTENUATION - OBSTACLES ATTENUATION";
                }
                else
                {
                    WzorBox.Text = "MOC NADAJNIKA + ZYSK NADAJNIKA - TŁUMIENNOŚĆ NADAJNIKA - FSL + ZYSK ODBIORNIKA - TŁUMIENNOŚĆ ODBIRONIKA - TŁUMIENNOŚĆ PRZESZKÓD";
                }
               
                textBox4.Show();
                label9.Show();
                label24.Show();
                label25.Show();
                textBox7.Show();
                comboBox1.Show();
                addButton.Show();
                Load_material();
            }
            else
            {
                if (lang == 1)
                {
                    WzorBox.Text = "TRANSMITTER POWER + TRANSMITTER GAIN - TRANSMITTER ATTENUATION - FSL + RECEIVER GAIN - RECEIVER ATTENUATION";
                }
                else
                {
                    WzorBox.Text = "MOC NADAJNIKA + ZYSK NADAJNIKA - TŁUMIENNOŚĆ NADAJNIKA - FSL + ZYSK ODBIORNIKA - TŁUMIENNOŚĆ ODBIRONIKA";
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
        private static string loadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //combobox nadajnik
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //combobox rodzaj anteny nadajnik
        {
            if (licznik == 0)
            {
                licznik++;
            }
            else
            {
                
                    string nazwa = comboBox2.GetItemText(comboBox2.SelectedItem);
                    string query = "SELECT zysk_dBi FROM Antena WHERE nazwa= '" + nazwa + "'";
                    string query2 = "SELECT moc FROM Urzadzenie JOIN Antena ON Urzadzenie.id_anteny=Antena.id WHERE Antena.nazwa= '" + nazwa + "'";


                    string output = "";
                    using (var cnn = new SQLiteConnection(loadConnectionString()))
                    {
                        Console.WriteLine(nazwa);
                        try
                        {
                            output = cnn.ExecuteScalar(query2).ToString();
                            textBoxMOC.Text = output;
                        }
                        catch (NullReferenceException ex)
                        {
                            output = "";
                            textBoxMOC.Text = output;
                            Console.WriteLine(ex);
                        }
                        Console.WriteLine(nazwa);
                        try
                        {
                            Load_kabel(nazwa);
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine(ex);
                        }
                        try
                        {
                            Load_zlacze(nazwa);
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine(ex);
                        }
                    try
                    {
                        output = cnn.ExecuteScalar(query).ToString();
                        textBoxZN.Text = output;
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex);
                    }

                    Console.WriteLine(textBoxZO.Text);
                    }
                if (IsEmptyTextBox(textBox9))
                {
                    Load_list();
                }
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) //combobox rodzaj kabla nadajnik
        {
            if(licznik3 == 0)
            {
                licznik3++;
            }
            else
            {

                    string nazwa = comboBox3.GetItemText(comboBox3.SelectedItem);
                    string czestotliwosc = textBox9.Text;
                    string dl_kabla = textBox5.Text;
                    string query = "SELECT tlumiennosc_db1m FROM Kabel WHERE symbol='" + nazwa + "' AND czestotliwosc_MHz = '" + czestotliwosc + "'";
                    string output = "";
                    using (var cnn = new SQLiteConnection(loadConnectionString()))
                    {
                        try
                        {
                            output = cnn.ExecuteScalar(query).ToString();
                            double x = Convert.ToDouble(output);
                            double y;
                            if (dl_kabla == "")
                            {
                                y = 1;
                            }
                            else
                            {
                                y = Convert.ToDouble(dl_kabla);
                            }
                            double opd = x * y;
                            textBox2.Text = opd.ToString();
                        }
                        catch (NullReferenceException ex)
                        {
                            output = "";
                            Console.WriteLine(ex);
                            textBox2.Text = output;
                        }

                    }
               
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) //combobx rodzaj zlacze nadajnik
        {
            if (licznik4 == 0)
            {
                licznik4++;
            }
            else
            {

                    string symbol = comboBox4.GetItemText(comboBox4.SelectedItem);
                    string query = "SELECT tlumiennosc_db FROM Zlacze WHERE symbol='" + symbol + "'";
                    string output = "";
                    using (var cnn = new SQLiteConnection(loadConnectionString()))
                    {
                        try
                        {
                            output = cnn.ExecuteScalar(query).ToString();
                            textBox3.Text = output;
                        }
                        catch (NullReferenceException ex)
                        {
                            output = "";
                            Console.WriteLine(ex);
                        }

                    }

            }
        }

        //combobox odbiornik

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (licznik2 == 0)
            {
                licznik2++;
            }
            else
            {

                string nazwa = comboBox7.GetItemText(comboBox7.SelectedItem);
                string query = "SELECT zysk_dBi FROM Antena WHERE nazwa= '" + nazwa + "'";
                string output = "";
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    Console.WriteLine(nazwa);
                    output = cnn.ExecuteScalar(query).ToString();
                    textBoxZO.Text = output;
                    Console.WriteLine(textBoxZO.Text);
                }
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    Console.WriteLine(nazwa);
                    try
                    {
                        Load_kabel2(nazwa);
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex);
                    }
                    try
                    {
                        Load_zlacze2(nazwa);
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex);
                    }
                    try
                    {
                        output = cnn.ExecuteScalar(query).ToString();
                        textBoxZO.Text = output;
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex);
                    }

                    Console.WriteLine(textBoxZO.Text);
                }
            }
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (licznik6 == 0)
            {
                licznik6++;
            }
            else
            {

                string nazwa = comboBox8.GetItemText(comboBox8.SelectedItem);
                string czestotliwosc = textBox9.Text;
                string dl_kabla = textBox6.Text;
                string query = "SELECT tlumiennosc_db1m FROM Kabel WHERE symbol='" + nazwa + "' AND czestotliwosc_MHz = '" + czestotliwosc + "'";
                string output = "";
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    try
                    {
                        output = cnn.ExecuteScalar(query).ToString();
                        double x = Convert.ToDouble(output);
                        double y;
                        if (dl_kabla == "")
                        {
                            y = 1;
                        }
                        else
                        {
                            y = Convert.ToDouble(dl_kabla);
                        }
                        double opd = x * y;
                        textBox11.Text = opd.ToString();
                    }
                    catch (NullReferenceException ex)
                    {
                        output = "";
                        Console.WriteLine(ex);
                        textBox11.Text = output;
                    }

                }

            }
        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (licznik5 == 0)
            {
                licznik5++;
            }
            else
            {

                string symbol = comboBox9.GetItemText(comboBox9.SelectedItem);
                string query = "SELECT tlumiennosc_db FROM Zlacze WHERE symbol='" + symbol + "'";
                string output = "";
                using (var cnn = new SQLiteConnection(loadConnectionString()))
                {
                    try
                    {
                        output = cnn.ExecuteScalar(query).ToString();
                        textBox10.Text = output;
                    }
                    catch (NullReferenceException ex)
                    {
                        output = "";
                        Console.WriteLine(ex);
                    }

                }

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

        //zmiana czestotliwosci

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (IsEmptyTextBox(textBox9))
            {
                comboBox2.ResetText();
                comboBox3.ResetText();
                comboBox4.ResetText();
                comboBox7.ResetText();
                comboBox8.ResetText();
                comboBox9.ResetText();
                comboBox1.ResetText();
                textBox7.Clear();

                    Load_list();
            }
            else
            {
                comboBox2.ResetText();
                comboBox3.ResetText();
                comboBox4.ResetText();
                comboBox7.ResetText();
                comboBox8.ResetText();
                comboBox9.ResetText();
                comboBox1.ResetText();
                textBox7.Clear();
                Load_antena();
                Load_kabel();
                Load_zlacze();
                Load_antena2();
                Load_kabel2();
                Load_zlacze2();
                Load_material();
            }
            double f;
            double d;
            if (!IsEmptyTextBox(textBox9))
            {
                f = Convert.ToDouble(textBox9.Text);
            }
            else
            {
                f = 0;
            }
            if (!IsEmptyTextBox(textBox8))
            {
                d = Convert.ToDouble(textBox8.Text);
            }
            else
            {
                d = 0;
            }
            double FSL = Math.Round(20 * Math.Log10(d) + 20 * Math.Log10(f) + 32.44, 3, MidpointRounding.ToEven);
            textBoxFSL.Text = FSL.ToString();

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double tk;
            double tz;
            if (!IsEmptyTextBox(textBox2))
            {
                tk = Convert.ToDouble(textBox2.Text);
            }
            else
            {
                tk = 0;
            }
            
            if (!IsEmptyTextBox(textBox3))
            {
                tz = Convert.ToDouble(textBox3.Text);
            }
            else
            {
                tz = 0;
            }
            double TN = tk + tz;
            textBoxTN.Text = TN.ToString();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double tk;
            double tz;
            if (!IsEmptyTextBox(textBox2))
            {
                tk = Convert.ToDouble(textBox2.Text);
            }
            else
            {
                tk = 0;
            }

            if (!IsEmptyTextBox(textBox3))
            {
                tz = Convert.ToDouble(textBox3.Text);
            }
            else
            {
                tz = 0;
            }
            double TN = tk + tz;
            textBoxTN.Text = TN.ToString();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string nazwa = comboBox3.GetItemText(comboBox3.SelectedItem);
            string czestotliwosc = textBox9.Text;
            string dl_kabla = textBox5.Text;
            string query = "SELECT tlumiennosc_db1m FROM Kabel WHERE symbol='" + nazwa + "' AND czestotliwosc_MHz = '" + czestotliwosc + "'";
            string output = "";
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                try
                {
                    output = cnn.ExecuteScalar(query).ToString();
                    double x = Convert.ToDouble(output);
                    double y;
                    if (dl_kabla == "")
                    {
                        y = 1;
                    }
                    else
                    {
                        y = Convert.ToDouble(dl_kabla);
                    }
                    double opd = x * y;
                    textBox2.Text = opd.ToString();
                }
                catch (NullReferenceException ex)
                {
                    output = "";
                    Console.WriteLine(ex);
                    textBox2.Text = output;
                }

            }

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            double tk;
            double tz;
            if (!IsEmptyTextBox(textBox2))
            {
                tk = Convert.ToDouble(textBox2.Text);
            }
            else
            {
                tk = 0;
            }

            if (!IsEmptyTextBox(textBox3))
            {
                tz = Convert.ToDouble(textBox3.Text);
            }
            else
            {
                tz = 0;
            }
            double TN = tk + tz;
            textBoxTO.Text = TN.ToString();
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            double tk;
            double tz;
            if (!IsEmptyTextBox(textBox2))
            {
                tk = Convert.ToDouble(textBox2.Text);
            }
            else
            {
                tk = 0;
            }

            if (!IsEmptyTextBox(textBox3))
            {
                tz = Convert.ToDouble(textBox3.Text);
            }
            else
            {
                tz = 0;
            }
            double TN = tk + tz;
            textBoxTO.Text = TN.ToString();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string nazwa = comboBox8.GetItemText(comboBox8.SelectedItem);
            string czestotliwosc = textBox9.Text;
            string dl_kabla = textBox6.Text;
            string query = "SELECT tlumiennosc_db1m FROM Kabel WHERE symbol='" + nazwa + "' AND czestotliwosc_MHz = '" + czestotliwosc + "'";
            string output = "";
            using (var cnn = new SQLiteConnection(loadConnectionString()))
            {
                try
                {
                    output = cnn.ExecuteScalar(query).ToString();
                    double x = Convert.ToDouble(output);
                    double y;
                    if (dl_kabla == "")
                    {
                        y = 1;
                    }
                    else
                    {
                        y = Convert.ToDouble(dl_kabla);
                    }
                    double opd = x * y;
                    textBox11.Text = opd.ToString();
                }
                catch (NullReferenceException ex)
                {
                    output = "";
                    Console.WriteLine(ex);
                    textBox2.Text = output;
                }

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            double f;
            double d;
            if (!IsEmptyTextBox(textBox9))
            {
                f = Convert.ToDouble(textBox9.Text);
            }
            else
            {
                f = 0;
            }
            if (!IsEmptyTextBox(textBox8))
            {
                d = Convert.ToDouble(textBox8.Text);
            }
            else
            {
                d = 0;
            }
            double FSL = 20 * Math.Log10(d) + 20 * Math.Log10(f) + 32.44;
            textBoxFSL.Text = FSL.ToString();
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string nazwa = comboBox1.GetItemText(comboBox1.SelectedItem);
            string query = "SELECT tlumiennosc FROM Material WHERE nazwa= '" + nazwa + "'";
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
                double x = tl / grubosc;
                double y = x * gruWpisana;

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
