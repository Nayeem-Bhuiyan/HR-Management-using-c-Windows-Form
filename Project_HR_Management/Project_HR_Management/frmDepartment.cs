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
    public partial class frmDepartment : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");

        public frmDepartment()
        {
            InitializeComponent();
        }

        private void btnDepInsert_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert Into tblDepartment Values('" + txtDepName.Text + "')";
                cmd.ExecuteNonQuery();
                lblMsgShow.Text = "Data Insert Successfully";
                txtDepName.Clear();
                txtDepName.Focus();
            }
            catch (Exception)
            {

                lblMsgShow.Text = "Data not Saved";
            }
            finally
            {
                con.Close();
            }

           
        }

        private void loadDepartment()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblDepartment", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmbDepartment.DataSource = dt;
                cmbDepartment.DisplayMember = "departmentName";
                cmbDepartment.ValueMember = "departmentId";

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }










        private void txtDepName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
           
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            loadDepartment();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update tblDepartment Set departmentName='" + txtDepName.Text + "'" +
                " Where departmentId=" + cmbDepartment.SelectedValue + "", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated Successfully");
                txtDepName.Clear();
                txtDepName.Focus();
            }
            catch (Exception)
            {

                MessageBox.Show("Select Department First which you want to Update ");
            }
            finally
            {
                con.Close();
            }
        }

      
    }
}
