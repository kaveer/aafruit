using BusinessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitCustomer.WebForms.Main
{
    public partial class New : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
        clsFruitModel fruit = new clsFruitModel();

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
                    List<clsFruitModel> fruits = new List<clsFruitModel>();
                    fruits = master.RetrieveFruits();

                    foreach (var item in fruits)
                    {
                        ListItem list = new ListItem(item.sFruitName, item.iFruitId.ToString(), true);
                        drpFruit.Items.Add(list);
                    }

                    drpFruit.SelectedIndex = 0;
                }

                LoadFruitByFruitId(Convert.ToInt32(drpFruit.SelectedValue));
                AddControlAttribute();

            }
            catch (Exception)
            {
                Response.Redirect(string.Format("Error.aspx?stat={0}", (int)ErrorStatus.InvalidSession));
            }
        }



        protected void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                clsOrderModel order = new clsOrderModel()
                {
                    iOrderId = 0,
                    eOrderType = OrderType.Pending,
                    objUserDetails = new clsUserDetailsModel()
                    {
                        iUserId = userDetails.iUserId,
                        iUserDetailsId = userDetails.iUserDetailsId
                    },
                    objFruit = new clsFruitModel()
                    {
                        iFruitId = fruit.iFruitId,
                        bStatus = fruit.bStatus,
                        deQuantity = fruit.deQuantity,
                        deUnitPrice = fruit.deUnitPrice,
                        eMeasurement = fruit.eMeasurement,
                        sDescription = fruit.sDescription,
                        sFruitName = fruit.sFruitName
                    },
                    bStatus = true,
                    deQuantity = string.IsNullOrWhiteSpace(txtQuantity.Text) ? 0 : Convert.ToDecimal(txtQuantity.Text),
                    bHasDiscount = string.IsNullOrWhiteSpace(txtDiscountPrice.Text) ? false : true,
                    dDeadline = GetValidDate(txtDeadLine.Text),
                    dRequestedDate = GetValidDate(txtRequestedOn.Text),
                    deTotalPrice = string.IsNullOrWhiteSpace(txtTotalPrice.Text) ? 0 : Convert.ToDecimal(txtTotalPrice.Text),
                    deTotalPriceAfterDiscount = string.IsNullOrWhiteSpace(txtDiscountPrice.Text) ? 0 : Convert.ToDecimal(txtDiscountPrice.Text),
                    sDiscount = txtDiscount.Text
                };

                BusinessLayer.PlaceOrder(order);

                pnlError.Visible = false;
                pnlSuccess.Visible = true;
            }
            catch (Exception ex)
            {
                pnlSuccess.Visible = false;
                pnlError.Visible = true;
                lblErrorDetails.Text = ex.Message;
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

        private void LoadFruitByFruitId(int fruitId)
        {
            List<clsDiscountModel> discount = new List<clsDiscountModel>();

            fruit = BusinessLayer.GetFruitByFruitId(fruitId);
            discount = master.RetrieveDiscount();

            txtAvailable.Text = string.Format("{0} {1}", fruit.deQuantity.ToString(), fruit.eMeasurement);
            txtUnitPrice.Text = string.Format("Rs {0}/{1}", fruit.deUnitPrice.ToString(), fruit.eMeasurement);

            hidAvailable.Value = fruit.deQuantity.ToString();
            hidUnitPrice.Value = fruit.deUnitPrice.ToString();
            hidMeasurement.Value = fruit.eMeasurement.ToString();
            hidDiscount.Value = JsonConvert.SerializeObject(discount);
        }

        private void AddControlAttribute()
        {
            txtDiscount.Attributes.Add("readonly", "readonly");
            txtDiscountPrice.Attributes.Add("readonly", "readonly");
            txtTotalPrice.Attributes.Add("readonly", "readonly");
            txtUnitPrice.Attributes.Add("readonly", "readonly");
            txtAvailable.Attributes.Add("readonly", "readonly");
        }

    }
}