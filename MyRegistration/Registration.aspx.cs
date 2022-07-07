using System;
using System.Collections.Generic;
using System.Configuration;
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
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {
                if (!IsPostBack)
                {


                    lblmobile.Text = "Welcome " + Session["User"].ToString();
                    FillDepartmentddl();
                    FillAgeddl();

                    //ViewState["DataSaved"] = "false";


                    if (Session["RegisterID"].ToString() != "0")
                    {
                        Label30.Visible = true;
                        string regID1 = Session["RegisterID"].ToString();
                        string rmobile1 = Session["RegisterID"].ToString();
                        LblRegistrationID.Text = regID1;
                        int[] stg = GetStageStatus(rmobile1, regID1);

                        if (stg[0] == 0 && stg[1] == 0 && stg[2] == 0)
                        {
                            MvRegistration.ActiveViewIndex = 0;
                            btnDepInfo.Enabled = false;
                            btnFinalize.Enabled = false;
                            btnMyInfo.ForeColor = System.Drawing.Color.DeepSkyBlue;
                        }
                        else if (stg[0] == 1 && stg[1] == 0 && stg[2] == 0)
                        {
                            MvRegistration.ActiveViewIndex = 1;
                            btnDepInfo.Enabled = true;
                            btnFinalize.Enabled = false;
                            btnDepInfo.ForeColor = System.Drawing.Color.DeepSkyBlue;
                            LoadControls(regID1);

                        }
                        else if (stg[0] == 1 && stg[1] == 1 && stg[2] == 0)
                        {
                            MvRegistration.ActiveViewIndex = 2;
                            btnMyInfo.Enabled = true;
                            btnDepInfo.Enabled = true;
                            btnFinalize.Enabled = true;
                            btnFinalize.ForeColor = System.Drawing.Color.DeepSkyBlue;
                            LoadControls(regID1);
                            LoadDependentControls(regID1);

                        }
                        else if (stg[0] == 1 && stg[1] == 1 && stg[2] == 1)
                        {
                            MvRegistration.ActiveViewIndex = 2;
                            btnMyInfo.Enabled = false;
                            btnDepInfo.Enabled = false;
                            btnFinalize.Enabled = false;
                            //btnFinalize.ForeColor = System.Drawing.Color.DeepSkyBlue;
                            btnFinalizeblock.Enabled = false;
                            //LoadControls(regID1);
                            //LoadDependentControls(regID1);
                            LoadFinalGridView(regID1);
                            lblMessage.Text = "Application is Completed!";
                        }
                    }
                    else
                    {
                        MvRegistration.ActiveViewIndex = 0;
                        btnDepInfo.Enabled = false;
                        btnFinalize.Enabled = false;
                        btnMyInfo.ForeColor = System.Drawing.Color.DeepSkyBlue;
                    }
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        } 
        #endregion

        #region Private Methods
        private void LoadFinalGridView(string regID1)
        {
            //SqlConnection con = null;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
            try
            {
                //const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyInfoDb;user ID=vardhanDB;Password=V@rdhan9764";
                //con = new SqlConnection(CONNECTION_STRING);
                SqlDataAdapter adapter = new SqlDataAdapter("Select FamilyMember,MemberName,MemberDOB,MemberAge,MemberRelation from UserDependent WHERE RegistrationID=" + regID1, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception e)
            {

            }
            // Closing the connection  
            finally

            {
                con.Close();
            }
        }
        private int[] GetStageStatus(string mobile, string regID1)
        {
            int[] stages = new int[3];
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
            string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["constring"].ToString();
            //const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyInfoDb;user ID=vardhanDB;Password=V@rdhan9764";
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Stage1_IND, Stage2_IND,Stage3_IND FROM USerMobile WHERE RegistrationID =" + regID1))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    try
                    {
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {

                            sdr.Read();
                            stages[0] = (int)sdr["Stage1_IND"];
                            stages[1] = (int)sdr["Stage2_IND"];
                            stages[2] = (int)sdr["Stage3_IND"];
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
            }

            return stages;
        }
        private void FillAgeddl()
        {
            for (var i = 1; i < 100; i++)
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
        private void FillDepartmentddl()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("Departments.xml"));
            ddlDepartment.DataTextField = "DeptName";
            ddlDepartment.DataValueField = "DeptID";
            ddlDepartment.DataSource = ds;
            ddlDepartment.DataBind();
        }
        public void LoadDependentControls(string regID1)
        {
            SqlConnection con = null;
            try
            {
                string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["constring"].ToString();
                //const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyInfoDb;user ID=vardhanDB;Password=V@rdhan9764";
                con = new SqlConnection(CONNECTION_STRING);

                SqlDataAdapter adapter = new SqlDataAdapter("Select FamilyMember,MemberName,MemberDOB,MemberAge,MemberRelation from UserDependent WHERE RegistrationID=" + regID1, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["FamilyMember"].ToString().Trim() == "Spouse")
                    {
                        txtSpouceName.Text = dr["MemberName"].ToString().Trim();
                        txtSpouceDOB.Text = dr["MemberDOB"].ToString().Trim();
                        lblSpouceAge.Text = dr["MemberAge"].ToString().Trim();

                    }
                    else if (dr["FamilyMember"].ToString().Trim() == "Child 1")
                    {
                        txtNameChild1.Text = dr["MemberName"].ToString().Trim();
                        txtDOBChild1.Text = dr["MemberDOB"].ToString().Trim();
                        lblAgeChild1.Text = dr["MemberAge"].ToString().Trim();
                        if (dr["MemberRelation"].ToString().Trim() == "SON")
                        {
                            ddlrelationChild1.SelectedValue = "S";
                        }
                        else if (dr["MemberRelation"].ToString().Trim() == "DAUGHTER")
                        {
                            ddlrelationChild1.SelectedValue = "D";
                        }

                        cblChild.SelectedValue = "1";
                        txtNameChild1.Enabled = true;
                        txtDOBChild1.Enabled = true;
                        ddlrelationChild1.Enabled = true;
                    }
                    else if (dr["FamilyMember"].ToString().Trim() == "Child 2")
                    {
                        txtNameChild2.Text = dr["MemberName"].ToString().Trim();
                        txtDOBChild2.Text = dr["MemberDOB"].ToString().Trim();
                        lblAgeChild2.Text = dr["MemberAge"].ToString().Trim();
                        if (dr["MemberRelation"].ToString().Trim() == "SON")
                        {
                            ddlrelationChild2.SelectedValue = "S";
                        }
                        else if (dr["MemberRelation"].ToString().Trim() == "DAUGHTER")
                        {
                            ddlrelationChild2.SelectedValue = "D";
                        }

                        cblChild.SelectedValue = "2";
                        txtNameChild2.Enabled = true;
                        txtDOBChild2.Enabled = true;
                        ddlrelationChild2.Enabled = true;
                    }
                    else if (dr["FamilyMember"].ToString().Trim() == "Child 3")
                    {
                        txtNameChild3.Text = dr["MemberName"].ToString().Trim();
                        txtDOBChild3.Text = dr["MemberDOB"].ToString().Trim();
                        lblAgeChild3.Text = dr["MemberAge"].ToString().Trim();
                        if (dr["MemberRelation"].ToString().Trim() == "SON")
                        {
                            ddlrelationChild3.SelectedValue = "S";
                        }
                        else if (dr["MemberRelation"].ToString().Trim() == "DAUGHTER")
                        {
                            ddlrelationChild3.SelectedValue = "D";
                        }

                        cblChild.SelectedValue = "3";
                        txtNameChild3.Enabled = true;
                        txtDOBChild3.Enabled = true;
                        ddlrelationChild3.Enabled = true;

                    }
                    else if (dr["FamilyMember"].ToString().Trim() == "Child 4")
                    {
                        txtNameChild4.Text = dr["MemberName"].ToString().Trim();
                        txtDOBChild4.Text = dr["MemberDOB"].ToString().Trim();
                        lblAgeChild4.Text = dr["MemberAge"].ToString().Trim();
                        if (dr["MemberRelation"].ToString().Trim() == "SON")
                        {
                            ddlrelationChild4.SelectedValue = "S";
                        }
                        else if (dr["MemberRelation"].ToString().Trim() == "DAUGHTER")
                        {
                            ddlrelationChild4.SelectedValue = "D";
                        }

                        cblChild.SelectedValue = "4";
                        txtNameChild4.Enabled = true;
                        txtDOBChild4.Enabled = true;
                        ddlrelationChild4.Enabled = true;
                    }
                    else if (dr["FamilyMember"].ToString().Trim() == "Father")
                    {
                        cblParent.SelectedValue = "1";
                        txtFatherName.Text = dr["MemberName"].ToString().Trim();
                        txtFatherName.Enabled = true;
                        if (dr["MemberDOB"].ToString().Trim() == "")
                        {
                            ddlFatherAge.SelectedValue = dr["MemberAge"].ToString().Trim();
                            ddlFatherAge.Enabled = true;
                            lblFatherAge.Text = dr["MemberAge"].ToString().Trim();
                            cbfatherDOB.Enabled = true;
                            ddlFatherAge.Visible = true;
                            cbfatherDOB.Checked = true;
                        }
                        else
                        {
                            txtFatherDOB.Text = dr["MemberDOB"].ToString().Trim();
                            lblFatherAge.Text = dr["MemberAge"].ToString().Trim();
                            txtFatherDOB.Enabled = true;
                            cbfatherDOB.Enabled = true;
                        }



                    }
                    else if (dr["FamilyMember"].ToString().Trim() == "Mother")
                    {
                        cblParent.SelectedValue = "2";
                        txtMotherName.Text = dr["MemberName"].ToString().Trim();
                        txtMotherName.Enabled = true;
                        if (dr["MemberDOB"].ToString().Trim() == "")
                        {
                            ddlMotherAge.SelectedValue = dr["MemberAge"].ToString().Trim();
                            ddlMotherAge.Enabled = true;
                            lblMotherAge.Text = dr["MemberAge"].ToString().Trim();
                            cbMotherDOB.Enabled = true;
                            ddlMotherAge.Visible = true;
                            cbMotherDOB.Checked = true;
                        }
                        else
                        {
                            txtMotherDOB.Text = dr["MemberDOB"].ToString().Trim();
                            lblMotherAge.Text = dr["MemberAge"].ToString().Trim();
                            txtMotherDOB.Enabled = true;
                            cbMotherDOB.Enabled = true;
                        }

                    }
                    else if (dr["FamilyMember"].ToString().Trim() == "Father In Law")
                    {
                        cblParent.SelectedValue = "3";
                        txtFatherILName.Text = dr["MemberName"].ToString().Trim();
                        txtFatherILName.Enabled = true;
                        if (dr["MemberDOB"].ToString().Trim() == "")
                        {
                            ddlFatherILAge.SelectedValue = dr["MemberAge"].ToString().Trim();
                            ddlFatherILAge.Enabled = true;
                            lblFatherILAge.Text = dr["MemberAge"].ToString().Trim();
                            cbfatherILDOB.Enabled = true;
                            ddlFatherILAge.Visible = true;
                            cbfatherILDOB.Checked = true;
                        }
                        else
                        {
                            txtFatherILDOB.Text = dr["MemberDOB"].ToString().Trim();
                            lblFatherILAge.Text = dr["MemberAge"].ToString().Trim();
                            txtFatherILDOB.Enabled = true;
                            cbfatherILDOB.Enabled = true;
                        }
                    }
                    else if (dr["FamilyMember"].ToString().Trim() == "Mother In Law")
                    {
                        cblParent.SelectedValue = "4";
                        txtMotherILName.Text = dr["MemberName"].ToString().Trim();
                        txtMotherILName.Enabled = true;
                        if (dr["MemberDOB"].ToString().Trim() == "")
                        {
                            ddlMotherILAge.SelectedValue = dr["MemberAge"].ToString().Trim();
                            ddlMotherILAge.Enabled = true;
                            lblMotherILAge.Text = dr["MemberAge"].ToString().Trim();
                            cbMotherILDOB.Enabled = true;
                            ddlMotherILAge.Visible = true;
                            cbMotherILDOB.Checked = true;
                        }
                        else
                        {
                            txtMotherILDOB.Text = dr["MemberDOB"].ToString().Trim();
                            lblMotherILAge.Text = dr["MemberAge"].ToString().Trim();
                            txtMotherILDOB.Enabled = true;
                            cbMotherILDOB.Enabled = true;
                        }
                    }

                }

                GridView1.DataSource = ds;
                GridView1.DataBind();


            }
            catch (Exception e)
            {

            }
            // Closing the connection  
            finally

            {
                con.Close();
            }

        }
        public void LoadControls(string regID1)
        {
            string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["constring"].ToString();
            //const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyInfoDb;user ID=vardhanDB;Password=V@rdhan9764";
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT FirstName, MiddleName,LastName,DOB,Age,Department,DOJ, GrossSalary,Taxpct,NetSalary FROM UserRegistration WHERE RegistrationID=" + regID1))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        txtFirstName.Text = sdr["FirstName"].ToString().Trim();
                        txtMiddleName.Text = sdr["MiddleName"].ToString().Trim();
                        txtLastName.Text = sdr["LastName"].ToString().Trim();
                        txtDOB.Text = sdr["DOB"].ToString().Trim();
                        lblAge.Text = sdr["Age"].ToString().Trim();
                        ddlDepartment.Items.FindByText(sdr["Department"].ToString().Trim()).Selected = true;
                        txtDOJ.Text = sdr["DOJ"].ToString().Trim();
                        txtGrossSal.Text = sdr["GrossSalary"].ToString().Trim();
                        ddlTax.SelectedValue = sdr["Taxpct"].ToString().Trim();
                        lblNetSalary.Text = sdr["NetSalary"].ToString().Trim();
                    }
                    con.Close();
                }
            }

        }
        private void UpdateStage2(string regID1)
        {
            SqlConnection con = null;
            try
            {
                string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["constring"].ToString();
                //const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyInfoDb;user ID=vardhanDB;Password=V@rdhan9764";
                con = new SqlConnection(CONNECTION_STRING);
                SqlCommand cm = new SqlCommand("Update USerMobile set  Stage2_IND=1 where RegistrationID=" + regID1, con);
                con.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();
            }
        }
        private void UpdateStage3(string regID1)
        {
            SqlConnection con = null;
            try
            {
                string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["constring"].ToString();
                //const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyInfoDb;user ID=vardhanDB;Password=V@rdhan9764";
                con = new SqlConnection(CONNECTION_STRING);
                SqlCommand cm = new SqlCommand("Update USerMobile set  Stage3_IND=1 where RegistrationID=" + regID1, con);
                con.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected int calculateAge(String dob)
        {
            int totalAge = 0;
            if (dob == "")
            {

            }
            else
            {
                String currentDate = DateTime.Now.ToString("dd-MM-yyyy");
                DateTime dob1 = Convert.ToDateTime(dob);
                DateTime cdate = Convert.ToDateTime(currentDate);
                TimeSpan time = cdate.Subtract(dob1);
                totalAge = (time.Days) / 365;
            }
            return totalAge;
        }
        #endregion

        #region Events
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
            lblFatherAge.Text = "";
            txtMotherName.Enabled = false;
            txtMotherDOB.Enabled = false;
            cbMotherDOB.Enabled = false;
            lblMotherAge.Text = "";

            txtFatherILName.Enabled = false;
            txtFatherILDOB.Enabled = false;
            cbfatherILDOB.Enabled = false;
            lblFatherILAge.Text = "";

            txtMotherILName.Enabled = false;
            txtMotherILDOB.Enabled = false;
            cbMotherILDOB.Enabled = false;
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
        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            String dob = txtDOB.Text;
            String lblID = lblAge.ID.ToString();

           int age = calculateAge(dob);
            lblAge.Text = age.ToString() ;

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
        #endregion

        #region Customvalidation
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
                                dt.Rows.Add(regID, "Child 1", txtNameChild1.Text.ToString().Trim(), txtDOBChild1.Text.ToString().Trim(), lblAgeChild1.Text.ToString().Trim(), ddlrelationChild1.SelectedItem.Text.ToString().Trim());

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
                                dt.Rows.Add(regID, "Child 2", txtNameChild2.Text.ToString().Trim(), txtDOBChild2.Text.ToString().Trim(), lblAgeChild2.Text.ToString().Trim(), ddlrelationChild2.SelectedItem.Text.ToString().Trim());
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
                                dt.Rows.Add(regID, "Child 3", txtNameChild3.Text.ToString().Trim(), txtDOBChild3.Text.ToString().Trim(), lblAgeChild3.Text.ToString().Trim(), ddlrelationChild3.SelectedItem.Text.ToString().Trim());
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
                                dt.Rows.Add(regID, "Child 4", txtNameChild4.Text.ToString().Trim(), txtDOBChild4.Text.ToString().Trim(), lblAgeChild4.Text.ToString().Trim(), ddlrelationChild4.SelectedItem.Text.ToString().Trim());
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
                                dt.Rows.Add(regID, "Father", txtFatherName.Text.ToString().Trim(), txtFatherDOB.Text.ToString().Trim(), lblFatherAge.Text.ToString().Trim(), "Father");
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
                                dt.Rows.Add(regID, "Mother", txtMotherName.Text.ToString().Trim(), txtMotherDOB.Text.ToString().Trim(), lblMotherAge.Text.ToString().Trim(), "Mother");
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
                                dt.Rows.Add(regID, "Father In Law", txtFatherILName.Text.ToString().Trim(), txtFatherILDOB.Text.ToString().Trim(), lblFatherILAge.Text.ToString().Trim(), "Father In Law");
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
                                dt.Rows.Add(regID, "Mother In Law", txtMotherILName.Text.ToString().Trim(), txtMotherILDOB.Text.ToString().Trim(), lblMotherILAge.Text.ToString().Trim(), "Mother In Law");
                            }
                            break;
                    }
                }

            }

            return isvalid;
        }
        #endregion

        #region Button Click Event Methods
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
        protected void btnSaveNext1_Click(object sender, EventArgs e)
        {

            String regID = LblRegistrationID.Text.ToString();
            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MyInfoDb.mdf;Integrated Security=True;User Instance=True");
            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MyInfoDb;user ID=vardhanDB;Password=V@rdhan9764");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
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
            cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("MiddleName", txtMiddleName.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("LastName", txtLastName.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("DOB", txtDOB.Text).ToString().Trim();
            cmd.Parameters.AddWithValue("Age", lblAge.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("Department", ddlDepartment.SelectedItem.Text);
            cmd.Parameters.AddWithValue("DOJ", txtDOJ.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("GrossSalary", txtGrossSal.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("Taxpct", ddlTax.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("NetSalary", lblNetSalary.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("DML_TS", System.DateTime.Now.ToString().Trim());
            cmd.Parameters.AddWithValue("inMobileNO", Session["User"].ToString().Trim());
            cmd.Parameters.Add("@RegistrationID", SqlDbType.Int, 1000);
            cmd.Parameters["@RegistrationID"].Direction = ParameterDirection.Output;
            con.Open();
            try
            {
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    if (regID == "")
                    {
                        LblRegistrationID.Text = cmd.Parameters["@RegistrationID"].Value.ToString().Trim();
                    }

                    btnDepInfo.Enabled = true;
                    MvRegistration.ActiveViewIndex = 1;
                    Label30.Visible = true;
                    btnDepInfo.ForeColor = System.Drawing.Color.DeepSkyBlue;
                    btnMyInfo.ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    lblSuccessfull.Text = "Data Not Saved";
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
            dt.Rows.Add(RegID, "Spouse", txtSpouceName.Text.ToString().Trim(), txtSpouceDOB.Text.ToString().Trim(), lblSpouceAge.Text.ToString().Trim(), "Spouse");
            bool isvalid1 = CustomValidator1_ServerValidate(dt, RegID);
            bool isvalid2 = CustomValidator2_ServerValidate(dt, RegID);
            if (isvalid1 && isvalid2)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
                btnFinalize.Enabled = true;
                btnDepInfo.Enabled = true;
                ViewState["table"] = dt;




                //const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MyInfoDb.mdf;Integrated Security=True;User Instance=True";
                //const string CONNECTION_STRING =@"Data Source=.\SQLEXPRESS;Initial Catalog=MyInfoDb;user ID=vardhanDB;Password=V@rdhan9764";
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
                //SqlConnection con1 = new SqlConnection(CONNECTION_STRING);
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

                string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["constring"].ToString();
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
                        string regID2 = Session["RegisterID"].ToString();
                        UpdateStage2(regID2);
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
        protected void btnClear2_Click(object sender, EventArgs e)
        {
            txtSpouceDOB.Text = "";
            txtSpouceName.Text = "";
            lblSpouceAge.Text = "";

            foreach (ListItem item in cblChild.Items)
            {
                item.Selected = false;
            }
            cblChild_SelectedIndexChanged(sender, e);
            foreach (ListItem item in cblParent.Items)
            {
                item.Selected = false;
            }
            cblParent_SelectedIndexChanged(sender, e);

        }
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("~/Login.aspx");
        }
        protected void btnFinalizeblock_Click(object sender, EventArgs e)
        {
 
            string regID2 = Session["RegisterID"].ToString();
            UpdateStage3(regID2);

            btnMyInfo.Enabled = false;
            btnDepInfo.Enabled = false;
            btnFinalize.Enabled = false;
            btnFinalizeblock.Enabled = false;
            btnFinalize.ForeColor = System.Drawing.Color.Gray;
            lblMessage.Text = "Please Note Registration ID for future reference.";

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
        #endregion

    }
}