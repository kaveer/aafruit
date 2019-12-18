using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLayer
{
    public class ClsStaff:clsUser
    {
        clsStaffData dataLayer = new clsStaffData();

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

        public List<clsUserDetailsModel> RetrieveUser(UserType userType)
        {
            List<clsUserDetailsModel> result = new List<clsUserDetailsModel>();
            DataSet dataSet = new DataSet();

            dataSet = dataLayer.RetrieveUser(userType);
            if (dataSet?.Tables.Count > 0 && dataSet?.Tables[0]?.Rows.Count > 0)
            {
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    clsUserDetailsModel customer = new clsUserDetailsModel()
                    {
                        iUserDetailsId = Convert.ToInt32(item[0]),
                        iUserId = Convert.ToInt32(item[1]),
                        eUserType = GetUserType(Convert.ToInt32(item[2])),
                        sName = item[3].ToString(),
                        sSurname = item[4].ToString(),
                        sAddress = item[5].ToString(),
                        sEmail = item[6].ToString(),
                        sFixLine = item[7].ToString(),
                        sWebsite = item[8].ToString(),
                        sNote = item[9].ToString(),
                        sCompany = item[10].ToString(),
                        sBRN = item[11].ToString(),
                        iCountryId = Convert.ToInt32(item[12]),
                        sMobile = item[13].ToString(),
                        bStatus = Convert.ToBoolean(item[14]),
                        sFax = item[15].ToString()
                    };

                    result.Add(customer);
                }
            }

            return result;
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

        private UserType GetUserType(int userTypeId)
        {
            UserType result = new UserType();

            switch (userTypeId)
            {
                case (int)UserType.Admin:
                    result = UserType.Admin;
                    break;
                case (int)UserType.AdminStaff:
                    result = UserType.AdminStaff;
                    break;
                case (int)UserType.Customer:
                    result = UserType.Customer;
                    break;
                case (int)UserType.Staff:
                    result = UserType.Staff;
                    break;
                case (int)UserType.Supplier:
                    result = UserType.Supplier;
                    break;
                default:
                    break;
            }

            return result;
        }


    }
}
