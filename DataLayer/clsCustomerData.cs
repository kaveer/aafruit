using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DataLayer
{
    public class clsCustomerData:clsUserData
    {
        private readonly string connectionString;
        private SqlConnection connection = new SqlConnection();

        public clsCustomerData()
        {
            connectionString = ConfigurationManager.AppSettings["appctxt"];
        }

        public void PlaceOrder(clsOrderModel item)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblOrderSave", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@UserDetailsId", item.objUserDetails.iUserDetailsId));
            command.Parameters.Add(new SqlParameter("@FruitId", item.objFruit.iFruitId));
            command.Parameters.Add(new SqlParameter("@RequestedDate", item.dRequestedDate));
            command.Parameters.Add(new SqlParameter("@Deadline", item.dDeadline));
            command.Parameters.Add(new SqlParameter("@Quantity", item.deQuantity));
            command.Parameters.Add(new SqlParameter("@TotalPrice", item.deTotalPrice));
            command.Parameters.Add(new SqlParameter("@HasDiscount", item.bHasDiscount));
            command.Parameters.Add(new SqlParameter("@DiscountValue", item.sDiscount));
            command.Parameters.Add(new SqlParameter("@DiscountTotalPrice", item.deTotalPriceAfterDiscount));
            command.Parameters.Add(new SqlParameter("@OrderTypeId", (int)item.eOrderType));
            command.Parameters.Add(new SqlParameter("@OrderStatus", item.bStatus));

            command.ExecuteNonQuery();
        }
    }
}
