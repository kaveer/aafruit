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
                }

                LoadFruitByFruitId(Convert.ToInt32(drpFruit.SelectedValue));
            }
            catch (Exception)
            {
                Response.Redirect(string.Format("Error.aspx?stat={0}", (int)ErrorStatus.InvalidSession));
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {

        }

        private void LoadFruitByFruitId(int fruitId)
        {
            clsFruitModel fruit = new clsFruitModel();
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

       
    }
}