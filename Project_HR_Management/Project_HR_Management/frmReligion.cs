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
    public partial class frmReligion : Form
    {
        public frmReligion()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert Into tblReligion Values('" + txtReligionName.Text + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Inserted Successfully!!!");
            txtReligionName.Clear();
            txtReligionName.Focus();
            con.Close();
        }

        private void txtReligionName_KeyPress(object sender, KeyPressEventArgs e)
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
