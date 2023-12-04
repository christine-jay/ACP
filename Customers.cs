using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;


namespace bakeryinventory
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source = TENAY\\SQLEXPRESS01; Initial Catalog = bakery; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader read;
        string sql;


        private void button2_Click(object sender, EventArgs e)
        {
            string cname = txtcname.Text;
            string address = txtaddress.Text;
            string email = txtemail.Text;
            string phone = txtphone.Text;
            string id = txtID.Text;

            sql = "UPDATE products SET c_name =@c_name, c_address =@c_address, c_email =@c_email, c_phone =@c_phone WHERE c_id =@c_id";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@c_name", cname);
            cmd.Parameters.AddWithValue("@c_address", address);
            cmd.Parameters.AddWithValue("@c_email", email);
            cmd.Parameters.AddWithValue("@c_phone", phone);
            cmd.ExecuteNonQuery();

            MessageBox.Show("CUSTOMER RECORD UPDATED SUCCESSFULLY");

            txtcname.Clear();
            txtaddress.Clear();
            txtemail.Clear();
            txtphone.Clear();
            txtcname.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          AdminHome obj = new AdminHome();
          obj.Show();
          this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cname = txtcname.Text;
            string address = txtaddress.Text;
            string email = txtemail.Text;
            string phone = txtphone.Text;

            sql = "INSERT INTO products (c_name, c_address, c_email, c_phone) VALUES (@c_name, @c_address, @c_email, @c_phone)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@c_name", cname);
            cmd.Parameters.AddWithValue("@c_address", address);
            cmd.Parameters.AddWithValue("@c_email", email);
            cmd.Parameters.AddWithValue("@c_phone", phone);
            cmd.ExecuteNonQuery();

            MessageBox.Show("CUSTOMER RECORD ADDED SUCCESSFULLY");

            txtcname.Clear();
            txtaddress.Clear();
            txtemail.Clear();
            txtphone.Clear();
            txtcname.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sql = "DELETE products where c_id=@c_id";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@c_id", txtID.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("PRODUCT RECORD DELETED SUCCESSFULLY");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;

            sql = "SELECT * FROM products WHERE c_id =@c_id";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@c_id", id);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtcname.Text = dr["c_name"].ToString();
                txtaddress.Text = dr["c_address"].ToString();
                txtemail.Text = dr["c_email"].ToString();
                txtphone.Text = dr["c_phone"].ToString();
            }
            else
            {
                MessageBox.Show("PRODUCT ID NOT FOUND");
            }

            con.Close();
        }
    }
}
