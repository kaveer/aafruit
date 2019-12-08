using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLayer
{
   public class clsUser
    {
        public clsUserDetailsModel Login(string username, string password)
        {
            return null;
        }
        public void Setting(clsUserDetailsModel item)
        {

        }

        public clsUserDetailsModel SignUp(clsUserDetailsModel item)
        {
            return null;
        }  

        public List<clsOrderModel> ViewOrder(bool isStaff, int customerId, OrderType orderType)
        {
            return null;
        }
    }
}
