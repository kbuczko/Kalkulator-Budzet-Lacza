using Dapper;
using ProjektBudzetLacza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Biblioteka
{
    public partial class home : Form
    {
        //LINIA 572
        public int lang;

        List<tl_materialow> lista_mat = new List<tl_materialow>();
        List<parametry_anteny> lista_ant = new List<parametry_anteny>();
        List<kabel> lista_kab = new List<kabel>();
        List<zlacze> lista_zla = new List<zlacze>();
        List<Budzet_lacza> lista_bud = new List<Budzet_lacza>();
        List<Urzadzenie> lista_urz = new List<Urzadzenie>();
        string calkowita = "(int)";
        string tekst = "(string)";
        string ulamek = "(double)";


        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private void clearTextBoxes()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Hide();
                }
            }
        }

        private void clearLabels()
        {
            foreach (var c in this.Controls)
            {
                if (c is Label && ((Label)c) != label2)
                {
                    ((Label)c).Text = "";
                }
            }
        }

        public home()
        {
            InitializeComponent();
            lista_bud = SqliteDataAccess.ListBudzet();
            lista_mat = SqliteDataAccess.listMaterials();
            lista_ant = SqliteDataAccess.ListParameters();
            lista_kab = SqliteDataAccess.ListCables();
            lista_zla = SqliteDataAccess.ListZlacza();
            lista_urz = SqliteDataAccess.ListUrzadzenie();
            

            DataTable dt = ToDataTable(lista_ant);
            dataGridView1.DataSource = dt;
            AddButton.Show();
            if (lang == 1)
            {
                clearTextBoxes();
                clearLabels();
                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                label2.Text = "Choose a table";
                label7.Text = "name" + calkowita;
                label1.Text = "gain_dBi" + calkowita;
                label3.Text = "frequency_MHz" + tekst;
            }
            else
            {
                clearTextBoxes();
                clearLabels();
                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                label7.Text = dataGridView1.Columns[1].HeaderText + tekst;
                label1.Text = dataGridView1.Columns[2].HeaderText + ulamek;
                label3.Text = dataGridView1.Columns[3].HeaderText + calkowita;
            }
            dataGridView1.Columns[0].Visible = false;


        }


        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem.ToString())
            {
               
                case "Urządzenie":
                case "Devices":

                    DataTable dt = ToDataTable(lista_urz);
                    dataGridView1.DataSource = dt;
                    AddButton.Show();
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    textBox4.Show();
                    textBox5.Show();
                    textBox6.Show();
                    dataGridView1.Columns[6].Visible = false;

                    if (lang == 1)
                    {
                        dataGridView1.Columns[1].HeaderText = "name";
                        dataGridView1.Columns[2].HeaderText = "power";
                        dataGridView1.Columns[3].HeaderText = "cable_id";
                        dataGridView1.Columns[4].HeaderText = "connector_id";
                        dataGridView1.Columns[5].HeaderText = "antenna_name";
                       
                        dataGridView1.Columns[7].HeaderText = "sensitivity";
                       

                        label2.Text = "Choose a table";
                        QuitButton.Text = "Quit";
                        AddButton.Text = "Add";
                        DeleteButton.Text = "Delete";

                        label7.Text = dataGridView1.Columns[1].HeaderText + tekst;
                        label1.Text = dataGridView1.Columns[2].HeaderText + calkowita;
                        label3.Text = "connector_name" + tekst;
                        label4.Text = "cable_name" + tekst;
                        label5.Text = "antenna_name" + tekst;
                        label6.Text = "sensitivity" + calkowita;
                    }

                    else
                    {
                        label7.Text = dataGridView1.Columns[1].HeaderText + tekst;
                        label1.Text = dataGridView1.Columns[2].HeaderText + calkowita;
                        label3.Text = "nazwa_zlacza" + tekst;
                        label4.Text = "nazwa_kabla" + tekst;
                        label5.Text = "nazwa_anteny" + tekst;
                        label6.Text = "czulosc" + calkowita;
                    }
                    break;

                case "Budżet łącza":
                case "Link Budget":
                    AddButton.Hide();
                    dataGridView1.Columns[0].Visible = false;
                    DataTable dt1 = ToDataTable(lista_bud);
                    dataGridView1.DataSource = dt1;
                    clearTextBoxes();
                    clearLabels();
                   

                    if (lang == 1)
                    {
                        dataGridView1.Columns[2].HeaderText = "distance_km";
                        dataGridView1.Columns[3].HeaderText = "frequency_MHz";
                        dataGridView1.Columns[4].HeaderText = "value";
                        label2.Text = "Choose a table";
                        QuitButton.Text = "Quit";
                        DeleteButton.Text = "Delete";
                    }

                    
                    break;
                case "Materiały":
                case "Materials":
                    dataGridView1.Columns[0].Visible = false;
                    DataTable dt2 = ToDataTable(lista_mat);
                    dataGridView1.DataSource = dt2;
                    AddButton.Show();
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    textBox4.Show();

                    if (lang == 1)
                    {
                        dataGridView1.Columns[1].HeaderText = "name";
                        dataGridView1.Columns[2].HeaderText = "attenuation_db";
                        dataGridView1.Columns[4].HeaderText = "frequency_MHz";
                        dataGridView1.Columns[3].HeaderText = "thickness_cm";
                        label2.Text = "Choose a table";
                        QuitButton.Text = "Quit";
                        AddButton.Text = "Add";
                        DeleteButton.Text = "Delete";
                        label7.Text = dataGridView1.Columns[1].HeaderText + tekst;
                        label1.Text = dataGridView1.Columns[2].HeaderText + calkowita;
                        label3.Text = dataGridView1.Columns[3].HeaderText + ulamek;
                        label4.Text = dataGridView1.Columns[4].HeaderText + calkowita;
                    }
                    else
                    {
                        label7.Text = dataGridView1.Columns[1].HeaderText + tekst;
                        label1.Text = dataGridView1.Columns[2].HeaderText + calkowita;
                        label3.Text = dataGridView1.Columns[3].HeaderText + ulamek;
                        label4.Text = dataGridView1.Columns[4].HeaderText + calkowita;
                    }
                   
                    break;
                case "Anteny":
                case "Antennas":
                    dataGridView1.Columns[0].Visible = false;
                    DataTable dt3 = ToDataTable(lista_ant);
                    dataGridView1.DataSource = dt3;
                    AddButton.Show();
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    textBox4.Show();

                    if (lang == 1)
                    {
                        dataGridView1.Columns[1].HeaderText = "name";
                        dataGridView1.Columns[2].HeaderText = "gain_dBi";
                        dataGridView1.Columns[3].HeaderText = "frequency_MHz";
                        dataGridView1.Columns[4].HeaderText = "connector_id";

                        label2.Text = "Choose a table";
                        QuitButton.Text = "Quit";
                        AddButton.Text = "Add";
                        DeleteButton.Text = "Delete";
                        label7.Text = dataGridView1.Columns[1].HeaderText + tekst;
                        label1.Text = dataGridView1.Columns[2].HeaderText + ulamek;
                        label3.Text = dataGridView1.Columns[3].HeaderText + calkowita;
                        label4.Text =  "connector_name" + tekst;
                    }
                    else
                    {
                        label7.Text = dataGridView1.Columns[1].HeaderText + tekst;
                        label1.Text = dataGridView1.Columns[2].HeaderText + ulamek;
                        label3.Text = dataGridView1.Columns[3].HeaderText + calkowita;
                        label4.Text =  "nazwa_zlacza" + tekst;
                    }
                    
                    break;
                case "Kable":
                case "Cables":
                    DataTable dt4 = ToDataTable(lista_kab);
                    dataGridView1.DataSource = dt4;
                    dataGridView1.Columns[4].Visible = false;
                    AddButton.Show();
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    textBox4.Show();

                    if (lang == 1)
                    {
                        dataGridView1.Columns[1].HeaderText = "frequency_MHZ";
                        dataGridView1.Columns[2].HeaderText = "name";
                        dataGridView1.Columns[3].HeaderText = "attenuation_db1m";
                        dataGridView1.Columns[5].HeaderText = "connector_name";
                        label2.Text = "Choose a table";
                        QuitButton.Text = "Quit";
                        AddButton.Text = "Add";
                        DeleteButton.Text = "Delete";
                        label7.Text = dataGridView1.Columns[1].HeaderText + calkowita;
                        label1.Text = dataGridView1.Columns[2].HeaderText + tekst;
                        label3.Text = dataGridView1.Columns[3].HeaderText + ulamek;
                        label4.Text = dataGridView1.Columns[5].HeaderText + tekst;
                    }

                    else
                    {
                        label7.Text = dataGridView1.Columns[1].HeaderText + calkowita;
                        label1.Text = dataGridView1.Columns[2].HeaderText + tekst;
                        label3.Text = dataGridView1.Columns[3].HeaderText + ulamek;
                        label4.Text = dataGridView1.Columns[5].HeaderText + tekst;
                    }
                    
                    break;
                case "Złącza":
                case "Connectors":
                    dataGridView1.Columns[0].Visible = false;
                    DataTable dt5 = ToDataTable(lista_zla);
                    AddButton.Show();
                    dataGridView1.DataSource = dt5;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();

                    if (lang == 1)
                    {
                        dataGridView1.Columns[1].HeaderText = "name";
                        dataGridView1.Columns[2].HeaderText = "attenuation_db";
                        dataGridView1.Columns[3].HeaderText = "frequency_MHz";
                        label2.Text = "Choose a table";
                        QuitButton.Text = "Quit";
                        AddButton.Text = "Add";
                        DeleteButton.Text = "Delete";
                        label7.Text = dataGridView1.Columns[1].HeaderText + tekst;
                        label1.Text = dataGridView1.Columns[2].HeaderText + ulamek;
                        label3.Text = dataGridView1.Columns[3].HeaderText + calkowita;
                    }

                    else
                    {
                        label7.Text = dataGridView1.Columns[1].HeaderText + tekst;
                        label1.Text = dataGridView1.Columns[2].HeaderText + ulamek;
                        label3.Text = dataGridView1.Columns[3].HeaderText + calkowita;
                    }
                    break;

            }
        }
        private static string loadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dodano = "Dodano do bazy";
            string added = "Added to database";
            string blad = "Wprowadzono błędne dane";
            string error = "Wrong data inserted";
            
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Urządzenie":
                case "Devices":

                    string value1 = textBox3.Text;
                    string value2 = textBox4.Text;
                    string value3 = textBox5.Text;

                    string query1 = "SELECT Zlacze.id FROM  Zlacze WHERE Zlacze.symbol = '" + value1 + "'";
                    string query2 = "SELECT Kabel.id FROM  Kabel WHERE Kabel.symbol = '" + value2 + "'";
                    string query3 = "SELECT Antena.id FROM  Antena WHERE Antena.nazwa = '" + value3 + "'";
                    int id_kab = 0, id_zlacz =0, id_ant = 0;
                    using (var cnn = new SQLiteConnection(loadConnectionString()))
                    {
                        var a = cnn.ExecuteScalar<int>(query1);
                        id_kab = a;
                    }
                    using (var cnn = new SQLiteConnection(loadConnectionString()))
                    {
                        var b = cnn.ExecuteScalar<int>(query2);
                        id_zlacz = b;
                    }
                    using (var cnn = new SQLiteConnection(loadConnectionString()))
                    {
                        var c = cnn.ExecuteScalar<int>(query3);
                        id_ant = c;
                    }
                    if (id_kab != 0 && id_zlacz != 0 && id_ant != 0)
                    {
                        try
                        {
                            Urzadzenie urz = new Urzadzenie
                            {
                                nazwa = textBox1.Text,
                                moc = Convert.ToInt32(textBox2.Text),
                                id_kabla = id_kab,
                                id_zlacza = id_zlacz,
                                id_anteny = id_ant,
                                czulosc = Convert.ToDouble(textBox6.Text)

                            };

                            SqliteDataAccess.saveDevices(urz);
                            if (lang == 1)
                            {
                                label8.ForeColor = Color.Green; label8.Text = added; label8.Show();
                            }
                            else
                            {
                                label8.ForeColor = Color.Green; label8.Text = dodano; label8.Show();
                            }
                            lista_urz = SqliteDataAccess.ListUrzadzenie();
                                dataGridView1.DataSource = lista_urz;
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                                textBox6.Text = "";


                        }
                        catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException) { 
                            if(lang == 1)
                            {
                                label8.ForeColor = Color.Red; label8.Text = error; label8.Show();
                            }
                            else
                            {
                                label8.ForeColor = Color.Red; label8.Text = blad; label8.Show();
                            }
                           
                        }
                    }
                    else
                    {
                        label8.ForeColor = Color.Red; label8.Text = "Złe dane."; label8.Show();
                    }
                    break;
                case "Materiały":
                case "Materials":

                    try
                    {
                        tl_materialow mat = new tl_materialow
                        {
                            nazwa = textBox1.Text,
                            tlumiennosc_db = Convert.ToDouble(textBox2.Text),
                            grubosc_cm = Convert.ToDouble(textBox3.Text),
                            czestotliwosc_MHz = Convert.ToDouble(textBox4.Text)
                        };
                        SqliteDataAccess.saveMaterials(mat);
                        if (lang == 1)
                        {
                            label8.ForeColor = Color.Green; label8.Text = added; label8.Show();
                        }
                        else
                        {
                            label8.ForeColor = Color.Green; label8.Text = dodano; label8.Show();
                        }
                        lista_mat = SqliteDataAccess.listMaterials();
                        dataGridView1.DataSource = lista_mat;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException)
                    {
                        if (lang == 1)
                        {
                            label8.ForeColor = Color.Red; label8.Text = error; label8.Show();
                        }
                        else
                        {
                            label8.ForeColor = Color.Red; label8.Text = blad; label8.Show();
                        }
                    }
                        break;
                case "Anteny":
                case "Antennas":
                    string zlacze_id = textBox4.Text;

                    string query_zlacze = "SELECT Zlacze.id FROM  Zlacze WHERE Zlacze.symbol = '" + zlacze_id + "'";
                    int id_zlacza = 0;
                    using (var cnn = new SQLiteConnection(loadConnectionString()))
                    {
                        var a = cnn.ExecuteScalar<int>(query_zlacze);
                        id_zlacza = a;
                    }

                    if (id_zlacza != 0)
                    {
                        try
                        {
                            parametry_anteny par = new parametry_anteny
                            {
                                zysk_dBi = Convert.ToDouble(textBox2.Text),
                                nazwa = textBox1.Text,
                                czestotliwosc_MHz = Convert.ToInt32(textBox3.Text),
                                id_zlacza = id_zlacza
                            };
                            SqliteDataAccess.saveParameters(par);
                            if (lang == 1)
                            {
                                label8.ForeColor = Color.Green; label8.Text = added; label8.Show();
                            }
                            else
                            {
                                label8.ForeColor = Color.Green; label8.Text = dodano; label8.Show();
                            }
                            lista_ant = SqliteDataAccess.ListParameters();
                            dataGridView1.DataSource = lista_ant;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                        }
                        catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException) {
                            if (lang == 1)
                            {
                                label8.ForeColor = Color.Red; label8.Text = error; label8.Show();
                            }
                            else
                            {
                                label8.ForeColor = Color.Red; label8.Text = blad; label8.Show();
                            }
                        }
                    }
                    else
                    {
                        if (lang == 1)
                        {
                            label8.ForeColor = Color.Red; label8.Text = "Connector not found"; label8.Show();
                        }
                        else
                        {
                            label8.ForeColor = Color.Red; label8.Text = "Nie znaleziono takiego zlacza"; label8.Show();
                        }
                    }
                    
                    break;
                case "Kable":
                case "Cables":

                    string symbol = textBox4.Text;
                    
                    string query_zlaczee = "SELECT id FROM zlacze WHERE symbol = '" + symbol + "'";

                    int id = 0;

                    using (var cnn = new SQLiteConnection(loadConnectionString()))
                    {
                        var a = cnn.ExecuteScalar<int>(query_zlaczee);
                        
                        id = a;
                    }
                    if (id != 0)
                    {
                        var lines_cables = File.ReadAllLines(@"..\..\..\Biblioteka\available\available_cables.txt");
                        if (lines_cables.Contains(textBox2.Text))
                        {
                            //MessageBox.Show("1");
                            try
                            {
                                kabel kab = new kabel
                                {
                                    czestotliwosc_MHz = Convert.ToInt32(textBox1.Text),
                                    symbol = textBox2.Text,
                                    tlumiennosc_db1m = Convert.ToDouble(textBox3.Text),
                                    id_zlacza = id
                                };

                                SqliteDataAccess.saveCables(kab);
                                if (lang == 1)
                                {
                                    label8.ForeColor = Color.Green; label8.Text = added; label8.Show();
                                }
                                else
                                {
                                    label8.ForeColor = Color.Green; label8.Text = dodano; label8.Show();
                                }
                                lista_kab = SqliteDataAccess.ListCables();
                                dataGridView1.DataSource = lista_kab;

                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                            }
                            catch (Exception ex) {
                                if (lang == 1)
                                {
                                    label8.ForeColor = Color.Red; label8.Text = error; label8.Show();
                                }
                                else
                                {
                                    label8.ForeColor = Color.Red; label8.Text = blad; label8.Show();
                                }
                            }
                        }
                        else
                        {
                            if (lang == 1)
                            {
                                label8.ForeColor = Color.Red; label8.Text = error; label8.Show();
                            }
                            else
                            {
                                label8.ForeColor = Color.Red; label8.Text = blad; label8.Show();
                            }
                        }
                       
                    }
                    else
                    {
                        if (lang == 1)
                        {
                            label8.ForeColor = Color.Red; label8.Text = error; label8.Show();
                        }
                        else
                        {
                            label8.ForeColor = Color.Red; label8.Text = blad; label8.Show();
                        }
                    }
                    
                    
                    break;
                case "Złącza":
                case "Connectors":

                    var lines = File.ReadAllLines(@"..\..\..\Biblioteka\available\available_connectors.txt");

                    if (lines.Contains(textBox1.Text))
                    {
                        try
                        {
                            zlacze zl = new zlacze
                            {
                                symbol = textBox1.Text,
                                tlumiennosc_db = Convert.ToDouble(textBox2.Text),
                                czestotliwosc_MHz = Convert.ToInt32(textBox3.Text)
                            };
                            SqliteDataAccess.saveZlacza(zl);
                            if (lang == 1)
                            {
                                label8.ForeColor = Color.Green; label8.Text = added; label8.Show();
                            }
                            else
                            {
                                label8.ForeColor = Color.Green; label8.Text = dodano; label8.Show();
                            }
                           
                            lista_zla = SqliteDataAccess.ListZlacza();
                            dataGridView1.DataSource = lista_zla;

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                        }
                        catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException) {
                            if (lang == 1)
                            {
                                label8.ForeColor = Color.Red; label8.Text = error; label8.Show();
                            }
                            else
                            {
                                label8.ForeColor = Color.Red; label8.Text = blad; label8.Show();
                            }
                        }
                    }
                    else
                    {
                        if (lang == 1)
                        {
                            label8.ForeColor = Color.Red; label8.Text = error; label8.Show();
                        }
                        else
                        {
                            label8.ForeColor = Color.Red; label8.Text = blad; label8.Show();
                        }
                    }              
                    break;
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string usunieto = "Usunięto z bazy";
            string deleted = "Deleted from database";

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            int id = 0;
            
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Urządzenie":
                case "Devices":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM urzadzenie WHERE id= '" + id + "'");

                    }
                    catch
                    {
                        if(lang == 1)
                        {
                            label8.ForeColor = Color.Green; label8.Text = deleted; label8.Show(); lista_urz = SqliteDataAccess.ListUrzadzenie();
                            dataGridView1.DataSource = lista_urz;
                        }
                        else
                        {
                            label8.ForeColor = Color.Green; label8.Text = usunieto; label8.Show(); lista_urz = SqliteDataAccess.ListUrzadzenie();
                            dataGridView1.DataSource = lista_urz;
                        }
                        
                    }
                    break;
                case "Materiały":
                case "Materials":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM material WHERE id= '" + id + "'");
                        
                    }
                    catch
                    {
                        if (lang == 1)
                        {
                            label8.ForeColor = Color.Green; label8.Text = deleted; label8.Show(); lista_mat = SqliteDataAccess.listMaterials();
                            dataGridView1.DataSource = lista_mat;
                        }
                        else
                        {
                            label8.ForeColor = Color.Green; label8.Text = usunieto; label8.Show(); lista_mat = SqliteDataAccess.listMaterials();
                            dataGridView1.DataSource = lista_mat;
                        }
                    }
                    break;
                case "Złącza":
                case "Connectors":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM zlacze WHERE id= '" + id + "'");
                        
                    }
                    catch
                    {
                        if (lang == 1)
                        {
                            label8.ForeColor = Color.Green; label8.Text = deleted; label8.Show(); lista_zla = SqliteDataAccess.ListZlacza();
                            dataGridView1.DataSource = lista_zla;
                        }
                        else
                        {
                            label8.ForeColor = Color.Green; label8.Text = usunieto; label8.Show(); lista_zla = SqliteDataAccess.ListZlacza();
                            dataGridView1.DataSource = lista_zla;
                        }
                    }
                    
                    break;
                case "Kable":
                case "Cables":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM kabel WHERE id= '" + id + "'");
                        
                    }
                    catch
                    {
                        if (lang == 1)
                        {
                            label8.ForeColor = Color.Green; label8.Text = deleted; label8.Show(); lista_kab = SqliteDataAccess.ListCables();
                            dataGridView1.DataSource = lista_kab;
                        }
                        else
                        {
                            label8.ForeColor = Color.Green; label8.Text = usunieto; label8.Show(); lista_kab = SqliteDataAccess.ListCables();
                            dataGridView1.DataSource = lista_kab;
                        }
                    }
                    break;
                case "Anteny":
                case "Antennas":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM antena WHERE id= '" + id + "'");
                        
                    }
                    catch
                    {
                        if (lang == 1)
                        {
                            label8.ForeColor = Color.Green; label8.Text = deleted; label8.Show(); lista_ant = SqliteDataAccess.ListParameters();
                            dataGridView1.DataSource = lista_ant;
                        }
                        else
                        {
                            label8.ForeColor = Color.Green; label8.Text = usunieto; label8.Show(); lista_ant = SqliteDataAccess.ListParameters();
                            dataGridView1.DataSource = lista_ant;
                        }
                    }
                    break;
                case "Budżet łącza":
                case "Link Budget":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM Budzet_lacza WHERE id= '" + id + "'");
                        
                    }
                    catch
                    {
                        if (lang == 1)
                        {
                            label8.ForeColor = Color.Green; label8.Text = deleted; label8.Show(); lista_bud = SqliteDataAccess.ListBudzet();
                            dataGridView1.DataSource = lista_bud;
                        }
                        else
                        {
                            label8.ForeColor = Color.Green; label8.Text = usunieto; label8.Show(); lista_bud = SqliteDataAccess.ListBudzet();
                            dataGridView1.DataSource = lista_bud;
                        }
                    }
                    break;
            }

            

        }

    }
    }
