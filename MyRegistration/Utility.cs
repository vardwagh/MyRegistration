using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MyRegistration
{
    public class Utility : Page
    {

        //Method will register mobile new mobile number and update timestamp for already register mobile using SP ->spRegisterMobile
        public void regiterMobile(String mobileNo)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MyInfoDb.mdf;Integrated Security=True;User Instance=True");
            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MyInfoDb;user ID=vardhanDB;Password=V@rdhan9764");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
            SqlCommand cmd = new SqlCommand("spRegisterMobile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("inMobileNO", mobileNo);
            cmd.Parameters.AddWithValue("inDML_TS", System.DateTime.Now.ToString());
            cmd.Parameters.Add("@RegistrationID", SqlDbType.Int, 1000);
            cmd.Parameters["@RegistrationID"].Direction = ParameterDirection.Output;
            con.Open();
            try
            {
                
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    Session["RegisterID"] = cmd.Parameters["@RegistrationID"].Value.ToString();

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
}