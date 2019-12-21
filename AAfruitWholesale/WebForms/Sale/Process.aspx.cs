using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.Sale
{
    public partial class Process : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();

        int orderId = 0;

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
                    LoadOrders();
                    orderId = Request.QueryString["orderid"] == null ? Convert.ToInt32(drpOrders.SelectedValue) : Convert.ToInt32(Request.QueryString["orderid"]);
                    drpOrders.SelectedValue = orderId.ToString();
                }

                if (orderId == 0)
                    orderId = Convert.ToInt32(drpOrders.SelectedValue);

                var selectedOrder = LoadOrdersByOrderId(orderId);
                if (selectedOrder != null || selectedOrder.iOrderId != 0)
                    AssignValue(selectedOrder);

                AddControlAttribute();
            }
            catch (Exception)
            {
                Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.InvalidSession));
            }
        }

        protected void drpOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrdersByOrderId(Convert.ToInt32(drpOrders.SelectedValue));
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                StockSummaryModel stock = new StockSummaryModel();
                clsOrderModel selectedOrder = new clsOrderModel();
                stock.objFruit = new clsFruitModel();
                stock.lstStock = new List<clsStockModel>();
                pnlError.Visible = false;
                pnlSuccess.Visible = false;

                selectedOrder = LoadOrdersByOrderId(Convert.ToInt32(drpOrders.SelectedValue));
                if (selectedOrder == null || selectedOrder.iOrderId == 0)
                    throw new Exception();

                stock.objFruit = selectedOrder.objFruit;
                if ((selectedOrder.objFruit.deQuantity - selectedOrder.deQuantity) <= 0)
                    throw new Exception("Ordered quantity greater than available");

                stock.objFruit.deQuantity = selectedOrder.objFruit.deQuantity - selectedOrder.deQuantity;
                businessLayer.UpsertInventory(stock);

                businessLayer.UpdateOrderStatus(Convert.ToInt32(drpOrders.SelectedValue), OrderType.Processing);

                LoadOrders();

                selectedOrder = LoadOrdersByOrderId(Convert.ToInt32(drpOrders.SelectedValue));
                if (selectedOrder != null || selectedOrder.iOrderId != 0)
                    AssignValue(selectedOrder);

                pnlError.Visible = false;
                pnlSuccess.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrorDetails.Text = ex.Message;
                pnlError.Visible = true;
                pnlSuccess.Visible = false;
            }
        }

        private void LoadOrders()
        {
            drpOrders.Items.Clear();
            List<clsOrderModel> orders = new List<clsOrderModel>();
            orders = businessLayer.ViewOrder(true, 0, OrderType.Pending);
            if (orders.Count > 0)
            {
                var sortedOrders = from order in orders
                                   orderby order.dDeadline ascending
                                   select order;

                foreach (var item in sortedOrders)
                {
                    ListItem list = new ListItem(string.Format("{0} - {1}", item.objUserDetails.sCompany, item.dDeadline.ToString("MM/dd/yyyy")), item.iOrderId.ToString(), true);
                    drpOrders.Items.Add(list);
                }
            }

            drpOrders.SelectedIndex = 0;
        }

        private clsOrderModel LoadOrdersByOrderId(int orderId)
        {
            List<clsOrderModel> orders = new List<clsOrderModel>();
            orders = businessLayer.ViewOrder(true, 0, OrderType.Pending);

            var selectedOrder = orders
                                    .Where(x => x.iOrderId == orderId)
                                    .FirstOrDefault();

            return selectedOrder;
        }

        private void AssignValue(clsOrderModel selectedOrder)
        {
            txtfruit.Text = selectedOrder.objFruit.sFruitName;
            txtQuantityAvailable.Text = selectedOrder.objFruit.deQuantity.ToString();
            txtCompany.Text = selectedOrder.objUserDetails.sCompany;
            txtRequestedOn.Text = selectedOrder.dRequestedDate.ToString("MM/dd/yyyy");
            txtDeadLine.Text = selectedOrder.dDeadline.ToString("MM/dd/yyyy");
            txtQuantity.Text = selectedOrder.deQuantity.ToString();
            TxtTotalPrice.Text = selectedOrder.bHasDiscount ? selectedOrder.deTotalPriceAfterDiscount.ToString() : selectedOrder.deTotalPrice.ToString();

            lblTotalPrice.Text = selectedOrder.bHasDiscount ? string.Format("Price WT Discount ({0})", selectedOrder.sDiscount) : "Total price";
        }

        private void AddControlAttribute()
        {
            txtfruit.Attributes.Add("readonly", "readonly");
            txtQuantityAvailable.Attributes.Add("readonly", "readonly");
            txtCompany.Attributes.Add("readonly", "readonly");
            txtRequestedOn.Attributes.Add("readonly", "readonly");
            txtDeadLine.Attributes.Add("readonly", "readonly");
            txtQuantity.Attributes.Add("readonly", "readonly");
            TxtTotalPrice.Attributes.Add("readonly", "readonly");
        }


    }
}