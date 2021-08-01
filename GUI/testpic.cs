using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NATO.GUI
{
    public partial class testpic : UserControl
    {
        public testpic()
        {
            InitializeComponent();
        }

        private byte[] pict;
        private string Id;
        OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg; *jpeg|*.png)", Multiselect = false };

        public byte[] Pict
        {
            get { return pict; }
            set { pict = value; pictureBox1.Image = Image.FromFile(ofd.FileName); }
        }
        public string ID
        {
            get { return Id; }
            set { Id = value; lbId.Text = value; }
        }
        

    }
}
