using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.More
{
    public partial class Add : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
        clsUserDetailsModel newUser = new clsUserDetailsModel();

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
                    List<clsUserTypeModel> userTypes = new List<clsUserTypeModel>();
                    countries = master.RetrieveCountry();
                    userTypes = master.RetrieveUserType();

                    foreach (var item in countries)
                    {
                        ListItem list = new ListItem(item.sCountryName, item.iCountryId.ToString(), true);
                        drpCountry.Items.Add(list);
                    }

                    foreach (var item in userTypes)
                    {
                        if (item.iUserTypeId == (int)UserType.Admin || item.iUserTypeId == (int)UserType.AdminStaff)
                            continue;

                        ListItem list = new ListItem(item.sUserType, item.iUserTypeId.ToString(), true);
                        drpRole.Items.Add(list);
                    }

                    drpCountry.SelectedValue = 1.ToString();
                    drpRole.SelectedValue = 2.ToString();
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

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                AssignValue();
                businessLayer.AddUser(newUser);

                pnlSuccess.Visible = true;
                pnlErrorCompany.Visible = false;
                pnlErrorContact.Visible = false;
                pnlErrorCredential.Visible = false;
                pnlErrorDetails.Visible = false;
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
                Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.AddUserFail));
            }
        }

        private void AssignValue()
        {
            newUser.sUsername = txtEmail.Text.Trim();
            newUser.sPassword = txtPassword.Text.Trim();
            newUser.sReEnterPassword = txtReEnterPassword.Text.Trim();
            newUser.eUserType = GetUserType(Convert.ToInt32(drpRole.SelectedValue));

            newUser.sName = txtName.Text.Trim();
            newUser.sSurname = txtSurname.Text.Trim();
            newUser.sAddress = txtAddress.Text.Trim();
            newUser.iCountryId = Convert.ToInt32(drpCountry.SelectedValue);

            newUser.sEmail = txtEmailDetail.Text.Trim();
            newUser.sFixLine = txtPhoneFix.Text.Trim();
            newUser.sMobile = txtPhoneMobile.Text.Trim();
            newUser.sFax = txtFax.Text.Trim();

            newUser.sCompany = txtCompany.Text.Trim();
            newUser.sBRN = txtBRN.Text.Trim();
            newUser.sNote = txtNote.Text.Trim();
        }

        private UserType GetUserType(int userTypeId)
        {
            UserType result = new UserType();

            switch (userTypeId)
            {
                case (int)UserType.Admin:
                    result = UserType.Admin;
                    break;
                case (int)UserType.AdminStaff:
                    result = UserType.AdminStaff;
                    break;
                case (int)UserType.Customer:
                    result = UserType.Customer;
                    break;
                case (int)UserType.Staff:
                    result = UserType.Staff;
                    break;
                case (int)UserType.Supplier:
                    result = UserType.Supplier;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}