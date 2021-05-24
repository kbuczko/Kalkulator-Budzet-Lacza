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
                var output = cnn.Query<tl_materialow>("select wartosc from tl_materialow where id=1", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<FSL> load()
        {
            using (IDbConnection cnn= new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<FSL>("select * from FSL", new DynamicParameters());
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

        public static List<kabel> ListCables()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<kabel>("select * from kabel", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<czestotliwosc> ListCzest()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<czestotliwosc>("select * from czestotliwosc", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<parametry_anteny> ListParameters()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<parametry_anteny>("select * from parametry_anteny", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<tl_materialow> listMaterials()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<tl_materialow>("select * from tl_materialow", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<odleglosc> listOdl()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<odleglosc>("select * from odleglosc", new DynamicParameters());
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

        public static void saveOdl(odleglosc odl)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into odleglosc (wartosc) values (@wartosc)", odl);
            }
        }

        public static void saveCzest(czestotliwosc czest)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into czestotliwosc (wartosc) values (@wartosc)", czest);
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
                cnn.Execute("insert into tl_materialow (nazwa, wartosc) values (@nazwa, @wartosc)", mat);
            }
        }

        public static void saveParameters(parametry_anteny par)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into parametry_anteny (rodzaj, zysk, moc, id_kabla, id_zlacza, czy_nad) values (@rodzaj, @zysk, @moc, @id_kabla, @id_zlacza, @czy_nad)", par);
            }
        }

        public static void SaveFsl(FSL fsl)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into FSL (odleglosc, czestotliwosc, wartosc) values (@odleglosc, @czestotliwosc, @wartosc)", fsl);

            }
        }
        private static string loadConnectionString(string id= "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        //kalkulator
        public static List<FSL2> calc_FSL_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<FSL2>("select * from FSL", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<parametry_anteny_moc> calc_MOC_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<parametry_anteny_moc>("select parametry_anteny.rodzaj, parametry_anteny.moc from parametry_anteny", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<parametry_anteny_zysk> calc_ZYSK_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<parametry_anteny_zysk>("select parametry_anteny.rodzaj, parametry_anteny.zysk from parametry_anteny", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<Tlumiennosc> calc_TLUMIENOSC_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<Tlumiennosc>("SELECT kabel.symbol, kabel.wartosc, zlacze.symbol, zlacze.tlumiennosc FROM parametry_anteny, kabel, zlacze", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<tl_materialow2> calc_MATERIALY_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<tl_materialow2>("select tl_materialow.nazwa, tl_materialow.wartosc from tl_materialow", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<czestotliwosc> calc_CZESTOTLIWOSC_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<czestotliwosc>("select * from czestotliwosc", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<odleglosc> calc_ODLEGLOSC_Load()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<odleglosc>("select * from odleglosc", new DynamicParameters());
                return output.ToList();
            }
        }
    }
}
