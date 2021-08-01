using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DTO;
using NATO.DAO;

namespace NATO.BUS
{
    public class TaiKhoan_BUS
    {
        public static TaiKhoan_BUS instance;
        public static TaiKhoan_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoan_BUS();
                return instance;
            }
        }

        public TaiKhoan_DTO getTaiKhoan(string username)
        {
            return TaiKhoan_DAO.Instance.getTaiKhoan(username);
        }

        public bool updateTaiKhoan(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.Instance.updateTaiKhoan(tk);
        }

        public bool isAdmin(string username)
        {
            return TaiKhoan_DAO.Instance.isAdmin(username);
        }
    }
}
