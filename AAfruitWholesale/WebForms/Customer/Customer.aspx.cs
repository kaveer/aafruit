using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;
using System.Drawing;

namespace AAfruitWholesale.WebForms.Customer
{
    public partial class Customer : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
        List<clsUserDetailsModel> customers = new List<clsUserDetailsModel>();
        DataTable dataTable = new DataTable();
        int selectedUserDetailsId = 0;

        ClsStaff BusinessLayer = new ClsStaff();

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
                    customers = new List<clsUserDetailsModel>();
                    customers = BusinessLayer.RetrieveUser(UserType.Customer);

                    dataTable = GenerateCustomCol(customers);
                    grdCustomer.DataSource = dataTable;
                    grdCustomer.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.InvalidSession));
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnSuspend_Click(object sender, EventArgs e)
        {

        }

        private DataTable GenerateCustomCol(List<clsUserDetailsModel> customers)
        {
            DataTable table = new DataTable();
            table.Columns.Add("userDetailsId", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Company", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Phone", typeof(string));
            table.Columns.Add("website", typeof(string));
            table.Columns.Add("BRN", typeof(string));
            table.Columns.Add("Mobile", typeof(string));
            table.Columns.Add("Fax", typeof(string));
            table.Columns.Add("Status", typeof(string));


            if (customers.Count > 0)
            {
                foreach (var item in customers)
                    table.Rows.Add(
                        item.iUserDetailsId,
                        string.Format("{0} {1}", item.sName, item.sSurname),
                        item.sCompany,
                        item.sAddress,
                        item.sEmail,
                        item.sFixLine,
                        item.sWebsite,
                        item.sBRN,
                        item.sMobile,
                        item.sFax,
                        item.bStatus? "Active":"Suspended"
                        );
            }

            return table;
        }

        protected void grdCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = grdCustomer.SelectedRow.Cells[0].Text;
            foreach (GridViewRow row in grdCustomer.Rows)
            {
                if (row.RowIndex == grdCustomer.SelectedIndex)
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

        protected void grdCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdCustomer, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }
    }
}