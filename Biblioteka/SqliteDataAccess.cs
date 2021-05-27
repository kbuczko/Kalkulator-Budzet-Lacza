using Biblioteka;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ProjektBudzetLacza
{
    public class SqliteDataAccess
    {
        public static void QueryResult(string query)
        {
            string result = "";
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                result = cnn.ExecuteScalar(query).ToString();
            }
        }

        public static List<tl_materialow> example()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<tl_materialow>("select wartosc from Material where id=1", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Nadajnik> ListNadajnik()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<Nadajnik>("SELECT Nadajnik.moc, Nadajnik.dl_kabla, Nadajnik.nazwa_kabla,  Nadajnik.nazwa_zlacza,Antena.nazwa AS nazwa_anteny FROM Nadajnik, Antena WHERE Antena.id = Nadajnik.id_anteny", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<zlacze> ListZlacza()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<zlacze>("select * from zlacze", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Budzet_lacza> ListBudzet()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<Budzet_lacza>("select * from 'Budzet lacza'", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<kabel> ListCables()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<kabel>("select * from kabel", new DynamicParameters());
                return output.ToList();
            }
        }

       

        public static List<parametry_anteny> ListParameters()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<parametry_anteny>("select * from Antena", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<tl_materialow> listMaterials()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<tl_materialow>("select * from Material", new DynamicParameters());
                return output.ToList();
            }
        }


        public static void saveZlacza(zlacze zl)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into kabel (symbol, tlumiennosc) values (@symbol, @tlumiennosc)", zl);
            }
        }

        

        public static void saveCables(kabel kab)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into kabel (id_czest, symbol, wartosc) values (@id_czest, @symbol, @wartosc)", kab);
            }
        }

        public static void saveMaterials(tl_materialow mat)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into Material (nazwa, wartosc) values (@nazwa, @wartosc)", mat);
            }
        }

        public static void saveParameters(parametry_anteny par)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into Antena (rodzaj, zysk, moc, id_kabla, id_zlacza, czy_nad) values (@rodzaj, @zysk, @moc, @id_kabla, @id_zlacza, @czy_nad)", par);
            }
        }

        private static string loadConnectionString(string id= "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //kalkulator
        public static List<parametry_anteny_moc> calc_MOC_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<parametry_anteny_moc>("select Antena.nazwa, Antena.moc from Antena", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<parametry_anteny_zysk> calc_ZYSK_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<parametry_anteny_zysk>("select Antena.nazwa, Antena.zysk_dBi from Antena", new DynamicParameters());
                return output.ToList();
            }
        }
       
        public static List<tl_materialow2> calc_MATERIALY_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<tl_materialow2>("select Material.nazwa, Material.wartosc, Material.grubosc_cm, Material.czestotliwosc_MHz from Material", new DynamicParameters());
                return output.ToList();
            }
        }
        
    }
}
