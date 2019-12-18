using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale
{
    public partial class SiteMaster : MasterPage
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();

        ClsStaff BusinessLayer = new ClsStaff();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Customer"] == null)
                    throw new Exception();

                sessionData = (clsUserDetailsModel)Session["Customer"];
                if (sessionData == null || (sessionData.iUserId == 0 || sessionData.iUserDetailsId == 0))
                    throw new Exception();

                userDetails = BusinessLayer.GetUserByUserDetailId(sessionData.iUserDetailsId);
                if (userDetails.iUserId == 0 || userDetails.iUserDetailsId == 0)
                    throw new Exception();

                if (userDetails.eUserType != UserType.Admin)
                {
                    lkAddUser.Visible = false;
                }

                if (!IsPostBack)
                {
                    
                }
            }
            catch (Exception)
            {
                Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.InvalidSession));
            }
        }

        protected void lkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx", false);
        }
    }
}