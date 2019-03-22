using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;


namespace Libray_Management
{
    public partial class books_stock : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HP\SQLEXPRESS;Initial Catalog=library_management_system;Integrated Security=True;Pooling=False");

        public books_stock()
        {
            InitializeComponent();
        }

        private void books_stock_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {

                con.Close();
            }
            con.Open();
            fill_books_info();

        }

        public void fill_books_info()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select  books_name,books_author_name,books_quantity,available_qty from books_info";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string i;
            i = dataGridView1.SelectedCells[0].Value.ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select   * from issue_books where books_name='"+i.ToString()+ "' and book_return_date=''";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select  books_name,books_author_name,books_quantity,available_qty from books_info where books_name like('%"+textBox1.Text+"%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string i;
            i = dataGridView2.SelectedCells[6].Value.ToString();
            textBox2.Text = i.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("fsshishir95@gmail.com", "gofranhaji");//email and password for same email
            MailMessage mail=new MailMessage("fsshishir95@gmail.com",textBox2.Text, "this is for book return notice",textBox3.Text);
            mail.Priority = MailPriority.High;
            smtp.Send(mail);
            MessageBox.Show("mail send");// imap shoud be turned on see the tutorial 16 minute 5:44

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
