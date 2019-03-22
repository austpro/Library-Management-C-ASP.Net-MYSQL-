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
    public partial class login : Form    
    {
        SqlConnection con = new SqlConnection(@"Data Source=HP\SQLEXPRESS;Initial Catalog=library_management_system;Integrated Security=True;Pooling=False");
        int count = 0;

        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from library_person where username= '"+ textBox1.Text + "' and password='"+ textBox2.Text +"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count=Convert.ToInt32(dt.Rows.Count.ToString());
            if(count==0)
            {
              MessageBox.Show("username and password doesnot match");

            }
            else
            {
               this.Hide();
                mdi_user mu=new mdi_user();
                mu.Show();
            }

        }

        private void login_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
