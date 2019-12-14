using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitCustomer.WebForms.Main
{
    public partial class Details : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();

        clsCustomer BusinessLayer = new clsCustomer();
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

                userDetails = BusinessLayer.GetUserByUserDetailId(sessionData.iUserDetailsId);
                if (userDetails.iUserId == 0 || userDetails.iUserDetailsId == 0)
                    throw new Exception();

                if (!IsPostBack)
                {
                    List<clsCountryModel> countries = new List<clsCountryModel>();
                    countries = master.RetrieveCountry();

                    foreach (var item in countries)
                    {
                        ListItem list = new ListItem(item.sCountryName, item.iCountryId.ToString(), true);
                        drpCountry.Items.Add(list);
                    }

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
                BusinessLayer.Setting(userDetails);

                pnlSuccess.Visible = true;
            }
            catch (FormatException ex)
            {
                pnlErrorCompany.Visible = false;
                pnlErrorContact.Visible = false;
                pnlErrorDetails.Visible = false;

                switch (Convert.ToInt32(ex.Message))
                {
                    case (int)ErrorStatus.SignupNameMissing:
                        pnlErrorDetails.Visible = true;
                        lblErrorDetails.Text = "Please enter owner name";
                        break;
                    case (int)ErrorStatus.SignupSurnameMissing:
                        pnlErrorDetails.Visible = true;
                        lblErrorDetails.Text = "Please enter owner surname";
                        break;
                    case (int)ErrorStatus.SignupCompanyMissing:
                        pnlErrorCompany.Visible = true;
                        lblErrorCompany.Text = "Please enter company name";
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
                userDetails.sName = txtName.Text.Trim();
                userDetails.sSurname = txtSurname.Text.Trim();
                userDetails.sAddress = txtAddress.Text.Trim();
                userDetails.iCountryId = Convert.ToInt32(drpCountry.SelectedValue);

                userDetails.sEmail = txtEmail.Text.Trim();
                userDetails.sFixLine = txtFixLine.Text.Trim();
                userDetails.sMobile = txtmobile.Text.Trim();

                userDetails.sCompany = txtCompany.Text.Trim();
                userDetails.sBRN = txtBRN.Text.Trim();
                userDetails.sNote = txtNote.Text.Trim();
            }
            else
            {
                txtName.Text = userDetails.sName;
                txtSurname.Text = userDetails.sSurname;
                txtAddress.Text = userDetails.sAddress;
                drpCountry.SelectedValue = userDetails.iCountryId.ToString();

                txtEmail.Text = userDetails.sEmail;
                txtFixLine.Text = userDetails.sFixLine;
                txtmobile.Text = userDetails.sMobile;

                txtCompany.Text = userDetails.sCompany;
                txtBRN.Text = userDetails.sBRN;
                txtNote.Text = userDetails.sNote;
            }
        }
    }
}