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
    public partial class frmCountry : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");
        public frmCountry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert Into tblCountry Values('" + txtCountryName.Text + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            lblMsgShow.Text = "Data Inserted Successfully";
            txtCountryName.Clear();
            txtCountryName.Focus();
            con.Close();

            cmbCountry.ResumeLayout();
            

        }

        private void LoadCountry()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblCountry", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbCountry.DataSource = ds.Tables[0];
            cmbCountry.DisplayMember = ds.Tables[0].Columns["countryName"].ToString();
            cmbCountry.ValueMember = ds.Tables[0].Columns["countryId"].ToString();

            con.Close();
        }

        private void txtCountryName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmCountry_Load(object sender, EventArgs e)
        {
            LoadCountry();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblCountry where countryId=" + cmbCountry.SelectedValue + "", con);
                int cmdValue = cmd.ExecuteNonQuery();
                if (cmdValue > 0)
                {
                    MessageBox.Show("Deleted Successfully!!!");
                }
                else
                {
                    MessageBox.Show("select Country for delete");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Not Deleted ");
            }
        }
    }
}
