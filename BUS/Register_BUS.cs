using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DAO;
using NATO.DTO;

namespace NATO.BUS
{
    public class Register_BUS
    {
        public static Register_BUS instance;
        public static Register_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new Register_BUS();
                return instance;
            }
        }

        public bool register(string username, string hoten, string mk, string email, string sdt, string gt, string diachi, string quoctich)
        {
            
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.Username = username;
            tk.HoTen = hoten;
            tk.MatKhau = mk;
            tk.Email = email;
            tk.SDT = sdt;
            tk.DiaChi = diachi;
            tk.QuocTich = quoctich;
            tk.GT = gt.Equals("Nam") ? false : true;
            tk.IsAdmin = false;
            tk.HinhAnh = "";

            return Register_DAO.Instance.register(tk);
        }
    }
}
