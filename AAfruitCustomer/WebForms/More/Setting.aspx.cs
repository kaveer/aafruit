using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitCustomer.WebForms.More
{
    public partial class Setting : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();

        clsCustomer businessLayer = new clsCustomer();
        clsMaster master = new clsMaster();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Customer"] == null)
                    throw new Exception();

                sessionData = (clsUserDetailsModel)Session["Customer"];
                if (sessionData == null || (sessionData.iUserId == 0 || sessionData.iUserDetailsId == 0))
                    throw new Exception();

                userDetails = businessLayer.GetUserByUserDetailId(sessionData.iUserDetailsId);
                if (userDetails.iUserId == 0 || userDetails.iUserDetailsId == 0)
                    throw new Exception();

                if (!IsPostBack)
                {
                    AssignValue(false);
                }
            }
            catch (Exception)
            {
                Response.Redirect(string.Format("Error.aspx?stat={0}", (int)ErrorStatus.InvalidSession));
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                AssignValue(true);
                businessLayer.Setting(userDetails);

                pnlSuccess.Visible = true;
                pnlErrorCredential.Visible = false;
            }
            catch (FormatException ex)
            {
                pnlErrorCredential.Visible = false;

                switch (Convert.ToInt32(ex.Message))
                {
                    case (int)ErrorStatus.SignupUsernameMissing:
                        pnlErrorCredential.Visible = true;
                        lblErrorDetails.Text = "Please enter email address";
                        break;
                    case (int)ErrorStatus.SigupPasswordMissing:
                        pnlErrorCredential.Visible = true;
                        lblErrorDetails.Text = "Please enter password";
                        break;
                    case (int)ErrorStatus.SignupRePasswordMissing:
                        pnlErrorCredential.Visible = true;
                        lblErrorDetails.Text = "Please re enter password";
                        break;
                    case (int)ErrorStatus.SignupPasswordNotMatch:
                        pnlErrorCredential.Visible = true;
                        lblErrorDetails.Text = "Password does not match";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                Response.Redirect(string.Format("Error.aspx?stat={0}", (int)ErrorStatus.UpdateUserDEtailsFail));
            }
        }

        private void AssignValue(bool FromTestbox)
        {
            if (FromTestbox)
            {
                userDetails.sEmail = txtEmail.Text.Trim();
                userDetails.sPassword = txtPassword.Text.Trim();
                userDetails.sReEnterPassword = txtRePassword.Text.Trim();
            }
            else
            {
                txtEmail.Text = userDetails.sEmail;
            }
        }
    }
}