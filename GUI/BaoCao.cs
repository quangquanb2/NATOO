using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NATO.BUS;

namespace NATO.GUI
{
    public partial class BaoCao : Form
    {
        
        public BaoCao()
        {
            InitializeComponent();
            load_Chart1();
            load_Chart2();
            load_PieChart3();
            load_PieChart4();
        }

        private void load_PieChart4()
        {
            Dictionary<string, int> dm = ThongKe_BUS.Instance.getMHBanChayT();

            chart4.Titles.Add("Pie Chart");
            chart4.Series["Mặt Hàng"].IsValueShownAsLabel = true;
            foreach (var item in dm)
            {
                chart4.Series["Mặt Hàng"].Points.AddXY(item.Key, item.Value);
            }
        }

        private void load_PieChart3()
        {
            Dictionary<string, int> dm = ThongKe_BUS.Instance.getDMBanChay();
            
            chart3.Titles.Add("Pie Chart");
            chart3.Series["Danh Mục"].IsValueShownAsLabel = true;
            foreach (var item in dm)
            {
                chart3.Series["Danh Mục"].Points.AddXY(item.Key, item.Value);
            }
        }

        private void load_Chart1()
        {
            Dictionary<string, float> sl = ThongKe_BUS.Instance.getSLBanChay();
            int count = sl.Count;

            chart1.Titles.Add("Tổng số lượng bán ra");
            chart1.Series.Add("Tổng số lượng");

            foreach (var item in sl)
            {
                chart1.Series["Tổng số lượng"].Points.AddXY(item.Key, item.Value);
            }
        }

        private void load_Chart2()
        {
            Dictionary<string, float> sl = ThongKe_BUS.Instance.getTTBanChay();
            int count = sl.Count;

            chart2.Series.Add("Tổng doanh thu");
            chart2.Titles.Add("Tổng doanh thu các mặt hàng");
            foreach (var item in sl)
            {
                chart2.Series["Tổng doanh thu"].Points.AddXY(item.Key, item.Value);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {

        }
    }
}
