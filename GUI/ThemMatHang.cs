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
    public partial class ThemMatHang : Form
    {
        Dictionary<string, string> choices;
        public ThemMatHang()
        {
            InitializeComponent();
            GetDM();
        }

        public void GetDM()
        {
            List<DanhMuc_DTO> dms = DanhMuc_BUS.Instance.getAllDanhMuc();

            choices = new Dictionary<string, string>();

            foreach (DanhMuc_DTO dm in dms) {
                choices[dm.MaDM] =  dm.TenDM;
            }

            cbDM.DataSource = new BindingSource(choices, null);
            cbDM.DisplayMember = "Value";
            cbDM.ValueMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MatHang_DTO mh = new MatHang_DTO();
            try
            {
                mh.MaHang = txtMahang.Text.ToString();
                mh.TenHang = txtTenhang.Text.ToString();
                mh.SoLuong = Convert.ToInt16(txtSL.Text.ToString());
                mh.HinhAnh = pictureBox1.ImageLocation.ToString();
                mh.Gia = float.Parse(txtGia.Text.ToString());
                mh.MoTa = txtMota.Text.ToString();
                mh.MaDM = cbDM.SelectedValue.ToString();

                bool kq = MatHang_BUS.Instance.themMatHang(mh);
                string mss = kq == true ? "Thêm thành công" : "Thêm thất bại";
                MessageBox.Show(mss);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhập đủ và đúng định dạng cho dữ liệu");
            }
        }

        private void ThemMatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kLMQSDataSet.MATHANG' table. You can move, or remove it, as needed.
            this.mATHANGTableAdapter.Fill(this.kLMQSDataSet.MATHANG);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string imageLocation;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = ofd.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string mmh = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                ChiTietMatHang ctmh = new ChiTietMatHang(mmh,choices);
                ctmh.ShowDialog();
            } catch (Exception ex)
            {
                MessageBox.Show("Bấm vô hàng sản phẩm cần sửa.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string mmh = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                bool kq = MatHang_BUS.Instance.xoaMH(mmh);
                string mss = kq == true ? "Xóa mặt hàng " + mmh + " thành công" : "Xóa thất bại";
                MessageBox.Show(mss);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bấm vô hàng sản phẩm cần Xóa.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtGia.Text = "";
            txtSL.Text = "";
            txtTenhang.Text = "";
            txtMota.Text = "";
            txtMahang.Text = "";
            pictureBox1.ImageLocation = "";
        }
    }
}
