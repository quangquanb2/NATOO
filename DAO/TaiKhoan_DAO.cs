using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DTO;

namespace NATO.DAO
{
    public class TaiKhoan_DAO
    {
        public static TaiKhoan_DAO instance;
        public static TaiKhoan_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoan_DAO();
                return instance;
            }
        }

        string cs = @"Data Source=DESKTOP-ADHIDMQ\SQLEXPRESS;Initial Catalog=KLMQS;Integrated Security=True";

        public TaiKhoan_DTO getTaiKhoan(string username)
        {
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM TAIKHOAN WHERE Username = @U";
                    cmd.Parameters.Add("@U", SqlDbType.NVarChar).Value = username;

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        tk.Username = username;
                        tk.HoTen = rdr["HoTen"].ToString();
                        tk.Email = rdr["Email"].ToString();
                        tk.SDT = rdr["SDT"].ToString();
                        tk.DiaChi = rdr["DiaChi"].ToString();

                        tk.GT = rdr.GetBoolean(rdr.GetOrdinal("GioiTinh"));

                        tk.QuocTich = rdr["QuocTich"].ToString();

                        tk.IsAdmin = rdr.GetBoolean(rdr.GetOrdinal("IsAdmin"));
                        tk.HinhAnh = rdr["AVATAR"].ToString();

                        return tk;
                    }
                    else
                    {
                        return null;
                    }
                        
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return null;
            }
        }

        public bool updateTaiKhoan(TaiKhoan_DTO tk)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    string username = tk.Username;
                    string hoten = tk.HoTen;
                    string email = tk.Email;
                    string sdt = tk.SDT;
                    string diachi = tk.DiaChi;
                    bool gt = tk.GT;
                    string quoctich = tk.QuocTich;
                    string matkhau = tk.MatKhau;
                    bool isadmin = tk.IsAdmin;
                    string hinh = tk.HinhAnh;

                    cmd.CommandText = "UPDATE TAIKHOAN SET HoTen=@ht, Email=@e, SDT=@s, DiaChi=@dc, GioiTinh=@gt, QuocTich=@qt, AVATAR=@av WHERE Username=@u";
                    cmd.Parameters.Add("@u", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@ht", SqlDbType.NVarChar).Value = hoten;
                    cmd.Parameters.Add("@e", SqlDbType.NVarChar).Value = email;
                    cmd.Parameters.Add("@s", SqlDbType.NVarChar).Value = sdt;
                    cmd.Parameters.Add("@dc", SqlDbType.NVarChar).Value = diachi;
                    cmd.Parameters.Add("@gt", SqlDbType.Bit).Value = gt;
                    cmd.Parameters.Add("@qt", SqlDbType.NVarChar).Value = quoctich;
                    cmd.Parameters.Add("@av", SqlDbType.NVarChar).Value = hinh;

                    int eff = cmd.ExecuteNonQuery();
                    if (eff == 1)
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

        public bool isAdmin(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT IsAdmin FROM TAIKHOAN WHERE Username = @U";
                    cmd.Parameters.Add("@U", SqlDbType.NVarChar).Value = username;

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        bool isAdmin = rdr.GetBoolean(rdr.GetOrdinal("IsAdmin"));
                        return isAdmin;
                    }
                    else
                    {
                        return false;
                    }
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
