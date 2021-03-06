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
        public static string QueryResult(string query)
        {
            string result = "";
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                result = cnn.ExecuteScalar(query).ToString();
            }
            return result;
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

        public static List<tl_materialow> listMaterials()
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                var output = cnn.Query<tl_materialow>("select * from tl_materialow", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void saveMaterials(tl_materialow mat)
        {
            using (IDbConnection cnn = new SQLiteConnection(loadConnectionString()))
            {
                cnn.Execute("insert into tl_materialow (nazwa, wartosc) values (@nazwa, @wartosc)", mat);
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
    }
}
