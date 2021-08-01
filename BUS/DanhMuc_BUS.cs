using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DTO;
using NATO.DAO;

namespace NATO.BUS
{
    public class DanhMuc_BUS
    {
        public static DanhMuc_BUS instance;
        public static DanhMuc_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DanhMuc_BUS();
                return instance;
            }
        }

        public bool themDanhMuc(DanhMuc_DTO dm)
        {
            return DanhMuc_DAO.Instance.themDanhMuc(dm);
        }

        public List<DanhMuc_DTO> getAllDanhMuc()
        {
            return DanhMuc_DAO.Instance.getAllDanhMuc();
        }
    }
}
