using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyRegistration
{
    public partial class Login : System.Web.UI.Page
    {
        public const int OTP = 1111;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtOTP.Visible = false;
                btnLogin.Visible = false;
            }

            if (Session["User"] != null)
            {
                Response.Redirect("~/Registration.aspx");
            }

        }
        
        #region Button Click Methods
        //Login Button Click
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Utility u = new Utility();

            if (txtOTP.Text.ToString() == OTP.ToString())
            {
                lblOPT.Text = "";
                Session["User"] = txtMobile.Text.ToString().Trim();
                
                u.regiterMobile(txtMobile.Text.ToString().Trim());
                Response.Redirect("~/Registration.aspx");

            }
            else
            {
                lblOPT.Text = "Incorrect OTP";
            }

        }

        //Send OTP Button Click
        protected void btnSendOtp_Click(object sender, EventArgs e)
        {
            lblotpsent.Text = "OTP Sent on Mobile Number - " + txtMobile.Text;
            txtOTP.Visible = true;
            btnLogin.Visible = true;
            RequiredFieldValidator2.Enabled = true;
        }
        #endregion  
    }
}