using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DataLayer
{
    public class clsUserData
    {
        private readonly string connectionString;

        public clsUserData()
        {

        }

        public DataSet Login(string username, string password)
        {
            return null;
        }
        public void Setting(clsUserDetailsModel item)
        {

        }

        public DataSet SignUp(clsUserDetailsModel item)
        {
            return null;
        }

        public DataSet ViewOrder(bool isStaff, int customerId, OrderType orderType)
        {
            return null;
        }
    }
}
