using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DAO;

namespace NATO.BUS
{
    public class ThongKe_BUS
    {
        public static ThongKe_BUS instance;
        public static ThongKe_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThongKe_BUS();
                return instance;
            }
        }

        ThongKe_DAO tkdao = new ThongKe_DAO();

        public Dictionary<string, float> getSLBanChay()
        {
            Dictionary<string, float> sl = tkdao.getSLBanChay();
            return sl;
        }

        public Dictionary<string, float> getTTBanChay()
        {
            Dictionary<string, float> sl = tkdao.getTTBanChay();
            return sl;
        }

        public Dictionary<string, int> getDMBanChay()
        {
            Dictionary<string, int> sl = tkdao.getDMBanChay();
            return sl;
        }

        public Dictionary<string, int> getMHBanChayT()
        {
            //DateTime td = DateTime.Today;
            DateTime td2 = DateTime.Today.AddDays(-180);
            Dictionary<string, int> sl = tkdao.getMHBanChayT(td2.ToString("MM-dd-yyyy"));
            return sl;
        }
    }
}
