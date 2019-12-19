using BusinessLayer;
using BusinessLayer.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace AAfruitWholesale.WebForms.Stock
{
    public partial class Inventory : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
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
                    RetriveFruit();
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
            Response.Redirect("New.aspx", false);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                pnlError.Visible = false;
                selectedFruitId = grdInventory.SelectedRow == null ? 0 : Convert.ToInt32(grdInventory.SelectedRow.Cells[0].Text);

                if (selectedFruitId == 0)
                    throw new Exception();

                Response.Redirect(string.Format("Configuration.aspx?fruitid={0}", selectedFruitId), false);
            }
            catch (Exception)
            {
                pnlError.Visible = true;
            }

        }

        protected void grdInventory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdInventory, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void grdInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFruitId = Convert.ToInt32(grdInventory.SelectedRow.Cells[0].Text);
            foreach (GridViewRow row in grdInventory.Rows)
            {
                if (row.RowIndex == grdInventory.SelectedIndex)
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

        private void RetriveFruit()
        {
            List<clsFruitModel> fruitsId = new List<clsFruitModel>();
            List<clsFruitModel> fruits = new List<clsFruitModel>();
            DataTable dataTable = new DataTable();

            fruitsId = master.RetrieveFruits();

            if (fruitsId.Count > 0)
            {
                foreach (var item in fruitsId)
                {
                    clsFruitModel fruit = new clsFruitModel();
                    fruit = businessLayer.GetFruitByFruitId(item.iFruitId);
                    fruits.Add(fruit);
                }
            }

            dataTable = GenerateCustomColumn(fruits);
            grdInventory.DataSource = dataTable;
            grdInventory.DataBind();
        }

        private DataTable GenerateCustomColumn(List<clsFruitModel> fruits)
        {
            DataTable table = new DataTable();
            table.Columns.Add("fruitId", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Available", typeof(string));
            table.Columns.Add("Unit price", typeof(string));
            table.Columns.Add("Measure unit", typeof(string));
            table.Columns.Add("Status", typeof(string));

            if (fruits.Count > 0)
            {
                foreach (var item in fruits)
                    table.Rows.Add(
                        item.iFruitId,
                        item.sFruitName,
                        item.sDescription,
                        item.deQuantity,
                        item.deUnitPrice,
                        clsCommon.GetMeasurementType((int)item.eMeasurement).ToString(),
                        item.bStatus ? "Active" : "Suspended"
                        );
            }

            return table;
        }
    }
}