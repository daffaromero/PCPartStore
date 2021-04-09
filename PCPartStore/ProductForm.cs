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
    public partial class ProductForm : Form, Button
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Daffa Romero\Documents\pcpartsdb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void button2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        public void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seller slform = new Seller();
            slform.Show();
            this.Hide();
        }
        private void fillCombo()
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CatTable", Conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);
            CatCombo.ValueMember = "CatName";
            CatCombo.DataSource = dt;
            Conn.Close();
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            fillCombo();
            populate();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                Conn.Open();
                string query = "insert into ProdTable values(" + ProdID.Text + ",'" + ProdName.Text + "','" + ProdQty.Text + "','" + ProdPrice.Text + "','" + CatCombo.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product added successfully.");
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
            string query = "select * from ProdTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV.DataSource = ds.Tables[0];
            Conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProdDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdID.Text = ProdDGV.SelectedRows[0].Cells[0].Value.ToString();
            ProdName.Text = ProdDGV.SelectedRows[0].Cells[1].Value.ToString();
            ProdQty.Text = ProdDGV.SelectedRows[0].Cells[2].Value.ToString();
            ProdPrice.Text = ProdDGV.SelectedRows[0].Cells[3].Value.ToString();
            CatCombo.SelectedValue = ProdDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        void FilterCategory()
        {
            try
            {
                Conn.Open();
                string query = "select * from ProdTable where ProdCat=='" + CatCombo.SelectedIndex.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                ProdDGV.DataSource = ds.Tables[0];
                Conn.Close();
            }
            catch
            {

            }
        }
        private void CatCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProdID.Text == "" || ProdName.Text == "" || ProdQty.Text == "" || ProdPrice.Text == "")
                {
                    MessageBox.Show("Missing information.");
                }
                else
                {
                    Conn.Open();
                    string query = "Update ProdTable set ProdName='" + ProdName.Text + "',ProdQty='" + ProdQty.Text + "',ProdPrice='" + ProdPrice.Text + "' where ProdID=" + ProdID.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product successfully updated.");
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
                if (ProdID.Text == "")
                {
                    MessageBox.Show("Select product to delete");
                }
                else
                {
                    Conn.Open();
                    string query = "delete from ProdTable where ProdID=" + ProdID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted.");
                    Conn.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellingForm sell = new SellingForm();
            sell.Show();
            this.Hide();
        }
    }
}
