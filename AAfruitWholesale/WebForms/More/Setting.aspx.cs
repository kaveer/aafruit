using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.More
{
    public partial class Setting : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();

        ClsStaff businessLayer = new ClsStaff();
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
                    List<clsCountryModel> countries = new List<clsCountryModel>();
                    countries = master.RetrieveCountry();

                    foreach (var item in countries)
                    {
                        ListItem list = new ListItem(item.sCountryName, item.iCountryId.ToString(), true);
                        drpCountry.Items.Add(list);
                    }

                    drpCountry.SelectedValue = 1.ToString();

                    AssignValue(false);
                }
            }
            catch (Exception ex)
            {
                switch (Convert.ToInt32(ex.Message))
                {
                    case (int)ErrorStatus.LoadCountryMasterDataFail:
                        Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.LoginFail));
                        break;
                    default:
                        break;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                AssignValue(true);
                businessLayer.Setting(userDetails);

                pnlErrorCredential.Visible = false;
                pnlErrorCompany.Visible = false;
                pnlErrorContact.Visible = false;
                pnlErrorDetails.Visible = false;
                pnlSuccess.Visible = true;
            }
            catch (FormatException ex)
            {
                pnlErrorCredential.Visible = false;
                pnlErrorCompany.Visible = false;
                pnlErrorContact.Visible = false;
                pnlErrorDetails.Visible = false;

                switch (Convert.ToInt32(ex.Message))
                {
                    case (int)ErrorStatus.SignupUsernameMissing:
                        pnlErrorCredential.Visible = true;
                        lblErrorCredential.Text = "Please enter email address";
                        break;
                    case (int)ErrorStatus.SigupPasswordMissing:
                        pnlErrorCredential.Visible = true;
                        lblErrorCredential.Text = "Please enter password";
                        break;
                    case (int)ErrorStatus.SignupRePasswordMissing:
                        pnlErrorCredential.Visible = true;
                        lblErrorCredential.Text = "Please re enter password";
                        break;
                    case (int)ErrorStatus.SignupPasswordNotMatch:
                        pnlErrorCredential.Visible = true;
                        lblErrorCredential.Text = "Password does not match";
                        break;
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
                userDetails.sUsername = txtEmail.Text.Trim();
                userDetails.sPassword = txtPassword.Text.Trim();
                userDetails.sReEnterPassword = txtReEnterPassword.Text.Trim();

                userDetails.sName = txtName.Text.Trim();
                userDetails.sSurname = txtSurname.Text.Trim();
                userDetails.sAddress = txtAddress.Text.Trim();
                userDetails.iCountryId = Convert.ToInt32(drpCountry.SelectedValue);

                userDetails.sEmail = txtEmailDetail.Text.Trim();
                userDetails.sFixLine = txtPhoneFix.Text.Trim();
                userDetails.sMobile = txtPhoneMobile.Text.Trim();

                userDetails.sCompany = txtCompany.Text.Trim();
                userDetails.sBRN = txtBRN.Text.Trim();
                userDetails.sNote = txtNote.Text.Trim();
            }
            else
            {
                txtEmail.Text = userDetails.sUsername;

                txtName.Text = userDetails.sName;
                txtSurname.Text = userDetails.sSurname;
                txtAddress.Text = userDetails.sAddress;
                drpCountry.SelectedValue = userDetails.iCountryId.ToString();

                txtEmailDetail.Text = userDetails.sEmail;
                txtPhoneFix.Text = userDetails.sFixLine;
                txtPhoneMobile.Text = userDetails.sMobile;

                txtCompany.Text = userDetails.sCompany;
                txtBRN.Text = userDetails.sBRN;
                txtNote.Text = userDetails.sNote;
            }
        }
    }
}