using BusinessLayer;
using BusinessLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.Stock
{
    public partial class New : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
        StockSummaryModel stock = new StockSummaryModel();

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
                    List<clsMeasurementUnitModel> measurementUnit = new List<clsMeasurementUnitModel>();
                    List<clsUserDetailsModel> suppliers = new List<clsUserDetailsModel>();
                    measurementUnit = master.RetrieveMeasurement();
                    suppliers = businessLayer.RetrieveUser(UserType.Supplier);

                    foreach (var item in measurementUnit)
                    {
                        ListItem list = new ListItem(item.sMeasurement, item.iMeasurementId.ToString(), true);
                        drpMeasureUnit.Items.Add(list);
                    }

                    foreach (var item in suppliers)
                    {
                        ListItem list = new ListItem(string.Format("{0} - {1} {2}", item.sCompany, item.sName, item.sSurname), item.iUserDetailsId.ToString(), true);
                        drpSuppliers.Items.Add(list);
                    }

                    drpMeasureUnit.SelectedValue = 1.ToString();
                    drpSuppliers.SelectedIndex = 1;
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
                AssignValue();
                businessLayer.UpsertInventory(stock);

                pnlErrorFruit.Visible = false;
                pnlErrorSupplier.Visible = false;
                pnlSuccess.Visible = true;
            }
            catch (FormatException ex)
            {
                pnlErrorFruit.Visible = false;
                pnlErrorSupplier.Visible = false;
                pnlSuccess.Visible = false;

                switch (Convert.ToInt32(ex.Message))
                {
                    case (int)ErrorStatus.InventoryInvalidModel:
                        pnlErrorFruit.Visible = true;
                        lblErrorFruit.Text = "Invalid fruit details";
                        break;
                    case (int)ErrorStatus.InventoryInvalidFruitName:
                        pnlErrorFruit.Visible = true;
                        lblErrorFruit.Text = "Invalid fruit name";
                        break;
                    case (int)ErrorStatus.InventoryInvalidQuantity:
                        pnlErrorFruit.Visible = true;
                        lblErrorFruit.Text = "Invalid quantity";
                        break;
                    case (int)ErrorStatus.InventoryInvalidUnitPrice:
                        pnlErrorFruit.Visible = true;
                        lblErrorFruit.Text = "Invalid unit price";
                        break;
                    case (int)ErrorStatus.InventorySupplierDetails:
                        pnlErrorSupplier.Visible = true;
                        lblErrorSupplier.Text = "invalid supplier details";
                        break;
                    case (int)ErrorStatus.InventoryInvalidDeliveryDate:
                        pnlErrorSupplier.Visible = true;
                        lblErrorSupplier.Text = "Invalid delivery date";
                        break;
                    case (int)ErrorStatus.InventoryInvalidPurchasePrice:
                        pnlErrorSupplier.Visible = true;
                        lblErrorSupplier.Text = "Invalid Purchase price";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.InventorySaveFail));
            }

        }

        private void AssignValue()
        {
            stock = new StockSummaryModel()
            {
                objFruit = new clsFruitModel()
                {
                    iFruitId = 0,
                    sFruitName = txtFruit.Text.Trim(),
                    eMeasurement = clsCommon.GetMeasurementType(Convert.ToInt32(drpMeasureUnit.SelectedValue.ToString())),
                    sDescription = txtDescription.Text.Trim(),
                    bStatus = true,
                    deQuantity = string.IsNullOrWhiteSpace(txtQuantiy.Text.Trim()) ? 0 : Convert.ToDecimal(txtQuantiy.Text.Trim()),
                    deUnitPrice = string.IsNullOrWhiteSpace(txtUnitPrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtQuantiy.Text.Trim()),
                },
                lstStock = new List<clsStockModel>()
                {
                    new clsStockModel()
                    {
                        iStockId = 0,
                        objUserDetails = new clsUserDetailsModel()
                        {
                            iUserDetailsId = Convert.ToInt32(drpSuppliers.SelectedValue.ToString())
                        },
                        bStatus = true,
                        sNote = txtNote.Text.Trim(),
                        deQuantityAdded = string.IsNullOrWhiteSpace(txtQuantiy.Text.Trim()) ? 0 : Convert.ToDecimal(txtQuantiy.Text.Trim()),
                        dDeliveryDate = GetValidDate(txtDate.Text.Trim()),
                        dePurchasePrice = string.IsNullOrWhiteSpace(txtPurchasePrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtPurchasePrice.Text.Trim())
                    }
                }
            };
        }

        private DateTime GetValidDate(string date)
        {
            DateTime now = DateTime.Now;
            DateTime result = DateTime.Now;

            if (string.IsNullOrWhiteSpace(date))
                return result = now.AddYears(-5);

            if (!DateTime.TryParse(date, out result))
                return result = now.AddYears(-5);

            return result;
        }
    }
}