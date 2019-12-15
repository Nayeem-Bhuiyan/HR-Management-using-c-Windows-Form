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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCountry con = new frmCountry();
            con.MdiParent = this;
            con.Show();
        }

        private void departmentEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartment dept = new frmDepartment();
            dept.MdiParent = this;
            dept.Show();
        }

        private void designationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDesignation desig = new frmDesignation();
            desig.MdiParent = this;
            desig.Show();
        }

        private void cityEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCity ct = new frmCity();
            ct.MdiParent = this;
            ct.Show();
        }

        private void genderEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGender gen = new frmGender();
            gen.MdiParent = this;
            gen.Show();
        }

        private void sectionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSection sec = new frmSection();
            sec.MdiParent = this;
            sec.Show();
        }

        private void religionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReligion rel = new frmReligion();
            rel.MdiParent = this;
            rel.Show();
        }

        private void employeeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee emp = new frmEmployee();
            emp.MdiParent = this;
            emp.Show();
        }

        private void designationWiseEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDesignationWiseEmployeeReport dr = new frmDesignationWiseEmployeeReport();
            dr.MdiParent = this;
            dr.Show();
        }
    }
}
