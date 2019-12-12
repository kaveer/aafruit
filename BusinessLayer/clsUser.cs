using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using ViewModel;

namespace BusinessLayer
{
    public class clsUser
    {
        clsCustomerData dataLayer = new clsCustomerData();

        public clsUserDetailsModel Login(string email, string password, UserType userType)
        {

            clsUserDetailsModel result = null;
            DataSet dataSet = new DataSet();

            if (IsControlValid(email, password))
            {
                dataSet = dataLayer.Login(email, password, userType);

                if (dataSet?.Tables?.Count == 0 || dataSet?.Tables[0]?.Rows?.Count == 0)
                    throw new FormatException("Invalid username and password");

                result = new clsUserDetailsModel()
                {
                    iUserId = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]),
                    iUserDetailsId = Convert.ToInt32(dataSet.Tables[0].Rows[0][1])
                };
            }
            return result;
        }

        public clsUserDetailsModel GetUserByUserDetailId(int userDetails)
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

        private bool IsControlValid(string username, string password)
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new FormatException("Please enter uername or password");

            return result;
        }
    }
}
