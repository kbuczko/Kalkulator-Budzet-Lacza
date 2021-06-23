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

        public static List<materialy> example()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<materialy>("select wartosc from Material where id=1", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Urzadzenie> ListUrzadzenie()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<Urzadzenie>("SELECT Urzadzenie.id, Urzadzenie.nazwa as nazwa, Urzadzenie.moc,Urzadzenie.id_kabla, Urzadzenie.id_zlacza, Urzadzenie.id_anteny,Urzadzenie.czulosc, Urzadzenie.ant_wbud , Antena.nazwa as nazwa_anteny FROM Urzadzenie, Antena WHERE Antena.id = Urzadzenie.id_anteny", new DynamicParameters());
                return output.ToList();
            }
        }


        public static List<Budzet_lacza> updateBudzet(double wartosc, double odl, int czest)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<Budzet_lacza>("UPDATE Budzet_lacza SET wartosc='" + wartosc + "' WHERE odleglosc_km= '" + odl + "' AND czestotliwosc_MHz = '" + czest + "'", new DynamicParameters()) ;
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
                var output = cnn.Query<Budzet_lacza>("select * from Budzet_lacza", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<kabel> ListCables()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<kabel>("select kabel.czestotliwosc_MHz, kabel.symbol, kabel.tlumiennosc_db1m, zlacze.symbol as nazwa_zlacza, kabel.id from kabel, zlacze WHERE kabel.id_zlacza = zlacze.id", new DynamicParameters());
                return output.ToList();
            }
        }

       

        public static List<Anteny> ListParameters()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<Anteny>("select * from Antena", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<materialy> listMaterials()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<materialy>("select * from Material", new DynamicParameters());
                return output.ToList();
            }
        }


        public static void saveZlacza(zlacze zl)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into zlacze (symbol, tlumiennosc_db, czestotliwosc_MHz) values (@symbol, @tlumiennosc_db, @czestotliwosc_MHz)", zl);
            }
        }
        public static void saveDevices(Urzadzenie urz)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into Urzadzenie (nazwa, moc, id_kabla, id_zlacza, id_anteny, czulosc, ant_wbud) values (@nazwa, @moc, @id_kabla, @id_zlacza, @id_anteny, @czulosc, 0)", urz);
            }
        }


        public static void saveCables(kabel kab)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into kabel (czestotliwosc_MHz, symbol, tlumiennosc_db1m, id_zlacza) values (@czestotliwosc_MHz, @symbol, @tlumiennosc_db1m, @id_zlacza)", kab);
            }
        }

        public static void saveMaterials(materialy mat)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into Material (nazwa, tlumiennosc_db, grubosc_cm, czestotliwosc_MHz) values (@nazwa, @tlumiennosc_db, @grubosc_cm, @czestotliwosc_MHz)", mat);
            }
        }

        public static void saveParameters(Anteny par)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into Antena (nazwa, zysk_dBi, czestotliwosc_MHz, id_zlacza) values (@nazwa, @zysk_dBi, @czestotliwosc_MHz, @id_zlacza)", par);
            }
        }
        public static void saveBudget(Budzet_lacza budzet)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into Budzet_lacza (fsl_db, odleglosc_km, czestotliwosc_MHz, wartosc) values (@fsl_db, @odleglosc_km, @czestotliwosc_MHz, @wartosc)", budzet);
            }
        }
        private static string loadConnectionString(string id= "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //kalkulator
        /*public static List<parametry_anteny_moc> calc_MOC_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<parametry_anteny_moc>("select Odbiornik.id, Odbiornik.moc from Odbiornik", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<budzet_lacza_fsl> calc_FSL_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<budzet_lacza_fsl>("select id, fsl_db FROM Budzet_lacza", new DynamicParameters());
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
                var output = cnn.Query<tl_materialow2>("select Material.nazwa, Material.tlumiennosc, Material.grubosc_cm, Material.czestotliwosc_MHz from Material", new DynamicParameters());
                return output.ToList();
            }
        }*/
        
    }
}
