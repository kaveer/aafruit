using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitCustomer
{
    public partial class Login : System.Web.UI.Page
    {
        clsCustomer businessLayer = new clsCustomer();
        clsUserDetailsModel model = new clsUserDetailsModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                model = new clsUserDetailsModel();
                model = businessLayer.Login(txtEmail.Text.Trim(), txtPassword.Text.Trim(), UserType.Customer);

                if (model == null || model.iUserId == 0)
                    throw new FormatException("Invalid username and password");

                Session["Customer"] = model;
                Response.Redirect("~/WebForms/Main/Details.aspx", false);

            }
            catch (FormatException ex)
            {
                pnlError.Visible = true;
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("Error.aspx?stat={0}", (int)ErrorStatus.LoginFail));
            }
        }



        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}