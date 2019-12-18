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
    public class clsStaffData:clsUserData
    {
        private readonly string connectionString;
        private SqlConnection connection = new SqlConnection();

        public clsStaffData()
        {
            connectionString = ConfigurationManager.AppSettings["appctxt"];
        }

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
            DataSet result = new DataSet();
            DataTable data = new DataTable();

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblUserDetailsRetrieveByUserType", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@userType", (int) item));

            data.Load(command.ExecuteReader());
            
            result.Tables.Add(data);

            if (connection != null)
                connection.Close();

            return result;
        }

        public void DeleteCustomer(int userDetailsId)
        {
            DataSet data = new DataSet();
            int userId = 0;

            data = GetUserByUserDetailId(userDetailsId);
            userId = Convert.ToInt32(data.Tables[0].Rows[0][0]);

            DeleteUser(userId);
            DeleteUserDetails(userDetailsId);
            DeleteOrders(userDetailsId);
        }

        public void UpdateOrderStatus(int orderId, OrderType item)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblOrderUpdateStatusById", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@orderId", orderId));
            command.Parameters.Add(new SqlParameter("@orderType", (int)item));

            command.ExecuteNonQuery();
        }

        public DataSet SalesReport(bool isSearch = false, DateTime? from = null, DateTime? to = null)
        {
            return null;
        }

        public DataSet PurchaseReport(bool isSearch = false, DateTime? from = null, DateTime? to = null)
        {
            return null;
        }

        private void DeleteOrders(int userDetailsId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblOrderDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@userDertailsId", userDetailsId));

            command.ExecuteNonQuery();
        }

        private void DeleteUserDetails(int userDetailsId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblUserDetailsDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@userDertailsId", userDetailsId));

            command.ExecuteNonQuery();
        }

        private void DeleteUser(int userId)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception();

            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection == null)
                throw new Exception();

            SqlCommand command = new SqlCommand("tblUserDelete", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@userId", userId));

            command.ExecuteNonQuery();
        }
    }
}
