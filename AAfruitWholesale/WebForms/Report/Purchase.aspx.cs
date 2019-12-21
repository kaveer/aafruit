using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.Report
{
    public partial class Purchase : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
        clsReportModel reports = new clsReportModel();

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
                    reports = businessLayer.PurchaseReport();
                    BindData();
                }

            }
            catch (FormatException ex)
            {
                pnlError.Visible = false;

                //switch (Convert.ToInt32(ex.Message))
                //{
                //    case (int)ErrorStatus.InventoryInvalidModel:
                //        pnlError.Visible = true;
                //        lblErrorFruit.Text = "Invalid fruit details";
                //        break;
                //    case (int)ErrorStatus.InventoryInvalidFruitName:
                //        pnlErrorFruit.Visible = true;
                //        lblErrorFruit.Text = "Invalid fruit name";
                //        break;
                //    case (int)ErrorStatus.InventoryInvalidQuantity:
                //        pnlErrorFruit.Visible = true;
                //        lblErrorFruit.Text = "Invalid quantity";
                //        break;
                //    case (int)ErrorStatus.InventoryInvalidUnitPrice:
                //        pnlErrorFruit.Visible = true;
                //        lblErrorFruit.Text = "Invalid unit price";
                //        break;
                //    case (int)ErrorStatus.InventorySupplierDetails:
                //        pnlErrorSupplier.Visible = false;
                //        lblErrorSupplier.Text = "invalid supplier details";
                //        break;
                //    case (int)ErrorStatus.InventoryInvalidDeliveryDate:
                //        pnlErrorSupplier.Visible = false;
                //        lblErrorSupplier.Text = "Invalid delivery date";
                //        break;
                //    default:
                //        break;
                //}
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.InvalidSession));
            }
        }

      

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                pnlError.Visible = false;
            }
            catch (FormatException ex)
            {
                pnlError.Visible = false;

                //switch (Convert.ToInt32(ex.Message))
                //{
                //    case (int)ErrorStatus.InventoryInvalidModel:
                //        pnlError.Visible = true;
                //        lblErrorFruit.Text = "Invalid fruit details";
                //        break;
                //    case (int)ErrorStatus.InventoryInvalidFruitName:
                //        pnlErrorFruit.Visible = true;
                //        lblErrorFruit.Text = "Invalid fruit name";
                //        break;
                //    case (int)ErrorStatus.InventoryInvalidQuantity:
                //        pnlErrorFruit.Visible = true;
                //        lblErrorFruit.Text = "Invalid quantity";
                //        break;
                //    case (int)ErrorStatus.InventoryInvalidUnitPrice:
                //        pnlErrorFruit.Visible = true;
                //        lblErrorFruit.Text = "Invalid unit price";
                //        break;
                //    case (int)ErrorStatus.InventorySupplierDetails:
                //        pnlErrorSupplier.Visible = false;
                //        lblErrorSupplier.Text = "invalid supplier details";
                //        break;
                //    case (int)ErrorStatus.InventoryInvalidDeliveryDate:
                //        pnlErrorSupplier.Visible = false;
                //        lblErrorSupplier.Text = "Invalid delivery date";
                //        break;
                //    default:
                //        break;
                //}
            }
            catch (Exception)
            {
                Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.Report));
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void BindData()
        {
            DataTable dataTable = new DataTable();
            if (reports != null || reports.Purchase.Count > 0)
            {
                dataTable = GenerateCustomCol(reports);

                grdPurchase.DataSource = null;
                grdPurchase.DataBind();

                grdPurchase.DataSource = dataTable;
                grdPurchase.DataBind();
            }
        }

        private DataTable GenerateCustomCol(clsReportModel reports)
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

            //if (orders.Count > 0)
            //{
            //    foreach (var item in orders)
            //        table.Rows.Add(
            //            item.iOrderId,
            //            string.Format("{0} {1}", item.objUserDetails.sName, item.objUserDetails.sSurname),
            //            item.objUserDetails.sCompany,
            //            item.dRequestedDate.ToString("MM/dd/yyyy"),
            //            item.dDeadline.ToString("MM/dd/yyyy"),
            //            item.deQuantity,
            //            item.deTotalPrice,
            //            item.sDiscount,
            //            item.deTotalPriceAfterDiscount,
            //            item.objFruit.sFruitName
            //            );
            //}

            return table;
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