using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_HR_Management
{
    public partial class frmDesignationWiseEmployeeReport : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");
        public frmDesignationWiseEmployeeReport()
        {
            InitializeComponent();
        }

        private void frmDesignationWiseEmployeeReport_Load(object sender, EventArgs e)
        {
            LoadDesignation();
            LoadGrid();
        }
        private void LoadDesignation()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Distinct * FROM tblDesignation", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbDesignation.DisplayMember = ds.Tables[0].Columns["designationName"].ToString();
            cmbDesignation.ValueMember = ds.Tables[0].Columns["designationId"].ToString();
            cmbDesignation.DataSource = ds.Tables[0];
            con.Close();
        }

        private void LoadGrid()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Distinct e.employeeName,dg.designationName from tblEmployee e "+
                                                       "INNER JOIN tblDesignation dg ON e.designationId = dg.designationId "+
                                                       "where dg.designationId = "+cmbDesignation.SelectedValue+"", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            

        }
        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
