using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.Supplier
{
    public partial class Upsert : System.Web.UI.Page
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

                    drpCountry.SelectedIndex = 1;
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                clsUserDetailsModel data = new clsUserDetailsModel()
                {
                    iUserId = 0,
                    sUsername = string.Format("#{0}_{1}@{2}", txtName.Text.Trim(), txtCompany.Text.Trim(), UserType.Supplier.ToString()),
                    sPassword = UserType.Supplier.ToString(),
                    sReEnterPassword = UserType.Supplier.ToString(),

                    iUserDetailsId = 0,
                    sName = txtName.Text.Trim(),
                    sSurname = txtSurname.Text.Trim(),
                    sAddress = txtAddress.Text.Trim(),
                    iCountryId = Convert.ToInt32(drpCountry.SelectedValue),

                    sEmail = txtEmailDetail.Text.Trim(),
                    sFixLine = txtPhoneFix.Text.Trim(),
                    sMobile = txtPhoneMobile.Text.Trim(),
                    sFax = txtFax.Text.Trim(),

                    sCompany = txtCompany.Text.Trim(),
                    sBRN = txtBRN.Text.Trim(),
                    sNote = txtNote.Text.Trim(),

                    bStatus = true,
                    eUserType = UserType.Supplier,
                    sWebsite = "EMPTY"
                };

                clsUserDetailsModel result = new clsUserDetailsModel();
                result = businessLayer.SignUp(data);

                if (result == null || result.iUserId == 0)
                    throw new Exception();

                pnlErrorCompany.Visible = false;
                pnlErrorContact.Visible = false;
                pnlErrorDetails.Visible = false;
                pnlSuccess.Visible = true;
            }
            catch (FormatException ex)
            {
                pnlErrorCompany.Visible = false;
                pnlErrorContact.Visible = false;
                pnlErrorDetails.Visible = false;
                pnlSuccess.Visible = false;

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
                    case (int)ErrorStatus.SignupUsernameMissing:
                    case (int)ErrorStatus.SigupPasswordMissing:
                    case (int)ErrorStatus.SignupRePasswordMissing:
                    case (int)ErrorStatus.SignupPasswordNotMatch:
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("Error.aspx?stat={0}", (int)ErrorStatus.AddSupplierFail));
            }
        }
    }
}