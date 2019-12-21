using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.Stock
{
    public partial class Stock : System.Web.UI.Page
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
                    List<clsFruitModel> fruits = new List<clsFruitModel>();
                    List<clsUserDetailsModel> suppliers = new List<clsUserDetailsModel>();

                    fruits = master.RetrieveFruits();
                    suppliers = businessLayer.RetrieveUser(UserType.Supplier);

                    foreach (var item in suppliers)
                    {
                        ListItem list = new ListItem(string.Format("{0} - {1} {2}", item.sCompany, item.sName, item.sSurname), item.iUserDetailsId.ToString(), true);
                        drpSuppliers.Items.Add(list);
                    }

                    foreach (var item in fruits)
                    {
                        ListItem list = new ListItem(item.sFruitName, item.iFruitId.ToString(), true);
                        drpFruit.Items.Add(list);
                    }

                    drpFruit.SelectedIndex = 0;
                    drpSuppliers.SelectedIndex = 0;
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
                StockSummaryModel result = new StockSummaryModel();
                clsFruitModel fruit = new clsFruitModel();

                pnlError.Visible = false;
                pnlSuccess.Visible = false;

                fruit = businessLayer.GetFruitByFruitId(Convert.ToInt32(drpFruit.SelectedValue));
                fruit.deQuantity = fruit.deQuantity + (string.IsNullOrWhiteSpace(txtQuantity.Text.Trim()) ? 0 : Convert.ToDecimal(txtQuantity.Text.Trim()));

                result = new StockSummaryModel()
                {
                    objFruit = fruit,
                    lstStock = new List<clsStockModel>()
                    {
                        new clsStockModel()
                        {
                            bStatus = true,
                            iStockId = 0,
                            sNote = txtNote.Text.Trim(),
                            dePurchasePrice = string.IsNullOrWhiteSpace(txtPurchasePrice.Text.Trim())? 0: Convert.ToDecimal(txtPurchasePrice.Text.Trim()),
                            deQuantityAdded = string.IsNullOrWhiteSpace(txtQuantity.Text.Trim()) ? 0 : Convert.ToDecimal(txtQuantity.Text.Trim()),
                            objUserDetails = new clsUserDetailsModel()
                            {
                                iUserDetailsId = Convert.ToInt32(drpSuppliers.SelectedValue)
                            },
                            dDeliveryDate = GetValidDate(txtDate.Text.Trim())
                        }
                    }
                };

                businessLayer.UpsertInventory(result);

                pnlSuccess.Visible = true;
            }
            catch (FormatException ex)
            {
                pnlError.Visible = true;
                pnlSuccess.Visible = false;

                switch (Convert.ToInt32(ex.Message))
                {
                    case (int)ErrorStatus.InventoryInvalidModel:
                        pnlError.Visible = true;
                        lblErrorFruit.Text = "Invalid fruit details";
                        break;
                    case (int)ErrorStatus.InventoryInvalidFruitName:
                        pnlError.Visible = true;
                        lblErrorFruit.Text = "Invalid fruit name";
                        break;
                    case (int)ErrorStatus.InventoryInvalidQuantity:
                        pnlError.Visible = true;
                        lblErrorFruit.Text = "Invalid quantity";
                        break;
                    case (int)ErrorStatus.InventoryInvalidUnitPrice:
                        pnlError.Visible = true;
                        lblErrorFruit.Text = "Invalid unit price";
                        break;
                    case (int)ErrorStatus.InventorySupplierDetails:
                        pnlError.Visible = false;
                        lblErrorFruit.Text = "invalid supplier details";
                        break;
                    case (int)ErrorStatus.InventoryInvalidDeliveryDate:
                        pnlError.Visible = false;
                        lblErrorFruit.Text = "Invalid delivery date";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                lblErrorFruit.Text = ex.Message;
            }
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