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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminHome obj = new AdminHome();
            obj.Show();
            this.Hide();
        }

        SqlConnection con = new SqlConnection("Data Source = TENAY\\SQLEXPRESS01; Initial Catalog = bakery; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader read;
        string sql;

        private void button1_Click(object sender, EventArgs e)
        {
            string pname = txtpname.Text;
            string price = txtprice.Text;
            string quantity = txtquantity.Text;

            sql = "insert into products(p_name, p_price, p_quantity) values (@p_name, @p_price, @p_quantity)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@p_name", pname);
            cmd.Parameters.AddWithValue("@p_price", price);
            cmd.Parameters.AddWithValue("@p_quantity", quantity);
            cmd.ExecuteNonQuery();

            MessageBox.Show("PRODUCT RECORD ADDED SUCCESSFULLY");

            txtpname.Clear();
            txtprice.Clear();
            txtquantity.Clear();
            txtpname.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pname = txtpname.Text;
            string price = txtprice.Text;
            string quantity = txtquantity.Text;
            string id = txtID.Text;

            sql = "UPDATE products SET p_name =@p_name, p_price =@p_price, p_quantity =@p_quantity WHERE p_id =@p_id";

            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@p_name", pname);
            cmd.Parameters.AddWithValue("@p_price", price);
            cmd.Parameters.AddWithValue("@p_quantity", quantity);
            cmd.Parameters.AddWithValue("@p_id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("PRODUCT RECORD UPDATED SUCCESSFULLY");
            con.Close();
            txtpname.Clear();
            txtprice.Clear();
            txtquantity.Clear();
            txtpname.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sql = "DELETE products where p_id=@p_id";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@p_id", txtID.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("PRODUCT RECORD DELETED SUCCESSFULLY");

            txtpname.Clear();
            txtprice.Clear();
            txtquantity.Clear();
            txtpname.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;

            
            sql = "SELECT * FROM products WHERE p_id =@p_id";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@p_id", id);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtpname.Text = dr["p_name"].ToString();
                txtprice.Text = dr["p_price"].ToString();
                txtquantity.Text = dr["p_quantity"].ToString();
            }
            else
            {
                MessageBox.Show("PRODUCT ID NOT FOUND");
            }

            con.Close();
        }
    }
}
