using BusinessLayer;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        List<StockSummaryModel> reports = new List<StockSummaryModel>();

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
                lblErrorCredential.Text = ex.Message;
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

                reports = businessLayer.PurchaseReport(true, Convert.ToDateTime(txtFrom.Text.Trim()), Convert.ToDateTime(txtTo.Text.Trim()));
                BindData();
            }
            catch (FormatException ex)
            {
                pnlError.Visible = true;
                lblErrorCredential.Text = ex.Message;
            }
            catch (Exception)
            {
                Response.Redirect(string.Format("~/Error.aspx?stat={0}", (int)ErrorStatus.Report));
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    grdPurchase.AllowPaging = false;

                    grdPurchase.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        private void BindData()
        {
            DataTable dataTable = new DataTable();
            if (reports != null || reports.Count > 0)
            {
                dataTable = GenerateCustomCol();

                grdPurchase.DataSource = null;
                grdPurchase.DataBind();

                grdPurchase.DataSource = dataTable;
                grdPurchase.DataBind();
            }
        }

        private DataTable GenerateCustomCol()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Surbane", typeof(string));
            table.Columns.Add("Company", typeof(string));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("Delivery", typeof(string));
            table.Columns.Add("Quantity", typeof(string));
            table.Columns.Add("Purchase Price", typeof(decimal));
            table.Columns.Add("Fruit", typeof(string));

            if (reports.Count > 0)
            {
                foreach (var report in reports)
                {
                    clsStockModel stockDetails = new clsStockModel();
                    if (report.lstStock.Count > 0)
                        stockDetails = report.lstStock.First();

                    table.Rows.Add(
                        stockDetails.objUserDetails.sName,
                        stockDetails.objUserDetails.sUsername,
                        stockDetails.objUserDetails.sCompany,
                        stockDetails.bStatus? "Active": "Inactive",
                        stockDetails.dDeliveryDate.ToString("MM/dd/yyyy"),
                        stockDetails.deQuantityAdded,
                        stockDetails.dePurchasePrice,
                        report.objFruit.sFruitName
                   );
                }
            }

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