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
    public partial class SignUp : System.Web.UI.Page
    {
        clsCustomer businessLayer = new clsCustomer();
        clsMaster master = new clsMaster();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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
                }
            }
            catch (Exception ex)
            {
                switch (Convert.ToInt32(ex.Message))
                {
                    case (int)ErrorStatus.LoadCountryMasterDataFail:
                        Response.Redirect(string.Format("Error.aspx?stat={0}", (int)ErrorStatus.LoginFail));
                        break;
                    default:
                        break;
                }
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                clsUserDetailsModel data = new clsUserDetailsModel()
                {
                    iUserId = 0,
                    sUsername = txtEmail.Text.Trim(),
                    sPassword = txtPassword.Text.Trim(),
                    sReEnterPassword = txtReEnterPassword.Text.Trim(),

                    iUserDetailsId = 0,
                    sName = txtName.Text.Trim(),
                    sSurname = txtSurname.Text.Trim(),
                    sAddress = txtAddress.Text.Trim(),
                    iCountryId = Convert.ToInt32(drpCountry.SelectedValue),

                    sEmail = txtEmailDetail.Text.Trim(),
                    sFixLine = txtPhoneFix.Text.Trim(),
                    sMobile = txtPhoneMobile.Text.Trim(),

                    sCompany = txtCompany.Text.Trim(),
                    sBRN = txtBRN.Text.Trim(),
                    sNote = txtNote.Text.Trim(),

                    bStatus = true,
                    eUserType = UserType.Customer
                };

                clsUserDetailsModel result = new clsUserDetailsModel();
                result = businessLayer.SignUp(data);

                if (result == null || result.iUserId == 0)
                    throw new Exception();

                Session["Customer"] = result;
                Response.Redirect("~/WebForms/Main/Details.aspx", false);
            }
            catch (FormatException ex)
            {
                pnlErrorCompany.Visible = false;
                pnlErrorContact.Visible = false;
                pnlErrorCredential.Visible = false;
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
            catch (Exception ex)
            {
                Response.Redirect(string.Format("Error.aspx?stat={0}", (int)ErrorStatus.SignUpFail));
            }
        }
    }
}