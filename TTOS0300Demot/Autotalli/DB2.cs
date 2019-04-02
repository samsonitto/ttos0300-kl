using System;
using System.Collections.Generic;
using System.Data; // geneerinen Data luokka
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace JAMK.IT.TTOS0300
{
    public class DB2
    {
        public static DataTable GetAutos()
        {
            //haetaan kaikki rivit taulusta autotalli
            DataTable dt = new DataTable();
            // muuttuvat arvot luetaan app.configista muuttujiin
            string palvelin = Autotall1.Properties.Settings.Default.server;
            string tietokanta = Autotall1.Properties.Settings.Default.database;
            string salasana = Autotall1.Properties.Settings.Default.password;
            try
            {
                MySqlConnectionStringBuilder mySB = new MySqlConnectionStringBuilder();
                mySB.Server = palvelin;
                mySB.Database = tietokanta;
                mySB.UserID = tietokanta;
                mySB.Password = salasana;
                mySB.SslMode = MySqlSslMode.None;
                using (MySqlConnection conn = new MySqlConnection(mySB.ConnectionString))
                {
                    string sql = "SELECT merkki, malli, vm, km, hinta, url FROM autotalli";
                    MySqlDataAdapter myDA = new MySqlDataAdapter(sql, conn);
                    myDA.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
