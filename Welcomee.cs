using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Libray_Management
{
    public partial class Welcomee : Form
    {
        public Welcomee()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register ob = new Register();
            ob.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login ob = new login();
            ob.Show();
        }

        private void Welcomee_Load(object sender, EventArgs e)
        {

        }
    }
}
