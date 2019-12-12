using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLayer
{
    public class ClsStaff:clsUser
    {
        public void AddUser(clsUserDetailsModel item)
        {

        }

        public List<clsFruitModel> ViewInventory()
        {
            return null;
        }

        public void UpsertInventory(clsFruitModel item)
        {

        }

        public List<clsUserDetailsModel> RetrieveUser(UserType item)
        {
            return null;
        }

        public void DeleteCustomer(int customerId)
        {

        }

        public void UpdateOrderStatus(int orderId, OrderType item)
        {

        }

        public List<clsOrderModel> SalesReport(bool isSearch = false, DateTime? from = null, DateTime? to = null)
        {
            return null;
        }

        public List<StockSummaryModel> PurchaseReport(bool isSearch = false, DateTime? from = null, DateTime? to = null)
        {
            return null;
        }


    }
}
