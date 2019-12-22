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
    public partial class Sales : System.Web.UI.Page
    {
        clsUserDetailsModel sessionData = new clsUserDetailsModel();
        clsUserDetailsModel userDetails = new clsUserDetailsModel();
        List<clsOrderModel> reports = new List<clsOrderModel>();

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
                    reports = businessLayer.SalesReport();
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

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    grdSales.AllowPaging = false;

                    grdSales.RenderControl(hw);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                pnlError.Visible = false;

                reports = businessLayer.SalesReport(true, GetValidDate(txtFrom.Text.Trim()), GetValidDate(txtTo.Text.Trim()));
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

        private void BindData()
        {
            DataTable dataTable = new DataTable();
            if (reports != null || reports.Count > 0)
            {
                dataTable = GenerateCustomCol();

                grdSales.DataSource = null;
                grdSales.DataBind();

                grdSales.DataSource = dataTable;
                grdSales.DataBind();
            }
        }

        private DataTable GenerateCustomCol()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Company", typeof(string));
            table.Columns.Add("Request date", typeof(string));
            table.Columns.Add("Deadline date", typeof(string));
            table.Columns.Add("Quantity", typeof(string));
            table.Columns.Add("Total Price", typeof(string));
            table.Columns.Add("Discount value", typeof(string));
            table.Columns.Add("Discount price", typeof(string));
            table.Columns.Add("Order status", typeof(string));
            table.Columns.Add("Fruit", typeof(string));

            if (reports.Count > 0)
            {
                foreach (var report in reports)
                {
                    table.Rows.Add(
                        report.objUserDetails.sCompany,
                        report.dRequestedDate.ToString("MM/dd/yyyy"),
                        report.dDeadline.ToString("MM/dd/yyyy"),
                        report.deQuantity,
                        report.deTotalPrice,
                        report.sDiscount,
                        report.deTotalPriceAfterDiscount,
                        report.eOrderType,
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