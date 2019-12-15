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
    public partial class frmDesignation : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");
        public frmDesignation()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert Into tblDesignation Values('" + txtDesigName.Text + "','"+cmbDepartment.SelectedValue+"')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Inserted Successfully!!!");
            txtDesigName.Clear();
            txtDesigName.Focus();
            con.Close();
        }

        private void frmDesignation_Load(object sender, EventArgs e)
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

        private void txtDesigName_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
