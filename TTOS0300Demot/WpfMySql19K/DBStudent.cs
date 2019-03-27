using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace JAMK.IT.TTOS0300
{
    class DB
    {
        public static List<Student> LoadStudentsFromMysql()
        {
            try
            {
                List<Student> students = new List<Student>();
                //luodaan yhteys labranetin mysql-palvelimelle
                string connstr = GetMysqlConnectionString();
                string sql = "SELECT firstName, lastName, asioID FROM student";
                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            //ORM eli tietokannan taulun tietue muutetaan student olioiksi
                            while (reader.Read())
                            {
                                Student s = new Student();
                                s.FirstName = reader.GetString(0);
                                s.LastName = reader.GetString(1);
                                s.AsioID = reader.GetString(2);
                                students.Add(s);
                            }
                            return students;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private static string GetMysqlConnectionString()
        {
            //palautetaan yhteysmerkkijono jolla saadaan yhteys Mysql-palveluun
            string ss = "Mn1GQ5TbFX7UI0tjH2Y4H2oWtcfs4zra";
            //return $"Data source=mysql.labranet.jamk.fi;Initial Catalog=M3156_1;user=M3156;password={ss};SslMode=none";
            return $"SERVER=mysql.labranet.jamk.fi;DATABASE=M3156_1;UID=M3156;PASSWORD={ss};SslMode=none";
        }
    }
}
