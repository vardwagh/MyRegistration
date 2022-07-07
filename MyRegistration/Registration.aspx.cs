using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyRegistration
{
    public partial class Registration : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                MvRegistration.ActiveViewIndex = 0;
                btnDepInfo.Enabled = false;
                btnFinalize.Enabled = false;

                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("Departments.xml"));
                ddlDepartment.DataTextField = "DeptName";
                ddlDepartment.DataValueField = "DeptID";
                ddlDepartment.DataSource = ds;
                ddlDepartment.DataBind();

                btnMyInfo.ForeColor = System.Drawing.Color.DeepSkyBlue;

                ViewState["DataSaved"] = "false";

            }



            for (var i = 0; i < 100; i++)
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();
                item.Value = i.ToString();
                ddlFatherAge.Items.Add(item);
                ddlFatherILAge.Items.Add(item);
                ddlMotherAge.Items.Add(item);
                ddlMotherILAge.Items.Add(item);
            }

        }

        protected void btnMyInfo_Click(object sender, EventArgs e)
        {
            MvRegistration.ActiveViewIndex = 0;
            btnDepInfo.ForeColor = System.Drawing.Color.Gray;
            btnFinalize.ForeColor = System.Drawing.Color.Gray;
            btnMyInfo.ForeColor = System.Drawing.Color.DeepSkyBlue;
        }

        protected void btnDepInfo_Click(object sender, EventArgs e)
        {
            MvRegistration.ActiveViewIndex = 1;
            btnMyInfo.ForeColor = System.Drawing.Color.Gray;
            btnFinalize.ForeColor = System.Drawing.Color.Gray;
            btnDepInfo.ForeColor = System.Drawing.Color.DeepSkyBlue;
        }

        protected void btnFinal_Click(object sender, EventArgs e)
        {
            MvRegistration.ActiveViewIndex = 2;
            btnDepInfo.ForeColor = System.Drawing.Color.Gray;
            btnMyInfo.ForeColor = System.Drawing.Color.Gray;
            btnFinalize.ForeColor = System.Drawing.Color.DeepSkyBlue;
        }

        protected void cblChild_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNameChild1.Enabled = false;
            txtNameChild1.Text = "";
            txtDOBChild1.Enabled = false;
            txtDOBChild1.Text = "";
            ddlrelationChild1.Enabled = false;
            ddlrelationChild1.SelectedValue = "";
            txtNameChild2.Enabled = false;
            txtNameChild2.Text = "";
            txtDOBChild2.Enabled = false;
            txtDOBChild2.Text = "";
            ddlrelationChild2.Enabled = false;
            ddlrelationChild2.SelectedValue = "";
            txtNameChild3.Enabled = false;
            txtNameChild3.Text = "";
            txtDOBChild3.Enabled = false;
            txtDOBChild3.Text = "";
            ddlrelationChild3.Enabled = false;
            ddlrelationChild3.SelectedValue = "";
            txtNameChild4.Enabled = false;
            txtNameChild4.Text = "";
            txtDOBChild4.Enabled = false;
            txtDOBChild4.Text = "";
            ddlrelationChild4.Enabled = false;
            ddlrelationChild4.SelectedValue = "";
            lblAgeChild1.Text = "";
            lblAgeChild2.Text = "";
            lblAgeChild3.Text = "";
            lblAgeChild4.Text = "";


            foreach (ListItem item in cblChild.Items)
            {
                if (item.Selected)
                {
                    switch (item.Text)
                    {
                        case "Child 1":
                            txtNameChild1.Enabled = true;
                            txtDOBChild1.Enabled = true;
                            ddlrelationChild1.Enabled = true;
                            break;
                        case "Child 2":
                            txtNameChild2.Enabled = true;
                            txtDOBChild2.Enabled = true;
                            ddlrelationChild2.Enabled = true;
                            break;
                        case "Child 3":
                            txtNameChild3.Enabled = true;
                            txtDOBChild3.Enabled = true;
                            ddlrelationChild3.Enabled = true;
                            break;
                        case "Child 4":
                            txtNameChild4.Enabled = true;
                            txtDOBChild4.Enabled = true;
                            ddlrelationChild4.Enabled = true;
                            break;
                    }
                }
                else 
                {
                    switch (item.Text)
                    {
                        case "Child 1":
                            lblErrChild1.Text = "";
                            break;
                        case "Child 2":
                            lblErrChild2.Text = "";
                            break;
                        case "Child 3":
                            lblErrChild3.Text = "";
                            break;
                        case "Child 4":
                            lblErrChild4.Text = "";
                            break;
                    }
                }
            }

           
        }



        protected void ddlFatherAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFatherAge.Text = ddlFatherAge.SelectedItem.Value.ToString();
        }

        protected void cbfatherDOB_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfatherDOB.Checked)
            {
                ddlFatherAge.Visible = true;
                txtFatherDOB.Enabled = false;
                txtFatherDOB.Text = "";
                lblFatherAge.Text = "";
            }
            else 
            {
                ddlFatherAge.Visible = false;
                txtFatherDOB.Enabled = true;
                lblFatherAge.Text = "";
            }
        }

        protected void cblParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFatherName.Enabled = false;
            txtFatherDOB.Enabled = false;
            cbfatherDOB.Enabled = false;
            txtMotherName.Enabled = false;
            txtMotherDOB.Enabled = false;
            cbMotherDOB.Enabled = false;
            txtFatherILName.Enabled = false;
            txtFatherILDOB.Enabled = false;
            cbfatherILDOB.Enabled = false;
            txtMotherILName.Enabled = false;
            txtMotherILDOB.Enabled = false;
            cbMotherILDOB.Enabled = false;
            lblFatherAge.Text = "";
            lblMotherAge.Text = "";
            lblFatherILAge.Text = "";
            lblMotherILAge.Text = "";

            txtFatherName.Text = "";
            txtFatherDOB.Text = "";
            cbfatherDOB.Checked = false;
            txtMotherName.Text = "";
            txtMotherDOB.Text = "";
            cbMotherDOB.Checked = false;
            txtFatherILName.Text = "";
            txtFatherILDOB.Text = "";
            cbfatherILDOB.Checked = false;
            txtMotherILName.Text = "";
            txtMotherILDOB.Text = "";
            cbMotherILDOB.Checked = false;

            foreach (ListItem item in cblParent.Items)
            {
                if (item.Selected)
                {
                    switch (item.Text)
                    {
                        case "Father":
                            txtFatherName.Enabled = true;
                            txtFatherDOB.Enabled = true;
                            cbfatherDOB.Enabled = true;
                            break;
                        case "Mother":
                            txtMotherName.Enabled = true;
                            txtMotherDOB.Enabled = true;
                            cbMotherDOB.Enabled = true;
                            break;
                        case "Father In Law":
                            txtFatherILName.Enabled = true;
                            txtFatherILDOB.Enabled = true;
                            cbfatherILDOB.Enabled = true;
                            break;
                        case "Mother In Law":
                            txtMotherILName.Enabled = true;
                            txtMotherILDOB.Enabled = true;
                            cbMotherILDOB.Enabled = true;
                            break;
                    }
                }
                else
                {
                    switch (item.Text)
                    {
                        case "Father":
                            lblFatherErr.Text = "";
                            ddlFatherAge.Visible = false;
                            break;
                        case "Mother":
                            lblMotherErr.Text = "";
                            ddlMotherAge.Visible = false;
                            break;
                        case "Father In Law":
                            lblFatherILErr.Text = "";
                            ddlFatherILAge.Visible = false;
                            break;
                        case "Mother In Law":
                            lblMotherILErr.Text = "";
                            ddlMotherILAge.Visible = false;
                            break;
                    }

                }
            }
        }

        protected void btnSaveNext1_Click(object sender, EventArgs e)
        {

            String regID = LblRegistrationID.Text.ToString();
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MyInfoDb.mdf;Integrated Security=True;User Instance=True");
            SqlCommand cmd = new SqlCommand("spSavesUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (regID == "")
            {
                cmd.Parameters.AddWithValue("lblRegistrationID", 0);
            }
            else 
            {
                cmd.Parameters.AddWithValue("lblRegistrationID", Convert.ToInt32(regID));
            }
            cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text.ToString());
            cmd.Parameters.AddWithValue("MiddleName", txtMiddleName.Text.ToString());
            cmd.Parameters.AddWithValue("LastName", txtLastName.Text.ToString());
            cmd.Parameters.AddWithValue("DOB", txtDOB.Text).ToString();
            cmd.Parameters.AddWithValue("Age", lblAge.Text.ToString());
            cmd.Parameters.AddWithValue("Department", ddlDepartment.SelectedItem.Text);
            cmd.Parameters.AddWithValue("DOJ", txtDOJ.Text.ToString());
            cmd.Parameters.AddWithValue("GrossSalary", txtGrossSal.Text.ToString());
            cmd.Parameters.AddWithValue("Taxpct", ddlTax.Text.ToString());
            cmd.Parameters.AddWithValue("NetSalary", lblNetSalary.Text.ToString());
            cmd.Parameters.AddWithValue("DML_TS", System.DateTime.Now.ToString());
            cmd.Parameters.Add("@RegistrationID", SqlDbType.Int,1000);
            cmd.Parameters["@RegistrationID"].Direction = ParameterDirection.Output;
            con.Open();
            try
            {
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    LblRegistrationID.Text = cmd.Parameters["@RegistrationID"].Value.ToString();
                    //lblSuccessfull.Text = "Details Saved Successfully..!";
                    //lblSuccessfull.ForeColor = System.Drawing.Color.Green;
                    btnDepInfo.Enabled = true;
                    MvRegistration.ActiveViewIndex = 1;
                    Label30.Visible = true;
                    btnDepInfo.ForeColor = System.Drawing.Color.DeepSkyBlue;
                    btnMyInfo.ForeColor = System.Drawing.Color.Gray;
                }else
                {
                    lblSuccessfull.Text = "Data Not Saved";
                }
            }
            catch (Exception )
            {

                throw;
            }
            finally
            { 
                con.Close(); 
            
            }
            
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            String dob = txtDOB.Text;
            String lblID = lblAge.ID.ToString();

           int age = calculateAge(dob);
            lblAge.Text = age.ToString() ;

        }

        protected int calculateAge(String dob)
        {
            int totalAge = 0;
            if (dob == "")
            { 
                
            }
            else { 

            String currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            DateTime dob1 = Convert.ToDateTime(dob);
            DateTime cdate = Convert.ToDateTime(currentDate);
            TimeSpan time = cdate.Subtract(dob1);
             totalAge = (time.Days) / 365;
            }
            return totalAge;
        }

        protected void ddlTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            String tax = ddlTax.SelectedValue.ToString();
            if (tax == "")
            {
                lblNetSalary.Text = "";
            }
            else
            {
                if (txtGrossSal.Text.ToString() != "")
                {
                    
                    int grossSal = Int32.Parse(txtGrossSal.Text.ToString());
                    int taxP = Int32.Parse(tax);
                    int totalTax = (taxP * grossSal) / 100;
                    int netSal = grossSal - totalTax;
                    lblNetSalary.Text = netSal.ToString();
                }
                else 
                {
                    lblNetSalary.Text = "";
                }
                
            }
            
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtDOB.Text = "";
            ddlDepartment.SelectedIndex = 0;

            txtDOJ.Text = "";
            txtGrossSal.Text = "";
            ddlTax.SelectedValue = "";
            lblNetSalary.Text = "";
            lblAge.Text = "";
        }

        protected void txtSpouceDOB_TextChanged(object sender, EventArgs e)
        {
            String dob = txtSpouceDOB.Text;
            int age = calculateAge(dob);
            lblSpouceAge.Text = age.ToString();
        }

        protected void txtDOBChild1_TextChanged(object sender, EventArgs e)
        {
            String dob = txtDOBChild1.Text;
            int age = calculateAge(dob);
            lblAgeChild1.Text = age.ToString();
        }

        protected void txtDOBChild2_TextChanged(object sender, EventArgs e)
        {
            String dob = txtDOBChild2.Text;
            int age = calculateAge(dob);
            lblAgeChild2.Text = age.ToString();
        }

        protected void txtDOBChild3_TextChanged(object sender, EventArgs e)
        {
            String dob = txtDOBChild3.Text;
            int age = calculateAge(dob);
            lblAgeChild3.Text = age.ToString();
        }

        protected void txtDOBChild4_TextChanged(object sender, EventArgs e)
        {
            String dob = txtDOBChild4.Text;
            int age = calculateAge(dob);
            lblAgeChild4.Text = age.ToString();
        }

        protected void txtFatherDOB_TextChanged(object sender, EventArgs e)
        {
            String dob = txtFatherDOB.Text;
            int age = calculateAge(dob);
            lblFatherAge.Text = age.ToString();
        }

        protected void txtMotherDOB_TextChanged(object sender, EventArgs e)
        {
            String dob = txtMotherDOB.Text;
            int age = calculateAge(dob);
            lblMotherAge.Text = age.ToString();
        }

        protected void txtFatherILDOB_TextChanged(object sender, EventArgs e)
        {
            String dob = txtFatherILDOB.Text;
            int age = calculateAge(dob);
            lblFatherILAge.Text = age.ToString();
        }

        protected void txtMotherILDOB_TextChanged(object sender, EventArgs e)
        {
            String dob = txtMotherILDOB.Text;
            int age = calculateAge(dob);
            lblMotherILAge.Text = age.ToString();
        }

        protected void ddlMotherAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMotherAge.Text = ddlMotherAge.SelectedItem.Value.ToString();
        }

        protected void ddlFatherILAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFatherILAge.Text = ddlFatherILAge.SelectedItem.Value.ToString();
        }

        protected void ddlMotherILAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMotherILAge.Text = ddlMotherILAge.SelectedItem.Value.ToString();
        }

        protected void cbMotherDOB_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMotherDOB.Checked)
            {
                ddlMotherAge.Visible = true;
                txtMotherDOB.Enabled = false;
                txtMotherDOB.Text = "";
                lblMotherAge.Text = "";
            }
            else
            {
                ddlMotherAge.Visible = false;
                txtMotherDOB.Enabled = true;
                lblMotherAge.Text = "";
            }
        }

        protected void cbfatherILDOB_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfatherILDOB.Checked)
            {
                ddlFatherILAge.Visible = true;
                txtFatherILDOB.Enabled = false;
                txtFatherILDOB.Text = "";
                lblFatherILAge.Text = "";
            }
            else
            {
                ddlFatherILAge.Visible = false;
                txtFatherILDOB.Enabled = true;
                lblFatherILAge.Text = "";
            }
        }

        protected void cbMotherILDOB_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMotherILDOB.Checked)
            {
                ddlMotherILAge.Visible = true;
                txtMotherILDOB.Enabled = false;
                txtMotherILDOB.Text = "";
                lblMotherILAge.Text = "";
            }
            else
            {
                ddlMotherILAge.Visible = false;
                txtMotherILDOB.Enabled = false;
                lblMotherILAge.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected bool CustomValidator1_ServerValidate(DataTable dt, int regID)
        {
            lblErrChild1.Text = "";
            lblErrChild2.Text = "";
            lblErrChild3.Text = "";
            lblErrChild4.Text = "";
            bool isvalid = true;
            foreach (ListItem item in cblChild.Items)
            {
                if (item.Selected)
                {
                    switch (item.Text)
                    {
                        case "Child 1":
                            if (txtNameChild1.Text == "" || txtDOBChild1.Text == "" || ddlrelationChild1.SelectedItem.Text == "Select")
                            {
                                lblErrChild1.Text = "Please select All details for Child 1";
                                isvalid = false;
                            }
                            else
                            {
                                lblErrChild1.Text = "";
                                isvalid = true;
                                dt.Rows.Add(regID, "Child 1", txtNameChild1.Text.ToString(), txtDOBChild1.Text.ToString(), lblAgeChild1.Text.ToString(), ddlrelationChild1.SelectedItem.Text.ToString());

                            }
                            break;
                        case "Child 2":
                            if (txtNameChild2.Text == "" || txtDOBChild2.Text == "" || ddlrelationChild2.SelectedItem.Text == "Select")
                            {
                                lblErrChild2.Text = "Please select All details for Child 2";
                                isvalid = false;


                            }
                            else
                            {
                                lblErrChild2.Text = "";
                                isvalid = true;
                                dt.Rows.Add(regID, "Child 2", txtNameChild2.Text.ToString(), txtDOBChild2.Text.ToString(), lblAgeChild2.Text.ToString(), ddlrelationChild2.SelectedItem.Text.ToString());
                            }
                            break;
                        case "Child 3":
                            if (txtNameChild3.Text == "" || txtDOBChild3.Text == "" || ddlrelationChild3.SelectedItem.Text == "Select")
                            {
                                lblErrChild3.Text = "Please select All details for Child 3";
                                isvalid = false;
                            }
                            else
                            {
                                lblErrChild3.Text = "";
                                isvalid = true;
                                dt.Rows.Add(regID, "Child 3", txtNameChild3.Text.ToString(), txtDOBChild3.Text.ToString(), lblAgeChild3.Text.ToString(), ddlrelationChild3.SelectedItem.Text.ToString());
                            }
                            break;
                        case "Child 4":
                            if (txtNameChild4.Text == "" || txtDOBChild4.Text == "" || ddlrelationChild4.SelectedItem.Text == "Select")
                            {
                                lblErrChild4.Text = "Please select All details for Child 4";
                                isvalid = false;
                            }
                            else
                            {
                                lblErrChild4.Text = "";
                                isvalid = true;
                                dt.Rows.Add(regID, "Child 4", txtNameChild4.Text.ToString(), txtDOBChild4.Text.ToString(), lblAgeChild4.Text.ToString(), ddlrelationChild4.SelectedItem.Text.ToString());
                            }
                            break;
                    }
                }
               
            }

            return isvalid;
        }

        protected bool CustomValidator2_ServerValidate(DataTable dt, int regID)
        {
            lblFatherErr.Text = "";
            lblMotherErr.Text = "";
            lblFatherILErr.Text = "";
            lblMotherILErr.Text = "";
            bool isvalid = true;
            foreach (ListItem item in cblParent.Items)
            {
                if (item.Selected)
                {
                    switch (item.Text)
                    {
                        case "Father":
                            if (txtFatherName.Text == "" || lblFatherAge.Text == "")
                            {
                                lblFatherErr.Text = "Please select All details for Father";
                                isvalid = false;
                            }
                            else
                            {
                                lblFatherErr.Text = "";
                                isvalid = true;
                                dt.Rows.Add(regID, "Father", txtFatherName.Text.ToString(), txtFatherDOB.Text.ToString(), lblFatherAge.Text.ToString(), "Father");
                            }
                            break;
                        case "Mother":
                            if (txtMotherName.Text == "" || lblMotherAge.Text == "")
                            {
                                lblMotherErr.Text = "Please select All details for Mother";
                                isvalid = false;
                            }
                            else
                            {
                                lblMotherErr.Text = "";
                                isvalid = true;
                                dt.Rows.Add(regID, "Mother", txtMotherName.Text.ToString(), txtMotherDOB.Text.ToString(), lblMotherAge.Text.ToString(), "Mother");
                            }
                            break;
                        case "Father In Law":
                            if (txtFatherILName.Text == "" || lblFatherILAge.Text == "")
                            {
                                lblFatherILErr.Text = "Please select All details for Father In Law";
                                isvalid = false;
                            }
                            else
                            {
                                lblFatherILErr.Text = "";
                                isvalid = true;
                                dt.Rows.Add(regID, "Father In Law", txtFatherILName.Text.ToString(), txtFatherILDOB.Text.ToString(), lblFatherILAge.Text.ToString(), "Father In Law");
                            }
                            break;
                        case "Mother In Law":
                            if (txtMotherILName.Text == "" || lblMotherILAge.Text == "")
                            {
                                lblMotherILErr.Text = "Please select All details for Mother In Law";
                                isvalid = false;
                            }
                            else
                            {
                                lblMotherILErr.Text = "";
                                isvalid = true;
                                dt.Rows.Add(regID, "Mother In Law", txtMotherILName.Text.ToString(), txtMotherILDOB.Text.ToString(), lblMotherILAge.Text.ToString(), "Mother In Law");
                            }
                            break;
                    }
                }
               
            }

            return isvalid;
        }

        public void btnSaveNext2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RegistrationID");
            dt.Columns.Add("FamilyMember");
            dt.Columns.Add("MemberName");
            dt.Columns.Add("MemberDOB");
            dt.Columns.Add("MemberAge");
            dt.Columns.Add("MemberRelation");

            int RegID = Convert.ToInt32(LblRegistrationID.Text.ToString());
            //int RegID = 101;
            dt.Rows.Add(RegID, "Spouse", txtSpouceName.Text.ToString(), txtSpouceDOB.Text.ToString(), lblSpouceAge.Text.ToString(), "Spouse");
            bool isvalid1 = CustomValidator1_ServerValidate(dt, RegID);
            bool isvalid2 = CustomValidator2_ServerValidate(dt, RegID);
            if (isvalid1 && isvalid2)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
                btnFinalize.Enabled = true;
                btnDepInfo.Enabled = true;
                ViewState["table"] = dt;
                
                


                const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MyInfoDb.mdf;Integrated Security=True;User Instance=True";
                SqlConnection con1 = new SqlConnection(CONNECTION_STRING);
                SqlCommand cmd = new SqlCommand(("DELETE FROM UserDependent WHERE REGISTRATIONID=@RegID"), con1);
                cmd.Parameters.AddWithValue("@RegID", Convert.ToInt32(LblRegistrationID.Text.ToString()));
                con1.Open();
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con1.Close();
                }

                using (var bulkCopy = new SqlBulkCopy(CONNECTION_STRING, SqlBulkCopyOptions.KeepIdentity))
                {

                    try
                    {
                        //DataTable dt = (DataTable)ViewState["table"];

                        bulkCopy.BulkCopyTimeout = 600;
                        bulkCopy.DestinationTableName = "UserDependent";
                        bulkCopy.WriteToServer(dt);

                        MvRegistration.ActiveViewIndex = 2;
                        btnDepInfo.ForeColor = System.Drawing.Color.Gray;
                        btnFinalize.ForeColor = System.Drawing.Color.DeepSkyBlue;

                        

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {

                    }


                }


            }
        }
        
        protected void btnFinalizeblock_Click(object sender, EventArgs e)
        {
            //const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MyInfoDb.mdf;Integrated Security=True;User Instance=True";
            //SqlConnection con1 = new SqlConnection(CONNECTION_STRING);
            //SqlCommand cmd = new SqlCommand(("DELETE FROM UserDependent WHERE REGISTRATIONID=@RegID"), con1);
            //cmd.Parameters.AddWithValue("@RegID", Convert.ToInt32(LblRegistrationID.Text.ToString()));
            //con1.Open();
            //try
            //{
            //    int rows = cmd.ExecuteNonQuery();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    con1.Close();
            //}

            //using (var bulkCopy = new SqlBulkCopy(CONNECTION_STRING, SqlBulkCopyOptions.KeepIdentity))
            //    {

            //    try
            //    {
            //        DataTable dt = (DataTable)ViewState["table"];

            //        bulkCopy.BulkCopyTimeout = 600;
            //        bulkCopy.DestinationTableName = "UserDependent";
            //        bulkCopy.WriteToServer(dt);

            //        btnMyInfo.Enabled = false;
            //        btnDepInfo.Enabled = false;
            //        btnFinalize.Enabled = false;
            //        btnFinalizeblock.Enabled = false;
            //        lblMessage.Text = "Details Saved, Please Note Registration ID for future reference.";

            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //    finally
            //    {

            //    }


            //}  


            btnMyInfo.Enabled = false;
            btnDepInfo.Enabled = false;
            btnFinalize.Enabled = false;
            btnFinalizeblock.Enabled = false;
            lblMessage.Text = "Please Note Registration ID for future reference.";

        }

        protected void btnClear2_Click(object sender, EventArgs e)
        {
            txtSpouceDOB.Text = "";
            txtSpouceName.Text = "";
            lblSpouceAge.Text = "";

            foreach (ListItem item in cblChild.Items)
            {
                item.Selected = false;
            }
            cblChild_SelectedIndexChanged(sender,e);
            foreach (ListItem item in cblParent.Items)
            {
                item.Selected = false;
            }
            cblParent_SelectedIndexChanged(sender, e);

        }
    }
}