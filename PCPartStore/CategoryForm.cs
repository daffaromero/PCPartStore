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
    public partial class CategoryForm : Form, Button
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Daffa Romero\Documents\pcpartsdb.mdf;Integrated Security=True;Connect Timeout=30");
        public void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                string query = "insert into CatTable values("+CatIDTb.Text+",'"+CatNameTb.Text+"','"+CatDescTb.Text+"')";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category added successfully.");
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
            Conn.Open();
            string query = "select * from CatTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CatDGV.DataSource = ds.Tables[0];
            Conn.Close();
        }

        private void CategoryForm_Load_1(object sender, EventArgs e)
        {
            populate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatIDTb.Text = CatDGV.SelectedRows[0].Cells[0].Value.ToString();
            CatNameTb.Text = CatDGV.SelectedRows[0].Cells[1].Value.ToString();
            CatDescTb.Text = CatDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        public void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if(CatIDTb.Text == "")
                {
                    MessageBox.Show("Select category to delete");
                } else
                {
                    Conn.Open();
                    string query = "delete from CatTable where CatID=" + CatIDTb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category deleted.");
                    Conn.Close();
                    populate();
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatIDTb.Text == "" || CatNameTb.Text == "" || CatDescTb.Text == "")
                {
                    MessageBox.Show("Missing information.");
                } else
                {
                    Conn.Open();
                    string query = "Update CatTable set CatName='" + CatNameTb.Text + "',CatDesc='" + CatDescTb.Text + "' where CatID=" + CatIDTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category successfully updated.");
                    Conn.Close();
                    populate();
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void CatIDTb_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seller slform = new Seller();
            slform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellingForm sell = new SellingForm();
            sell.Show();
            this.Hide();
        }
    }
}
