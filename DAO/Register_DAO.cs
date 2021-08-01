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
    public class Register_DAO
    {
        public static Register_DAO instance;
        public static Register_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Register_DAO();
                return instance;
            }
        }

        string cs = @"Data Source=DESKTOP-ADHIDMQ\SQLEXPRESS;Initial Catalog=KLMQS;Integrated Security=True";

        public bool register(TaiKhoan_DTO tk)
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
                    string hinhanh = tk.HinhAnh;

                    cmd.CommandText = "INSERT INTO TAIKHOAN VALUES(@u,@h,@e,@sdt,@dc,@gt,@qt,@mk,@ia,@hinh)";
                    cmd.Parameters.Add("@u", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@h", SqlDbType.NVarChar).Value = hoten;
                    cmd.Parameters.Add("@e", SqlDbType.NVarChar).Value = email;
                    cmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = sdt;
                    cmd.Parameters.Add("@dc", SqlDbType.NVarChar).Value = diachi;
                    cmd.Parameters.Add("@gt", SqlDbType.NVarChar).Value = gt;
                    cmd.Parameters.Add("@qt", SqlDbType.NVarChar).Value = quoctich;
                    cmd.Parameters.Add("@mk", SqlDbType.NVarChar).Value = matkhau;
                    cmd.Parameters.Add("@ia", SqlDbType.NVarChar).Value = isadmin;
                    cmd.Parameters.Add("@hinh", SqlDbType.NVarChar).Value = hinhanh;

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
    }
}
