using Dapper;
using ProjektBudzetLacza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// DODAC ODSWIEZANIE PO USUNIECIU DANYCH
// DODAC ID KABLI I ZLACZ DO URZADZENIA
namespace Biblioteka
{
    public partial class home : Form
    {
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

            
            dataGridView1.DataSource = lista_ant;
            if(lang == 1)
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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
            SortOrder strSortOrder = getSortOrder(e.ColumnIndex);

            if (strSortOrder == SortOrder.Ascending)
            {
                lista_zla = lista_zla.OrderBy(x => typeof(zlacze).GetProperty(strColumnName).GetValue(x, null)).ToList();
            }
            else
            {
                lista_zla = lista_zla.OrderByDescending(x => typeof(zlacze).GetProperty(strColumnName).GetValue(x, null)).ToList();
            }
            dataGridView1.DataSource = lista_zla;
            dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
        }

        private SortOrder getSortOrder(int columnIndex)
        {
            if (dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
            {
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else
            {
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
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
                    
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_urz;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    textBox4.Show();
                    textBox5.Show();
                    textBox6.Show();


                    if (lang == 1)
                    {
                        dataGridView1.Columns[0].HeaderText = "power";
                        dataGridView1.Columns[1].HeaderText = "cable_length";
                        dataGridView1.Columns[3].HeaderText = "cable_name";
                        dataGridView1.Columns[5].HeaderText = "connector_name";
                        dataGridView1.Columns[6].HeaderText = "antenna_name";
                        dataGridView1.Columns[8].HeaderText = "sensitivity";

                        label2.Text = "Choose a table";
                        QuitButton.Text = "Quit";
                        AddButton.Text = "Add";
                        DeleteButton.Text = "Delete";
                        label7.Text = dataGridView1.Columns[0].HeaderText + ulamek;
                        label1.Text = dataGridView1.Columns[1].HeaderText + ulamek;
                        label3.Text = "cable_name" + tekst;
                        label4.Text = "connector_name" + tekst;
                        label5.Text = "antenna_name" + tekst;
                        label6.Text = dataGridView1.Columns[8].HeaderText + ulamek;
                    }

                    else
                    {
                        label7.Text = dataGridView1.Columns[0].HeaderText + ulamek;
                        label1.Text = dataGridView1.Columns[1].HeaderText + ulamek;
                        label3.Text = "nazwa_kabla" + tekst;
                        label4.Text = "nazwa_zlacza" + tekst;
                        label5.Text = "nazwa_anteny" + tekst;
                        label6.Text = dataGridView1.Columns[8].HeaderText + ulamek;
                    }
                    
                    break;
                case "Budżet łącza":
                case "Link Budget":
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_bud;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();

                    if (lang == 1)
                    {
                        dataGridView1.Columns[2].HeaderText = "distance_km";
                        dataGridView1.Columns[3].HeaderText = "frequency_MHz";
                        dataGridView1.Columns[4].HeaderText = "value";
                        label2.Text = "Choose a table";
                        QuitButton.Text = "Quit";
                        AddButton.Text = "Add";
                        DeleteButton.Text = "Delete";
                        label7.Text = dataGridView1.Columns[1].HeaderText + ulamek;
                        label1.Text = dataGridView1.Columns[2].HeaderText + ulamek;
                        label3.Text = dataGridView1.Columns[3].HeaderText + calkowita;
                    }
                    else
                    {
                        label7.Text = dataGridView1.Columns[1].HeaderText + ulamek;
                        label1.Text = dataGridView1.Columns[2].HeaderText + ulamek;
                        label3.Text = dataGridView1.Columns[3].HeaderText + calkowita;
                    }

                    
                    break;
                case "Materiały":
                case "Materials":
                    dataGridView1.Columns[0].Visible = false;
                    
                    dataGridView1.DataSource = lista_mat;
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
                        label1.Text = dataGridView1.Columns[2].HeaderText + ulamek;
                        label3.Text = dataGridView1.Columns[3].HeaderText + ulamek;
                        label4.Text = dataGridView1.Columns[4].HeaderText + ulamek;
                    }
                    else
                    {
                        label7.Text = dataGridView1.Columns[1].HeaderText + tekst;
                        label1.Text = dataGridView1.Columns[2].HeaderText + ulamek;
                        label3.Text = dataGridView1.Columns[3].HeaderText + ulamek;
                        label4.Text = dataGridView1.Columns[4].HeaderText + ulamek;
                    }
                   
                    break;
                case "Anteny":
                case "Antennas":
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_ant;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();

                    if (lang == 1)
                    {
                        dataGridView1.Columns[1].HeaderText = "name";
                        dataGridView1.Columns[2].HeaderText = "gain_dBi";
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
                case "Kable":
                case "Cables":
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_kab;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();

                    if (lang == 1)
                    {
                        dataGridView1.Columns[1].HeaderText = "frequency_MHZ";
                        dataGridView1.Columns[2].HeaderText = "name";
                        dataGridView1.Columns[3].HeaderText = "attenuation_db1m";
                        label2.Text = "Choose a table";
                        QuitButton.Text = "Quit";
                        AddButton.Text = "Add";
                        DeleteButton.Text = "Delete";
                        label7.Text = dataGridView1.Columns[1].HeaderText + calkowita;
                        label1.Text = dataGridView1.Columns[2].HeaderText + tekst;
                        label3.Text = dataGridView1.Columns[3].HeaderText + ulamek;
                    }

                    else
                    {
                        label7.Text = dataGridView1.Columns[1].HeaderText + calkowita;
                        label1.Text = dataGridView1.Columns[2].HeaderText + tekst;
                        label3.Text = dataGridView1.Columns[3].HeaderText + ulamek;
                    }
                    
                    break;
                case "Złącza":
                case "Connectors":
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.DataSource = lista_zla;
                    clearTextBoxes();
                    clearLabels();
                    textBox1.Show();
                    textBox2.Show();
                    textBox3.Show();

                    if (lang == 1)
                    {
                        dataGridView1.Columns[1].HeaderText = "name";
                        dataGridView1.Columns[2].HeaderText = "attenuation_db";
                        dataGridView1.Columns[3].HeaderText = "cable_id";
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
            
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Urządzenie":
                case "Devices":

                    string value1 = textBox3.Text;
                    string value2 = textBox4.Text;
                    string value3 = textBox5.Text;

                    string query1 = "SELECT Kabel.id FROM Urzadzenie, Kabel WHERE Kabel.symbol = '" + value1 + "'AND Urzadzenie.id_kabla = Kabel.id";
                    string query2 = "SELECT Zlacze.id FROM Urzadzenie, Zlacze WHERE Zlacze.symbol = '" + value2 + "'AND Urzadzenie.id_zlacza = Zlacze.id";
                    string query3 = "SELECT Antena.id FROM Urzadzenie, Antena WHERE Antena.nazwa = '" + value3 + "'AND Antena.id = Urzadzenie.id_anteny";
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

                    try
                    {
                        Urzadzenie urz = new Urzadzenie
                        {

                            moc = Convert.ToInt32(textBox1.Text),
                            dl_kabla = Convert.ToInt32(textBox2.Text),
                            id_kabla = id_kab,
                            id_zlacza = id_zlacz,
                            id_anteny = id_ant,
                            czulosc = Convert.ToDouble(textBox6.Text)

                        };
                        label8.ForeColor = Color.Green; label8.Text = "Dodano do bazy"; label8.Show();
                        if(urz.id_kabla == 0 || urz.id_zlacza ==0 || urz.id_anteny == 0)
                        {
                            label8.ForeColor = Color.Red; label8.Text = "Złe dane."; label8.Show();
                        }
                        SqliteDataAccess.saveDevices(urz);
                        lista_urz = SqliteDataAccess.ListUrzadzenie();
                        dataGridView1.DataSource = lista_urz;
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException) { label8.ForeColor = Color.Red; label8.Text = "Wprowadzono błędne dane"; label8.Show(); }



                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
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
                        label8.ForeColor = Color.Green; label8.Text = "Dodano do bazy"; label8.Show();
                        lista_mat = SqliteDataAccess.listMaterials();
                        dataGridView1.DataSource = lista_mat;
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException) { label8.ForeColor = Color.Red; label8.Text = "Wprowadzono błędne dane"; label8.Show(); }


                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    break;
                case "Anteny":
                case "Antennas":
                    try
                    {
                        parametry_anteny par = new parametry_anteny
                        {
                            zysk_dBi = Convert.ToDouble(textBox2.Text),
                            nazwa = textBox1.Text,
                            czestotliwosc_MHz = Convert.ToInt32(textBox3.Text)
                        };
                        SqliteDataAccess.saveParameters(par);
                        label8.ForeColor = Color.Green; label8.Text = "Dodano do bazy"; label8.Show();
                        lista_ant = SqliteDataAccess.ListParameters();
                        dataGridView1.DataSource = lista_ant;
                    }
                    catch(Exception ex) when (ex is ArgumentNullException || ex is FormatException) { label8.ForeColor = Color.Red; label8.Text = "Wprowadzono błędne dane"; label8.Show(); }
                    
                    

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    break;
                case "Kable":
                case "Cables":
                    try
                    {
                        kabel kab = new kabel
                    {
                        czestotliwosc_MHz = Convert.ToInt32(textBox1.Text),
                        symbol = textBox2.Text,
                        tlumiennosc_db1m = Convert.ToInt32(textBox3.Text)
                    };
                        SqliteDataAccess.saveCables(kab);
                        label8.ForeColor = Color.Green; label8.Text = "Dodano do bazy"; label8.Show();
                        lista_kab = SqliteDataAccess.ListCables();
                        dataGridView1.DataSource = lista_kab;
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException) { label8.ForeColor = Color.Red; label8.Text = "Wprowadzono błędne dane"; label8.Show(); }
                    

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    break;
                case "Złącza":
                case "Connectors":
                    try
                    {
                        zlacze zl = new zlacze
                        {
                            symbol = textBox1.Text,
                            tlumiennosc_db = Convert.ToDouble(textBox2.Text),
                            id_kab = Convert.ToInt32(textBox3.Text)
                        };
                        SqliteDataAccess.saveZlacza(zl);
                        label8.ForeColor = Color.Green; label8.Text = "Dodano do bazy"; label8.Show();
                        lista_zla = SqliteDataAccess.ListZlacza();
                        dataGridView1.DataSource = lista_zla;
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException) { label8.ForeColor = Color.Red; label8.Text = "Wprowadzono błędne dane"; label8.Show(); }


                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    break;
                case "Budżet łącza":
                case "Link Budget":
                    try
                    {
                        Budzet_lacza budzet = new Budzet_lacza
                        {
                            fsl_db = Convert.ToDouble(textBox1.Text),
                            odleglosc_km = Convert.ToDouble(textBox2.Text),
                            czestotliwosc_MHz = Convert.ToInt32(textBox3.Text),
                        };
                        label8.ForeColor = Color.Green; label8.Text = "Dodano do bazy"; label8.Show();
                        SqliteDataAccess.saveBudget(budzet);
                        lista_bud = SqliteDataAccess.ListBudzet();
                        dataGridView1.DataSource = lista_bud;
                    }
                    catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException) { label8.ForeColor = Color.Red; label8.Text = "Wprowadzono błędne dane"; label8.Show(); }

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            int id = 0;
            
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Materiały":
                case "Materials":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM material WHERE id= '" + id + "'");
                        
                    }
                    catch { label8.ForeColor = Color.Green; label8.Text = "Usunięto!"; label8.Show(); lista_mat = SqliteDataAccess.listMaterials();
                        dataGridView1.DataSource = lista_mat;
                    }
                    break;
                case "Złącza":
                case "Connectors":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM zlacze WHERE id= '" + id + "'");
                        
                    }
                    catch { label8.ForeColor = Color.Green; label8.Text = "Usunięto!"; label8.Show(); lista_zla = SqliteDataAccess.ListZlacza();
                        dataGridView1.DataSource = lista_zla;
                    }
                    
                    break;
                case "Kable":
                case "Cables":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM kabel WHERE id= '" + id + "'");
                        
                    }
                    catch { label8.ForeColor = Color.Green; label8.Text = "Usunięto!"; label8.Show(); lista_kab = SqliteDataAccess.ListCables();
                        dataGridView1.DataSource = lista_kab;
                    }
                    break;
                case "Anteny":
                case "Antennas":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM antena WHERE id= '" + id + "'");
                        
                    }
                    catch { label8.ForeColor = Color.Green; label8.Text = "Usunięto!"; label8.Show(); lista_ant = SqliteDataAccess.ListParameters(); dataGridView1.DataSource = lista_ant;}
                    break;
                case "Budżet łącza":
                case "Budet Link":
                    id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    try
                    {
                        SqliteDataAccess.QueryResult("Delete FROM Budzet_lacza WHERE id= '" + id + "'");
                        
                    }
                    catch { label8.ForeColor = Color.Green; label8.Text = "Usunięto!"; label8.Show(); lista_bud = SqliteDataAccess.ListBudzet();
                        dataGridView1.DataSource = lista_bud;
                    }
                    break;
            }

            

        }

    }
    }
