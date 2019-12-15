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
    
    public partial class frmCity : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");
        public frmCity()
        {
            InitializeComponent();
        }








        private void frmCity_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblCountry", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmbCountry.DataSource = dt;
                cmbCountry.DisplayMember = "countryName";
                cmbCountry.ValueMember = "countryId";
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






        private void button1_Click(object sender, EventArgs e)
        {
          
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert Into tblCity Values('"+txtCityName.Text+"','"+cmbCountry.SelectedValue+"')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Inserted Successfully");
            txtCityName.Clear();
            txtCityName.Focus();
            con.Close();
            con.Close();
        }

        private void txtCityName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCityName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
