using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCPartStore
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PwdTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UnameTb.Text=="" || PwdTb.Text=="")
            {
                MessageBox.Show("Enter your data!");
            }
            else
            {
                if (RoleCombo.SelectedIndex > -1)
                {


                    if (RoleCombo.SelectedItem.ToString() == "Admin")
                    {
                        if (UnameTb.Text == "Admin" && PwdTb.Text == "Admin")
                        {
                            ProductForm prod = new ProductForm();
                            prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Nice try lol.");
                        }
                    }
                    else if (RoleCombo.SelectedItem.ToString() == "Seller")
                    {
                        MessageBox.Show("You are a seller.");
                    }
                    else
                    {
                        MessageBox.Show("Please select a role.");
                    }
                }
            }
        }
    }
}
