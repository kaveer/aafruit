using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.Supplier
{
    public partial class View : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
        int supplierId = 0;

        ClsStaff businessLayer = new ClsStaff();
        clsMaster master = new clsMaster();

        protected void Page_Load(object sender, EventArgs e)
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
                RetrieveSupplier();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            supplierId = grdSupplier.SelectedRow == null ? 0 : Convert.ToInt32(grdSupplier.SelectedRow.Cells[0].Text);

            if (supplierId == 0)
                throw new Exception();

            Response.Redirect(string.Format("Upsert.aspx?suppid={0}", supplierId), false);
        }

        private void RetrieveSupplier()
        {
            List<clsUserDetailsModel> suppliers = new List<clsUserDetailsModel>();
            DataTable dataTable = new DataTable();

            suppliers = businessLayer.RetrieveUser(UserType.Supplier);
            dataTable = GenerateCustomColumn(suppliers);
            grdSupplier.DataSource = dataTable;
            grdSupplier.DataBind();
        }

        protected void grdSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdSupplier, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void grdSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierId = Convert.ToInt32(grdSupplier.SelectedRow.Cells[0].Text);
            foreach (GridViewRow row in grdSupplier.Rows)
            {
                if (row.RowIndex == grdSupplier.SelectedIndex)
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

        private DataTable GenerateCustomColumn(List<clsUserDetailsModel> supplier)
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

            if (supplier.Count > 0)
            {
                foreach (var item in supplier)
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
                        item.bStatus ? "Active" : "Suspended"
                        );
            }

            return table;
        }
    }
}