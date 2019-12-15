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
    public partial class frmGender : Form
    {
        public frmGender()
        {
            InitializeComponent();
        }

        private void frmGender_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert Into tblGender values('" + txtGenderName.Text + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Inserted Successfully!!!");
            txtGenderName.Clear();
            txtGenderName.Focus();
            con.Close();

        }

        private void txtGenderName_KeyPress(object sender, KeyPressEventArgs e)
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
