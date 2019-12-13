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

            if (IsLoginModelValid(email, password))
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
            clsUserDetailsModel result = new clsUserDetailsModel();
            DataSet data = new DataSet();

            if (IsSignUpModelValid(item))
            {
                data = dataLayer.SignUp(item);

                if (data?.Tables.Count == 0)
                    throw new Exception();

                if (data?.Tables[0].Rows.Count == 0 || data?.Tables[1].Rows.Count == 0)
                    throw new Exception();

                result = new clsUserDetailsModel()
                {
                    iUserId = Convert.ToInt32(data?.Tables[0].Rows[0][0]),
                    iUserDetailsId = Convert.ToInt32(data?.Tables[1].Rows[0][0]),
                };
            }

            return result;
        }

        public List<clsOrderModel> ViewOrder(bool isStaff, int customerId, OrderType orderType)
        {
            return null;
        }

        private bool IsLoginModelValid(string username, string password)
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new FormatException("Please enter uername or password");

            return result;
        }

        private bool IsSignUpModelValid(clsUserDetailsModel item)
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(item.sUsername))
                throw new FormatException(Convert.ToString((int)ErrorStatus.SignupUsernameMissing));

            if (string.IsNullOrWhiteSpace(item.sPassword))
                throw new FormatException(Convert.ToString((int)ErrorStatus.SigupPasswordMissing));

            if (string.IsNullOrWhiteSpace(item.sReEnterPassword))
                throw new FormatException(Convert.ToString((int)ErrorStatus.SignupRePasswordMissing));

            if (item.sPassword != item.sReEnterPassword)
                throw new FormatException(Convert.ToString((int)ErrorStatus.SignupPasswordNotMatch));

            if (string.IsNullOrWhiteSpace(item.sName))
                throw new FormatException(Convert.ToString((int)ErrorStatus.SignupNameMissing));

            if (string.IsNullOrWhiteSpace(item.sSurname))
                throw new FormatException(Convert.ToString((int)ErrorStatus.SignupSurnameMissing));

            if (string.IsNullOrWhiteSpace(item.sCompany))
                throw new FormatException(Convert.ToString((int)ErrorStatus.SignupCompanyMissing));

            return result;
        }
    }
}
