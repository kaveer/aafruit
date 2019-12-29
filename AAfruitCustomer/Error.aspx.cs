using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitCustomer
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int errorId = Request.QueryString["stat"] == null ? 0 : Convert.ToInt32(Request.QueryString["stat"]);

            switch (errorId)
            {
                case (int)ErrorStatus.LoginFail:
                    lblDescription.Text = "Fail to login";
                    break;
                case (int)ErrorStatus.LoadCountryMasterDataFail:
                    lblDescription.Text = "Meta data loading fail";
                    break;
                case (int)ErrorStatus.SignUpFail:
                    lblDescription.Text = "Sign up fail";
                    break;
                case (int)ErrorStatus.SignupUsernameMissing:
                    lblDescription.Text = "Missing username";
                    break;
                case (int)ErrorStatus.SigupPasswordMissing:
                    lblDescription.Text = "Missing password";
                    break;
                case (int)ErrorStatus.SignupPasswordNotMatch:
                    lblDescription.Text = "Password does math";
                    break;
                case (int)ErrorStatus.SignupNameMissing:
                    lblDescription.Text = "Name missing";
                    break;
                case (int)ErrorStatus.SignupSurnameMissing:
                    lblDescription.Text = "Surname missing";
                    break;
                case (int)ErrorStatus.SignupCompanyMissing:
                    lblDescription.Text = "Company information missing";
                    break;
                case (int)ErrorStatus.SignupRePasswordMissing:
                    lblDescription.Text = "Password missing";
                    break;
                case (int)ErrorStatus.InvalidSession:
                    lblDescription.Text = "Invalid user";
                    break;
                case (int)ErrorStatus.UpdateUserDEtailsFail:
                    lblDescription.Text = "Update user details fails";
                    break;
                case (int)ErrorStatus.LoadDiscountMasterDataFail:
                    lblDescription.Text = "Load master data fail";
                    break;
                case (int)ErrorStatus.LoadFruitMasterDataFail:
                    lblDescription.Text = "Load master data fail";
                    break;
                case (int)ErrorStatus.LoadUserTypeMasterDataFail:
                    lblDescription.Text = "Load master data fail";
                    break;
                case (int)ErrorStatus.LoadMeasurementMasterDataFail:
                    lblDescription.Text = "Load master data fail";
                    break;
                case (int)ErrorStatus.LoadSuppliersDataFail:
                    lblDescription.Text = "Load master data fail";
                    break;
                case (int)ErrorStatus.AddUserFail:
                    lblDescription.Text = "Add userfails";
                    break;
                case (int)ErrorStatus.InventorySaveFail:
                    lblDescription.Text = "Update inventory fail";
                    break;
                case (int)ErrorStatus.InventoryInvalidModel:
                    lblDescription.Text = "Update inventory fail";
                    break;
                case (int)ErrorStatus.InventoryInvalidFruitName:
                    lblDescription.Text = "Invalid inventory";
                    break;
                case (int)ErrorStatus.InventoryInvalidQuantity:
                    lblDescription.Text = "Invalid inventory";
                    break;
                case (int)ErrorStatus.InventoryInvalidUnitPrice:
                    lblDescription.Text = "Invalid inventory";
                    break;
                case (int)ErrorStatus.InventorySupplierDetails:
                    lblDescription.Text = "Invalid inventory";
                    break;
                case (int)ErrorStatus.InventoryInvalidDeliveryDate:
                    lblDescription.Text = "Invalid inventory";
                    break;
                case (int)ErrorStatus.InventoryConfigurationFail:
                    lblDescription.Text = "Invalid inventory";
                    break;
                case (int)ErrorStatus.AddSupplierFail:
                    lblDescription.Text = "Add supplier fail";
                    break;
                case (int)ErrorStatus.Report:
                    lblDescription.Text = "Generate report fail";
                    break;
                case (int)ErrorStatus.InventoryInvalidPurchasePrice:
                    lblDescription.Text = "Invalid inventory";
                    break;
                default:
                    break;
            }
        }
    }
}