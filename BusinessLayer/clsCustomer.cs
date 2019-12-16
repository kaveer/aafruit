using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLayer
{
    public class clsCustomer : clsUser
    {
        private clsCustomerData dataLayer = new clsCustomerData();

        public void PlaceOrder(clsOrderModel item)
        {
            if (IsOrderValid(item))
                dataLayer.PlaceOrder(item);
        }

        private bool IsOrderValid(clsOrderModel item)
        {
            bool result = true;

            if (item.objUserDetails == null || item.objUserDetails.iUserId == 0 || item.objUserDetails.iUserDetailsId == 0)
                throw new Exception("Invalid user");

            if (item.dRequestedDate < DateTime.Today)
                throw new Exception("Invalid requested date");

            if (item.dDeadline < DateTime.Today)
                throw new Exception("Invalid deadline date");

            if (item.deQuantity == 0)
                throw new Exception("Invalid quantity");

            if (item.objFruit.iFruitId == 0)
                throw new Exception("Invalid fruit");

            if (item.objFruit.deQuantity < item.deQuantity)
                throw new Exception("Fruit quantity not available");

            if (item.dDeadline <= item.dRequestedDate)
                throw new Exception("Deadline cannot be less that requested date");

            return result;
        }
    }
}
