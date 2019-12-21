using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.Sale
{
    public partial class Sales : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
        int selectedOrderId = 0;

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
                    Navigate(OrderType.Pending);
                    LoadOrders(OrderType.Pending);
                }
                    
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.InvalidSession), false);
            }
        }

        

        protected void lkPending_Click(object sender, EventArgs e)
        {
            Navigate(OrderType.Pending);
            LoadOrders(OrderType.Pending);
        }

        protected void lkProcessing_Click(object sender, EventArgs e)
        {
            Navigate(OrderType.Processing);
            LoadOrders(OrderType.Processing);
        }

        protected void lkReadyForDelivery_Click(object sender, EventArgs e)
        {
            Navigate(OrderType.ReadyForDelivery);
            LoadOrders(OrderType.ReadyForDelivery);
        }

        protected void lkDelivered_Click(object sender, EventArgs e)
        {
            Navigate(OrderType.Delivered);
            LoadOrders(OrderType.Delivered);
        }

        protected void lkReturened_Click(object sender, EventArgs e)
        {
            Navigate(OrderType.Returned);
            LoadOrders(OrderType.Returned);
        }

        protected void lkHold_Click(object sender, EventArgs e)
        {
            Navigate(OrderType.Hold);
            LoadOrders(OrderType.Hold);
        }

        protected void btnPending_Click(object sender, EventArgs e)
        {
            try
            {
                GetOrderIdOnClick();
                businessLayer.UpdateOrderStatus(selectedOrderId, OrderType.Pending);
                Navigate(OrderType.Pending);
                LoadOrders(OrderType.Pending);
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }
        }

        protected void btnProcessing_Click(object sender, EventArgs e)
        {
            try
            {
                GetOrderIdOnClick();
                Response.Redirect(string.Format("Process.aspx?orderid={0}", selectedOrderId), false);
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }
        }

        protected void btnReadyForDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                GetOrderIdOnClick();
                businessLayer.UpdateOrderStatus(selectedOrderId, OrderType.ReadyForDelivery);
                Navigate(OrderType.ReadyForDelivery);
                LoadOrders(OrderType.ReadyForDelivery);
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }
        }

        protected void btnDelivered_Click(object sender, EventArgs e)
        {
            try
            {
                GetOrderIdOnClick();
                businessLayer.UpdateOrderStatus(selectedOrderId, OrderType.Delivered);
                Navigate(OrderType.Delivered);
                LoadOrders(OrderType.Delivered);
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }
        }

        protected void btnReturned_Click(object sender, EventArgs e)
        {
            try
            {
                GetOrderIdOnClick();
                businessLayer.UpdateOrderStatus(selectedOrderId, OrderType.Returned);
                Navigate(OrderType.Returned);
                LoadOrders(OrderType.Returned);
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }
        }

        protected void btnHold_Click(object sender, EventArgs e)
        {
            try
            {
                GetOrderIdOnClick();
                businessLayer.UpdateOrderStatus(selectedOrderId, OrderType.Hold);
                Navigate(OrderType.Hold);
                LoadOrders(OrderType.Hold);
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }
        }

        private void Navigate(OrderType orderType)
        {
            btnPending.Visible = false;
            btnProcessing.Visible = false;
            btnReadyForDelivery.Visible = false;
            btnDelivered.Visible = false;
            btnReturned.Visible = false;
            btnHold.Visible = false;

            switch (orderType)
            {
                case OrderType.Pending:
                    VisibilitySetting(OrderType.Pending);
                    CssSetting(OrderType.Pending);
                    break;
                case OrderType.Processing:
                    VisibilitySetting(OrderType.Processing);
                    CssSetting(OrderType.Processing);
                    break;
                case OrderType.ReadyForDelivery:
                    VisibilitySetting(OrderType.ReadyForDelivery);
                    CssSetting(OrderType.ReadyForDelivery);
                    break;
                case OrderType.Delivered:
                    VisibilitySetting(OrderType.Delivered);
                    CssSetting(OrderType.Delivered);
                    break;
                case OrderType.Returned:
                    VisibilitySetting(OrderType.Returned);
                    CssSetting(OrderType.Returned);
                    break;
                case OrderType.Hold:
                    VisibilitySetting(OrderType.Hold);
                    CssSetting(OrderType.Hold);
                    break;
                default:
                    break;
            }

        }

      

        protected void grdOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdOrder, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void grdOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedOrderId = Convert.ToInt32(grdOrder.SelectedRow.Cells[0].Text);
            foreach (GridViewRow row in grdOrder.Rows)
            {
                if (row.RowIndex == grdOrder.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        private void LoadOrders(OrderType order)
        {
           
            DataTable dataTable = new DataTable();
            List<clsOrderModel> orders = new List<clsOrderModel>();

            switch (order)
            {
                case OrderType.Pending:
                    orders = businessLayer.ViewOrder(true, 0, OrderType.Pending);
                    dataTable = GenerateCustomCol(orders);
                    BindData(dataTable);
                    break;
                case OrderType.Processing:
                    orders = businessLayer.ViewOrder(true, 0, OrderType.Processing);
                    dataTable = GenerateCustomCol(orders);
                    BindData(dataTable);
                    break;
                case OrderType.ReadyForDelivery:
                    orders = businessLayer.ViewOrder(true, 0, OrderType.ReadyForDelivery);
                    dataTable = GenerateCustomCol(orders);
                    BindData(dataTable);
                    break;
                case OrderType.Delivered:
                    orders = businessLayer.ViewOrder(true, 0, OrderType.Delivered);
                    dataTable = GenerateCustomCol(orders);
                    BindData(dataTable);
                    break;
                case OrderType.Returned:
                    orders = businessLayer.ViewOrder(true, 0, OrderType.Returned);
                    dataTable = GenerateCustomCol(orders);
                    BindData(dataTable);
                    break;
                case OrderType.Hold:
                    orders = businessLayer.ViewOrder(true, 0, OrderType.Hold);
                    dataTable = GenerateCustomCol(orders);
                    BindData(dataTable);
                    break;
                default:
                    break;
            }
        }

        private void BindData(DataTable dataTable)
        {
            grdOrder.DataSource = null;
            grdOrder.DataBind();

            grdOrder.DataSource = dataTable;
            grdOrder.DataBind();
        }

        private DataTable GenerateCustomCol(List<clsOrderModel> orders)
        {
            DataTable table = new DataTable();
            table.Columns.Add("OrderId", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Company", typeof(string));
            table.Columns.Add("Requested", typeof(string));
            table.Columns.Add("Deadline", typeof(string));
            table.Columns.Add("Quantity", typeof(decimal));
            table.Columns.Add("Total price", typeof(decimal));
            table.Columns.Add("Discount", typeof(string));
            table.Columns.Add("Discount price", typeof(decimal));
            table.Columns.Add("Fruit", typeof(string));

            if (orders.Count > 0)
            {
                foreach (var item in orders)
                    table.Rows.Add(
                        item.iOrderId,
                        string.Format("{0} {1}", item.objUserDetails.sName, item.objUserDetails.sSurname),
                        item.objUserDetails.sCompany,
                        item.dRequestedDate.ToString("MM/dd/yyyy"),
                        item.dDeadline.ToString("MM/dd/yyyy"),
                        item.deQuantity,
                        item.deTotalPrice,
                        item.sDiscount,
                        item.deTotalPriceAfterDiscount,
                        item.objFruit.sFruitName
                        );
            }

            return table;
        }

        private void GetOrderIdOnClick()
        {
            pnlError.Visible = false;
            selectedOrderId = grdOrder.SelectedRow == null ? 0 : Convert.ToInt32(grdOrder.SelectedRow.Cells[0].Text);

            if (selectedOrderId == 0)
                throw new Exception();
        }

        private void CssSetting(OrderType orderType)
        {
            switch (orderType)
            {
                case OrderType.Pending:
                    liPendind.Attributes["class"] = "active";
                    liProcessing.Attributes["class"] = "";
                    liReady.Attributes["class"] = "";
                    liDelivered.Attributes["class"] = "";
                    liReturned.Attributes["class"] = "";
                    liHold.Attributes["class"] = "";
                    break;
                case OrderType.Processing:
                    liPendind.Attributes["class"] = "";
                    liProcessing.Attributes["class"] = "active";
                    liReady.Attributes["class"] = "";
                    liDelivered.Attributes["class"] = "";
                    liReturned.Attributes["class"] = "";
                    liHold.Attributes["class"] = "";
                    break;
                case OrderType.ReadyForDelivery:
                    liPendind.Attributes["class"] = "";
                    liProcessing.Attributes["class"] = "";
                    liReady.Attributes["class"] = "active";
                    liDelivered.Attributes["class"] = "";
                    liReturned.Attributes["class"] = "";
                    liHold.Attributes["class"] = "";
                    break;
                case OrderType.Delivered:
                    liPendind.Attributes["class"] = "";
                    liProcessing.Attributes["class"] = "";
                    liReady.Attributes["class"] = "";
                    liDelivered.Attributes["class"] = "active";
                    liReturned.Attributes["class"] = "";
                    liHold.Attributes["class"] = "";
                    break;
                case OrderType.Returned:
                    liPendind.Attributes["class"] = "";
                    liProcessing.Attributes["class"] = "";
                    liReady.Attributes["class"] = "";
                    liDelivered.Attributes["class"] = "";
                    liReturned.Attributes["class"] = "active";
                    liHold.Attributes["class"] = "";
                    break;
                case OrderType.Hold:
                    liPendind.Attributes["class"] = "";
                    liProcessing.Attributes["class"] = "";
                    liReady.Attributes["class"] = "";
                    liDelivered.Attributes["class"] = "";
                    liReturned.Attributes["class"] = "";
                    liHold.Attributes["class"] = "active";
                    break;
                default:
                    break;
            }
        }

        private void VisibilitySetting(OrderType orderType)
        {
            switch (orderType)
            {
                case OrderType.Pending:
                    btnPending.Visible = false;
                    btnProcessing.Visible = true;
                    btnReadyForDelivery.Visible = false;
                    btnDelivered.Visible = false;
                    btnReturned.Visible = true;
                    btnHold.Visible = true;
                    break;
                case OrderType.Processing:
                    btnPending.Visible = true;
                    btnProcessing.Visible = false;
                    btnReadyForDelivery.Visible = true;
                    btnDelivered.Visible = false;
                    btnReturned.Visible = true;
                    btnHold.Visible = true;
                    break;
                case OrderType.ReadyForDelivery:
                    btnPending.Visible = false;
                    btnProcessing.Visible = false;
                    btnReadyForDelivery.Visible = false;
                    btnDelivered.Visible = true;
                    btnReturned.Visible = true;
                    btnHold.Visible = true;
                    break;
                case OrderType.Delivered:
                    btnPending.Visible = false;
                    btnProcessing.Visible = false;
                    btnReadyForDelivery.Visible = false;
                    btnDelivered.Visible = false;
                    btnReturned.Visible = false;
                    btnHold.Visible = false;
                    break;
                case OrderType.Returned:
                    btnPending.Visible = true;
                    btnProcessing.Visible = false;
                    btnReadyForDelivery.Visible = false;
                    btnDelivered.Visible = false;
                    btnReturned.Visible = false;
                    btnHold.Visible = false;
                    break;
                case OrderType.Hold:
                    btnPending.Visible = true;
                    btnProcessing.Visible = false;
                    btnReadyForDelivery.Visible = false;
                    btnDelivered.Visible = false;
                    btnReturned.Visible = false;
                    btnHold.Visible = false;
                    break;
                default:
                    break;
            }
        }
    }
}