using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NATO.DAO
{
    public class Login_DAO
    {
        public static Login_DAO instance;
        public static Login_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Login_DAO();
                return instance;
            }
        }

        public bool login(string username, string password)
        {
            string cs = @"Data Source=DESKTOP-ADHIDMQ\SQLEXPRESS;Initial Catalog=KLMQS;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM TAIKHOAN WHERE Username = @U" + " AND MatKhau = @P";
                    cmd.Parameters.Add("@U", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@P", SqlDbType.NVarChar).Value = password;

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return false;
            }
        }
    }
}
