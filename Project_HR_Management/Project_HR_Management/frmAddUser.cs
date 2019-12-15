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
    public partial class frmAddUser : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");


        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblUser VALUES('" + txtUserName.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + txtContact.Text + "')", con);

            try
            {
                if (txtUserName.Text != "" & txtPassword.Text != "" & txtEmail.Text != "" & txtContact.Text != "")
                {
                    cmd.ExecuteNonQuery();

                    this.Hide();
                    new frmLogin().Show();
                    MessageBox.Show("Registration Successfully done and Now Please Login here!!");
                }
                else
                {
                    MessageBox.Show("Please give your Information");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Data not Saved due to invalid formate Data or connection error");

            }
            finally
            {
                con.Close();
            }
        }
    }
}
