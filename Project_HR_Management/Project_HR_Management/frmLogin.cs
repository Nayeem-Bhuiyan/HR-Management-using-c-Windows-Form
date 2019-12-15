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

namespace Project_HR_Management
{
    public partial class frmLogin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {





            SqlCommand cmd = new SqlCommand("SELECT * FROM tblUser WHERE	userName='" + txtUserName.Text + "' AND password='" + txtPassword.Text + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            try
            {
                if (dt.Rows.Count > 0)
                {


                    new Form1().Show();
                    this.Hide();
                    MessageBox.Show("Login Successfully done And Welcome to Our Home Page!!");
                }
                if (txtUserName.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("UserName or Password can not be Empty");
                }
                if (dt.Rows.Count <= 0 & (txtUserName.Text != "" & txtPassword.Text != ""))
                {

                    MessageBox.Show("Invalid Password or UserName");

                }
                Clear();

            }
            catch (Exception)
            {

                MessageBox.Show("You are not valid User please registered First");
            }
            finally
            {

                con.Close();
            }
        }


        private void Clear()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAddUser ad = new frmAddUser();
            ad.Show();
        }
    }
}

