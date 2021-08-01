using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NATO.DTO;
using NATO.BUS;

namespace NATO.GUI
{
    public partial class ThemDanhMuc : Form
    {
        public ThemDanhMuc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DanhMuc_DTO dm = new DanhMuc_DTO();
            dm.MaDM = txtMDM.Text.ToString();
            dm.TenDM = txtTDM.Text.ToString();
            dm.MoTa = txtMT.Text.ToString();

            bool kq = DanhMuc_BUS.Instance.themDanhMuc(dm);
            if (kq == true)
            {
                MessageBox.Show("Them Danh Muc Thanh Cong");
            } else
            {
                MessageBox.Show("Them Khong Thanh Cong");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMDM.Text = "";
            txtMT.Text = "";
            txtTDM.Text = "";
        }
    }
}
