
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace network_finalproject_server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 f1 = new Form2();
            f1.ShowDialog();
            f1 = null;
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
