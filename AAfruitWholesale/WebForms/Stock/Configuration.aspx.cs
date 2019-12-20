using BusinessLayer;
using BusinessLayer.Helper;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.Stock
{
    public partial class Configuration : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
        clsFruitModel fruit = new clsFruitModel();
        int selectedFruitId = 0;

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
                    List<clsMeasurementUnitModel> measurementUnit = new List<clsMeasurementUnitModel>();
                    fruits = master.RetrieveFruits();
                    measurementUnit = master.RetrieveMeasurement();

                    foreach (var item in fruits)
                    {
                        ListItem list = new ListItem(item.sFruitName, item.iFruitId.ToString(), true);
                        drpFruit.Items.Add(list);
                    }

                    foreach (var item in measurementUnit)
                    {
                        ListItem list = new ListItem(item.sMeasurement, item.iMeasurementId.ToString(), true);
                        drpMeasureUnit.Items.Add(list);
                    }

                    drpFruit.SelectedIndex = 0;
                    drpMeasureUnit.SelectedIndex = 0;

                    selectedFruitId = Request.QueryString["fruitid"] == null ? Convert.ToInt32(drpFruit.SelectedValue) : Convert.ToInt32(Request.QueryString["fruitid"]);
                    LoadFruitByFruitId(selectedFruitId);
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
                clsFruitModel fruitResult = new clsFruitModel()
                {
                    bStatus = true,
                    deQuantity = string.IsNullOrWhiteSpace(txtQuatity.Text.Trim()) ? 0 : Convert.ToDecimal(txtQuatity.Text.Trim()),
                    deUnitPrice = string.IsNullOrWhiteSpace(txtUnitPrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtUnitPrice.Text.Trim()),
                    eMeasurement = clsCommon.GetMeasurementType(Convert.ToInt32(drpMeasureUnit.SelectedValue)),
                    iFruitId = Convert.ToInt32(drpFruit.SelectedValue),
                    sDescription = txtDescription.Text.Trim(),
                    sFruitName = txtname.Text.Trim()
                };

                StockSummaryModel result = new StockSummaryModel()
                {
                    objFruit = fruitResult,
                    lstStock = new List<clsStockModel>()
                };

                businessLayer.UpsertInventory(result);
                pnlError.Visible = false;
                pnlSuccess.Visible = true;

                drpFruit.Items.Clear();
                List<clsFruitModel> fruits = new List<clsFruitModel>();
                fruits = master.RetrieveFruits();

                foreach (var item in fruits)
                {
                    ListItem list = new ListItem(item.sFruitName, item.iFruitId.ToString(), true);
                    drpFruit.Items.Add(list);
                }

                drpFruit.SelectedIndex = 0;
                LoadFruitByFruitId(Convert.ToInt32(drpFruit.SelectedValue));
            }
            catch (FormatException ex)
            {
                pnlError.Visible = true;
                pnlSuccess.Visible = false;

                switch (Convert.ToInt32(ex.Message))
                {
                    case (int)ErrorStatus.InventoryInvalidModel:
                        pnlError.Visible = true;
                        lblErrorDetails.Text = "Invalid fruit details";
                        break;
                    case (int)ErrorStatus.InventoryInvalidFruitName:
                        pnlError.Visible = true;
                        lblErrorDetails.Text = "Invalid fruit name";
                        break;
                    case (int)ErrorStatus.InventoryInvalidQuantity:
                        pnlError.Visible = true;
                        lblErrorDetails.Text = "Invalid quantity";
                        break;
                    case (int)ErrorStatus.InventoryInvalidUnitPrice:
                        pnlError.Visible = true;
                        lblErrorDetails.Text = "Invalid unit price";
                        break;
                    case (int)ErrorStatus.InventorySupplierDetails:
                        pnlError.Visible = false;
                        lblErrorDetails.Text = "invalid supplier details";
                        break;
                    case (int)ErrorStatus.InventoryInvalidDeliveryDate:
                        pnlError.Visible = false;
                        lblErrorDetails.Text = "Invalid delivery date";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.InventoryConfigurationFail));
            }
        }

        private void LoadFruitByFruitId(int fruitId)
        {
            fruit = businessLayer.GetFruitByFruitId(fruitId);

            txtname.Text = fruit.sFruitName;
            txtQuatity.Text = fruit.deQuantity.ToString();
            txtUnitPrice.Text = fruit.deUnitPrice.ToString();
            txtDescription.Text = fruit.sDescription;
            drpMeasureUnit.SelectedValue = Convert.ToString((int)fruit.eMeasurement);
        }

        protected void drpFruit_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            pnlSuccess.Visible = false;

            selectedFruitId = Convert.ToInt32(drpFruit.SelectedValue);
            LoadFruitByFruitId(selectedFruitId);
        }
    }
}