using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NATO.DAO;
using NATO.DTO;
using NATO.BUS;
using System.Data.SqlClient;

namespace NATO.GUI
{
    public partial class test : Form
    {

        string cs = @"Data Source=DESKTOP-ADHIDMQ\SQLEXPRESS;Initial Catalog=KLMQS;Integrated Security=True";

        public test()
        {
            InitializeComponent();

            /*List<DanhMuc_DTO> dms = DanhMuc_BUS.Instance.getAllDanhMuc();

            Dictionary<string, string> choices = new Dictionary<string, string>();

            foreach (DanhMuc_DTO dm in dms)
            {
                choices[dm.MaDM] = dm.TenDM;
            }

            comboBox1.DataSource = new BindingSource(choices, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";*/
            comboBox1.SelectedItem = "Les";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tr = comboBox1.SelectedValue.ToString();
            MessageBox.Show(tr);
        }

        public void Insert(string fileName, byte[] image)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "INSERT INTO TEST VALUES(@f,@p)";
                    cmd.Parameters.Add("@f", SqlDbType.NVarChar).Value = fileName;
                    cmd.Parameters.Add("@f", SqlDbType.Image).Value = image;

                    int eff = cmd.ExecuteNonQuery();
                    if (eff == 1) MessageBox.Show("DONE");
                    else MessageBox.Show("NONE");
                }
            } catch (Exception ex)
            {

            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
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
            } catch (Exception ex)
            {

            }
        }
    }
}
