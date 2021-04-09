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

namespace PCPartStore
{
    public partial class Seller : Form, Button
    {
        public Seller()
        {
            InitializeComponent();
        }

        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Daffa Romero\Documents\pcpartsdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                string query = "insert into SellerTable values(" + SellerID.Text + ",'" + SellerPwd.Text + "','" + SellerName.Text + "','" + SellerPhone.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller added successfully.");
                Conn.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void populate()
        {
            string query = "select * from SellerTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0];
            Conn.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            populate();
        }

        private void SellerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SellerID.Text = SellerDGV.SelectedRows[0].Cells[0].Value.ToString();
            SellerPwd.Text = SellerDGV.SelectedRows[0].Cells[1].Value.ToString();
            SellerName.Text = SellerDGV.SelectedRows[0].Cells[2].Value.ToString();
            SellerPhone.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void SellerID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellerID.Text == "" || SellerPwd.Text == "" || SellerName.Text == "" || SellerPhone.Text == "")
                {
                    MessageBox.Show("Missing information.");
                }
                else
                {
                    Conn.Open();
                    string query = "Update SellerTable set SellerPwd='" + SellerPwd.Text + "',SellerName='" + SellerName.Text + "',SellerPhone='" + SellerPhone.Text + "' where SellerID=" + SellerID.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller successfully updated.");
                    Conn.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellerID.Text == "")
                {
                    MessageBox.Show("Select seller to delete");
                }
                else
                {
                    Conn.Open();
                    string query = "delete from SellerTable where SellerID=" + SellerID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller deleted.");
                    Conn.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }
    }
}
