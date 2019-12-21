using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitCustomer.WebForms.Main
{
    public partial class Orders : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
        List<clsOrderModel> customerOrder = new List<clsOrderModel>();

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
                    LoadOrderType((int)OrderType.Pending);
                }
            }
            catch (Exception)
            {
                Response.Redirect(string.Format("Error.aspx?stat={0}", (int)ErrorStatus.InvalidSession));
            }
        }

        void GrdCustomer_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }

        private void LoadOrderType(int orderType)
        {
            

            switch (orderType)
            {
                case (int)OrderType.Pending:
                    customerOrder = BusinessLayer.ViewOrder(false, userDetails.iUserDetailsId, OrderType.Pending);
                    BindData(customerOrder);
                    CssSetting(OrderType.Pending);
                    break;
                case (int)OrderType.Processing:
                    customerOrder = BusinessLayer.ViewOrder(false, userDetails.iUserDetailsId, OrderType.Processing);
                    BindData(customerOrder);
                    CssSetting(OrderType.Processing);
                    break;
                case (int)OrderType.ReadyForDelivery:
                    customerOrder = BusinessLayer.ViewOrder(false, userDetails.iUserDetailsId, OrderType.ReadyForDelivery);
                    BindData(customerOrder);
                    CssSetting(OrderType.ReadyForDelivery);
                    break;
                case (int)OrderType.Delivered:
                    customerOrder = BusinessLayer.ViewOrder(false, userDetails.iUserDetailsId, OrderType.Delivered);
                    BindData(customerOrder);
                    CssSetting(OrderType.Delivered);
                    break;
                case (int)OrderType.Returned:
                    customerOrder = BusinessLayer.ViewOrder(false, userDetails.iUserDetailsId, OrderType.Returned);
                    BindData(customerOrder);
                    CssSetting(OrderType.Returned);
                    break;
                case (int)OrderType.Hold:
                    customerOrder = BusinessLayer.ViewOrder(false, userDetails.iUserDetailsId, OrderType.Hold);
                    BindData(customerOrder);
                    CssSetting(OrderType.Hold);
                    break;
                default:
                    break;
            }
        }

       

        protected void lkPending_Click(object sender, EventArgs e)
        {
            LoadOrderType((int)OrderType.Pending);
        }

        protected void lkProcessing_Click(object sender, EventArgs e)
        {
            LoadOrderType((int)OrderType.Processing);
        }

        protected void lkReadyForDelivery_Click(object sender, EventArgs e)
        {
            LoadOrderType((int)OrderType.ReadyForDelivery);
        }

        protected void lkDelivery_Click(object sender, EventArgs e)
        {
            LoadOrderType((int)OrderType.Delivered);
        }

        protected void lkReturned_Click(object sender, EventArgs e)
        {
            LoadOrderType((int)OrderType.Returned);
        }

        protected void lkHold_Click(object sender, EventArgs e)
        {
            LoadOrderType((int)OrderType.Hold);
        }

        private DataTable GenerateCustomCol(List<clsOrderModel> customerOrder)
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

            if (customerOrder.Count > 0)
            {
                foreach (var item in customerOrder)
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

        private void BindData(List<clsOrderModel> customerOrder)
        {
            DataTable dataTable = new DataTable();

            dataTable = GenerateCustomCol(customerOrder);
            grdOrder.DataSource = dataTable;
            grdOrder.RowDataBound += new GridViewRowEventHandler(GrdCustomer_RowDataBound);
            grdOrder.DataBind();
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

    }
}