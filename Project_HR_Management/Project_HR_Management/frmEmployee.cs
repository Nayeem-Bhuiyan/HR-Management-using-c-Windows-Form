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
    public partial class frmEmployee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_MDB;Integrated Security=True");
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadCountry();
            loadDepartment();
            loadReligion();
            loadGender();
            loadSection();
            
        }


       

        private void loadSection()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblSection", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmbSection.DataSource = dt;
                cmbSection.DisplayMember = "sectionName";
                cmbSection.ValueMember = "sectionId";

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



        private void loadReligion()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblReligion", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmbReligion.DataSource = dt;
                cmbReligion.DisplayMember = "religionName";
                cmbReligion.ValueMember = "religionId";

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



        private void loadGender()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblGender", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmbGender.DataSource = dt;
                cmbGender.DisplayMember = "genderName";
                cmbGender.ValueMember = "genderId";

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





        private void LoadCountry()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblCountry",con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbCountry.DataSource = ds.Tables[0];
            cmbCountry.DisplayMember = ds.Tables[0].Columns["countryName"].ToString();
            cmbCountry.ValueMember = ds.Tables[0].Columns["countryId"].ToString();
           
            con.Close();
        }




        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(" Insert Into tblEmployee Values('" + txtName.Text + "', '" + txtAddress.Text + "', '" + dtpDOB.Value.ToString() + "', '" + txtPhone.Text+ "', '" + txtEmail.Text + "', " + Convert.ToInt32(txtSalary.Text) + ", '" + dtpJoiningDate.Value.ToString() + "', " + cmbDesignation.SelectedValue + ", " + cmbSection.SelectedValue + ", " + cmbDepartment.SelectedValue + ", " + cmbGender.SelectedValue + ", " + cmbReligion.SelectedValue + ", " + cmbCity.SelectedValue + ", " + cmbCountry.SelectedValue + ")", con);
                con.Open();

            int cmdValue =cmd.ExecuteNonQuery();
            if (cmdValue > 0)
            {
                MessageBox.Show("Data Inserted Successfully!!!");
            }
            else
            {
                MessageBox.Show("Data Not Inserted");
            }



                txtName.Clear();
                txtAddress.Clear();
                txtPhone.Clear();
                txtEmail.Clear();
                txtSalary.Clear();
                
                txtName.Focus();
              
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid formated data or Empty Field Error");
            }
            finally
            {
                con.Close();
            }
        }

        private void Clear()
        {
            txtAddress.Text="";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtSalary.Text = "";
            cmbCity.Text = "";
            cmbCountry.Text = "";
            cmbDesignation.Text = "";
            cmbGender.Text = "";
            cmbReligion.Text = "";
            cmbSection.Text= "";
            cmbDepartment.Text= "";
      
        }


 

        private void btnSearch_Click(object sender, EventArgs e)
        {



            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select " +
                    " e.employeeName,e.employeeAddress,e.employeeDOB,e.employeePhone,e.employeeEmail," +
                    "e.employeeCurrentSalary,e.employeeJoiningDate," +
                    "de.departmentName,dg.designationName,s.sectionName,g.genderName,r.religionName," +
                    "c.countryName,ci.cityName from tblEmployee e " +
                      "join tblCity ci on e.cityId = ci.cityId " +
                      "join tblCountry c on e.countryId = c.countryId " +
                      "join tblDepartment de on e.departmentId = de.departmentId " +
                      "join tblDesignation dg on e.designationId = dg.designationId " +
                      "join tblGender g on e.genderId = g.genderId " +
                      "join tblReligion r on e.religionId = r.religionId " +
                      "join tblSection s on e.sectionId = s.sectionId " +
                       "where e.employeeId = " + txtEmpIdSearch.Text + "", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
       

            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    txtName.Text = dr["employeeName"].ToString();
            //    txtAddress.Text = dr["employeeAddress"].ToString();
            //    dtpDOB.Text = dr["employeeDOB"].ToString();
            //    txtPhone.Text = dr["employeePhone"].ToString();
            //    txtEmail.Text = dr["employeeEmail"].ToString();
            //    txtSalary.Text = dr["employeeCurrentSalary"].ToString();
            //    dtpJoiningDate.Text = dr["employeeJoiningDate"].ToString();
            //    cmbDesignation.SelectedText = dr["designationName"].ToString();

            //    cmbCountry.SelectedText = dr["countryName"].ToString();
            //    //cmbCountry.SelectedValue= dr["countryId"].ToString();

            //    cmbCity.SelectedText = dr["cityName"].ToString();
            //    //cmbCity.SelectedText = dr["cityId"].ToString();
            //    cmbDepartment.SelectedText = dr["departmentName"].ToString();
            //    cmbSection.SelectedText = dr["sectionName"].ToString();
            //    cmbGender.SelectedText = dr["genderName"].ToString();
            //    cmbReligion.SelectedText= dr["religionName"].ToString();
            //}
           

           
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCity Where countryId=" + cmbCountry.SelectedValue + "", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cmbCity.DataSource = dt;

                    cmbCity.DisplayMember = "cityName";
                    cmbCity.ValueMember = "cityId";

                }
                else
                {
                    cmbCity.Text = "";

                }

            }
            catch (Exception)
            {

               
            }
            finally
            {
                con.Close();
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("SELECT designationId,designationName FROM tblDesignation where departmentId=" + cmbDepartment.SelectedValue + "", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    cmbDesignation.DataSource = dt;
                    cmbDesignation.DisplayMember = "designationName";
                    cmbDesignation.ValueMember = "designationId";
                }
                else
                {
                    cmbDesignation.Text="";
                }

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblEmployee where employeeId="+txtEmpIdSearch.Text+"", con);
                int cmdValue=cmd.ExecuteNonQuery();
                if (cmdValue>0)
                {
                    MessageBox.Show("Deleted Successfully!!!");
                }
                else
                {
                    MessageBox.Show("invalid Data or Empty field Error");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Not Deleted ");
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
      
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled =true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (char.IsUpper(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

        }



        private void cmbDesignation_MouseEnter(object sender, EventArgs e)
        {
            if (cmbDesignation.Text == "")
            {
                MessageBox.Show("No Designation entry found for the above  department ");
            }
        }



        private void cmbGender_MouseLeave(object sender, EventArgs e)
        {
            if (cmbGender.Text=="")
            {
                MessageBox.Show("No Entry of Gender has been Found ");
            }
        }

        private void cmbReligion_MouseHover(object sender, EventArgs e)
        {
            if (cmbReligion.Text=="")
            {
                MessageBox.Show("No Entry of Religion has been Found");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update tblEmployee"+
               " SET employeeName = '"+txtName.Text+"', employeeAddress = '"+txtAddress.Text+"', employeeCurrentSalary = "+(txtSalary.Text)+", employeeDOB = '"+dtpDOB.Value.ToString()+"', employeeEmail = '"+txtEmail.Text+"', employeeJoiningDate = '"+dtpJoiningDate.Value.ToString()+"', employeePhone = '"+txtPhone.Text+"', departmentId = "+cmbDepartment.SelectedValue+", sectionId = "+cmbSection.SelectedValue+", designationId = "+cmbDesignation.SelectedValue+", genderId = "+cmbGender.SelectedValue+", religionId = "+cmbReligion.SelectedValue+", countryId = "+cmbCountry.SelectedValue+", cityId = "+cmbCity+ " where employeeId = " + txtEmpIdSearch.Text + "", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Updated Successfully");


                txtAddress.Text = "";
                txtEmail.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
                txtSalary.Text = "";

            }
            catch (Exception)
            {

                MessageBox.Show("Not Updated ");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
