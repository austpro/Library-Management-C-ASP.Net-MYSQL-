using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Libray_Management
{
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HP\SQLEXPRESS;Initial Catalog=library_management_system;Integrated Security=True;Pooling=False");
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into library_person values('" + textBox2fullname.Text + "','" + textBox3username.Text + "','" + textBox4password.Text + "','" + textBox5email.Text + "','" + textBox6contact.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox2fullname.Text = "";
            textBox3username.Text = "";
            textBox4password.Text = "";
            
            textBox5email.Text = "";
            textBox6contact.Text = "";

            MessageBox.Show("successfully Registered");
        }

        private void textBox6contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcomee ob = new Welcomee();
            ob.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
