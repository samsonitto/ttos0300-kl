using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public class DB
    {
        public static DataTable ReadFromSQLite(string fileName, string tableName)
        {
            if (System.IO.File.Exists(fileName))
            {
                SQLiteConnection conn = new SQLiteConnection($"Data source={fileName};Version=3;New=False;Compress=True");
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM " + tableName;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                //muunnetaan reader DataTableksi
                DataTable dt = new DataTable();
                dt.Load(rdr);
                rdr.Close();
                conn.Close();
                //palautus
                return dt;
            }
            else
            {
                throw new System.IO.FileNotFoundException("Tiedostoa ei löydy");
            }
        }
        public static bool AddToSQLite(string fileName, string tableName, string name, string team, int number)
        {
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    SQLiteConnection conn = new SQLiteConnection($"Data source={fileName};Version=3");
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"INSERT INTO {tableName} (nimi, joukkue, numero) VALUES ('{name}','{team}','{number}');";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //palautus
                    return true;
                }
                else
                {
                    throw new System.IO.FileNotFoundException("Tiedostoa ei löydy");
                }
            }
            catch
            {

                throw;
            }
        }
        public static bool DeleteFromSQLite(string fileName, string tableName, string name)
        {
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    SQLiteConnection conn = new SQLiteConnection($"Data source={fileName};Version=3");
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = $"DELETE FROM {tableName} WHERE nimi LIKE '{name}'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //palautus
                    return true;
                }
                else
                {
                    throw new System.IO.FileNotFoundException("Tiedostoa ei löydy");
                }
            }
            catch
            {

                throw;
            }
        }
    }
}
