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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register rs = new Register();
            rs.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (Login_BUS.Instance.login(username, password) == true)
            {
                this.Hide();
                HomePage hp = new HomePage(username);
                hp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username hoặc password không hợp lệ");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thoát ứng dụng?", "THOÁT ỨNG DỤNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }
    }
}
