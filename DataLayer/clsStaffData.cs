using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DataLayer
{
    public class clsStaffData:clsUserData
    {
        public void AddUser(clsUserDetailsModel item)
        {

        }

        public DataSet ViewInventory()
        {
            return null;
        }

        public void UpsertInventory(clsFruitModel item)
        {

        }

        public DataSet RetrieveUser(UserType item)
        {
            return null;
        }

        public void DeleteCustomer(int customerId)
        {

        }

        public void UpdateOrderStatus(int orderId, OrderType item)
        {

        }

        public DataSet SalesReport(bool isSearch = false, DateTime? from = null, DateTime? to = null)
        {
            return null;
        }

        public DataSet PurchaseReport(bool isSearch = false, DateTime? from = null, DateTime? to = null)
        {
            return null;
        }
    }
}
